using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMNamedMDNodeRef
    {
        public LLVMNamedMDNodeRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMNamedMDNodeRef(LLVMOpaqueNamedMDNode* value)
        {
            return new LLVMNamedMDNodeRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueNamedMDNode*(LLVMNamedMDNodeRef value)
        {
            return (LLVMOpaqueNamedMDNode*)value.Pointer;
        }
    }
}
