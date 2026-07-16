// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcSymbolStringPoolRef(IntPtr handle) : IEquatable<LLVMOrcSymbolStringPoolRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcSymbolStringPoolRef(LLVMOrcOpaqueSymbolStringPool* value) => new LLVMOrcSymbolStringPoolRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueSymbolStringPool*(LLVMOrcSymbolStringPoolRef value) => (LLVMOrcOpaqueSymbolStringPool*)value.Handle;

    public static bool operator ==(LLVMOrcSymbolStringPoolRef left, LLVMOrcSymbolStringPoolRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcSymbolStringPoolRef left, LLVMOrcSymbolStringPoolRef right) => !(left == right);

    public readonly void ClearDeadEntries() => LLVM.OrcSymbolStringPoolClearDeadEntries(this);

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcSymbolStringPoolRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcSymbolStringPoolRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMOrcSymbolStringPoolRef)}: {Handle:X}";
}
