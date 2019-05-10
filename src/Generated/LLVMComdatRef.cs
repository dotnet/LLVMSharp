using System;

namespace LLVMSharp
{
    public partial struct LLVMComdatRef
    {
        public LLVMComdatRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
