// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcObjectLayerRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcObjectLayerRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcObjectLayerRef(LLVMOrcOpaqueObjectLayer* value) => new LLVMOrcObjectLayerRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueObjectLayer*(LLVMOrcObjectLayerRef value) => (LLVMOrcOpaqueObjectLayer*)value.Handle;

    public static bool operator ==(LLVMOrcObjectLayerRef left, LLVMOrcObjectLayerRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcObjectLayerRef left, LLVMOrcObjectLayerRef right) => !(left == right);

    // Takes ownership of ObjBuffer.
    public readonly LLVMErrorRef AddObjectFile(LLVMOrcJITDylibRef JD, LLVMMemoryBufferRef ObjBuffer) => LLVM.OrcObjectLayerAddObjectFile(this, JD, ObjBuffer);

    // Takes ownership of ObjBuffer.
    public readonly LLVMErrorRef AddObjectFileWithRT(LLVMOrcResourceTrackerRef RT, LLVMMemoryBufferRef ObjBuffer) => LLVM.OrcObjectLayerAddObjectFileWithRT(this, RT, ObjBuffer);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.OrcDisposeObjectLayer(this);
            Handle = IntPtr.Zero;
        }
    }

    // Takes ownership of R and ObjBuffer.
    public readonly void Emit(LLVMOrcMaterializationResponsibilityRef R, LLVMMemoryBufferRef ObjBuffer) => LLVM.OrcObjectLayerEmit(this, R, ObjBuffer);

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcObjectLayerRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcObjectLayerRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void RegisterJITEventListener(LLVMJITEventListenerRef Listener) => LLVM.OrcRTDyldObjectLinkingLayerRegisterJITEventListener(this, Listener);

    public override readonly string ToString() => $"{nameof(LLVMOrcObjectLayerRef)}: {Handle:X}";
}
