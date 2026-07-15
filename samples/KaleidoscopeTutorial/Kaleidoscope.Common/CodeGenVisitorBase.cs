// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;
using LLVMSharp.Interop;

namespace Kaleidoscope;

/// <summary>
/// Base class for the per-chapter code generators. It owns the state shared by every chapter — the
/// current <see cref="Module"/>, its <see cref="Builder"/>, the in-scope <see cref="NamedValues"/>,
/// and the <see cref="FunctionProtos"/> map used to re-declare functions across modules — and routes
/// each <see cref="ExprAST"/> to a <c>protected virtual</c> that a chapter overrides. Nodes a chapter
/// doesn't support fall through to a throwing default.
/// </summary>
public abstract class CodeGenVisitorBase
{
    /// <summary>Remembered prototypes so a function can be re-declared in a later module.</summary>
    protected Dictionary<string, PrototypeAST> FunctionProtos { get; } = new();

    /// <summary>The symbols currently in scope while generating a function body.</summary>
    protected Dictionary<string, LLVMValueRef> NamedValues { get; } = new();

    /// <summary>The module the generator is currently emitting into.</summary>
    protected LLVMModuleRef Module { get; private set; }

    /// <summary>A builder positioned within <see cref="Module"/>.</summary>
    protected LLVMBuilderRef Builder { get; private set; }

    /// <summary>Points the generator at a new module, creating a builder in that module's context.</summary>
    public void SetModule(LLVMModuleRef module)
    {
        Module = module;
        Builder = module.Context.CreateBuilder();
    }

    /// <summary>Generates code for an expression, dispatching to the chapter-specific override.</summary>
    public LLVMValueRef Codegen(ExprAST node) => node switch
    {
        NumberExprAST n => CodegenNumber(n),
        VariableExprAST n => CodegenVariable(n),
        BinaryExprAST n => CodegenBinary(n),
        UnaryExprAST n => CodegenUnary(n),
        CallExprAST n => CodegenCall(n),
        IfExprAST n => CodegenIf(n),
        ForExprAST n => CodegenFor(n),
        VarExprAST n => CodegenVar(n),
        _ => throw Unsupported(node),
    };

    /// <summary>Emits a declaration for an <c>extern</c> and remembers it for later modules.</summary>
    public LLVMValueRef CodegenExtern(PrototypeAST node)
    {
        RegisterPrototype(node);
        return CodegenPrototype(node);
    }

    /// <summary>
    /// Remembers a prototype without emitting anything. The JIT driver uses this for <c>extern</c>:
    /// a declaration isn't a definition, so it needs no module of its own — the declaration is emitted
    /// lazily by <see cref="GetFunction"/> into whichever module first references it.
    /// </summary>
    public void RegisterPrototype(PrototypeAST node) => FunctionProtos[node.Name] = node;

    /// <summary>Declares a function (its prototype) in the current module.</summary>
    public abstract LLVMValueRef CodegenPrototype(PrototypeAST node);

    /// <summary>Defines a function (prototype plus body) in the current module.</summary>
    public abstract LLVMValueRef CodegenFunction(FunctionAST node);

    protected virtual LLVMValueRef CodegenNumber(NumberExprAST node) => throw Unsupported(node);

    protected virtual LLVMValueRef CodegenVariable(VariableExprAST node) => throw Unsupported(node);

    protected virtual LLVMValueRef CodegenBinary(BinaryExprAST node) => throw Unsupported(node);

    protected virtual LLVMValueRef CodegenUnary(UnaryExprAST node) => throw Unsupported(node);

    protected virtual LLVMValueRef CodegenCall(CallExprAST node) => throw Unsupported(node);

    protected virtual LLVMValueRef CodegenIf(IfExprAST node) => throw Unsupported(node);

    protected virtual LLVMValueRef CodegenFor(ForExprAST node) => throw Unsupported(node);

    protected virtual LLVMValueRef CodegenVar(VarExprAST node) => throw Unsupported(node);

    /// <summary>
    /// Returns the named function from the current module, declaring it from a remembered prototype
    /// when it isn't present. This is what lets a call resolve a callee that was defined in an
    /// earlier, separate module (each top-level item is its own module once the JIT is involved).
    /// </summary>
    protected LLVMValueRef GetFunction(string name)
    {
        LLVMValueRef existing = Module.GetNamedFunction(name);
        if (existing.Handle != IntPtr.Zero)
        {
            return existing;
        }

        return FunctionProtos.TryGetValue(name, out PrototypeAST? proto) ? CodegenPrototype(proto) : default;
    }

    /// <summary>
    /// Recovers a function's type from the function value. Using this avoids the friendly
    /// <c>LLVMValueRef.FunctionType</c>, which depends on the (unshipped) <c>libLLVMSharp</c> native
    /// helper; <see cref="LLVM.GlobalGetValueType"/> works against the stock <c>libLLVM</c>.
    /// </summary>
    protected static unsafe LLVMTypeRef GetFunctionType(LLVMValueRef function) => LLVM.GlobalGetValueType(function);

    private static NotSupportedException Unsupported(object node) =>
        new($"This chapter's code generator does not support {node.GetType().Name}.");
}
