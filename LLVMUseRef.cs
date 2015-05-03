namespace LLVMSharp
{
    using System;

    public partial struct LLVMUseRef : IEquatable<LLVMUseRef>
    {
        public bool Equals(LLVMUseRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMUseRef)
            {
                return this.Equals((LLVMUseRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMUseRef op1, LLVMUseRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMUseRef op1, LLVMUseRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
