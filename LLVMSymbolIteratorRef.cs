namespace LLVMSharp
{
    using System;

    public partial struct LLVMSymbolIteratorRef : IEquatable<LLVMSymbolIteratorRef>, IHandle<SymbolIterator>
    {
        public IntPtr GetInternalPointer() => Pointer;

        public bool Equals(LLVMSymbolIteratorRef other)
        {
            return this.Pointer == other.Pointer;
        }

        SymbolIterator IHandle<SymbolIterator>.ToWrapperType()
        {
            return new SymbolIterator(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMSymbolIteratorRef)
            {
                return this.Equals((LLVMSymbolIteratorRef)obj);
            }
            else
            {
                return false;
            }  
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
