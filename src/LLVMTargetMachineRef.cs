namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMTargetMachineRef : IEquatable<LLVMTargetMachineRef>, IHandle<TargetMachine>
    {
        IntPtr IHandle<TargetMachine>.GetInternalPointer() => this.Pointer;
        TargetMachine IHandle<TargetMachine>.ToWrapperType() => new TargetMachine(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMTargetMachineRef t && this.Equals(t);
        public bool Equals(LLVMTargetMachineRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMTargetMachineRef op1, LLVMTargetMachineRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMTargetMachineRef op1, LLVMTargetMachineRef op2) => !(op1 == op2);
    }
}
