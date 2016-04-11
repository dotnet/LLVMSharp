namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMRelocationIteratorRef : IEquatable<LLVMRelocationIteratorRef>, IHandle<RelocationIterator>
    {
        IntPtr IHandle<RelocationIterator>.GetInternalPointer() => this.Pointer;
        RelocationIterator IHandle<RelocationIterator>.ToWrapperType() => new RelocationIterator(this);

        public bool Equals(LLVMRelocationIteratorRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMRelocationIteratorRef)
            {
                return this.Equals((LLVMRelocationIteratorRef)obj);
            }
            return false;
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
