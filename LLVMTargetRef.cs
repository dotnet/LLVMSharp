namespace LLVMSharp
{
    using System;

    public partial struct LLVMTargetRef : IEquatable<LLVMTargetRef>, IHandle<Target>
    {
        public IntPtr GetInternalPointer() => Pointer;

        public bool Equals(LLVMTargetRef other)
        {
            return this.Pointer == other.Pointer;
        }

        Target IHandle<Target>.ToWrapperType()
        {
            return new Target(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMTargetRef)
            {
                return this.Equals((LLVMTargetRef)obj);
            }
            else
            {
                return false;
            }
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
