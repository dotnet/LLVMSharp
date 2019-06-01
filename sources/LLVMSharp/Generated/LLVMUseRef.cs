using System;

namespace LLVMSharp
{
    public partial struct LLVMUseRef
    {
        public LLVMUseRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
