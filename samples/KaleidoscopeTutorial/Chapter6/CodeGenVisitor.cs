// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;
using LLVMSharp.Interop;

namespace Kaleidoscope.Chapter6;

/// <summary>
/// Chapter 6 code generation delta — user-defined operators lower to ordinary function calls. A unary
/// operator <c>!x</c> calls <c>unary!</c>; a binary operator <c>a op b</c> that isn't one of the
/// built-ins calls <c>binary&lt;op&gt;</c>. The operator functions themselves are just normal function
/// definitions, so they reuse the inherited <see cref="CodeGenVisitorBase.CodegenFunction"/>.
/// </summary>
public class CodeGenVisitor : Chapter5.CodeGenVisitor
{
    protected override LLVMValueRef CodegenBinary(BinaryExprAST node)
    {
        // The built-in operators keep their inlined lowering from chapter 3.
        switch (node.Op)
        {
            case '+':
            case '-':
            case '*':
            case '<':
            {
                return base.CodegenBinary(node);
            }
        }

        // Anything else is a user-defined operator: emit a call to its binary<op> function.
        LLVMValueRef left = Codegen(node.Lhs);
        LLVMValueRef right = Codegen(node.Rhs);

        LLVMValueRef function = GetFunction("binary" + node.Op);
        if (function.Handle == IntPtr.Zero)
        {
            throw new InvalidOperationException($"binary operator '{node.Op}' not found");
        }

        LLVMTypeRef functionType = GetFunctionType(function);
        return Builder.BuildCall2(functionType, function, new LLVMValueRef[] { left, right }, "binop");
    }

    protected override LLVMValueRef CodegenUnary(UnaryExprAST node)
    {
        LLVMValueRef operand = Codegen(node.Operand);

        LLVMValueRef function = GetFunction("unary" + node.Opcode);
        if (function.Handle == IntPtr.Zero)
        {
            throw new InvalidOperationException($"unary operator '{node.Opcode}' not found");
        }

        LLVMTypeRef functionType = GetFunctionType(function);
        return Builder.BuildCall2(functionType, function, new LLVMValueRef[] { operand }, "unop");
    }
}
