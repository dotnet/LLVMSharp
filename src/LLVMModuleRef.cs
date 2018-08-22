namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMModuleRef : IEquatable<LLVMModuleRef>, IHandle<Module>
    {
        IntPtr IHandle<Module>.GetInternalPointer() => this.Pointer;
        Module IHandle<Module>.ToWrapperType() => new Module(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMModuleRef t && this.Equals(t);
        public bool Equals(LLVMModuleRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMModuleRef op1, LLVMModuleRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMModuleRef op1, LLVMModuleRef op2) => !(op1 == op2);
    }
}
