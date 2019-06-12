using System;

namespace LLVMSharp
{
    public partial struct LLVMTargetDataRef : IEquatable<LLVMTargetDataRef>
    {
        public static bool operator ==(LLVMTargetDataRef left, LLVMTargetDataRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMTargetDataRef left, LLVMTargetDataRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMTargetDataRef other && Equals(other);

        public bool Equals(LLVMTargetDataRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
