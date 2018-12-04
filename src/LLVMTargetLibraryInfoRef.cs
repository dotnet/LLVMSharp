namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMTargetLibraryInfoRef : IEquatable<LLVMTargetLibraryInfoRef>, IHandle<TargetLibraryInfo>
    {
        IntPtr IHandle<TargetLibraryInfo>.GetInternalPointer() => this.Pointer;
        TargetLibraryInfo IHandle<TargetLibraryInfo>.ToWrapperType() => new TargetLibraryInfo(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMTargetLibraryInfoRef t && this.Equals(t);
        public bool Equals(LLVMTargetLibraryInfoRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMTargetLibraryInfoRef op1, LLVMTargetLibraryInfoRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMTargetLibraryInfoRef op1, LLVMTargetLibraryInfoRef op2) => !(op1 == op2);
    }
}
