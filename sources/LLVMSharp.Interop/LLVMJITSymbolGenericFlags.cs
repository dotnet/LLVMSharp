// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-15.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop;

[NativeTypeName("int")]
[Flags]
public enum LLVMJITSymbolGenericFlags : uint
{
    LLVMJITSymbolGenericFlagsNone = 0,
    LLVMJITSymbolGenericFlagsExported = 1U << 0,
    LLVMJITSymbolGenericFlagsWeak = 1U << 1,
    LLVMJITSymbolGenericFlagsCallable = 1U << 2,
    LLVMJITSymbolGenericFlagsMaterializationSideEffectsOnly = 1U << 3,
}
