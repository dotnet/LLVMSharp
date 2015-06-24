namespace LLVMSharp
{
    using System.Runtime.InteropServices;

    partial struct LLVMMCJITCompilerOptions
    {
        public static LLVMMCJITCompilerOptions Initialize()
        {
            LLVMMCJITCompilerOptions options;
            var sizeOfOptions = Marshal.SizeOf(typeof (LLVMMCJITCompilerOptions));
            LLVM.InitializeMCJITCompilerOptions(out options, sizeOfOptions);
            return options;
        }
    }
}
