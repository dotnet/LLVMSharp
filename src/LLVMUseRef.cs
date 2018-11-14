namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMUseRef : IEquatable<LLVMUseRef>, IHandle<Use>
    {
        IntPtr IHandle<Use>.GetInternalPointer() => this.Pointer;
        Use IHandle<Use>.ToWrapperType() => new Use(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMUseRef t && this.Equals(t);
        public bool Equals(LLVMUseRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMUseRef op1, LLVMUseRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMUseRef op1, LLVMUseRef op2) => !(op1 == op2);
    }
}
