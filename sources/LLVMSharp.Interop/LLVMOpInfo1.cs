// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-13.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

namespace LLVMSharp.Interop
{
    public partial struct LLVMOpInfo1
    {
        [NativeTypeName("struct LLVMOpInfoSymbol1")]
        public LLVMOpInfoSymbol1 AddSymbol;

        [NativeTypeName("struct LLVMOpInfoSymbol1")]
        public LLVMOpInfoSymbol1 SubtractSymbol;

        [NativeTypeName("uint64_t")]
        public ulong Value;

        [NativeTypeName("uint64_t")]
        public ulong VariantKind;
    }
}
