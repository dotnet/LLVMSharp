namespace LLVMSharp
{
    using LLVMSharp.Api;
    using LLVMSharp.Utilities;
    using System;

    partial struct LLVMContextRef : IHandle<Context>, IEquatable<LLVMContextRef>
    {
        IntPtr IHandle<Context>.GetInternalPointer() => this.Pointer;
        Context IHandle<Context>.ToWrapperType() => new Context(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMContextRef t && this.Equals(t);
        public bool Equals(LLVMContextRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMContextRef op1, LLVMContextRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMContextRef op1, LLVMContextRef op2) => !(op1 == op2);
    }
}
