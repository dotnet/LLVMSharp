// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcIRTransformLayerRef(IntPtr handle) : IEquatable<LLVMOrcIRTransformLayerRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcIRTransformLayerRef(LLVMOrcOpaqueIRTransformLayer* value) => new LLVMOrcIRTransformLayerRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueIRTransformLayer*(LLVMOrcIRTransformLayerRef value) => (LLVMOrcOpaqueIRTransformLayer*)value.Handle;

    public static bool operator ==(LLVMOrcIRTransformLayerRef left, LLVMOrcIRTransformLayerRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcIRTransformLayerRef left, LLVMOrcIRTransformLayerRef right) => !(left == right);

    // Takes ownership of MR and TSM.
    public readonly void Emit(LLVMOrcMaterializationResponsibilityRef MR, LLVMOrcThreadSafeModuleRef TSM) => LLVM.OrcIRTransformLayerEmit(this, MR, TSM);

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcIRTransformLayerRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcIRTransformLayerRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void SetTransform(delegate* unmanaged[Cdecl]<void*, LLVMOrcOpaqueThreadSafeModule**, LLVMOrcOpaqueMaterializationResponsibility*, LLVMOpaqueError*> TransformFunction, void* Ctx) => LLVM.OrcIRTransformLayerSetTransform(this, TransformFunction, Ctx);

    public override readonly string ToString() => $"{nameof(LLVMOrcIRTransformLayerRef)}: {Handle:X}";
}
