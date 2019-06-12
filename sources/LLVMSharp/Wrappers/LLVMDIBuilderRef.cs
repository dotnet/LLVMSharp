using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMDIBuilderRef
    {
        public LLVMDIBuilderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMDIBuilderRef(LLVMOpaqueDIBuilder* value)
        {
            return new LLVMDIBuilderRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueDIBuilder*(LLVMDIBuilderRef value)
        {
            return (LLVMOpaqueDIBuilder*)value.Pointer;
        }
    }
}
