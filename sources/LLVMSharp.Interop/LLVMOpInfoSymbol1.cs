// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-13.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMOpInfoSymbol1
    {
        [NativeTypeName("uint64_t")]
        public ulong Present;

        [NativeTypeName("const char *")]
        public sbyte* Name;

        [NativeTypeName("uint64_t")]
        public ulong Value;
    }
}
