using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
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
