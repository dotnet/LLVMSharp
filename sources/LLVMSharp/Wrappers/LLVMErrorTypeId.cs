using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMErrorTypeId
    {
        public LLVMErrorTypeId(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static explicit operator LLVMErrorTypeId(void* value)
        {
            return new LLVMErrorTypeId((IntPtr)value);
        }

        public static implicit operator void*(LLVMErrorTypeId value)
        {
            return (void*)value.Pointer;
        }
    }
}
