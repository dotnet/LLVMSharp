using System;

namespace LLVMSharp
{
    public partial struct LLVMDisasmContextRef : IEquatable<LLVMDisasmContextRef>
    {
        public static bool operator ==(LLVMDisasmContextRef left, LLVMDisasmContextRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMDisasmContextRef left, LLVMDisasmContextRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMDisasmContextRef other && Equals(other);

        public bool Equals(LLVMDisasmContextRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
