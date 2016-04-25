namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMPassManagerRef : IEquatable<LLVMPassManagerRef>, IHandle<PassManager>
    {
        IntPtr IHandle<PassManager>.GetInternalPointer() => this.Pointer;
        PassManager IHandle<PassManager>.ToWrapperType() => new PassManager(this);

        public bool Equals(LLVMPassManagerRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMPassManagerRef)
            {
                return this.Equals((LLVMPassManagerRef)obj);
            }
            return false;
        }

        public static bool operator ==(LLVMPassManagerRef op1, LLVMPassManagerRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMPassManagerRef op1, LLVMPassManagerRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
