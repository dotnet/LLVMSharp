using System;

namespace LLVMSharp
{
    public partial struct LLVMBasicBlockRef
    {
        public LLVMBasicBlockRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
