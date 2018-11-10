namespace LLVMSharp
{
    using System;
    using LLVMSharp.Api.Values;
    using LLVMSharp.Utilities;

    partial struct LLVMBasicBlockRef : IHandle<BasicBlock>
    {
        IntPtr IHandle<BasicBlock>.GetInternalPointer() => this.Pointer;
        BasicBlock IHandle<BasicBlock>.ToWrapperType() => new BasicBlock(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMBasicBlockRef t && this.Equals(t);
        public bool Equals(LLVMBasicBlockRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMBasicBlockRef op1, LLVMBasicBlockRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMBasicBlockRef op1, LLVMBasicBlockRef op2) => !(op1 == op2);
    }
}
