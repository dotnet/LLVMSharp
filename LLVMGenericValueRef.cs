namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMGenericValueRef : IEquatable<LLVMGenericValueRef>, IHandle<GenericValue>
    {
        IntPtr IHandle<GenericValue>.GetInternalPointer() => this.Pointer;
        GenericValue IHandle<GenericValue>.ToWrapperType() => new GenericValue(this);

        public bool Equals(LLVMGenericValueRef other)
        {
            return this.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMGenericValueRef)
            {
                return this.Equals((LLVMGenericValueRef)obj);
            }
            return false;
        }

        public static bool operator ==(LLVMGenericValueRef op1, LLVMGenericValueRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMGenericValueRef op1, LLVMGenericValueRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
