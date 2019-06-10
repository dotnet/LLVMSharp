using System;

namespace LLVMSharp
{
    public partial struct LLVMTargetLibraryInfoRef
    {
        public LLVMTargetLibraryInfoRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
