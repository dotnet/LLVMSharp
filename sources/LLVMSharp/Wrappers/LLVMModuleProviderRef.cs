using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMModuleProviderRef
    {
        public LLVMModuleProviderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMModuleProviderRef(LLVMOpaqueModuleProvider* value)
        {
            return new LLVMModuleProviderRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueModuleProvider*(LLVMModuleProviderRef value)
        {
            return (LLVMOpaqueModuleProvider*)value.Pointer;
        }
    }
}
