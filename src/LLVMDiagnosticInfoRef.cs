namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMDiagnosticInfoRef : IEquatable<LLVMDiagnosticInfoRef>, IHandle<DiagnosticInfo>
    {
        IntPtr IHandle<DiagnosticInfo>.GetInternalPointer() => this.Pointer;
        DiagnosticInfo IHandle<DiagnosticInfo>.ToWrapperType() => new DiagnosticInfo(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMDiagnosticInfoRef t && this.Equals(t);
        public bool Equals(LLVMDiagnosticInfoRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMDiagnosticInfoRef op1, LLVMDiagnosticInfoRef op2) => op1.Equals(op2);
        public static bool operator !=(LLVMDiagnosticInfoRef op1, LLVMDiagnosticInfoRef op2) => !(op1 == op2);
    }
}
