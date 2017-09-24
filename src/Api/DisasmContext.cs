namespace LLVMSharp.Api
{
    using System;
    using Utilities;

    public sealed class DisasmContext : IDisposableWrapper<LLVMDisasmContextRef>, IDisposable
    {
        public static DisasmContext CreateDisasm(string tripleName, IntPtr disInfo, int tagType, LLVMOpInfoCallback getOpInfo,
                                           LLVMSymbolLookupCallback symbolLookUp)
        {
            return
                LLVM.CreateDisasm(tripleName, disInfo, tagType, getOpInfo, symbolLookUp)
                    .Wrap()
                    .MakeHandleOwner<DisasmContext, LLVMDisasmContextRef>();
        }

        public static DisasmContext CreateDisasmCPU(string triple, string cpu, IntPtr disInfo, int tagType, LLVMOpInfoCallback getOpInfo, LLVMSymbolLookupCallback symbolLookUp)
        {
            return
                LLVM.CreateDisasmCPU(triple, cpu, disInfo, tagType, getOpInfo, symbolLookUp)
                    .Wrap()
                    .MakeHandleOwner<DisasmContext, LLVMDisasmContextRef>();
        }

        public static DisasmContext CreateDisasmCPUFeatures(string triple, string cpu, string features, IntPtr disInfo,
                                                     int tagType, LLVMOpInfoCallback getOpInfo,
                                                     LLVMSymbolLookupCallback symbolLookUp)
        {
            return LLVM.CreateDisasmCPUFeatures(triple, cpu, features, disInfo, tagType, getOpInfo,
                                                symbolLookUp)
                       .Wrap()
                       .MakeHandleOwner<DisasmContext, LLVMDisasmContextRef>();
        }

        LLVMDisasmContextRef IWrapper<LLVMDisasmContextRef>.ToHandleType()
        {
            return this._instance;
        }

        void IDisposableWrapper<LLVMDisasmContextRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

        private readonly LLVMDisasmContextRef _instance;
        private bool _disposed;
        private bool _owner;

        internal DisasmContext(LLVMDisasmContextRef instance)
        {
            this._instance = instance;
        }

        ~DisasmContext()
        {
            this.Dispose(false);
        }

        public int SetDisasmOptions(ulong options)
        {
            return LLVM.SetDisasmOptions(this.Unwrap(), options);
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
                LLVM.DisasmDispose(this.Unwrap());
            }

            this._disposed = true;
        }

        public size_t DisasmInstruction(IntPtr bytes, ulong bytesSize, ulong pc, IntPtr outString, int outStringSize)
        {
            return LLVM.DisasmInstruction(this.Unwrap(), bytes, bytesSize, pc, outString, new size_t(outStringSize));
        }
    }
}
