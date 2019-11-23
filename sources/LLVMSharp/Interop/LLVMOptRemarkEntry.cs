// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-9.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

namespace LLVMSharp
{
    public unsafe partial struct LLVMOptRemarkEntry
    {
        public LLVMOptRemarkStringRef RemarkType;

        public LLVMOptRemarkStringRef PassName;

        public LLVMOptRemarkStringRef RemarkName;

        public LLVMOptRemarkStringRef FunctionName;

        public LLVMOptRemarkDebugLoc DebugLoc;

        [NativeTypeName("uint32_t")]
        public uint Hotness;

        [NativeTypeName("uint32_t")]
        public uint NumArgs;

        [NativeTypeName("LLVMOptRemarkArg *")]
        public LLVMOptRemarkArg* Args;
    }
}
