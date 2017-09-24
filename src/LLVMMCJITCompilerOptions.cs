namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    partial struct LLVMMCJITCompilerOptions
    {
        public unsafe static LLVMMCJITCompilerOptions Initialize()
        {
            LLVMMCJITCompilerOptions options;
            var sizeOfOptions = new size_t(new IntPtr(Marshal.SizeOf(typeof (LLVMMCJITCompilerOptions))));
            LLVM.InitializeMCJITCompilerOptions(&options, sizeOfOptions);
            return options;
        }
    }
}
