namespace LLVMSharp
{
    using System;

    public partial struct LLVMTargetMachineRef : IEquatable<LLVMTargetMachineRef>, IHandle<TargetMachine>
    {
        public bool Equals(LLVMTargetMachineRef other)
        {
            return this.Pointer == other.Pointer;
        }

        TargetMachine IHandle<TargetMachine>.ToWrapperType()
        {
            return new TargetMachine(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMTargetMachineRef)
            {
                return this.Equals((LLVMTargetMachineRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator==(LLVMTargetMachineRef op1, LLVMTargetMachineRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMTargetMachineRef op1, LLVMTargetMachineRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
