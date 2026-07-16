// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcJITDylibRef(IntPtr handle) : IEquatable<LLVMOrcJITDylibRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcJITDylibRef(LLVMOrcOpaqueJITDylib* value) => new LLVMOrcJITDylibRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueJITDylib*(LLVMOrcJITDylibRef value) => (LLVMOrcOpaqueJITDylib*)value.Handle;

    public static bool operator ==(LLVMOrcJITDylibRef left, LLVMOrcJITDylibRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcJITDylibRef left, LLVMOrcJITDylibRef right) => !(left == right);

    // Takes ownership of DG.
    public readonly void AddGenerator(LLVMOrcDefinitionGeneratorRef DG) => LLVM.OrcJITDylibAddGenerator(this, DG);

    public readonly LLVMErrorRef Clear() => LLVM.OrcJITDylibClear(this);

    public readonly LLVMOrcResourceTrackerRef CreateResourceTracker() => LLVM.OrcJITDylibCreateResourceTracker(this);

    // Takes ownership of MU.
    public readonly LLVMErrorRef Define(LLVMOrcMaterializationUnitRef MU) => LLVM.OrcJITDylibDefine(this, MU);

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcJITDylibRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcJITDylibRef other) => this == other;

    public readonly LLVMOrcResourceTrackerRef GetDefaultResourceTracker() => LLVM.OrcJITDylibGetDefaultResourceTracker(this);

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMOrcJITDylibRef)}: {Handle:X}";
}
