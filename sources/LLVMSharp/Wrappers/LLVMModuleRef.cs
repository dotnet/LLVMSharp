using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMModuleRef
    {
        public LLVMModuleRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMModuleRef(LLVMOpaqueModule* value)
        {
            return new LLVMModuleRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueModule*(LLVMModuleRef value)
        {
            return (LLVMOpaqueModule*)value.Pointer;
        }
    }
}
