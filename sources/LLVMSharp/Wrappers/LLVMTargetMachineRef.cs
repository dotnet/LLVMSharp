using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMTargetMachineRef
    {
        public LLVMTargetMachineRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMTargetMachineRef(LLVMOpaqueTargetMachine* value)
        {
            return new LLVMTargetMachineRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueTargetMachine*(LLVMTargetMachineRef value)
        {
            return (LLVMOpaqueTargetMachine*)value.Pointer;
        }
    }
}
