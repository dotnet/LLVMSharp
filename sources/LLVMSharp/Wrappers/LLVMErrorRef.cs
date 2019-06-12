using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMErrorRef
    {
        public LLVMErrorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMErrorRef(LLVMOpaqueError* value)
        {
            return new LLVMErrorRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueError*(LLVMErrorRef value)
        {
            return (LLVMOpaqueError*)value.Pointer;
        }
    }
}
