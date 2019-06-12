using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMTargetDataRef
    {
        public LLVMTargetDataRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMTargetDataRef(LLVMOpaqueTargetData* TargetData)
        {
            return new LLVMTargetDataRef((IntPtr)TargetData);
        }

        public static implicit operator LLVMOpaqueTargetData*(LLVMTargetDataRef TargetData)
        {
            return (LLVMOpaqueTargetData*)TargetData.Pointer;
        }
    }
}
