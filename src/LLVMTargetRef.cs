namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMTargetRef : IEquatable<LLVMTargetRef>, IHandle<Target>
    {
        IntPtr IHandle<Target>.GetInternalPointer() => this.Pointer;
        Target IHandle<Target>.ToWrapperType() => new Target(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMTargetRef t && this.Equals(t);
        public bool Equals(LLVMTargetRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMTargetRef op1, LLVMTargetRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMTargetRef op1, LLVMTargetRef op2) => !(op1 == op2);
    }
}
