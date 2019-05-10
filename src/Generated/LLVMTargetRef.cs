using System;

namespace LLVMSharp
{
    public partial struct LLVMTargetRef
    {
        public LLVMTargetRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
