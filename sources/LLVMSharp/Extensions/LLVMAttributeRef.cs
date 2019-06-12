using System;

namespace LLVMSharp
{
    public partial struct LLVMAttributeRef : IEquatable<LLVMAttributeRef>
    {
        public static bool operator ==(LLVMAttributeRef left, LLVMAttributeRef right) => left.Equals(right);

        public static bool operator !=(LLVMAttributeRef left, LLVMAttributeRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMAttributeRef other && Equals(other);

        public bool Equals(LLVMAttributeRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
