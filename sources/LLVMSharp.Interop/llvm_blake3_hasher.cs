// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-16.0.6/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

namespace LLVMSharp.Interop;

public unsafe partial struct llvm_blake3_hasher
{
    [NativeTypeName("uint32_t[8]")]
    public fixed uint key[8];

    public llvm_blake3_chunk_state chunk;

    [NativeTypeName("uint8_t")]
    public byte cv_stack_len;

    [NativeTypeName("uint8_t[1760]")]
    public fixed byte cv_stack[1760];
}
