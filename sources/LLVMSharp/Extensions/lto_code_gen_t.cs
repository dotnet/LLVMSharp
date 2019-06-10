namespace LLVMSharp
{
    using System;

    partial struct lto_code_gen_t : IEquatable<lto_code_gen_t>
    {
        public bool Equals(lto_code_gen_t other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is lto_code_gen_t)
            {
                return this.Equals((lto_code_gen_t)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(lto_code_gen_t op1, lto_code_gen_t op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(lto_code_gen_t op1, lto_code_gen_t op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
