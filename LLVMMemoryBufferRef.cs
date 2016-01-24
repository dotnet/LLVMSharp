namespace LLVMSharp
{
    using System;

    public partial struct LLVMMemoryBufferRef : IEquatable<LLVMMemoryBufferRef>, IHandle<MemoryBuffer>
    {
        MemoryBuffer IHandle<MemoryBuffer>.ToWrapperType()
        {
            return new MemoryBuffer(this);
        }

        public bool Equals(LLVMMemoryBufferRef other)
        {
            return this.Pointer == other.Pointer;
        }
        
        public override bool Equals(object obj)
        {
            if (obj is LLVMMemoryBufferRef)
            {
                return this.Equals((LLVMMemoryBufferRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMMemoryBufferRef op1, LLVMMemoryBufferRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMMemoryBufferRef op1, LLVMMemoryBufferRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
