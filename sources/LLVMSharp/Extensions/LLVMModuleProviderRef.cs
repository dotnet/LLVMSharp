using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMModuleProviderRef : IEquatable<LLVMModuleProviderRef>
    {
        public static bool operator ==(LLVMModuleProviderRef left, LLVMModuleProviderRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMModuleProviderRef left, LLVMModuleProviderRef right) => !(left == right);

        public LLVMPassManagerRef CreateFunctionPassManager() => LLVM.CreateFunctionPassManager(this);

        public override bool Equals(object obj) => obj is LLVMModuleProviderRef other && Equals(other);

        public bool Equals(LLVMModuleProviderRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
