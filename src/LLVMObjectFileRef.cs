namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMObjectFileRef : IEquatable<LLVMObjectFileRef>, IHandle<ObjectFile>
    {
        IntPtr IHandle<ObjectFile>.GetInternalPointer() => this.Pointer;
        ObjectFile IHandle<ObjectFile>.ToWrapperType() => new ObjectFile(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMObjectFileRef t && this.Equals(t);
        public bool Equals(LLVMObjectFileRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMObjectFileRef op1, LLVMObjectFileRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMObjectFileRef op1, LLVMObjectFileRef op2) => !(op1 == op2);
    }
}
