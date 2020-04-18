// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public partial class Instruction : User
    {
        private protected Instruction(LLVMValueRef handle) : base(handle.IsAInstruction, LLVMValueKind.LLVMInstructionValueKind)
        {
        }

        internal static new Instruction Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAUnaryOperator != null => new UnaryOperator(handle),
            _ when handle.IsABinaryOperator != null => new BinaryOperator(handle),
            _ when handle.IsACallInst != null => CallInst.Create(handle),
            _ when handle.IsACmpInst != null => CmpInst.Create(handle),
            _ when handle.IsAExtractElementInst != null => new ExtractElementInst(handle),
            _ when handle.IsAGetElementPtrInst != null => new GetElementPtrInst(handle),
            _ when handle.IsAInsertElementInst != null => new InsertElementInst(handle),
            _ when handle.IsAInsertValueInst != null => new InsertValueInst(handle),
            _ when handle.IsALandingPadInst != null => new LandingPadInst(handle),
            _ when handle.IsAPHINode != null => new PHINode(handle),
            _ when handle.IsASelectInst != null => new SelectInst(handle),
            _ when handle.IsAShuffleVectorInst != null => new ShuffleVectorInst(handle),
            _ when handle.IsAStoreInst != null => new StoreInst(handle),
            _ when handle.IsABranchInst != null => new BranchInst(handle),
            _ when handle.IsAIndirectBrInst != null => new IndirectBrInst(handle),
            _ when handle.IsAInvokeInst != null => new InvokeInst(handle),
            _ when handle.IsAReturnInst != null => new ReturnInst(handle),
            _ when handle.IsASwitchInst != null => new SwitchInst(handle),
            _ when handle.IsAUnreachableInst != null => new UnreachableInst(handle),
            _ when handle.IsAResumeInst != null => new ResumeInst(handle),
            _ when handle.IsACleanupReturnInst != null => new CleanupReturnInst(handle),
            _ when handle.IsACatchReturnInst != null => new CatchReturnInst(handle),
            _ when handle.IsACatchSwitchInst != null => new CatchSwitchInst(handle),
            _ when handle.IsACallBrInst != null => new CallBrInst(handle),
            _ when handle.IsAFuncletPadInst != null => FuncletPadInst.Create(handle),
            _ when handle.IsAUnaryInstruction != null => UnaryInstruction.Create(handle),
            _ when handle.IsAAtomicCmpXchgInst != null => new AtomicCmpXchgInst(handle),
            _ when handle.IsAAtomicRMWInst != null => new AtomicRMWInst(handle),
            _ when handle.IsAFenceInst != null => new FenceInst(handle),
            _ => new Instruction(handle),
        };
    }
}
