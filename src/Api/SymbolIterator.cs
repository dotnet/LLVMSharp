namespace LLVMSharp.API
{
    using System;
    using Utilities;

    public sealed class SymbolIterator : IDisposableWrapper<LLVMSymbolIteratorRef>, IDisposable
    {
        LLVMSymbolIteratorRef IWrapper<LLVMSymbolIteratorRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMSymbolIteratorRef>.MakeHandleOwner() => this._owner = true;

        private readonly LLVMSymbolIteratorRef _instance;
        private bool _disposed;
        private bool _owner;

        internal SymbolIterator(LLVMSymbolIteratorRef instance)
        {
            this._instance = instance;
        }

        ~SymbolIterator()
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
                LLVM.DisposeSymbolIterator(this.Unwrap());
            }

            this._disposed = true;
        }

        public void MoveToNextSymbol() => LLVM.MoveToNextSymbol(this.Unwrap());

        public string SymbolName => LLVM.GetSymbolName(this.Unwrap());
        public int SymbolAddress => (int)LLVM.GetSymbolAddress(this.Unwrap());
        public int SymbolSize => (int)LLVM.GetSymbolSize(this.Unwrap());
    }
}
