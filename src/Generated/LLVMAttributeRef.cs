using System;

namespace LLVMSharp
{
    public partial struct LLVMAttributeRef
    {
        public LLVMAttributeRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
