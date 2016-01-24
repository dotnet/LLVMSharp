namespace LLVMSharp
{
    using System;

    public partial struct LLVMPassManagerRef : IEquatable<LLVMPassManagerRef>, IHandle<PassManager>
    {
        PassManager IHandle<PassManager>.ToWrapperType()
        {
            return new PassManager(this);
        }

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
            else
            {
                return false;
            }
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
