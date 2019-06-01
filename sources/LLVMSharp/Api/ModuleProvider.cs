namespace LLVMSharp.API
{
    using System;
    using Utilities;

    public sealed class ModuleProvider : IDisposableWrapper<LLVMModuleProviderRef>, IDisposable
    {
        LLVMModuleProviderRef IWrapper<LLVMModuleProviderRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMModuleProviderRef>.MakeHandleOwner() => this._owner = true;

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
