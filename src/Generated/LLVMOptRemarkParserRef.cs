using System;

namespace LLVMSharp
{
    public partial struct LLVMOptRemarkParserRef
    {
        public LLVMOptRemarkParserRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
