namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMMCJITMemoryManagerRef : IEquatable<LLVMMCJITMemoryManagerRef>, IHandle<MCJITMemoryManager>
    {
        IntPtr IHandle<MCJITMemoryManager>.GetInternalPointer() => this.Pointer;
        MCJITMemoryManager IHandle<MCJITMemoryManager>.ToWrapperType() => new MCJITMemoryManager(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMMCJITMemoryManagerRef t && this.Equals(t);
        public bool Equals(LLVMMCJITMemoryManagerRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMMCJITMemoryManagerRef op1, LLVMMCJITMemoryManagerRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMMCJITMemoryManagerRef op1, LLVMMCJITMemoryManagerRef op2) => !(op1 == op2);
    }
}
