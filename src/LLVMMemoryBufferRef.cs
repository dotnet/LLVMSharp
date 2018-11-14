namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMMemoryBufferRef : IEquatable<LLVMMemoryBufferRef>, IHandle<MemoryBuffer>
    {
        IntPtr IHandle<MemoryBuffer>.GetInternalPointer() => this.Pointer;
        MemoryBuffer IHandle<MemoryBuffer>.ToWrapperType() => new MemoryBuffer(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMMemoryBufferRef t && this.Equals(t);
        public bool Equals(LLVMMemoryBufferRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMMemoryBufferRef op1, LLVMMemoryBufferRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMMemoryBufferRef op1, LLVMMemoryBufferRef op2) => !(op1 == op2);
    }
}
