using System;

namespace LLVMSharp
{
    public partial struct LLVMMemoryBufferRef : IEquatable<LLVMMemoryBufferRef>
    {
        public static bool operator ==(LLVMMemoryBufferRef left, LLVMMemoryBufferRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMMemoryBufferRef left, LLVMMemoryBufferRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMMemoryBufferRef other && Equals(other);

        public bool Equals(LLVMMemoryBufferRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
