// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;
using LLVMSharp.Interop;

namespace Kaleidoscope.Chapter3;

/// <summary>
/// Chapter 3 — "Code generation to LLVM IR". Lowers the core expression language (numbers, variables,
/// the built-in <c>+ - * &lt;</c> operators, calls) and function definitions to LLVM IR. Later chapters
/// inherit this class and override only the nodes they add.
/// </summary>
public class CodeGenVisitor : CodeGenVisitorBase
{
    protected override LLVMValueRef CodegenNumber(NumberExprAST node)
    {
        return LLVMValueRef.CreateConstReal(Module.Context.DoubleType, node.Value);
    }

    protected override LLVMValueRef CodegenVariable(VariableExprAST node)
    {
        if (NamedValues.TryGetValue(node.Name, out LLVMValueRef value))
        {
            return value;
        }

        throw new InvalidOperationException($"Unknown variable name '{node.Name}'");
    }

    protected override LLVMValueRef CodegenBinary(BinaryExprAST node)
    {
        LLVMValueRef left = Codegen(node.Lhs);
        LLVMValueRef right = Codegen(node.Rhs);

        switch (node.Op)
        {
            case '+':
            {
                return Builder.BuildFAdd(left, right, "addtmp");
            }

            case '-':
            {
                return Builder.BuildFSub(left, right, "subtmp");
            }

            case '*':
            {
                return Builder.BuildFMul(left, right, "multmp");
            }

            case '<':
            {
                LLVMValueRef comparison = Builder.BuildFCmp(LLVMRealPredicate.LLVMRealULT, left, right, "cmptmp");

                // Convert the i1 result to a double (0.0 or 1.0), Kaleidoscope's only value type.
                return Builder.BuildUIToFP(comparison, Module.Context.DoubleType, "booltmp");
            }

            default:
            {
                throw new InvalidOperationException($"invalid binary operator '{node.Op}'");
            }
        }
    }

    protected override LLVMValueRef CodegenCall(CallExprAST node)
    {
        LLVMValueRef callee = GetFunction(node.Callee);
        if (callee.Handle == IntPtr.Zero)
        {
            throw new InvalidOperationException($"Unknown function '{node.Callee}' referenced");
        }

        if (callee.ParamsCount != node.Arguments.Count)
        {
            throw new InvalidOperationException("Incorrect # arguments passed");
        }

        var arguments = new LLVMValueRef[node.Arguments.Count];
        for (int i = 0; i < arguments.Length; i++)
        {
            arguments[i] = Codegen(node.Arguments[i]);
        }

        // Recover the callee's function type from the value itself; BuildCall2 needs it explicitly.
        LLVMTypeRef functionType = GetFunctionType(callee);
        return Builder.BuildCall2(functionType, callee, arguments, "calltmp");
    }

    public override LLVMValueRef CodegenPrototype(PrototypeAST node)
    {
        LLVMTypeRef doubleType = Module.Context.DoubleType;

        var parameterTypes = new LLVMTypeRef[node.Arguments.Count];
        Array.Fill(parameterTypes, doubleType);

        LLVMTypeRef functionType = LLVMTypeRef.CreateFunction(doubleType, parameterTypes);
        LLVMValueRef function = Module.AddFunction(node.Name, functionType);

        for (int i = 0; i < node.Arguments.Count; i++)
        {
            function.GetParam((uint)i).Name = node.Arguments[i];
        }

        return function;
    }

    public override LLVMValueRef CodegenFunction(FunctionAST node)
    {
        // Remember the prototype (so recursive references resolve) then get-or-declare the function.
        RegisterPrototype(node.Proto);
        LLVMValueRef function = GetFunction(node.Proto.Name);

        if (function.BasicBlocksCount != 0)
        {
            throw new InvalidOperationException($"Function '{node.Proto.Name}' cannot be redefined");
        }

        LLVMBasicBlockRef entry = function.AppendBasicBlock("entry");
        Builder.PositionAtEnd(entry);

        CreateParameterBindings(function, node.Proto);

        try
        {
            LLVMValueRef body = Codegen(node.Body);
            Builder.BuildRet(body);
            function.VerifyFunction(LLVMVerifierFailureAction.LLVMPrintMessageAction);
            return function;
        }
        catch
        {
            // Remove the half-built function so the REPL can keep going after an error.
            function.DeleteFunction();
            throw;
        }
    }

    /// <summary>
    /// Binds the function's parameters into <see cref="CodeGenVisitorBase.NamedValues"/> before the body
    /// is generated. Chapter 3 binds the SSA parameter values directly; chapter 7 overrides this to give
    /// each parameter a stack slot so it can be reassigned.
    /// </summary>
    protected virtual void CreateParameterBindings(LLVMValueRef function, PrototypeAST proto)
    {
        NamedValues.Clear();
        for (int i = 0; i < proto.Arguments.Count; i++)
        {
            NamedValues[proto.Arguments[i]] = function.GetParam((uint)i);
        }
    }
}
