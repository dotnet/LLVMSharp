namespace LLVMSharp.API
{
    using System;
    using Utilities;

    public sealed class RelocationIterator : IDisposableWrapper<LLVMRelocationIteratorRef>, IDisposable
    {
        LLVMRelocationIteratorRef IWrapper<LLVMRelocationIteratorRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMRelocationIteratorRef>.MakeHandleOwner() => this._owner = true;

        private readonly LLVMRelocationIteratorRef _instance;
        private bool _disposed;
        private bool _owner;

        internal RelocationIterator(LLVMRelocationIteratorRef instance)
        {
            this._instance = instance;
        }

        ~RelocationIterator()
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
                LLVM.DisposeRelocationIterator(this.Unwrap());
            }

            this._disposed = true;
        }

        public void MoveToNextRelocation()
        {
            LLVM.MoveToNextRelocation(this.Unwrap());
        }

        public ulong Offset => LLVM.GetRelocationOffset(this.Unwrap());
        public SymbolIterator Symbol => LLVM.GetRelocationSymbol(this.Unwrap()).Wrap();
        public ulong Type => LLVM.GetRelocationType(this.Unwrap());
        public string TypeName => LLVM.GetRelocationTypeName(this.Unwrap());
        public string ValueString => LLVM.GetRelocationValueString(this.Unwrap());
    }
}
