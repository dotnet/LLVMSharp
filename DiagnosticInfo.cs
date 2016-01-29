namespace LLVMSharp
{
    using System;

    public sealed class DiagnosticInfo : IWrapper<LLVMDiagnosticInfoRef>
    {
        LLVMDiagnosticInfoRef IWrapper<LLVMDiagnosticInfoRef>.ToHandleType()
        {
            return this._instance;
        }

        private readonly LLVMDiagnosticInfoRef _instance;

        internal DiagnosticInfo(LLVMDiagnosticInfoRef instance)
        {
            this._instance = instance;
        }

        public string Description
        {
            get { return LLVM.GetDiagInfoDescription(this.Unwrap()).IntPtrToString(); }
        }

        public LLVMDiagnosticSeverity Severity
        {
            get { return LLVM.GetDiagInfoSeverity(this.Unwrap()); }
        }
    }
}
