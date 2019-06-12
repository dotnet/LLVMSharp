using System;

namespace LLVMSharp
{
    public partial struct LLVMSectionIteratorRef : IEquatable<LLVMSectionIteratorRef>
    {
        public static bool operator ==(LLVMSectionIteratorRef left, LLVMSectionIteratorRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMSectionIteratorRef left, LLVMSectionIteratorRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMSectionIteratorRef other && Equals(other);

        public bool Equals(LLVMSectionIteratorRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
