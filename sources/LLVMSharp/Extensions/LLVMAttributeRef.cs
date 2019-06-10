namespace LLVMSharp
{
    using System;
    using Utilities;
    using Attribute = LLVMSharp.API.Attribute;

    partial struct LLVMAttributeRef : IEquatable<LLVMAttributeRef>, IHandle<Attribute>
    {
        IntPtr IHandle<Attribute>.GetInternalPointer() => this.Pointer;
        Attribute IHandle<Attribute>.ToWrapperType() => new Attribute(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMAttributeRef t && this.Equals(t);
        public bool Equals(LLVMAttributeRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMAttributeRef op1, LLVMAttributeRef op2) => op1.Equals(op2);
        public static bool operator !=(LLVMAttributeRef op1, LLVMAttributeRef op2) => !(op1 == op2);
    }
}
