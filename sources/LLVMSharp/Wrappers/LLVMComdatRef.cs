using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMComdatRef
    {
        public LLVMComdatRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMComdatRef(LLVMComdat* Comdat)
        {
            return new LLVMComdatRef((IntPtr)Comdat);
        }

        public static implicit operator LLVMComdat*(LLVMComdatRef Comdat)
        {
            return (LLVMComdat*)Comdat.Pointer;
        }
    }
}
