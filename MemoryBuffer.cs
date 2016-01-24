namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class MemoryBuffer : IWrapper<LLVMMemoryBufferRef>, IDisposable
    {
        public static MemoryBuffer CreateMemoryBufferWithContentsOfFile(string path)
        {
            LLVMMemoryBufferRef bufferRef;
            IntPtr error;
            if (LLVM.CreateMemoryBufferWithContentsOfFile(path, out bufferRef, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return bufferRef.Wrap().MakeHandleOwner<MemoryBuffer, LLVMMemoryBufferRef>();
        }

        public static MemoryBuffer CreateMemoryBufferWithSTDIN()
        {
            LLVMMemoryBufferRef bufferRef;
            IntPtr error;
            if (LLVM.CreateMemoryBufferWithSTDIN(out bufferRef, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return bufferRef.Wrap().MakeHandleOwner<MemoryBuffer, LLVMMemoryBufferRef>();
        }

        public static MemoryBuffer CreateMemoryBufferWithMemoryRange(string inputData, int inputDataLength,
                                                                     string bufferLength, bool requiresNullTerminator)
        {
            return
                LLVM.CreateMemoryBufferWithMemoryRange(inputData, inputDataLength, bufferLength, requiresNullTerminator)
                    .Wrap().MakeHandleOwner<MemoryBuffer, LLVMMemoryBufferRef>();
        }

        public static MemoryBuffer CreateMemoryBufferWithMemoryRangeCopy(string inputData, int inputDataLength,
                                                                         string bufferName)
        {
            return
                LLVM.CreateMemoryBufferWithMemoryRangeCopy(inputData, inputDataLength, bufferName)
                    .Wrap()
                    .MakeHandleOwner<MemoryBuffer, LLVMMemoryBufferRef>();
        }

        LLVMMemoryBufferRef IWrapper<LLVMMemoryBufferRef>.ToHandleType() => this._instance;

        void IWrapper<LLVMMemoryBufferRef>.MakeHandleOwner()
        {
            this._owner = true;
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

        public string BufferStart
        {
            get { return LLVM.GetBufferStart(this.Unwrap()); }
        }

        public int BufferSize
        {
            get { return LLVM.GetBufferSize(this.Unwrap()); }
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
                LLVM.DisposeMemoryBuffer(this.Unwrap());
            }

            this._disposed = true;

        }

        public Module ParseBitcode()
        {
            LLVMModuleRef m;
            IntPtr error;
            if (LLVM.ParseBitcode(this.Unwrap(), out m, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return m.Wrap();
        }

        public Module GetBitcodeModule()
        {
            LLVMModuleRef m;
            IntPtr error;
            if (LLVM.GetBitcodeModule(this.Unwrap(), out m, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return m.Wrap();
        }

        public ModuleProvider GetBitcodeModuleProvider()
        {
            LLVMModuleProviderRef m;
            IntPtr error;
            if (LLVM.GetBitcodeModuleProvider(this.Unwrap(), out m, out error).Failed())
            {
                ErrorUtilities.Throw(error);
            }

            return m.Wrap();
        }
    }
}
