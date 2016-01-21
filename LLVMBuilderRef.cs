namespace LLVMSharp
{
    using System;

    public partial struct LLVMBuilderRef : IEquatable<LLVMBuilderRef>, IHandle<IRBuilder>
    {
        public bool Equals(LLVMBuilderRef other)
        {
            return this.Pointer == other.Pointer;
        }

        IRBuilder IHandle<IRBuilder>.ToWrapperType()
        {
            return new IRBuilder(this);
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
        
        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }


    }
}
