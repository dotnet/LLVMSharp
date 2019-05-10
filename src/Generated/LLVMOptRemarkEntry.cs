using System;

namespace LLVMSharp
{
    public partial struct LLVMOptRemarkEntry
    {
        public LLVMOptRemarkStringRef RemarkType;
        public LLVMOptRemarkStringRef PassName;
        public LLVMOptRemarkStringRef RemarkName;
        public LLVMOptRemarkStringRef FunctionName;
        public LLVMOptRemarkDebugLoc DebugLoc;
        public uint Hotness;
        public uint NumArgs;
        public IntPtr Args;
    }
}
