using System;

namespace LLVMSharp
{
    public partial struct LLVMDisasmContextRef
    {
        public LLVMDisasmContextRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
