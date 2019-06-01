namespace LLVMSharp
{
    using System;

    public partial struct llvm_lto_t : IEquatable<llvm_lto_t>
    {
        public bool Equals(llvm_lto_t other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is llvm_lto_t)
            {
                return this.Equals((llvm_lto_t)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(llvm_lto_t op1, llvm_lto_t op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(llvm_lto_t op1, llvm_lto_t op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
