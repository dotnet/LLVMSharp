namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMSymbolIteratorRef : IEquatable<LLVMSymbolIteratorRef>, IHandle<SymbolIterator>
    {
        IntPtr IHandle<SymbolIterator>.GetInternalPointer() => this.Pointer;
        SymbolIterator IHandle<SymbolIterator>.ToWrapperType() => new SymbolIterator(this);

        public bool Equals(LLVMSymbolIteratorRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMSymbolIteratorRef)
            {
                return this.Equals((LLVMSymbolIteratorRef)obj);
            }
            return false;
        }

        public static bool operator ==(LLVMSymbolIteratorRef op1, LLVMSymbolIteratorRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMSymbolIteratorRef op1, LLVMSymbolIteratorRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
