using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMPassManagerRef
    {
        public LLVMPassManagerRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMPassManagerRef(LLVMOpaquePassManager* value)
        {
            return new LLVMPassManagerRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaquePassManager*(LLVMPassManagerRef value)
        {
            return (LLVMOpaquePassManager*)value.Pointer;
        }
    }
}
