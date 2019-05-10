namespace LLVMSharp
{
    public partial struct LLVMMCJITCompilerOptions
    {
        public uint OptLevel;
        public LLVMCodeModel CodeModel;
        public LLVMBool NoFramePointerElim;
        public LLVMBool EnableFastISel;
        public LLVMMCJITMemoryManagerRef MCJMM;
    }
}
