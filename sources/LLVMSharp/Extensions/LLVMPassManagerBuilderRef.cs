using System;

namespace LLVMSharp
{
    public partial struct LLVMPassManagerBuilderRef : IEquatable<LLVMPassManagerBuilderRef>
    {
        public static bool operator ==(LLVMPassManagerBuilderRef left, LLVMPassManagerBuilderRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMPassManagerBuilderRef left, LLVMPassManagerBuilderRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMPassManagerBuilderRef other && Equals(other);

        public bool Equals(LLVMPassManagerBuilderRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
