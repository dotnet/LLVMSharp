namespace LLVMSharp.API
{
    using System;
    using Utilities;

    public sealed class TargetMachine : IDisposableWrapper<LLVMTargetMachineRef>, IDisposable
    {
        LLVMTargetMachineRef IWrapper<LLVMTargetMachineRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMTargetMachineRef>.MakeHandleOwner() => this._owner = true;

        private readonly LLVMTargetMachineRef _instance;
        private bool _disposed;
        private bool _owner;

        internal TargetMachine(LLVMTargetMachineRef instance)
        {
            this._instance = instance;
        }

        ~TargetMachine()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (this._owner)
            {
                LLVM.DisposeTargetMachine(this.Unwrap());
            }

            this._disposed = true;
        }

        public Target Target => LLVM.GetTargetMachineTarget(this.Unwrap()).Wrap();
        public string Triple => LLVM.GetTargetMachineTriple(this.Unwrap()).MessageToString();
        public string CPU => LLVM.GetTargetMachineCPU(this.Unwrap()).MessageToString();

        public string FeatureString => LLVM.GetTargetMachineFeatureString(this.Unwrap()).MessageToString();

        public void SetAsmVerbosity(bool verboseAsm) => LLVM.SetTargetMachineAsmVerbosity(this.Unwrap(), verboseAsm);

        public bool EmitToFile(Module m, IntPtr filename, LLVMCodeGenFileType codegen, out IntPtr errorMessage) => LLVM.TargetMachineEmitToFile(this.Unwrap(), m.Unwrap(), filename, codegen, out errorMessage);

        public MemoryBuffer EmitToMemoryBuffer(Module m, LLVMCodeGenFileType codegen)
        {
            if (LLVM.TargetMachineEmitToMemoryBuffer(this.Unwrap(), m.Unwrap(), codegen, out IntPtr error, out LLVMMemoryBufferRef buf).Failed())
            {
                TextUtilities.Throw(error);
            }

            return buf.Wrap();
        }

        public void AddAnalysisPasses(PassManager pm) => LLVM.AddAnalysisPasses(this.Unwrap(), pm.Unwrap());
    }
}
