namespace LLVMSharp.API
{
    using System;
    using Utilities;

    public sealed class SectionIterator : IDisposableWrapper<LLVMSectionIteratorRef>, IDisposable
    {
        LLVMSectionIteratorRef IWrapper<LLVMSectionIteratorRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMSectionIteratorRef>.MakeHandleOwner() => this._owner = true;

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

        public void MoveToNextSection() => LLVM.MoveToNextSection(this.Unwrap());
        public void MoveToContainingSection(SymbolIterator sym) => LLVM.MoveToContainingSection(this.Unwrap(), sym.Unwrap());
        public string SectionName => LLVM.GetSectionName(this.Unwrap());
        public ulong SectionSize => LLVM.GetSectionSize(this.Unwrap());
        public string SectionContents => LLVM.GetSectionContents(this.Unwrap());
        public ulong SectionAddress => LLVM.GetSectionAddress(this.Unwrap());

        public RelocationIterator Relocations => LLVM.GetRelocations(this.Unwrap()).Wrap();
        public bool IsRelocationIteratorAtEnd(RelocationIterator ri) => LLVM.IsRelocationIteratorAtEnd(this.Unwrap(), ri.Unwrap());

        public bool SectionContainsSymbol(SymbolIterator sym) => LLVM.GetSectionContainsSymbol(this.Unwrap(), sym.Unwrap());
    }
}
