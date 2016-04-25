namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMModuleProviderRef : IEquatable<LLVMModuleProviderRef>, IHandle<ModuleProvider>
    {
        IntPtr IHandle<ModuleProvider>.GetInternalPointer() => this.Pointer;
        ModuleProvider IHandle<ModuleProvider>.ToWrapperType() => new ModuleProvider(this);

        public bool Equals(LLVMModuleProviderRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMModuleProviderRef)
            {
                return this.Equals((LLVMModuleProviderRef)obj);
            }
            return false;
        }

        public static bool operator ==(LLVMModuleProviderRef op1, LLVMModuleProviderRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMModuleProviderRef op1, LLVMModuleProviderRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
