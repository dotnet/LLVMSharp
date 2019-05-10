using System;

namespace LLVMSharp
{
    public partial struct LLVMErrorRef
    {
        public LLVMErrorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
