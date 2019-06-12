using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMValueRef
    {
        public LLVMValueRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMValueRef(LLVMOpaqueValue* value)
        {
            return new LLVMValueRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueValue*(LLVMValueRef value)
        {
            return (LLVMOpaqueValue*)value.Pointer;
        }
    }
}
