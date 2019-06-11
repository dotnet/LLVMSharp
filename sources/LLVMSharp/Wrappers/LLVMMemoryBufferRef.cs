using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMMemoryBufferRef
    {
        public LLVMMemoryBufferRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMMemoryBufferRef(LLVMOpaqueMemoryBuffer* MemoryBuffer)
        {
            return new LLVMMemoryBufferRef((IntPtr)MemoryBuffer);
        }

        public static implicit operator LLVMOpaqueMemoryBuffer*(LLVMMemoryBufferRef MemoryBuffer)
        {
            return (LLVMOpaqueMemoryBuffer*)MemoryBuffer.Pointer;
        }
    }
}
