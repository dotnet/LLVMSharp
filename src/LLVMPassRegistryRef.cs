namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMPassRegistryRef : IEquatable<LLVMPassRegistryRef>, IHandle<PassRegistry>
    {
        IntPtr IHandle<PassRegistry>.GetInternalPointer() => this.Pointer;
        PassRegistry IHandle<PassRegistry>.ToWrapperType() => new PassRegistry(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMPassRegistryRef t && this.Equals(t);
        public bool Equals(LLVMPassRegistryRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMPassRegistryRef op1, LLVMPassRegistryRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMPassRegistryRef op1, LLVMPassRegistryRef op2) => !(op1 == op2);
    }
}
