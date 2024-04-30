// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-18.1.3/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using System.Runtime.CompilerServices;

namespace LLVMSharp.Interop;

public partial struct llvm_blake3_chunk_state
{
    [NativeTypeName("uint32_t[8]")]
    public _cv_e__FixedBuffer cv;

    [NativeTypeName("uint64_t")]
    public ulong chunk_counter;

    [NativeTypeName("uint8_t[64]")]
    public _buf_e__FixedBuffer buf;

    [NativeTypeName("uint8_t")]
    public byte buf_len;

    [NativeTypeName("uint8_t")]
    public byte blocks_compressed;

    [NativeTypeName("uint8_t")]
    public byte flags;

    [InlineArray(8)]
    public partial struct _cv_e__FixedBuffer
    {
        public uint e0;
    }

    [InlineArray(64)]
    public partial struct _buf_e__FixedBuffer
    {
        public byte e0;
    }
}
