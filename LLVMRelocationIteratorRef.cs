namespace LLVMSharp
{
    using System;

    public partial struct LLVMRelocationIteratorRef : IEquatable<LLVMRelocationIteratorRef>, IHandle<RelocationIterator>
    {
        public bool Equals(LLVMRelocationIteratorRef other)
        {
            return this.Pointer == other.Pointer;
        }

        RelocationIterator IHandle<RelocationIterator>.ToWrapperType()
        {
            return new RelocationIterator(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMRelocationIteratorRef)
            {
                return this.Equals((LLVMRelocationIteratorRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMRelocationIteratorRef op1, LLVMRelocationIteratorRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMRelocationIteratorRef op1, LLVMRelocationIteratorRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
