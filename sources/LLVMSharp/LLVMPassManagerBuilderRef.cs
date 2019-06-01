namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMPassManagerBuilderRef : IEquatable<LLVMPassManagerBuilderRef>, IHandle<PassManagerBuilder>
    {
        IntPtr IHandle<PassManagerBuilder>.GetInternalPointer() => this.Pointer;
        PassManagerBuilder IHandle<PassManagerBuilder>.ToWrapperType() => new PassManagerBuilder(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMPassManagerBuilderRef t && this.Equals(t);
        public bool Equals(LLVMPassManagerBuilderRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMPassManagerBuilderRef op1, LLVMPassManagerBuilderRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMPassManagerBuilderRef op1, LLVMPassManagerBuilderRef op2) => !(op1 == op2);
    }
}
