// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcObjectTransformLayerRef(IntPtr handle) : IEquatable<LLVMOrcObjectTransformLayerRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcObjectTransformLayerRef(LLVMOrcOpaqueObjectTransformLayer* value) => new LLVMOrcObjectTransformLayerRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueObjectTransformLayer*(LLVMOrcObjectTransformLayerRef value) => (LLVMOrcOpaqueObjectTransformLayer*)value.Handle;

    public static bool operator ==(LLVMOrcObjectTransformLayerRef left, LLVMOrcObjectTransformLayerRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcObjectTransformLayerRef left, LLVMOrcObjectTransformLayerRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcObjectTransformLayerRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcObjectTransformLayerRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void SetTransform(delegate* unmanaged[Cdecl]<void*, LLVMOpaqueMemoryBuffer**, LLVMOpaqueError*> TransformFunction, void* Ctx) => LLVM.OrcObjectTransformLayerSetTransform(this, TransformFunction, Ctx);

    public override readonly string ToString() => $"{nameof(LLVMOrcObjectTransformLayerRef)}: {Handle:X}";
}
