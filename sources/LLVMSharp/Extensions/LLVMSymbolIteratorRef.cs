namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMSymbolIteratorRef : IEquatable<LLVMSymbolIteratorRef>, IHandle<SymbolIterator>
    {
        IntPtr IHandle<SymbolIterator>.GetInternalPointer() => this.Pointer;
        SymbolIterator IHandle<SymbolIterator>.ToWrapperType() => new SymbolIterator(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMSymbolIteratorRef t && this.Equals(t);
        public bool Equals(LLVMSymbolIteratorRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMSymbolIteratorRef op1, LLVMSymbolIteratorRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMSymbolIteratorRef op1, LLVMSymbolIteratorRef op2) => !(op1 == op2);
    }
}
