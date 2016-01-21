namespace LLVMSharp
{
    using System;

    public sealed class ModuleProvider : IWrapper<LLVMModuleProviderRef>, IDisposable
    {
        LLVMModuleProviderRef IWrapper<LLVMModuleProviderRef>.ToHandleType()
        {
            return this._instance;
        }

        void IWrapper<LLVMModuleProviderRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

        private readonly LLVMModuleProviderRef _instance;
        private bool _disposed;
        private bool _owner;

        internal ModuleProvider(LLVMModuleProviderRef instance)
        {
            this._instance = instance;
        }

        ~ModuleProvider()
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
                LLVM.DisposeModuleProvider(this.Unwrap());
            }

            this._disposed = true;
        }
    }
}
