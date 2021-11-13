// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public partial class Instruction
    {
        public enum CastOps
        {
            Trunc = LLVMOpcode.LLVMTrunc,
            ZExt = LLVMOpcode.LLVMZExt,
            SExt = LLVMOpcode.LLVMSExt,
            FPToUI = LLVMOpcode.LLVMFPToUI,
            FPToSI = LLVMOpcode.LLVMFPToSI,
            UIToFP = LLVMOpcode.LLVMUIToFP,
            SIToFP = LLVMOpcode.LLVMSIToFP,
            FPTrunc = LLVMOpcode.LLVMFPTrunc,
            FPExt = LLVMOpcode.LLVMFPExt,
            PtrToInt = LLVMOpcode.LLVMPtrToInt,
            IntToPtr = LLVMOpcode.LLVMIntToPtr,
            BitCast = LLVMOpcode.LLVMBitCast,
            AddrSpaceCast = LLVMOpcode.LLVMAddrSpaceCast,
        }
    }
}
