namespace LLVMSharp
{
    using System;

    public partial struct LLVMTargetLibraryInfoRef : IEquatable<LLVMTargetLibraryInfoRef>
    {
        public bool Equals(LLVMTargetLibraryInfoRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMTargetLibraryInfoRef)
            {
                return this.Equals((LLVMTargetLibraryInfoRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMTargetLibraryInfoRef op1, LLVMTargetLibraryInfoRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMTargetLibraryInfoRef op1, LLVMTargetLibraryInfoRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
