namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMTargetMachineRef : IEquatable<LLVMTargetMachineRef>, IHandle<TargetMachine>
    {
        IntPtr IHandle<TargetMachine>.GetInternalPointer() => this.Pointer;
        TargetMachine IHandle<TargetMachine>.ToWrapperType() => new TargetMachine(this);

        public bool Equals(LLVMTargetMachineRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMTargetMachineRef)
            {
                return this.Equals((LLVMTargetMachineRef)obj);
            }
            return false;
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
