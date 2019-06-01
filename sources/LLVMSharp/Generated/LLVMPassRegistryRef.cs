using System;

namespace LLVMSharp
{
    public partial struct LLVMPassRegistryRef
    {
        public LLVMPassRegistryRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
