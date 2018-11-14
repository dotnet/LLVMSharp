namespace LLVMSharp
{
    using System;

    partial struct lto_module_t : IEquatable<lto_module_t>
    {
        public bool Equals(lto_module_t other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is lto_module_t)
            {
                return this.Equals((lto_module_t)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(lto_module_t op1, lto_module_t op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(lto_module_t op1, lto_module_t op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
