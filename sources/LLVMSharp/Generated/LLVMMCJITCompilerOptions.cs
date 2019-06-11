namespace LLVMSharp
{
    public unsafe partial struct LLVMMCJITCompilerOptions
    {
        [NativeTypeName("unsigned int")]
        public uint OptLevel;

        public LLVMCodeModel CodeModel;

        [NativeTypeName("LLVMBool")]
        public int NoFramePointerElim;

        [NativeTypeName("LLVMBool")]
        public int EnableFastISel;

        [NativeTypeName("LLVMMCJITMemoryManagerRef")]
        public LLVMOpaqueMCJITMemoryManager* MCJMM;
    }
}
