// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

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
