namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMModuleProviderRef : IEquatable<LLVMModuleProviderRef>, IHandle<ModuleProvider>
    {
        IntPtr IHandle<ModuleProvider>.GetInternalPointer() => this.Pointer;
        ModuleProvider IHandle<ModuleProvider>.ToWrapperType() => new ModuleProvider(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMModuleProviderRef t && this.Equals(t);
        public bool Equals(LLVMModuleProviderRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMModuleProviderRef op1, LLVMModuleProviderRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMModuleProviderRef op1, LLVMModuleProviderRef op2) => !(op1 == op2);
    }
}
