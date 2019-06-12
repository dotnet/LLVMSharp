using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMPassRegistryRef
    {
        public LLVMPassRegistryRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMPassRegistryRef(LLVMOpaquePassRegistry* value)
        {
            return new LLVMPassRegistryRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaquePassRegistry*(LLVMPassRegistryRef value)
        {
            return (LLVMOpaquePassRegistry*)value.Pointer;
        }
    }
}
