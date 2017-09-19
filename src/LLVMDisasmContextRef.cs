namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMDisasmContextRef : IEquatable<LLVMDisasmContextRef>, IHandle<DisasmContext>
    {
        IntPtr IHandle<DisasmContext>.GetInternalPointer() => this.Pointer;
        DisasmContext IHandle<DisasmContext>.ToWrapperType() => new DisasmContext(this);

        public bool Equals(LLVMDisasmContextRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMDisasmContextRef)
            {
                return this.Equals((LLVMDisasmContextRef)obj);
            }
            return false;
        }

        public static bool operator ==(LLVMDisasmContextRef op1, LLVMDisasmContextRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMDisasmContextRef op1, LLVMDisasmContextRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
