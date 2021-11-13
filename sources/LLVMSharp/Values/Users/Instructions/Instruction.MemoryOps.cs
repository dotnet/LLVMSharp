// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;

namespace LLVMSharp
{
    public partial class Instruction
    {
        public enum MemoryOps
        {
            Alloca = LLVMOpcode.LLVMAlloca,
            Load = LLVMOpcode.LLVMLoad,
            Store = LLVMOpcode.LLVMStore,
            GetElementPtr = LLVMOpcode.LLVMGetElementPtr,
            Fence = LLVMOpcode.LLVMFence,
            AtomicCmpXchg = LLVMOpcode.LLVMAtomicCmpXchg,
            AtomicRMW = LLVMOpcode.LLVMAtomicRMW,
        }
    }
}
