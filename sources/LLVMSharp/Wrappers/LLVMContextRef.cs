using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMContextRef
    {
        public LLVMContextRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMContextRef(LLVMOpaqueContext* value)
        {
            return new LLVMContextRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueContext*(LLVMContextRef value)
        {
            return (LLVMOpaqueContext*)value.Pointer;
        }
    }
}
