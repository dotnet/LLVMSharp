using System;

namespace LLVMSharp
{
    public partial struct LLVMDiagnosticInfoRef
    {
        public LLVMDiagnosticInfoRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
