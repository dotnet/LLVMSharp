using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMJITEventListenerRef
    {
        public LLVMJITEventListenerRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMJITEventListenerRef(LLVMOpaqueJITEventListener* value)
        {
            return new LLVMJITEventListenerRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueJITEventListener*(LLVMJITEventListenerRef value)
        {
            return (LLVMOpaqueJITEventListener*)value.Pointer;
        }
    }
}
