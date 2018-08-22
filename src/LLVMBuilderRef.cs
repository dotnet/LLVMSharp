namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMBuilderRef : IEquatable<LLVMBuilderRef>, IHandle<IRBuilder>
    {
        IntPtr IHandle<IRBuilder>.GetInternalPointer() => this.Pointer;
        IRBuilder IHandle<IRBuilder>.ToWrapperType() => new IRBuilder(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMBuilderRef t && this.Equals(t);
        public bool Equals(LLVMBuilderRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMBuilderRef op1, LLVMBuilderRef op2) => op1.Equals(op2);
        public static bool operator !=(LLVMBuilderRef op1, LLVMBuilderRef op2) => !(op1 == op2);
    }
}
