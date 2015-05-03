namespace LLVMSharp
{
    using System;

    public partial struct LLVMGenericValueRef : IEquatable<LLVMGenericValueRef>
    {
        public bool Equals(LLVMGenericValueRef other)
        {
            return this.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMGenericValueRef)
            {
                return this.Equals((LLVMGenericValueRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMGenericValueRef op1, LLVMGenericValueRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMGenericValueRef op1, LLVMGenericValueRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
