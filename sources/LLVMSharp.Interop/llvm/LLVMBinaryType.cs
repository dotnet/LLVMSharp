// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-20.1.2/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

namespace LLVMSharp.Interop;

public enum LLVMBinaryType
{
    LLVMBinaryTypeArchive,
    LLVMBinaryTypeMachOUniversalBinary,
    LLVMBinaryTypeCOFFImportFile,
    LLVMBinaryTypeIR,
    LLVMBinaryTypeWinRes,
    LLVMBinaryTypeCOFF,
    LLVMBinaryTypeELF32L,
    LLVMBinaryTypeELF32B,
    LLVMBinaryTypeELF64L,
    LLVMBinaryTypeELF64B,
    LLVMBinaryTypeMachO32L,
    LLVMBinaryTypeMachO32B,
    LLVMBinaryTypeMachO64L,
    LLVMBinaryTypeMachO64B,
    LLVMBinaryTypeWasm,
    LLVMBinaryTypeOffload,
}
