namespace LLVMSharp.Api
{
    using Utilities;

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

        public string Description => LLVM.GetDiagInfoDescription(this.Unwrap()).IntPtrToString();

        public LLVMDiagnosticSeverity Severity => LLVM.GetDiagInfoSeverity(this.Unwrap());
    }
}
