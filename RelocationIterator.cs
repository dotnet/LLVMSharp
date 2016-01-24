namespace LLVMSharp
{
    using System;

    public sealed class RelocationIterator : IWrapper<LLVMRelocationIteratorRef>, IDisposable
    {
        LLVMRelocationIteratorRef IWrapper<LLVMRelocationIteratorRef>.ToHandleType()
        {
            return this._instance;
        }

        void IWrapper<LLVMRelocationIteratorRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

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

        public int Address
        {
            get { return LLVM.GetRelocationAddress(this.Unwrap()); }
        }

        public int Offset
        {
            get { return LLVM.GetRelocationOffset(this.Unwrap()); }
        }

        public SymbolIterator Symbol
        {
            get { return LLVM.GetRelocationSymbol(this.Unwrap()).Wrap(); }
        }

        public int Type
        {
            get { return LLVM.GetRelocationType(this.Unwrap()); }
        }

        public string TypeName
        {
            get { return LLVM.GetRelocationTypeName(this.Unwrap()); }
        }

        public string ValueString
        {
            get { return LLVM.GetRelocationValueString(this.Unwrap()); }
        }


    }
}
