namespace LLVMSharp
{
    using System;

    public sealed class PassManagerBuilder : IWrapper<LLVMPassManagerBuilderRef>, IDisposable
    {
        public static PassManagerBuilder Create()
        {
            return
                LLVM.PassManagerBuilderCreate().Wrap().MakeHandleOwner<PassManagerBuilder, LLVMPassManagerBuilderRef>();
        }

        LLVMPassManagerBuilderRef IWrapper<LLVMPassManagerBuilderRef>.ToHandleType()
        {
            return this._instance;
        }

        void IWrapper<LLVMPassManagerBuilderRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

        private readonly LLVMPassManagerBuilderRef _instance;
        private bool _disposed;
        private bool _owner;

        internal PassManagerBuilder(LLVMPassManagerBuilderRef instance)
        {
            this._instance = instance;
        }

        ~PassManagerBuilder()
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
                LLVM.PassManagerBuilderDispose(this.Unwrap());
            }

            this._disposed = true;
        }

        public void SetOptLevel(uint optLevel)
        {
            LLVM.PassManagerBuilderSetOptLevel(this.Unwrap(), optLevel);
        }

        public void SetSizeLevel(uint sizeLevel)
        {
            LLVM.PassManagerBuilderSetSizeLevel(this.Unwrap(), sizeLevel);
        }

        public void SetDisableUnitAtATime(bool value)
        {
            LLVM.PassManagerBuilderSetDisableUnitAtATime(this.Unwrap(), value);
        }

        public void SetDisableUnrollLoops(bool value)
        {
            LLVM.PassManagerBuilderSetDisableUnrollLoops(this.Unwrap(), value);
        }

        public void SetDisableSimplifyLibCalls(bool value)
        {
            LLVM.PassManagerBuilderSetDisableSimplifyLibCalls(this.Unwrap(), value);
        }

        public void UseInlinerWithThreshold(uint threshold)
        {
            LLVM.PassManagerBuilderUseInlinerWithThreshold(this.Unwrap(), threshold);
        }

        public void PopulateFunctionPassManager(PassManager pm)
        {
            LLVM.PassManagerBuilderPopulateFunctionPassManager(this.Unwrap(), pm.Unwrap());
        }

        public void PopulateModulePassManager(PassManager pm)
        {
            LLVM.PassManagerBuilderPopulateModulePassManager(this.Unwrap(), pm.Unwrap());
        }

        public void PopulateLTOPassManager(PassManager pm, bool internalize, bool runInliner)
        {
            LLVM.PassManagerBuilderPopulateLTOPassManager(this.Unwrap(), pm.Unwrap(), internalize, runInliner);
        }
        
    }
}
