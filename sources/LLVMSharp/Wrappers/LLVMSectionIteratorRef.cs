using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMSectionIteratorRef
    {
        public LLVMSectionIteratorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMSectionIteratorRef(LLVMOpaqueSectionIterator* value)
        {
            return new LLVMSectionIteratorRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueSectionIterator*(LLVMSectionIteratorRef value)
        {
            return (LLVMOpaqueSectionIterator*)value.Pointer;
        }
    }
}
