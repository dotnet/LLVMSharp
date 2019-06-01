namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMRelocationIteratorRef : IEquatable<LLVMRelocationIteratorRef>, IHandle<RelocationIterator>
    {
        IntPtr IHandle<RelocationIterator>.GetInternalPointer() => this.Pointer;
        RelocationIterator IHandle<RelocationIterator>.ToWrapperType() => new RelocationIterator(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMRelocationIteratorRef t && this.Equals(t);
        public bool Equals(LLVMRelocationIteratorRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMRelocationIteratorRef op1, LLVMRelocationIteratorRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMRelocationIteratorRef op1, LLVMRelocationIteratorRef op2) => !(op1 == op2);
    }
}
