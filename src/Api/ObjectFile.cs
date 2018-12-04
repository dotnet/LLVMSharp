namespace LLVMSharp.API
{
    using System;
    using Utilities;

    public sealed class ObjectFile : IDisposableWrapper<LLVMObjectFileRef>, IDisposable
    {
        LLVMObjectFileRef IWrapper<LLVMObjectFileRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMObjectFileRef>.MakeHandleOwner() => this._owner = true;

        public static ObjectFile Create(MemoryBuffer memBuf)
        {
            return LLVM.CreateObjectFile(memBuf.Unwrap()).Wrap().MakeHandleOwner<ObjectFile, LLVMObjectFileRef>();
        }

        private readonly LLVMObjectFileRef _instance;
        private bool _disposed;
        private bool _owner;

        internal ObjectFile(LLVMObjectFileRef instance)
        {
            this._instance = instance;
        }

        ~ObjectFile()
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
                LLVM.DisposeObjectFile(this.Unwrap());
            }

            this._disposed = true;
        }

        public SectionIterator Sections => LLVM.GetSections(this.Unwrap()).Wrap();
        public bool IsSectionIteratorAtEnd(SectionIterator si) => LLVM.IsSectionIteratorAtEnd(this.Unwrap(), si.Unwrap());

        public SymbolIterator Symbols => LLVM.GetSymbols(this.Unwrap()).Wrap();
        public bool IsSymbolIteratorAtEnd(SymbolIterator si) => LLVM.IsSymbolIteratorAtEnd(this.Unwrap(), si.Unwrap());
    }
}
