namespace LLVMSharp
{
    using System;

    public sealed class LLVMContext : IEquatable<LLVMContext>
    {
        private readonly LLVMContextRef innerRef;

        public LLVMContext()
        {
            this.innerRef = LLVM.ContextCreate();
        }

        public LLVMContextRef InternalValue { get { return this.innerRef; } }

        public uint GetMDKindID(string name)
        {
            return LLVM.GetMDKindIDInContext(this.innerRef, name, (uint)name.Length);
        }

        public void SetDiagnosticHandler(LLVMDiagnosticHandler diagHandler, IntPtr diagContext)
        {
            LLVM.ContextSetDiagnosticHandler(this.innerRef, diagHandler, diagContext);
        }

        public void SetDiagnosticHandler(LLVMDiagnosticHandler diagHandler)
        {
            this.SetDiagnosticHandler(diagHandler, IntPtr.Zero);
        }

        public void SetYieldCallBack(LLVMYieldCallback callback, IntPtr opaqueHande)
        {
            LLVM.ContextSetYieldCallback(this.innerRef, callback, opaqueHande);
        }

        public bool Equals(LLVMContext other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            else
            {
                return this.innerRef == other.innerRef;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as LLVMContext);
        }

        public static bool operator ==(LLVMContext op1, LLVMContext op2)
        {
            if (ReferenceEquals(op1, null))
            {
                return ReferenceEquals(op2, null);
            }
            else
            {
                return op1.Equals(op2);
            }
        }

        public static bool operator !=(LLVMContext op1, LLVMContext op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.innerRef.GetHashCode();
        }
    }
}