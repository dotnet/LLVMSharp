namespace LLVMSharp.API
{
    using System;
    using Utilities;

    public sealed class MemoryBuffer : IDisposableWrapper<LLVMMemoryBufferRef>, IDisposable
    {
        LLVMMemoryBufferRef IWrapper<LLVMMemoryBufferRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMMemoryBufferRef>.MakeHandleOwner() => this._owner = true;

        public static MemoryBuffer CreateMemoryBufferWithContentsOfFile(string path)
        {
            if (LLVM.CreateMemoryBufferWithContentsOfFile(path, out LLVMMemoryBufferRef bufferRef, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return bufferRef.Wrap().MakeHandleOwner<MemoryBuffer, LLVMMemoryBufferRef>();
        }

        public static MemoryBuffer CreateMemoryBufferWithSTDIN()
        {
            if (LLVM.CreateMemoryBufferWithSTDIN(out LLVMMemoryBufferRef bufferRef, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return bufferRef.Wrap().MakeHandleOwner<MemoryBuffer, LLVMMemoryBufferRef>();
        }

        public unsafe static MemoryBuffer CreateMemoryBufferWithMemoryRange(string inputData, string bufferLength, bool requiresNullTerminator)
        {
            return LLVM.CreateMemoryBufferWithMemoryRange(inputData, (IntPtr)(inputData.Length), bufferLength, requiresNullTerminator).Wrap().MakeHandleOwner<MemoryBuffer, LLVMMemoryBufferRef>();
        }

        public unsafe static MemoryBuffer CreateMemoryBufferWithMemoryRangeCopy(string inputData, string bufferName)
        {
            return LLVM.CreateMemoryBufferWithMemoryRangeCopy(inputData, (IntPtr)(inputData.Length), bufferName).Wrap().MakeHandleOwner<MemoryBuffer, LLVMMemoryBufferRef>();
        }

        private readonly LLVMMemoryBufferRef _instance;
        private bool _disposed;
        private bool _owner;

        internal MemoryBuffer(LLVMMemoryBufferRef instance)
        {
            this._instance = instance;
        }

        ~MemoryBuffer()
        {
            this.Dispose(false);
        }

        public IntPtr BufferStart => LLVM.GetBufferStart(this.Unwrap());
        public IntPtr BufferSize => LLVM.GetBufferSize(this.Unwrap());

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
                LLVM.DisposeMemoryBuffer(this.Unwrap());
            }

            this._disposed = true;

        }

        public Module ParseBitcode()
        {
            if (LLVM.ParseBitcode(this.Unwrap(), out LLVMModuleRef m, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return m.Wrap();
        }

        public Module GetBitcodeModule()
        {
            if (LLVM.GetBitcodeModule(this.Unwrap(), out LLVMModuleRef m, out IntPtr error).Failed())
            {
                TextUtilities.Throw(error);
            }

            return m.Wrap();
        }
    }
}
