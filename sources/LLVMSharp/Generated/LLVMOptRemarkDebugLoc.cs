namespace LLVMSharp
{
    public partial struct LLVMOptRemarkDebugLoc
    {
        public LLVMOptRemarkStringRef SourceFile;

        [NativeTypeName("uint32_t")]
        public uint SourceLineNumber;

        [NativeTypeName("uint32_t")]
        public uint SourceColumnNumber;
    }
}
