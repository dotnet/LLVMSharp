using System;

namespace LLVMSharp
{
    public partial struct LLVMMetadataRef
    {
        public LLVMMetadataRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
