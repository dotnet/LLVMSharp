using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    public unsafe partial struct LLVMExecutionEngineRef : IDisposable, IEquatable<LLVMExecutionEngineRef>
    {
        public LLVMTargetDataRef TargetData => (Pointer != IntPtr.Zero) ? LLVM.GetExecutionEngineTargetData(this) : default;

        public LLVMTargetMachineRef TargetMachine => (Pointer != IntPtr.Zero) ? LLVM.GetExecutionEngineTargetMachine(this) : default;

        public static bool operator ==(LLVMExecutionEngineRef left, LLVMExecutionEngineRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMExecutionEngineRef left, LLVMExecutionEngineRef right) => !(left == right);

        public void AddGlobalMapping(LLVMValueRef Global, IntPtr Addr) => LLVM.AddGlobalMapping(this, Global, (void*)Addr);

        public override bool Equals(object obj) => obj is LLVMExecutionEngineRef other && Equals(other);

        public bool Equals(LLVMExecutionEngineRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();

        public void AddModule(LLVMModuleRef M) => LLVM.AddModule(this, M);

        public void Dispose()
        {
            if (Pointer != IntPtr.Zero)
            {
                LLVM.DisposeExecutionEngine(this);
                Pointer = IntPtr.Zero;
            }
        }

        public LLVMValueRef FindFunction(string Name)
        {
            if (!TryFindFunction(Name, out var Fn))
            {
                throw new ExternalException();
            }

            return Fn;
        }

        public void FreeMachineCodeForFunction(LLVMValueRef F) => LLVM.FreeMachineCodeForFunction(this, F);

        public ulong GetFunctionAddress(string Name)
        {
            using (var marshaledName = new MarshaledString(Name))
            {
                return LLVM.GetFunctionAddress(this, marshaledName);
            }
        }

        public ulong GetGlobalValueAddress(string Name)
        {
            using (var marshaledName = new MarshaledString(Name))
            {
                return LLVM.GetGlobalValueAddress(this, marshaledName);
            }
        }

        public IntPtr GetPointerToGlobal(LLVMValueRef Global) => (IntPtr)LLVM.GetPointerToGlobal(this, Global);

        public TDelegate GetPointerToGlobal<TDelegate>(LLVMValueRef Global)
        {
            var pGlobal = GetPointerToGlobal(Global);
            return Marshal.GetDelegateForFunctionPointer<TDelegate>(pGlobal);
        }

        public LLVMModuleRef RemoveModule(LLVMModuleRef M)
        {
            if (!TryRemoveModule(M, out LLVMModuleRef Mod, out string Error))
            {
                throw new ExternalException(Error);
            }

            return Mod;
        }

        public LLVMGenericValueRef RunFunction(LLVMValueRef F, LLVMGenericValueRef[] Args)
        {
            fixed (LLVMGenericValueRef* pArgs = Args)
            {
                return LLVM.RunFunction(this, F, (uint)Args?.Length, (LLVMOpaqueGenericValue**)pArgs);
            }
        }

        public int RunFunctionAsMain(LLVMValueRef F, uint ArgC, string[] ArgV, string[] EnvP)
        {
            using (var marshaledArgV = new MarshaledStringArray(ArgV))
            using (var marshaledEnvP = new MarshaledStringArray(EnvP))
            {
                var pArgV = stackalloc sbyte*[marshaledArgV.Count];
                marshaledArgV.Fill(pArgV);

                var pEnvP = stackalloc sbyte*[marshaledEnvP.Count];
                marshaledEnvP.Fill(pEnvP);

                return LLVM.RunFunctionAsMain(this, F, ArgC, pArgV, pEnvP);
            }
        }

        public void RunStaticConstructors() => LLVM.RunStaticConstructors(this);

        public void RunStaticDestructors() => LLVM.RunStaticDestructors(this);

        public IntPtr RecompileAndRelinkFunction(LLVMValueRef Fn) => (IntPtr)LLVM.RecompileAndRelinkFunction(this, Fn);

        public bool TryFindFunction(string Name, out LLVMValueRef OutFn)
        {
            using (var marshaledName = new MarshaledString(Name))
            fixed (LLVMValueRef* pOutFn = &OutFn)
            {
                return LLVM.FindFunction(this, marshaledName, (LLVMOpaqueValue**)pOutFn) == 0;
            }
        }

        public bool TryRemoveModule(LLVMModuleRef M, out LLVMModuleRef OutMod, out string OutError)
        {
            fixed (LLVMModuleRef* pOutMod = &OutMod)
            {
                sbyte* pError;
                var result = LLVM.RemoveModule(this, M, (LLVMOpaqueModule**)pOutMod, &pError);

                if (pError is null)
                {
                    OutError = string.Empty;
                }
                else
                {
                    var span = new ReadOnlySpan<byte>(pError, int.MaxValue);
                    OutError = span.Slice(0, span.IndexOf((byte)'\0')).AsString();
                }

                return result == 0;
            }
        }
    }
}
