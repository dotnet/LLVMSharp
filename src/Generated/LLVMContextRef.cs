using System;

namespace LLVMSharp
{
    public partial struct LLVMContextRef
    {
        public LLVMContextRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
