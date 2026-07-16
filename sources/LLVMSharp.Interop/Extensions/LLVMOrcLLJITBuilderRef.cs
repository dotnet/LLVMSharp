// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcLLJITBuilderRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcLLJITBuilderRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcLLJITBuilderRef(LLVMOrcOpaqueLLJITBuilder* value) => new LLVMOrcLLJITBuilderRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueLLJITBuilder*(LLVMOrcLLJITBuilderRef value) => (LLVMOrcOpaqueLLJITBuilder*)value.Handle;

    public static bool operator ==(LLVMOrcLLJITBuilderRef left, LLVMOrcLLJITBuilderRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcLLJITBuilderRef left, LLVMOrcLLJITBuilderRef right) => !(left == right);

    public static LLVMOrcLLJITBuilderRef Create() => LLVM.OrcCreateLLJITBuilder();

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.OrcDisposeLLJITBuilder(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcLLJITBuilderRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcLLJITBuilderRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    // Takes ownership of JTMB.
    public readonly void SetJITTargetMachineBuilder(LLVMOrcJITTargetMachineBuilderRef JTMB) => LLVM.OrcLLJITBuilderSetJITTargetMachineBuilder(this, JTMB);

    public readonly void SetObjectLinkingLayerCreator(delegate* unmanaged[Cdecl]<void*, LLVMOrcOpaqueExecutionSession*, sbyte*, LLVMOrcOpaqueObjectLayer*> F, void* Ctx) => LLVM.OrcLLJITBuilderSetObjectLinkingLayerCreator(this, F, Ctx);

    public override readonly string ToString() => $"{nameof(LLVMOrcLLJITBuilderRef)}: {Handle:X}";
}
