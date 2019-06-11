using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMTargetRef
    {
        public LLVMTargetRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMTargetRef(LLVMTarget* value)
        {
            return new LLVMTargetRef((IntPtr)value);
        }

        public static implicit operator LLVMTarget*(LLVMTargetRef value)
        {
            return (LLVMTarget*)value.Pointer;
        }
    }
}
