using System;

namespace LLVMSharp
{
    public partial struct LLVMObjectFileRef : IEquatable<LLVMObjectFileRef>
    {
        public static bool operator ==(LLVMObjectFileRef left, LLVMObjectFileRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMObjectFileRef left, LLVMObjectFileRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMObjectFileRef other && Equals(other);

        public bool Equals(LLVMObjectFileRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
