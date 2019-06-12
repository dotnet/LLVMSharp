using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMUseRef
    {
        public LLVMUseRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMUseRef(LLVMOpaqueUse* Use)
        {
            return new LLVMUseRef((IntPtr)Use);
        }

        public static implicit operator LLVMOpaqueUse*(LLVMUseRef Use)
        {
            return (LLVMOpaqueUse*)Use.Pointer;
        }
    }
}
