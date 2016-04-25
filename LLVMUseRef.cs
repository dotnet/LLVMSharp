namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMUseRef : IEquatable<LLVMUseRef>, IHandle<Use>
    {
        IntPtr IHandle<Use>.GetInternalPointer() => this.Pointer;
        Use IHandle<Use>.ToWrapperType() => new Use(this);

        public bool Equals(LLVMUseRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMUseRef)
            {
                return this.Equals((LLVMUseRef)obj);
            }
            return false;
        }

        public static bool operator ==(LLVMUseRef op1, LLVMUseRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMUseRef op1, LLVMUseRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
