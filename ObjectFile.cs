namespace LLVMSharp
{
    using System;

    public sealed class ObjectFile : IWrapper<LLVMObjectFileRef>, IDisposable
    {
        public static ObjectFile Create(MemoryBuffer memBuf)
        {
            return LLVM.CreateObjectFile(memBuf.Unwrap()).Wrap().MakeHandleOwner<ObjectFile, LLVMObjectFileRef>();
        }

        LLVMObjectFileRef IWrapper<LLVMObjectFileRef>.ToHandleType()
        {
            return this._instance;
        }

        void IWrapper<LLVMObjectFileRef>.MakeHandleOwner()
        {
            this._owner = true;
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

        public SectionIterator Sections
        {
            get { return LLVM.GetSections(this.Unwrap()).Wrap(); }
        }

        public bool IsSectionIteratorAtEnd(SectionIterator si)
        {
            return LLVM.IsSectionIteratorAtEnd(this.Unwrap(), si.Unwrap());
        }

        public SymbolIterator Symbols
        {
            get { return LLVM.GetSymbols(this.Unwrap()).Wrap(); }
        }

        public bool IsSymbolIteratorAtEnd(SymbolIterator si)
        {
            return LLVM.IsSymbolIteratorAtEnd(this.Unwrap(), si.Unwrap());
        }


    }
}
