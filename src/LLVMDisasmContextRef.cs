namespace LLVMSharp
{
    using System;
    using API;
    using Utilities;

    partial struct LLVMDisasmContextRef : IEquatable<LLVMDisasmContextRef>, IHandle<DisasmContext>
    {
        IntPtr IHandle<DisasmContext>.GetInternalPointer() => this.Pointer;
        DisasmContext IHandle<DisasmContext>.ToWrapperType() => new DisasmContext(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMDisasmContextRef t && this.Equals(t);
        public bool Equals(LLVMDisasmContextRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMDisasmContextRef op1, LLVMDisasmContextRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMDisasmContextRef op1, LLVMDisasmContextRef op2) => !(op1 == op2);
    }
}
