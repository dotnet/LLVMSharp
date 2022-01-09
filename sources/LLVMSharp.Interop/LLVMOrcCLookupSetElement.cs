// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-13.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMOrcCLookupSetElement
    {
        [NativeTypeName("LLVMOrcSymbolStringPoolEntryRef")]
        public LLVMOrcOpaqueSymbolStringPoolEntry* Name;

        public LLVMOrcSymbolLookupFlags LookupFlags;
    }
}
