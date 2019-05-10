using System;

namespace LLVMSharp
{
    public partial struct LLVMErrorTypeId
    {
        public LLVMErrorTypeId(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
