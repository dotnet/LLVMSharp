// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;
using LLVMSharp.Interop;

namespace Kaleidoscope.Chapter3;

/// <summary>
/// Chapter 3's driver: it generates IR into one module and prints it. There is no execution yet — the
/// point of this chapter is just to see the generated LLVM IR. Chapter 4 keeps the same code generator
/// but adds a JIT so top-level expressions actually run.
/// </summary>
public sealed class DumpDriver : ReplDriver
{
    private readonly CodeGenVisitor _visitor;

    public DumpDriver(Lexer lexer, Parser parser, CodeGenVisitor visitor, LLVMModuleRef module)
        : base(lexer, parser)
    {
        _visitor = visitor;
        _visitor.SetModule(module);
    }

    protected override void OnDefinition(FunctionAST function)
    {
        LLVMValueRef ir = _visitor.CodegenFunction(function);
        Console.WriteLine("Read function definition:");
        Console.WriteLine(ir);
    }

    protected override void OnExtern(PrototypeAST prototype)
    {
        LLVMValueRef ir = _visitor.CodegenExtern(prototype);
        Console.WriteLine("Read extern:");
        Console.WriteLine(ir);
    }

    protected override void OnTopLevelExpression(FunctionAST function)
    {
        LLVMValueRef ir = _visitor.CodegenFunction(function);
        Console.WriteLine("Read top-level expression:");
        Console.WriteLine(ir);
    }
}
