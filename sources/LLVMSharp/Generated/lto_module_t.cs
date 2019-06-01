using System;

namespace LLVMSharp
{
    public partial struct lto_module_t
    {
        public lto_module_t(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
