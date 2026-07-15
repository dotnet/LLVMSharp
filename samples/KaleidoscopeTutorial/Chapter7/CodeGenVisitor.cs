// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;
using LLVMSharp.Interop;

namespace Kaleidoscope.Chapter7;

/// <summary>
/// Chapter 7 code generation delta — mutable variables. Every variable now lives in a stack slot
/// (an <c>alloca</c>): reads become loads, assignment (<c>=</c>) becomes a store, function parameters
/// and loop variables get their own slots, and <c>var/in</c> introduces new ones. The optimizer's
/// <c>mem2reg</c> pass (already in the pipeline) promotes these back to SSA registers, so the emitted
/// code is as tight as the earlier chapters despite the extra loads/stores.
/// </summary>
public class CodeGenVisitor : Chapter6.CodeGenVisitor
{
    protected override LLVMValueRef CodegenVariable(VariableExprAST node)
    {
        if (!NamedValues.TryGetValue(node.Name, out LLVMValueRef alloca))
        {
            throw new InvalidOperationException($"Unknown variable name '{node.Name}'");
        }

        // Variables are now stack slots, so a reference is a load from the slot.
        return Builder.BuildLoad2(Module.Context.DoubleType, alloca, node.Name);
    }

    protected override LLVMValueRef CodegenBinary(BinaryExprAST node)
    {
        // Assignment is special: it does not evaluate its left-hand side as an expression.
        if (node.Op == '=')
        {
            if (node.Lhs is not VariableExprAST target)
            {
                throw new InvalidOperationException("destination of '=' must be a variable");
            }

            LLVMValueRef value = Codegen(node.Rhs);
            if (!NamedValues.TryGetValue(target.Name, out LLVMValueRef alloca))
            {
                throw new InvalidOperationException($"Unknown variable name '{target.Name}'");
            }

            Builder.BuildStore(value, alloca);
            return value;
        }

        return base.CodegenBinary(node);
    }

    protected override LLVMValueRef CodegenFor(ForExprAST node)
    {
        LLVMValueRef function = Builder.InsertBlock.Parent;

        // Give the loop variable a stack slot and initialize it with the start value.
        LLVMValueRef alloca = CreateEntryBlockAlloca(function, node.VarName);
        LLVMValueRef startValue = Codegen(node.Start);
        Builder.BuildStore(startValue, alloca);

        LLVMBasicBlockRef loopBlock = function.AppendBasicBlock("loop");
        Builder.BuildBr(loopBlock);
        Builder.PositionAtEnd(loopBlock);

        // Bring the loop variable into scope, shadowing any outer binding.
        bool hadOldValue = NamedValues.TryGetValue(node.VarName, out LLVMValueRef oldValue);
        NamedValues[node.VarName] = alloca;

        // Emit the body; its value is discarded.
        Codegen(node.Body);

        // Compute the step, then reload/increment/store the loop variable.
        LLVMValueRef stepValue = node.Step is not null
            ? Codegen(node.Step)
            : LLVMValueRef.CreateConstReal(Module.Context.DoubleType, 1.0);

        LLVMValueRef endCondition = Codegen(node.End);

        LLVMValueRef currentValue = Builder.BuildLoad2(Module.Context.DoubleType, alloca, node.VarName);
        LLVMValueRef nextValue = Builder.BuildFAdd(currentValue, stepValue, "nextvar");
        Builder.BuildStore(nextValue, alloca);

        LLVMValueRef zero = LLVMValueRef.CreateConstReal(Module.Context.DoubleType, 0.0);
        endCondition = Builder.BuildFCmp(LLVMRealPredicate.LLVMRealONE, endCondition, zero, "loopcond");

        LLVMBasicBlockRef afterBlock = function.AppendBasicBlock("afterloop");
        Builder.BuildCondBr(endCondition, loopBlock, afterBlock);
        Builder.PositionAtEnd(afterBlock);

        // Restore the shadowed variable.
        if (hadOldValue)
        {
            NamedValues[node.VarName] = oldValue;
        }
        else
        {
            NamedValues.Remove(node.VarName);
        }

        // A 'for' expression always evaluates to 0.0.
        return LLVMValueRef.CreateConstReal(Module.Context.DoubleType, 0.0);
    }

    protected override LLVMValueRef CodegenVar(VarExprAST node)
    {
        LLVMValueRef function = Builder.InsertBlock.Parent;
        var oldBindings = new List<(string Name, LLVMValueRef OldValue, bool Existed)>();

        foreach ((string name, ExprAST? init) in node.VarNames)
        {
            // Evaluate the initializer before this name enters scope, so 'var a = a' sees the outer a.
            LLVMValueRef initValue = init is not null
                ? Codegen(init)
                : LLVMValueRef.CreateConstReal(Module.Context.DoubleType, 0.0);

            LLVMValueRef alloca = CreateEntryBlockAlloca(function, name);
            Builder.BuildStore(initValue, alloca);

            bool existed = NamedValues.TryGetValue(name, out LLVMValueRef oldValue);
            oldBindings.Add((name, oldValue, existed));
            NamedValues[name] = alloca;
        }

        LLVMValueRef body = Codegen(node.Body);

        // Restore all shadowed bindings.
        foreach ((string name, LLVMValueRef oldValue, bool existed) in oldBindings)
        {
            if (existed)
            {
                NamedValues[name] = oldValue;
            }
            else
            {
                NamedValues.Remove(name);
            }
        }

        return body;
    }

    protected override void CreateParameterBindings(LLVMValueRef function, PrototypeAST proto)
    {
        // Each parameter gets a stack slot seeded with the incoming argument value.
        NamedValues.Clear();
        for (int i = 0; i < proto.Arguments.Count; i++)
        {
            string name = proto.Arguments[i];
            LLVMValueRef alloca = CreateEntryBlockAlloca(function, name);
            Builder.BuildStore(function.GetParam((uint)i), alloca);
            NamedValues[name] = alloca;
        }
    }

    /// <summary>
    /// Creates an <c>alloca</c> at the very start of the function's entry block. Keeping every alloca in
    /// the entry block is what lets <c>mem2reg</c> promote them to SSA registers.
    /// </summary>
    protected LLVMValueRef CreateEntryBlockAlloca(LLVMValueRef function, string name)
    {
        LLVMBasicBlockRef entry = function.EntryBasicBlock;

        using LLVMBuilderRef temporary = Module.Context.CreateBuilder();
        LLVMValueRef firstInstruction = entry.FirstInstruction;
        if (firstInstruction.Handle != IntPtr.Zero)
        {
            temporary.PositionBefore(firstInstruction);
        }
        else
        {
            temporary.PositionAtEnd(entry);
        }

        return temporary.BuildAlloca(Module.Context.DoubleType, name);
    }
}
