namespace LLVMSharp
{
    using System;

    public partial struct LLVMMCJITMemoryManagerRef : IEquatable<LLVMMCJITMemoryManagerRef>
    {
        public bool Equals(LLVMMCJITMemoryManagerRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMMCJITMemoryManagerRef)
            {
                return this.Equals((LLVMMCJITMemoryManagerRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMMCJITMemoryManagerRef op1, LLVMMCJITMemoryManagerRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMMCJITMemoryManagerRef op1, LLVMMCJITMemoryManagerRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
