namespace LLVMSharp
{
    using System;

    public sealed class MCJITMemoryManager : IDisposableWrapper<LLVMMCJITMemoryManagerRef>, IDisposable
    {
        public static MCJITMemoryManager Create(IntPtr opaque, LLVMMemoryManagerAllocateCodeSectionCallback allocateCodeSection, LLVMMemoryManagerAllocateDataSectionCallback allocateDataSection, LLVMMemoryManagerFinalizeMemoryCallback finalizeMemory, LLVMMemoryManagerDestroyCallback destroy)
        {
            return LLVM.CreateSimpleMCJITMemoryManager(opaque, allocateCodeSection, allocateDataSection, finalizeMemory,
                                                       destroy).Wrap().MakeHandleOwner<MCJITMemoryManager, LLVMMCJITMemoryManagerRef>();
        }

        LLVMMCJITMemoryManagerRef IWrapper<LLVMMCJITMemoryManagerRef>.ToHandleType()
        {
            return this._instance;
        }

        void IDisposableWrapper<LLVMMCJITMemoryManagerRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

        private readonly LLVMMCJITMemoryManagerRef _instance;
        private bool _disposed;
        private bool _owner;

        internal MCJITMemoryManager(LLVMMCJITMemoryManagerRef instance)
        {
            this._instance = instance;
        }

        ~MCJITMemoryManager()
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
                LLVM.DisposeMCJITMemoryManager(this.Unwrap());
            }

            this._disposed = true;

        }
    }
}
