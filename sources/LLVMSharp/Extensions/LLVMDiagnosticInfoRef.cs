using System;

namespace LLVMSharp
{
    public partial struct LLVMDiagnosticInfoRef : IEquatable<LLVMDiagnosticInfoRef>
    {
        public static bool operator ==(LLVMDiagnosticInfoRef left, LLVMDiagnosticInfoRef right) => left.Equals(right);

        public static bool operator !=(LLVMDiagnosticInfoRef left, LLVMDiagnosticInfoRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMDiagnosticInfoRef other && Equals(other);

        public bool Equals(LLVMDiagnosticInfoRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
