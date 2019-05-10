using System;

namespace LLVMSharp
{
    public partial struct LLVMValueRef
    {
        public LLVMValueRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
