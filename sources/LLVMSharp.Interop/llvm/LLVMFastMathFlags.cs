// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-18.1.3/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop;

[Flags]
public enum LLVMFastMathFlags
{
    LLVMFastMathAllowReassoc = (1 << 0),
    LLVMFastMathNoNaNs = (1 << 1),
    LLVMFastMathNoInfs = (1 << 2),
    LLVMFastMathNoSignedZeros = (1 << 3),
    LLVMFastMathAllowReciprocal = (1 << 4),
    LLVMFastMathAllowContract = (1 << 5),
    LLVMFastMathApproxFunc = (1 << 6),
    LLVMFastMathNone = 0,
    LLVMFastMathAll = LLVMFastMathAllowReassoc | LLVMFastMathNoNaNs | LLVMFastMathNoInfs | LLVMFastMathNoSignedZeros | LLVMFastMathAllowReciprocal | LLVMFastMathAllowContract | LLVMFastMathApproxFunc,
}
