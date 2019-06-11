using System;

namespace LLVMSharp
{
    public partial struct LLVMPassRegistryRef : IEquatable<LLVMPassRegistryRef>
    {
        public static bool operator ==(LLVMPassRegistryRef left, LLVMPassRegistryRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMPassRegistryRef left, LLVMPassRegistryRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMPassRegistryRef other && Equals(other);

        public bool Equals(LLVMPassRegistryRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
