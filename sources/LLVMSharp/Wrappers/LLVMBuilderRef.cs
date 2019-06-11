using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMBuilderRef
    {
        public LLVMBuilderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMBuilderRef(LLVMOpaqueBuilder* Builder)
        {
            return new LLVMBuilderRef((IntPtr)Builder);
        }

        public static implicit operator LLVMOpaqueBuilder*(LLVMBuilderRef Builder)
        {
            return (LLVMOpaqueBuilder*)Builder.Pointer;
        }
    }
}
