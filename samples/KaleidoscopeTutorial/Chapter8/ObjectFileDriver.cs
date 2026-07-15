// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;
using LLVMSharp.Interop;

namespace Kaleidoscope.Chapter8;

/// <summary>
/// Chapter 8's driver: instead of JIT-executing top-level expressions, it generates every definition,
/// extern, and top-level expression into a single module. The program then hands that module to a
/// target machine to emit a native object file. There is no execution here — the output is a `.o`.
/// </summary>
public sealed class ObjectFileDriver : ReplDriver
{
    private readonly CodeGenVisitorBase _visitor;

    public ObjectFileDriver(Lexer lexer, Parser parser, CodeGenVisitorBase visitor, LLVMModuleRef module)
        : base(lexer, parser)
    {
        _visitor = visitor;
        _visitor.SetModule(module);
    }

    protected override void OnDefinition(FunctionAST function) => _visitor.CodegenFunction(function);

    protected override void OnExtern(PrototypeAST prototype) => _visitor.CodegenExtern(prototype);

    protected override void OnTopLevelExpression(FunctionAST function) => _visitor.CodegenFunction(function);
}
