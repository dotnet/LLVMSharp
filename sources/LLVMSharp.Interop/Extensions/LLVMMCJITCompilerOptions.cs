// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMMCJITCompilerOptions
    {
        public static LLVMMCJITCompilerOptions Create()
        {
            LLVMMCJITCompilerOptions Options;
            LLVM.InitializeMCJITCompilerOptions(&Options, (UIntPtr)Marshal.SizeOf<LLVMMCJITCompilerOptions>());
            return Options;
        }
    }
}
