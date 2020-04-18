// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

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
