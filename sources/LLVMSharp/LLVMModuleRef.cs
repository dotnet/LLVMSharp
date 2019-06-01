namespace LLVMSharp
{
    using System;
    using Utilities;

    partial struct LLVMModuleRef : IEquatable<LLVMModuleRef>, IHandle<API.Module>
    {
        IntPtr IHandle<API.Module>.GetInternalPointer() => this.Pointer;
        API.Module IHandle<API.Module>.ToWrapperType() => new API.Module(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMModuleRef t && this.Equals(t);
        public bool Equals(LLVMModuleRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMModuleRef op1, LLVMModuleRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMModuleRef op1, LLVMModuleRef op2) => !(op1 == op2);
    }
}
