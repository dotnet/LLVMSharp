using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMOrcJITStackRef
    {
        public LLVMOrcJITStackRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMOrcJITStackRef(LLVMOrcOpaqueJITStack* value)
        {
            return new LLVMOrcJITStackRef((IntPtr)value);
        }

        public static implicit operator LLVMOrcOpaqueJITStack*(LLVMOrcJITStackRef value)
        {
            return (LLVMOrcOpaqueJITStack*)value.Pointer;
        }
    }
}
