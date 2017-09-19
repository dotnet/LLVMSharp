namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMPassRegistryRef : IEquatable<LLVMPassRegistryRef>, IHandle<PassRegistry>
    {
        IntPtr IHandle<PassRegistry>.GetInternalPointer() => this.Pointer;
        PassRegistry IHandle<PassRegistry>.ToWrapperType() => new PassRegistry(this);

        public bool Equals(LLVMPassRegistryRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMPassRegistryRef)
            {
                return this.Equals((LLVMPassRegistryRef)obj);
            }
            return false;
        }

        public static bool operator ==(LLVMPassRegistryRef op1, LLVMPassRegistryRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMPassRegistryRef op1, LLVMPassRegistryRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
