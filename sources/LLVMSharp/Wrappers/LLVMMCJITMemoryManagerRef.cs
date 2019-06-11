using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMMCJITMemoryManagerRef
    {
        public LLVMMCJITMemoryManagerRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMMCJITMemoryManagerRef(LLVMOpaqueMCJITMemoryManager* value)
        {
            return new LLVMMCJITMemoryManagerRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueMCJITMemoryManager*(LLVMMCJITMemoryManagerRef value)
        {
            return (LLVMOpaqueMCJITMemoryManager*)value.Pointer;
        }
    }
}
