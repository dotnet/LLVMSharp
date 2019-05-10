using System;

namespace LLVMSharp
{
    public partial struct LLVMMCJITMemoryManagerRef
    {
        public LLVMMCJITMemoryManagerRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
