using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMDiagnosticInfoRef
    {
        public LLVMDiagnosticInfoRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMDiagnosticInfoRef(LLVMOpaqueDiagnosticInfo* value)
        {
            return new LLVMDiagnosticInfoRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueDiagnosticInfo*(LLVMDiagnosticInfoRef value)
        {
            return (LLVMOpaqueDiagnosticInfo*)value.Pointer;
        }
    }
}
