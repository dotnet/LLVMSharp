using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMExecutionEngineRef
    {
        public LLVMExecutionEngineRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMExecutionEngineRef(LLVMOpaqueExecutionEngine* value)
        {
            return new LLVMExecutionEngineRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueExecutionEngine*(LLVMExecutionEngineRef value)
        {
            return (LLVMOpaqueExecutionEngine*)value.Pointer;
        }
    }
}
