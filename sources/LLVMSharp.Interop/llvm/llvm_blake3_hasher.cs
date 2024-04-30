// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-18.1.3/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using System.Runtime.CompilerServices;

namespace LLVMSharp.Interop;

public partial struct llvm_blake3_hasher
{
    [NativeTypeName("uint32_t[8]")]
    public _key_e__FixedBuffer key;

    public llvm_blake3_chunk_state chunk;

    [NativeTypeName("uint8_t")]
    public byte cv_stack_len;

    [NativeTypeName("uint8_t[1760]")]
    public _cv_stack_e__FixedBuffer cv_stack;

    [InlineArray(8)]
    public partial struct _key_e__FixedBuffer
    {
        public uint e0;
    }

    [InlineArray(1760)]
    public partial struct _cv_stack_e__FixedBuffer
    {
        public byte e0;
    }
}
