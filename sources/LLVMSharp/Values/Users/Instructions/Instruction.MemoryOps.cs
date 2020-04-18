// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

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
