namespace LLVMSharp
{
    using System;
    using Utilities;

    partial struct LLVMPassManagerRef : IEquatable<LLVMPassManagerRef>, IHandle<API.PassManager>
    {
        IntPtr IHandle<API.PassManager>.GetInternalPointer() => this.Pointer;
        API.PassManager IHandle<API.PassManager>.ToWrapperType() => new API.PassManager(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMPassManagerRef t && this.Equals(t);
        public bool Equals(LLVMPassManagerRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMPassManagerRef op1, LLVMPassManagerRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMPassManagerRef op1, LLVMPassManagerRef op2) => !(op1 == op2);
    }
}
