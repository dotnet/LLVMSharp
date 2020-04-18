// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public partial class Instruction
    {
        public enum TermOps
        {
            Ret = LLVMOpcode.LLVMRet,
            Br = LLVMOpcode.LLVMBr,
            Switch = LLVMOpcode.LLVMSwitch,
            IndirectBr = LLVMOpcode.LLVMIndirectBr,
            Invoke = LLVMOpcode.LLVMInvoke,
            Resume = LLVMOpcode.LLVMResume,
            Unreachable = LLVMOpcode.LLVMUnreachable,
            CleanupRet = LLVMOpcode.LLVMCleanupRet,
            CatchRet = LLVMOpcode.LLVMCatchRet,
            CatchSwitch = LLVMOpcode.LLVMCatchSwitch,
            CallBr = LLVMOpcode.LLVMCallBr,
        }
    }
}
