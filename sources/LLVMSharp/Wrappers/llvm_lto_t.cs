using System;

namespace LLVMSharp
{
    public partial struct llvm_lto_t
    {
        public llvm_lto_t(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
