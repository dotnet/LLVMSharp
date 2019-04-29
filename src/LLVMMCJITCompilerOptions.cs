namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    partial struct LLVMMCJITCompilerOptions
    {
        public unsafe static LLVMMCJITCompilerOptions Initialize()
        {
            LLVMMCJITCompilerOptions options;
            var sizeOfOptions = (IntPtr)(Marshal.SizeOf(typeof (LLVMMCJITCompilerOptions)));
            LLVM.InitializeMCJITCompilerOptions(out options, sizeOfOptions);
            return options;
        }
    }
}
