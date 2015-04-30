namespace LLVMSharp
{
    using System;

    public sealed class LLVMContext
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
    }
}