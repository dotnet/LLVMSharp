namespace LLVMSharp
{
    using System;

    public partial struct LLVMDiagnosticInfoRef : IEquatable<LLVMDiagnosticInfoRef>, IHandle<DiagnosticInfo>
    {
        public IntPtr GetInternalPointer() => Pointer;

        DiagnosticInfo IHandle<DiagnosticInfo>.ToWrapperType()
        {
            return new DiagnosticInfo(this);
        }

        public bool Equals(LLVMDiagnosticInfoRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMDiagnosticInfoRef)
            {
                return this.Equals((LLVMDiagnosticInfoRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMDiagnosticInfoRef op1, LLVMDiagnosticInfoRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMDiagnosticInfoRef op1, LLVMDiagnosticInfoRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
