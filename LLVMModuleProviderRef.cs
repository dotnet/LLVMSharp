namespace LLVMSharp
{
    using System;

    public partial struct LLVMModuleProviderRef : IEquatable<LLVMModuleProviderRef>, IHandle<ModuleProvider>
    {
        public IntPtr GetInternalPointer() => Pointer;

        ModuleProvider IHandle<ModuleProvider>.ToWrapperType()
        {            
            return new ModuleProvider(this);
        }

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
            else
            {
                return false;
            }
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
