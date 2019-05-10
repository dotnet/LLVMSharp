using System;

namespace LLVMSharp
{
    public partial struct LLVMModuleProviderRef
    {
        public LLVMModuleProviderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
