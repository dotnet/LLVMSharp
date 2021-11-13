// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public partial class AtomicRMWInst
    {
        public enum BinOp
        {
            Xchg = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpXchg,
            Add = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpAdd,
            Sub = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpSub,
            And = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpAnd,
            Nand = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpNand,
            Or = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpOr,
            Xor = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpXor,
            Max = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpMax,
            Min = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpMin,
            UMax = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpUMax,
            UMin = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpUMin,
            FAdd = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpFAdd,
            FSub = LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpFSub,
        }
    }
}
