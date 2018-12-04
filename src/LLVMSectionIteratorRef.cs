namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMSectionIteratorRef : IEquatable<LLVMSectionIteratorRef>, IHandle<SectionIterator>
    {
        IntPtr IHandle<SectionIterator>.GetInternalPointer() => this.Pointer;
        SectionIterator IHandle<SectionIterator>.ToWrapperType() => new SectionIterator(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMSectionIteratorRef t && this.Equals(t);
        public bool Equals(LLVMSectionIteratorRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMSectionIteratorRef op1, LLVMSectionIteratorRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMSectionIteratorRef op1, LLVMSectionIteratorRef op2) => !(op1 == op2);
    }
}
