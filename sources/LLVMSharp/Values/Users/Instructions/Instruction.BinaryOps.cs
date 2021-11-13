// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public partial class Instruction
    {
        public enum BinaryOps
        {
            Add = LLVMOpcode.LLVMAdd,
            FAdd = LLVMOpcode.LLVMFAdd,
            Sub = LLVMOpcode.LLVMSub,
            FSub = LLVMOpcode.LLVMFSub,
            Mul = LLVMOpcode.LLVMMul,
            FMul = LLVMOpcode.LLVMFMul,
            UDiv = LLVMOpcode.LLVMUDiv,
            SDiv = LLVMOpcode.LLVMSDiv,
            FDiv = LLVMOpcode.LLVMFDiv,
            URem = LLVMOpcode.LLVMURem,
            SRem = LLVMOpcode.LLVMSRem,
            FRem = LLVMOpcode.LLVMFRem,
            Shl = LLVMOpcode.LLVMShl,
            LShr = LLVMOpcode.LLVMLShr,
            AShr = LLVMOpcode.LLVMAShr,
            And = LLVMOpcode.LLVMAnd,
            Or = LLVMOpcode.LLVMOr,
            Xor = LLVMOpcode.LLVMXor,
        }
    }
}
