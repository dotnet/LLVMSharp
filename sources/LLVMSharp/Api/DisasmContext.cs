namespace LLVMSharp.API
{
    using System;
    using System.Text;
    using Utilities;

    public sealed class DisasmContext : IDisposableWrapper<LLVMDisasmContextRef>, IDisposable
    {
        LLVMDisasmContextRef IWrapper<LLVMDisasmContextRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMDisasmContextRef>.MakeHandleOwner() => this._owner = true;

        public static DisasmContext CreateDisasm(string tripleName, IntPtr disInfo, int tagType, LLVMOpInfoCallback opInfoCallback,
                                           LLVMSymbolLookupCallback symbolCallback)
        {
            var disasmContext =
                LLVM.CreateDisasm(tripleName, disInfo, tagType, opInfoCallback, symbolCallback)
                    .Wrap()
                    .MakeHandleOwner<DisasmContext, LLVMDisasmContextRef>();
            disasmContext._opInfoCallback = opInfoCallback;
            return disasmContext;
        }

        public static DisasmContext CreateDisasmCPU(string triple, string cpu, IntPtr disInfo, int tagType, LLVMOpInfoCallback opInfoCallback,
                                            LLVMSymbolLookupCallback symbolCallback)
        {
            var disasmContext = 
                LLVM.CreateDisasmCPU(triple, cpu, disInfo, tagType, opInfoCallback, symbolCallback)
                    .Wrap()
                    .MakeHandleOwner<DisasmContext, LLVMDisasmContextRef>();
            disasmContext._opInfoCallback = opInfoCallback;
            disasmContext._symbolLookupCallback = symbolCallback;
            return disasmContext;
        }

        public static DisasmContext CreateDisasmCPUFeatures(string triple, string cpu, string features, IntPtr disInfo,
                                                     int tagType, LLVMOpInfoCallback opInfoCallback,
                                                     LLVMSymbolLookupCallback symbolCallback)
        {
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
            var outputBuffer = new byte[1024];
            var count = LLVM.DisasmInstruction(this.Unwrap(), out instructionBytes[0], (ulong)instructionBytes.Length, programCounter, out outputBuffer[0], (IntPtr)(outputBuffer.Length));
            var text = new UTF8Encoding().GetString(outputBuffer, 0, outputBuffer.Length);
            return new Tuple<string, int>(text, count.ToInt32());
        }
    }
}
