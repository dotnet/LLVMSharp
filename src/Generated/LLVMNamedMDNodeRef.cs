using System;

namespace LLVMSharp
{
    public partial struct LLVMNamedMDNodeRef
    {
        public LLVMNamedMDNodeRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
