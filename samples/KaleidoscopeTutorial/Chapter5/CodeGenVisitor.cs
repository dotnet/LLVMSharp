// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using Kaleidoscope.AST;
using LLVMSharp.Interop;

namespace Kaleidoscope.Chapter5;

/// <summary>
/// Chapter 5 code generation delta — lowers <c>if/then/else</c> and <c>for/in</c> to control flow.
/// The loop variable here is an SSA PHI node; chapter 7 revisits it with stack allocations so it can
/// be mutated. Everything else is inherited from chapter 3.
/// </summary>
public class CodeGenVisitor : Chapter3.CodeGenVisitor
{
    protected override LLVMValueRef CodegenIf(IfExprAST node)
    {
        LLVMValueRef condition = Codegen(node.Condition);

        // Convert the condition to a bool by comparing it to 0.0.
        LLVMValueRef zero = LLVMValueRef.CreateConstReal(Module.Context.DoubleType, 0.0);
        condition = Builder.BuildFCmp(LLVMRealPredicate.LLVMRealONE, condition, zero, "ifcond");

        LLVMValueRef function = Builder.InsertBlock.Parent;
        LLVMBasicBlockRef thenBlock = function.AppendBasicBlock("then");
        LLVMBasicBlockRef elseBlock = function.AppendBasicBlock("else");
        LLVMBasicBlockRef mergeBlock = function.AppendBasicBlock("ifcont");

        Builder.BuildCondBr(condition, thenBlock, elseBlock);

        // Emit the 'then' value.
        Builder.PositionAtEnd(thenBlock);
        LLVMValueRef thenValue = Codegen(node.Then);
        Builder.BuildBr(mergeBlock);
        thenBlock = Builder.InsertBlock; // codegen of 'then' may have changed the current block.

        // Emit the 'else' value.
        Builder.PositionAtEnd(elseBlock);
        LLVMValueRef elseValue = Codegen(node.Else);
        Builder.BuildBr(mergeBlock);
        elseBlock = Builder.InsertBlock; // codegen of 'else' may have changed the current block.

        // Emit the merge block with a PHI selecting the value from whichever branch ran.
        Builder.PositionAtEnd(mergeBlock);
        LLVMValueRef phi = Builder.BuildPhi(Module.Context.DoubleType, "iftmp");
        phi.AddIncoming([thenValue, elseValue], [thenBlock, elseBlock], 2);
        return phi;
    }

    protected override LLVMValueRef CodegenFor(ForExprAST node)
    {
        // Emit the start value first, in the current (preheader) block.
        LLVMValueRef startValue = Codegen(node.Start);

        LLVMValueRef function = Builder.InsertBlock.Parent;
        LLVMBasicBlockRef preheaderBlock = Builder.InsertBlock;
        LLVMBasicBlockRef loopBlock = function.AppendBasicBlock("loop");
        Builder.BuildBr(loopBlock);

        // Start the loop body; the loop variable is a PHI merging the start and stepped values.
        Builder.PositionAtEnd(loopBlock);
        LLVMValueRef variable = Builder.BuildPhi(Module.Context.DoubleType, node.VarName);
        variable.AddIncoming([startValue], [preheaderBlock], 1);

        // Bring the loop variable into scope, shadowing any outer binding of the same name.
        bool hadOldValue = NamedValues.TryGetValue(node.VarName, out LLVMValueRef oldValue);
        NamedValues[node.VarName] = variable;

        // Emit the body; its value is discarded.
        Codegen(node.Body);

        // Compute the next value of the loop variable.
        LLVMValueRef stepValue = node.Step is not null
            ? Codegen(node.Step)
            : LLVMValueRef.CreateConstReal(Module.Context.DoubleType, 1.0);
        LLVMValueRef nextVariable = Builder.BuildFAdd(variable, stepValue, "nextvar");

        // Evaluate the end condition (!= 0.0 continues the loop).
        LLVMValueRef endCondition = Codegen(node.End);
        LLVMValueRef zero = LLVMValueRef.CreateConstReal(Module.Context.DoubleType, 0.0);
        endCondition = Builder.BuildFCmp(LLVMRealPredicate.LLVMRealONE, endCondition, zero, "loopcond");

        LLVMBasicBlockRef loopEndBlock = Builder.InsertBlock;
        LLVMBasicBlockRef afterBlock = function.AppendBasicBlock("afterloop");
        Builder.BuildCondBr(endCondition, loopBlock, afterBlock);
        Builder.PositionAtEnd(afterBlock);

        // Wire the stepped value back into the PHI now that we know the loop's back-edge block.
        variable.AddIncoming([nextVariable], [loopEndBlock], 1);

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
}
