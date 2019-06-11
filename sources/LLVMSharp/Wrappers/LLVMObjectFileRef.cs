using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMObjectFileRef
    {
        public LLVMObjectFileRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMObjectFileRef(LLVMOpaqueObjectFile* value)
        {
            return new LLVMObjectFileRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueObjectFile*(LLVMObjectFileRef value)
        {
            return (LLVMOpaqueObjectFile*)value.Pointer;
        }
    }
}
