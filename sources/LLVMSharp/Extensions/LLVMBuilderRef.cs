namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMBuilderRef : IEquatable<LLVMBuilderRef>, IHandle<API.IRBuilder>
    {
        IntPtr IHandle<API.IRBuilder>.GetInternalPointer() => this.Pointer;
        API.IRBuilder IHandle<API.IRBuilder>.ToWrapperType() => new API.IRBuilder(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMBuilderRef t && this.Equals(t);
        public bool Equals(LLVMBuilderRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMBuilderRef op1, LLVMBuilderRef op2) => op1.Equals(op2);
        public static bool operator !=(LLVMBuilderRef op1, LLVMBuilderRef op2) => !(op1 == op2);
    }
}
