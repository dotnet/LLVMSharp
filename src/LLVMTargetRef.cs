namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMTargetRef : IEquatable<LLVMTargetRef>, IHandle<Target>
    {
        IntPtr IHandle<Target>.GetInternalPointer() => this.Pointer;
        Target IHandle<Target>.ToWrapperType() => new Target(this);

        public bool Equals(LLVMTargetRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMTargetRef)
            {
                return this.Equals((LLVMTargetRef)obj);
            }
            return false;
        }

        public static bool operator ==(LLVMTargetRef op1, LLVMTargetRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMTargetRef op1, LLVMTargetRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
