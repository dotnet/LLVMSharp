using System;

namespace LLVMSharp
{
    public partial struct LLVMTargetMachineRef : IEquatable<LLVMTargetMachineRef>
    {
        public static bool operator ==(LLVMTargetMachineRef left, LLVMTargetMachineRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMTargetMachineRef left, LLVMTargetMachineRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMTargetMachineRef other && Equals(other);

        public bool Equals(LLVMTargetMachineRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
