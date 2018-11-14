namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMGenericValueRef : IEquatable<LLVMGenericValueRef>, IHandle<GenericValue>
    {
        IntPtr IHandle<GenericValue>.GetInternalPointer() => this.Pointer;
        GenericValue IHandle<GenericValue>.ToWrapperType() => new GenericValue(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMGenericValueRef t && this.Equals(t);
        public bool Equals(LLVMGenericValueRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMGenericValueRef op1, LLVMGenericValueRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMGenericValueRef op1, LLVMGenericValueRef op2) => !(op1 == op2);
    }
}
