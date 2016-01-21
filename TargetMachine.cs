namespace LLVMSharp
{
    using System;

    public sealed class TargetMachine : IWrapper<LLVMTargetMachineRef>, IDisposable
    {
        LLVMTargetMachineRef IWrapper<LLVMTargetMachineRef>.ToHandleType()
        {
            return this._instance;
        }

        void IWrapper<LLVMTargetMachineRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

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

        public Target Target
        {
            get { return LLVM.GetTargetMachineTarget(this.Unwrap()).Wrap(); }
        }

        public IntPtr Triple
        {
            get { return LLVM.GetTargetMachineTriple(this.Unwrap()); }
        }

        public IntPtr CPU
        {
            get { return LLVM.GetTargetMachineCPU(this.Unwrap()); }
        }

        public IntPtr FeatureString
        {
            get { return LLVM.GetTargetMachineFeatureString(this.Unwrap()); }
        }

        public TargetData Data
        {
            get { return LLVM.GetTargetMachineData(this.Unwrap()).Wrap(); }
        }

        public void SetAsmVerbosity(bool verboseAsm)
        {
            LLVM.SetTargetMachineAsmVerbosity(this.Unwrap(), verboseAsm);
        }

        public bool EmitToFile(Module m, IntPtr filename, LLVMCodeGenFileType codegen, out IntPtr errorMessage)
        {
            return LLVM.TargetMachineEmitToFile(this.Unwrap(), m.Unwrap(), filename, codegen, out errorMessage);
        }

        public MemoryBuffer EmitToMemoryBuffer(Module m, LLVMCodeGenFileType codegen)
        {
            LLVMMemoryBufferRef buf;
            IntPtr error;
            if (
                LLVM.TargetMachineEmitToMemoryBuffer(this.Unwrap(), m.Unwrap(), codegen, out error, out buf)
                    .Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return buf.Wrap();
        }

        public void AddAnalysisPasses(PassManager pm)
        {
            LLVM.AddAnalysisPasses(this.Unwrap(), pm.Unwrap());
        }

    }
}
