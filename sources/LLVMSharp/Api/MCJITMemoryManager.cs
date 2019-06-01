namespace LLVMSharp.API
{
    using System;
    using Utilities;

    public sealed class MCJITMemoryManager : IDisposableWrapper<LLVMMCJITMemoryManagerRef>, IDisposable
    {
        LLVMMCJITMemoryManagerRef IWrapper<LLVMMCJITMemoryManagerRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMMCJITMemoryManagerRef>.MakeHandleOwner() => this._owner = true;

        public static MCJITMemoryManager Create(IntPtr opaque, LLVMMemoryManagerAllocateCodeSectionCallback allocCodeSectionCallback, LLVMMemoryManagerAllocateDataSectionCallback allocDataSectionCallback, LLVMMemoryManagerFinalizeMemoryCallback finalizeMemoryCallback, LLVMMemoryManagerDestroyCallback destroyCallback)
        {
            var memoryManager = LLVM.CreateSimpleMCJITMemoryManager(opaque, allocCodeSectionCallback, allocDataSectionCallback, finalizeMemoryCallback, destroyCallback)
                                    .Wrap()
                                    .MakeHandleOwner<MCJITMemoryManager, LLVMMCJITMemoryManagerRef>();
            memoryManager._allocCodeSectionCallback = allocCodeSectionCallback;
            memoryManager._allocDataSectionCallback = allocDataSectionCallback;
            memoryManager._finalizeMemoryCallback = finalizeMemoryCallback;
            memoryManager._destroyCallback = destroyCallback;
            return memoryManager;
        }

        private readonly LLVMMCJITMemoryManagerRef _instance;
        private bool _disposed;
        private bool _owner;
        private LLVMMemoryManagerAllocateCodeSectionCallback _allocCodeSectionCallback;
        private LLVMMemoryManagerAllocateDataSectionCallback _allocDataSectionCallback;
        private LLVMMemoryManagerFinalizeMemoryCallback _finalizeMemoryCallback;
        private LLVMMemoryManagerDestroyCallback _destroyCallback;

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
