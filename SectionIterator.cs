namespace LLVMSharp
{
    using System;

    public sealed class SectionIterator : IDisposableWrapper<LLVMSectionIteratorRef>, IDisposable
    {
        LLVMSectionIteratorRef IWrapper<LLVMSectionIteratorRef>.ToHandleType()
        {
            return this._instance;
        }

        void IDisposableWrapper<LLVMSectionIteratorRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

        private readonly LLVMSectionIteratorRef _instance;
        private bool _disposed;
        private bool _owner;

        internal SectionIterator(LLVMSectionIteratorRef instance)
        {
            this._instance = instance;
        }

        ~SectionIterator()
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
                LLVM.DisposeSectionIterator(this.Unwrap());
            }

            this._disposed = true;
        }

        public void MoveToNextSection()
        {
            LLVM.MoveToNextSection(this.Unwrap());
        }

        public void MoveToContainingSection(SymbolIterator sym)
        {
            LLVM.MoveToContainingSection(this.Unwrap(), sym.Unwrap());
        }

        public string SectionName
        {
            get { return LLVM.GetSectionName(this.Unwrap()); }
        }

        public int SectionSize
        {
            get { return LLVM.GetSectionSize(this.Unwrap()); }
        }

        public string SectionContents
        {
            get { return LLVM.GetSectionContents(this.Unwrap()); }
        }

        public int SectionAddress
        {
            get { return LLVM.GetSectionAddress(this.Unwrap()); }
        }

        public bool SectionContainsSymbol(SymbolIterator sym)
        {
            return LLVM.GetSectionContainsSymbol(this.Unwrap(), sym.Unwrap());
        }

        public RelocationIterator Relocations
        {
            get { return LLVM.GetRelocations(this.Unwrap()).Wrap(); }
        }

        public bool IsRelocationIteratorAtEnd(RelocationIterator ri)
        {
            return LLVM.IsRelocationIteratorAtEnd(this.Unwrap(), ri.Unwrap());
        }
    }
}
