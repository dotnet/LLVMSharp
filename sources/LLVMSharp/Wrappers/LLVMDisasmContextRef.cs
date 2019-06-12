using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMDisasmContextRef
    {
        public LLVMDisasmContextRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static explicit operator LLVMDisasmContextRef(void* value)
        {
            return new LLVMDisasmContextRef((IntPtr)value);
        }

        public static implicit operator void*(LLVMDisasmContextRef value)
        {
            return (void*)value.Pointer;
        }
    }
}
