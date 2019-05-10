using System;

namespace LLVMSharp
{
    public partial struct LLVMJITEventListenerRef
    {
        public LLVMJITEventListenerRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
