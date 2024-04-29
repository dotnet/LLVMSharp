// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMMCJITCompilerOptions
{
    public static LLVMMCJITCompilerOptions Create()
    {
        LLVMMCJITCompilerOptions Options;
        LLVM.InitializeMCJITCompilerOptions(&Options, (uint)sizeof(LLVMMCJITCompilerOptions));
        return Options;
    }
}
