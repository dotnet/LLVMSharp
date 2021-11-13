// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMExecutionEngineRef : IDisposable, IEquatable<LLVMExecutionEngineRef>
    {
        public IntPtr Handle;

        public LLVMExecutionEngineRef(IntPtr handle)
        {
            Handle = handle;
        }

        public LLVMTargetDataRef TargetData => (Handle != IntPtr.Zero) ? LLVM.GetExecutionEngineTargetData(this) : default;

        public LLVMTargetMachineRef TargetMachine => (Handle != IntPtr.Zero) ? LLVM.GetExecutionEngineTargetMachine(this) : default;

        public static implicit operator LLVMExecutionEngineRef(LLVMOpaqueExecutionEngine* value) => new LLVMExecutionEngineRef((IntPtr)value);

        public static implicit operator LLVMOpaqueExecutionEngine*(LLVMExecutionEngineRef value) => (LLVMOpaqueExecutionEngine*)value.Handle;

        public static bool operator ==(LLVMExecutionEngineRef left, LLVMExecutionEngineRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMExecutionEngineRef left, LLVMExecutionEngineRef right) => !(left == right);

        public void AddGlobalMapping(LLVMValueRef Global, IntPtr Addr) => LLVM.AddGlobalMapping(this, Global, (void*)Addr);

        public void AddModule(LLVMModuleRef M) => LLVM.AddModule(this, M);

        public void Dispose()
        {
            if (Handle != IntPtr.Zero)
            {
                LLVM.DisposeExecutionEngine(this);
                Handle = IntPtr.Zero;
            }
        }

        public override bool Equals(object obj) => (obj is LLVMExecutionEngineRef other) && Equals(other);

        public bool Equals(LLVMExecutionEngineRef other) => this == other;

        public LLVMValueRef FindFunction(string Name) => FindFunction(Name.AsSpan());

        public LLVMValueRef FindFunction(ReadOnlySpan<char> Name)
        {
            if (!TryFindFunction(Name, out var Fn))
            {
                throw new ExternalException();
            }

            return Fn;
        }

        public void FreeMachineCodeForFunction(LLVMValueRef F) => LLVM.FreeMachineCodeForFunction(this, F);

        public ulong GetFunctionAddress(string Name) => GetFunctionAddress(Name.AsSpan());

        public ulong GetFunctionAddress(ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.GetFunctionAddress(this, marshaledName);
        }

        public ulong GetGlobalValueAddress(string Name) => GetGlobalValueAddress(Name.AsSpan()); 

        public ulong GetGlobalValueAddress(ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.GetGlobalValueAddress(this, marshaledName);
        }

        public override int GetHashCode() => Handle.GetHashCode();

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

        public LLVMGenericValueRef RunFunction(LLVMValueRef F, LLVMGenericValueRef[] Args) => RunFunction(F, Args.AsSpan());

        public LLVMGenericValueRef RunFunction(LLVMValueRef F, ReadOnlySpan<LLVMGenericValueRef> Args)
        {
            fixed (LLVMGenericValueRef* pArgs = Args)
            {
                return LLVM.RunFunction(this, F, (uint)Args.Length, (LLVMOpaqueGenericValue**)pArgs);
            }
        }

        public int RunFunctionAsMain(LLVMValueRef F, uint ArgC, string[] ArgV, string[] EnvP) => RunFunctionAsMain(F, ArgC, ArgV.AsSpan(), EnvP.AsSpan());

        public int RunFunctionAsMain(LLVMValueRef F, uint ArgC, ReadOnlySpan<string> ArgV, ReadOnlySpan<string> EnvP)
        {
            using var marshaledArgV = new MarshaledStringArray(ArgV);
            using var marshaledEnvP = new MarshaledStringArray(EnvP);

            var pArgV = stackalloc sbyte*[marshaledArgV.Count];
            marshaledArgV.Fill(pArgV);

            var pEnvP = stackalloc sbyte*[marshaledEnvP.Count];
            marshaledEnvP.Fill(pEnvP);

            return LLVM.RunFunctionAsMain(this, F, ArgC, pArgV, pEnvP);
        }

        public void RunStaticConstructors() => LLVM.RunStaticConstructors(this);

        public void RunStaticDestructors() => LLVM.RunStaticDestructors(this);

        public IntPtr RecompileAndRelinkFunction(LLVMValueRef Fn) => (IntPtr)LLVM.RecompileAndRelinkFunction(this, Fn);

        public override string ToString() => $"{nameof(LLVMExecutionEngineRef)}: {Handle:X}";

        public bool TryFindFunction(string Name, out LLVMValueRef OutFn) => TryFindFunction(Name.AsSpan(), out OutFn);

        public bool TryFindFunction(ReadOnlySpan<char> Name, out LLVMValueRef OutFn)
        {
            fixed (LLVMValueRef* pOutFn = &OutFn)
            {
                using var marshaledName = new MarshaledString(Name);
                return LLVM.FindFunction(this, marshaledName, (LLVMOpaqueValue**)pOutFn) == 0;
            }
        }

        public bool TryRemoveModule(LLVMModuleRef M, out LLVMModuleRef OutMod, out string OutError)
        {
            fixed (LLVMModuleRef* pOutMod = &OutMod)
            {
                sbyte* pError = null;
                var result = LLVM.RemoveModule(this, M, (LLVMOpaqueModule**)pOutMod, &pError);

                if (pError == null)
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
