// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public partial class Instruction
    {
        public enum OtherOps
        {
            ICmp  = LLVMOpcode.LLVMICmp,
            FCmp = LLVMOpcode.LLVMFCmp,
            PHI = LLVMOpcode.LLVMPHI,
            Call = LLVMOpcode.LLVMCall,
            Select = LLVMOpcode.LLVMSelect,
            UserOp1 = LLVMOpcode.LLVMUserOp1,
            UserOp2 = LLVMOpcode.LLVMUserOp2,
            VAArg = LLVMOpcode.LLVMVAArg,
            ExtractElement = LLVMOpcode.LLVMExtractElement,
            InsertElement = LLVMOpcode.LLVMInsertElement,
            ShuffleVector = LLVMOpcode.LLVMShuffleVector,
            ExtractValue = LLVMOpcode.LLVMExtractValue,
            InsertValue = LLVMOpcode.LLVMInsertValue,
            LandingPad = LLVMOpcode.LLVMLandingPad,
            Freeze = LLVMOpcode.LLVMFreeze,
        }
    }
}
