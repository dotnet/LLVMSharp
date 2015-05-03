namespace LLVMSharp
{
    using System;

    public partial struct LLVMTargetDataRef : IEquatable<LLVMTargetDataRef>
    {
        public bool Equals(LLVMTargetDataRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMTargetDataRef)
            {
                return this.Equals((LLVMTargetDataRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMTargetDataRef op1, LLVMTargetDataRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMTargetDataRef op1, LLVMTargetDataRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
