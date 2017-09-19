namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMSectionIteratorRef : IEquatable<LLVMSectionIteratorRef>, IHandle<SectionIterator>
    {
        IntPtr IHandle<SectionIterator>.GetInternalPointer() => this.Pointer;
        SectionIterator IHandle<SectionIterator>.ToWrapperType() => new SectionIterator(this);

        public bool Equals(LLVMSectionIteratorRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMSectionIteratorRef)
            {
                return this.Equals((LLVMSectionIteratorRef)obj);
            }
            return false;
        }

        public static bool operator ==(LLVMSectionIteratorRef op1, LLVMSectionIteratorRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMSectionIteratorRef op1, LLVMSectionIteratorRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
