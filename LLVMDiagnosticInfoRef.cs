namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMDiagnosticInfoRef : IEquatable<LLVMDiagnosticInfoRef>, IHandle<DiagnosticInfo>
    {
        IntPtr IHandle<DiagnosticInfo>.GetInternalPointer() => this.Pointer;
        DiagnosticInfo IHandle<DiagnosticInfo>.ToWrapperType() => new DiagnosticInfo(this);

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
            return false;
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
