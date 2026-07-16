// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcThreadSafeModuleRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcThreadSafeModuleRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcThreadSafeModuleRef(LLVMOrcOpaqueThreadSafeModule* value) => new LLVMOrcThreadSafeModuleRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueThreadSafeModule*(LLVMOrcThreadSafeModuleRef value) => (LLVMOrcOpaqueThreadSafeModule*)value.Handle;

    public static bool operator ==(LLVMOrcThreadSafeModuleRef left, LLVMOrcThreadSafeModuleRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcThreadSafeModuleRef left, LLVMOrcThreadSafeModuleRef right) => !(left == right);

    // Takes ownership of M.
    public static LLVMOrcThreadSafeModuleRef Create(LLVMModuleRef M, LLVMOrcThreadSafeContextRef TSCtx) => LLVM.OrcCreateNewThreadSafeModule(M, TSCtx);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.OrcDisposeThreadSafeModule(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcThreadSafeModuleRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcThreadSafeModuleRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly LLVMErrorRef WithModuleDo(delegate* unmanaged[Cdecl]<void*, LLVMOpaqueModule*, LLVMOpaqueError*> F, void* Ctx) => LLVM.OrcThreadSafeModuleWithModuleDo(this, F, Ctx);

    public override readonly string ToString() => $"{nameof(LLVMOrcThreadSafeModuleRef)}: {Handle:X}";
}
