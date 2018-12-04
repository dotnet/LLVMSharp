namespace LLVMSharp
{
    using System;

    partial struct lto_bool_t : IEquatable<lto_bool_t>
    {
        public bool Equals(lto_bool_t other)
        {
            return this.Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is lto_bool_t)
            {
                return this.Equals((lto_bool_t)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(lto_bool_t op1, lto_bool_t op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(lto_bool_t op1, lto_bool_t op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
