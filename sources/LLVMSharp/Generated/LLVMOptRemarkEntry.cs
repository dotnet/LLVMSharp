namespace LLVMSharp
{
    public unsafe partial struct LLVMOptRemarkEntry
    {
        public LLVMOptRemarkStringRef RemarkType;

        public LLVMOptRemarkStringRef PassName;

        public LLVMOptRemarkStringRef RemarkName;

        public LLVMOptRemarkStringRef FunctionName;

        public LLVMOptRemarkDebugLoc DebugLoc;

        [NativeTypeName("uint32_t")]
        public uint Hotness;

        [NativeTypeName("uint32_t")]
        public uint NumArgs;

        [NativeTypeName("LLVMOptRemarkArg *")]
        public LLVMOptRemarkArg* Args;
    }
}
