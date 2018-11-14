namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMTargetDataRef : IEquatable<LLVMTargetDataRef>, IHandle<TargetData>
    {
        IntPtr IHandle<TargetData>.GetInternalPointer() => this.Pointer;
        TargetData IHandle<TargetData>.ToWrapperType() => new TargetData(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMTargetDataRef t && this.Equals(t);
        public bool Equals(LLVMTargetDataRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMTargetDataRef op1, LLVMTargetDataRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMTargetDataRef op1, LLVMTargetDataRef op2) => !(op1 == op2);
    }
}
