namespace LLVMSharp
{
    using System;

    public partial struct LLVMBuilderRef : IEquatable<LLVMBuilderRef>
    {
        public bool Equals(LLVMBuilderRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMBuilderRef)
            {
                return this.Equals((LLVMBuilderRef) obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMBuilderRef op1, LLVMBuilderRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMBuilderRef op1, LLVMBuilderRef op2)
        {
            return !(op1 == op2);
        }

        public static implicit operator LLVMBuilderRef(IRBuilder builder)
        {
            return builder.instance;
        }


        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
