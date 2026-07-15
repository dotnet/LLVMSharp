// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;
using LLVMSharp.Interop;

namespace Kaleidoscope.Chapter4;

/// <summary>
/// Chapter 4 — "Adding JIT and optimizer support". Reuses chapter 3's code generator unchanged, but
/// instead of just printing IR it optimizes each top-level item and feeds it to an ORC LLJIT so
/// top-level expressions actually run. Each item is compiled into its own module; the anonymous
/// expression is added under a resource tracker and removed after it runs, so the REPL can evaluate
/// any number of expressions in a row (upstream issue #1, which the old MCJIT sample could not do).
///
/// This driver is deliberately independent of the code generator's chapter — later chapters reuse it
/// as-is and only pass in their own <see cref="CodeGenVisitorBase"/>.
/// </summary>
public sealed unsafe class JitReplDriver : ReplDriver, IDisposable
{
    // Function-level cleanup/optimization pipeline, parsed by the new pass manager. mem2reg only does
    // work once chapter 7 introduces allocas; it is harmless before then, so one pipeline serves all.
    private const string PassPipeline = "function(mem2reg,instcombine,reassociate,gvn,simplifycfg)";

    private readonly CodeGenVisitorBase _visitor;
    private readonly KaleidoscopeJit _jit;
    private readonly LLVMTargetMachineRef _targetMachine;

    public JitReplDriver(Lexer lexer, Parser parser, CodeGenVisitorBase visitor)
        : base(lexer, parser)
    {
        _visitor = visitor;
        _jit = new KaleidoscopeJit();
        _targetMachine = LlvmSupport.CreateHostTargetMachine();

        // Make putchard/printd available to any 'extern' that references them.
        HostFunctions.DefineAll(_jit);
    }

    protected override void OnDefinition(FunctionAST function)
    {
        LLVMModuleRef module = CreateModule();
        _visitor.SetModule(module);

        LLVMValueRef ir = _visitor.CodegenFunction(function);
        Console.WriteLine("Read function definition:");
        Console.Write(ir);

        Optimize(module);
        _jit.AddModule(module); // keep the definition around so later expressions can call it.
    }

    protected override void OnExtern(PrototypeAST prototype)
    {
        // A declaration needs no module of its own — remember it so it is emitted into whichever
        // module first references it (see CodeGenVisitorBase.GetFunction).
        _visitor.RegisterPrototype(prototype);
        Console.WriteLine($"Read extern: {prototype.Name}");
    }

    protected override void OnTopLevelExpression(FunctionAST function)
    {
        LLVMModuleRef module = CreateModule();
        _visitor.SetModule(module);
        _visitor.CodegenFunction(function);
        Optimize(module);

        // Add under a resource tracker so we can drop this anonymous module once we've called it,
        // freeing the __anon_expr name for the next top-level expression.
        nint tracker = _jit.AddModuleRemovable(module);
        try
        {
            ulong address = _jit.Lookup(Parser.AnonymousExpressionName);
            var evaluate = (delegate* unmanaged[Cdecl]<double>)address;
            Console.WriteLine($"Evaluated to {evaluate()}");
        }
        finally
        {
            _jit.RemoveModule(tracker);
        }
    }

    private LLVMModuleRef CreateModule()
    {
        // Each module is built in its own context; the JIT takes ownership of that context when the
        // module is added. Stamp it with the JIT's data layout/triple so codegen matches the target.
        LLVMContextRef context = LLVMContextRef.Create();
        LLVMModuleRef module = context.CreateModuleWithName("KaleidoscopeModule");
        _jit.ConfigureModule(module);
        return module;
    }

    private void Optimize(LLVMModuleRef module)
    {
        using LLVMPassBuilderOptionsRef options = LLVMPassBuilderOptionsRef.Create();
        using var passes = new MarshaledString(PassPipeline);
        LLVMOpaqueError* error = LLVM.RunPasses(module, passes, _targetMachine, options);
        LlvmSupport.ThrowIfError(error, "Optimization failed");
    }

    public void Dispose() => _jit.Dispose();
}
