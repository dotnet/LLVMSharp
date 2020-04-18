// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

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
