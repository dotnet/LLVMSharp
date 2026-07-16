// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcSymbolStringPoolEntryRef(IntPtr handle) : IEquatable<LLVMOrcSymbolStringPoolEntryRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcSymbolStringPoolEntryRef(LLVMOrcOpaqueSymbolStringPoolEntry* value) => new LLVMOrcSymbolStringPoolEntryRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueSymbolStringPoolEntry*(LLVMOrcSymbolStringPoolEntryRef value) => (LLVMOrcOpaqueSymbolStringPoolEntry*)value.Handle;

    public static bool operator ==(LLVMOrcSymbolStringPoolEntryRef left, LLVMOrcSymbolStringPoolEntryRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcSymbolStringPoolEntryRef left, LLVMOrcSymbolStringPoolEntryRef right) => !(left == right);

    // The returned c-string is owned by the pool entry and remains valid until the entry is released.
    public readonly string Str => (Handle != IntPtr.Zero) ? SpanExtensions.AsString(LLVM.OrcSymbolStringPoolEntryStr(this)) : string.Empty;

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcSymbolStringPoolEntryRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcSymbolStringPoolEntryRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void Release() => LLVM.OrcReleaseSymbolStringPoolEntry(this);

    public readonly void Retain() => LLVM.OrcRetainSymbolStringPoolEntry(this);

    public override readonly string ToString() => $"{nameof(LLVMOrcSymbolStringPoolEntryRef)}: {Handle:X}";
}
