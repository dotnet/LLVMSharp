namespace LLVMSharp.API
{
    using Utilities;

    public sealed class DiagnosticInfo : IWrapper<LLVMDiagnosticInfoRef>
    {
        LLVMDiagnosticInfoRef IWrapper<LLVMDiagnosticInfoRef>.ToHandleType => this._instance;

        private readonly LLVMDiagnosticInfoRef _instance;

        internal DiagnosticInfo(LLVMDiagnosticInfoRef instance)
        {
            this._instance = instance;
        }

        public DiagnosticSeverity Severity => LLVM.GetDiagInfoSeverity(this.Unwrap()).Wrap();
        public string Description => LLVM.GetDiagInfoDescription(this.Unwrap()).MessageToString();
    }
}
