using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMSymbolIteratorRef
    {
        public LLVMSymbolIteratorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMSymbolIteratorRef(LLVMOpaqueSymbolIterator* value)
        {
            return new LLVMSymbolIteratorRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueSymbolIterator*(LLVMSymbolIteratorRef value)
        {
            return (LLVMOpaqueSymbolIterator*)value.Pointer;
        }
    }
}
