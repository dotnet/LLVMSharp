namespace LLVMSharp
{
    using System;

    public partial struct LLVMPassManagerBuilderRef : IEquatable<LLVMPassManagerBuilderRef>
    {
        public bool Equals(LLVMPassManagerBuilderRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMPassManagerBuilderRef)
            {
                return this.Equals((LLVMPassManagerBuilderRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMPassManagerBuilderRef op1, LLVMPassManagerBuilderRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMPassManagerBuilderRef op1, LLVMPassManagerBuilderRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
