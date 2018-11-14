namespace LLVMSharp.API
{
    using System;
    using Utilities;
    using AllocCodeSectionCallback = global::System.Func<global::System.IntPtr, global::System.IntPtr, uint, uint, string, global::System.IntPtr>;
    using AllocDataSectionCallback = global::System.Func<global::System.IntPtr, global::System.IntPtr, uint, uint, string, bool, global::System.IntPtr>;
    using FinalizeMemoryCallback = global::System.Func<global::System.IntPtr, global::System.Tuple<int, global::System.IntPtr>>;

    public sealed class MCJITMemoryManager : IDisposableWrapper<LLVMMCJITMemoryManagerRef>, IDisposable
    {
        LLVMMCJITMemoryManagerRef IWrapper<LLVMMCJITMemoryManagerRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMMCJITMemoryManagerRef>.MakeHandleOwner() => this._owner = true;

        private class MemoryManagerFinalizeMemoryClosure
        {
            private readonly FinalizeMemoryCallback _callback;

            public MemoryManagerFinalizeMemoryClosure(FinalizeMemoryCallback callback)
            {
                this._callback = callback;
            }

            public int Invoke(IntPtr opaque, out IntPtr errMsg)
            {
                var r = _callback(opaque);
                errMsg = r.Item2;
                return r.Item1;
            }
        }

        public static MCJITMemoryManager Create(IntPtr opaque, AllocCodeSectionCallback allocateCodeSection, AllocDataSectionCallback allocateDataSection, FinalizeMemoryCallback finalizeMemory, Action<IntPtr> destroy)
        {
            var allocCodeSectionCallback = new LLVMMemoryManagerAllocateCodeSectionCallback(allocateCodeSection);
            var allocDataSectionCallback = new LLVMMemoryManagerAllocateDataSectionCallback((a, b, c, d, e, f) => allocateDataSection(a, b, c, d, e, f));
            var finalizeMemoryCallback = new LLVMMemoryManagerFinalizeMemoryCallback(new MemoryManagerFinalizeMemoryClosure(finalizeMemory).Invoke);
            var destroyCallback = new LLVMMemoryManagerDestroyCallback(destroy);
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
