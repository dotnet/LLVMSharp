namespace LLVMSharp.API
{
    using System;
    using System.Text;
    using Utilities;
    using OpInfoCallback = System.Func<System.IntPtr, ulong, ulong, ulong, int, System.IntPtr, int>;
    using SymbolLookupCallback = System.Func<System.IntPtr, ulong, ulong, System.Tuple<System.IntPtr, ulong, System.IntPtr>>;

    public sealed class DisasmContext : IDisposableWrapper<LLVMDisasmContextRef>, IDisposable
    {
        LLVMDisasmContextRef IWrapper<LLVMDisasmContextRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMDisasmContextRef>.MakeHandleOwner() => this._owner = true;
        
        private class SymbolLookupClosure
        {
            private readonly SymbolLookupCallback _callback;

            public SymbolLookupClosure(SymbolLookupCallback c)
            {
                this._callback = c;
            }

            public IntPtr Invoke(IntPtr @DisInfo, ulong @ReferenceValue, out ulong @ReferenceType, ulong @ReferencePC, out IntPtr @ReferenceName)
            {
                var r = this._callback(DisInfo, ReferenceValue, ReferencePC);
                ReferenceType = r.Item2;
                ReferenceName = r.Item3;
                return r.Item1;
            }
        }
        
        public static DisasmContext CreateDisasm(string tripleName, IntPtr disInfo, int tagType, OpInfoCallback getOpInfo,
                                           SymbolLookupCallback symbolLookUp)
        {
            var opInfoCallback = new LLVMOpInfoCallback(getOpInfo);
            var symbolCallback = new LLVMSymbolLookupCallback(new SymbolLookupClosure(symbolLookUp).Invoke);
            var disasmContext =
                LLVM.CreateDisasm(tripleName, disInfo, tagType, opInfoCallback, symbolCallback)
                    .Wrap()
                    .MakeHandleOwner<DisasmContext, LLVMDisasmContextRef>();
            disasmContext._opInfoCallback = opInfoCallback;
            return disasmContext;
        }

        public static DisasmContext CreateDisasmCPU(string triple, string cpu, IntPtr disInfo, int tagType, OpInfoCallback getOpInfo,
                                            SymbolLookupCallback symbolLookUp)
        {
            var opInfoCallback = new LLVMOpInfoCallback(getOpInfo);
            var symbolCallback = new LLVMSymbolLookupCallback(new SymbolLookupClosure(symbolLookUp).Invoke);
            var disasmContext = 
                LLVM.CreateDisasmCPU(triple, cpu, disInfo, tagType, opInfoCallback, symbolCallback)
                    .Wrap()
                    .MakeHandleOwner<DisasmContext, LLVMDisasmContextRef>();
            disasmContext._opInfoCallback = opInfoCallback;
            disasmContext._symbolLookupCallback = symbolCallback;
            return disasmContext;
        }

        public static DisasmContext CreateDisasmCPUFeatures(string triple, string cpu, string features, IntPtr disInfo,
                                                     int tagType, OpInfoCallback getOpInfo,
                                                     SymbolLookupCallback symbolLookUp)
        {
            var opInfoCallback = new LLVMOpInfoCallback(getOpInfo);
            var symbolCallback = new LLVMSymbolLookupCallback(new SymbolLookupClosure(symbolLookUp).Invoke);
            var disasmContext = LLVM.CreateDisasmCPUFeatures(triple, cpu, features, disInfo, tagType, opInfoCallback, symbolCallback)
                       .Wrap()
                       .MakeHandleOwner<DisasmContext, LLVMDisasmContextRef>();
            disasmContext._opInfoCallback = opInfoCallback;
            disasmContext._symbolLookupCallback = symbolCallback;
            return disasmContext;
        }

        private readonly LLVMDisasmContextRef _instance;
        private bool _disposed;
        private bool _owner;
        private LLVMOpInfoCallback _opInfoCallback;
        private LLVMSymbolLookupCallback _symbolLookupCallback;

        internal DisasmContext(LLVMDisasmContextRef instance)
        {
            this._instance = instance;
        }

        ~DisasmContext()
        {
            this.Dispose(false);
        }

        public int SetDisasmOptions(ulong options) => LLVM.SetDisasmOptions(this.Unwrap(), options);

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

        public unsafe Tuple<string, int> DisasmInstruction(byte[] instructionBytes, ulong programCounter)
        {
            fixed(byte* iptr = &instructionBytes[0])
            {
                var outputBuffer = new byte[1024];
                fixed(byte* optr = &outputBuffer[0])
                {
                    var count = LLVM.DisasmInstruction(this.Unwrap(), new IntPtr(iptr), (ulong)instructionBytes.Length, programCounter, new IntPtr(optr), new size_t(outputBuffer.Length));
                    var text = new UTF8Encoding().GetString(outputBuffer, 0, outputBuffer.Length);
                    return new Tuple<string, int>(text, count.Pointer.ToInt32());
                }
            }
        }
    }
}
