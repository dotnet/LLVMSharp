using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMTypeRef
    {
        public LLVMTypeRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMTypeRef(LLVMOpaqueType* value)
        {
            return new LLVMTypeRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueType*(LLVMTypeRef value)
        {
            return (LLVMOpaqueType*)value.Pointer;
        }
    }
}
