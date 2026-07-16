// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcLookupStateRef(IntPtr handle) : IEquatable<LLVMOrcLookupStateRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcLookupStateRef(LLVMOrcOpaqueLookupState* value) => new LLVMOrcLookupStateRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueLookupState*(LLVMOrcLookupStateRef value) => (LLVMOrcOpaqueLookupState*)value.Handle;

    public static bool operator ==(LLVMOrcLookupStateRef left, LLVMOrcLookupStateRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcLookupStateRef left, LLVMOrcLookupStateRef right) => !(left == right);

    public readonly void ContinueLookup(LLVMErrorRef Err) => LLVM.OrcLookupStateContinueLookup(this, Err);

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcLookupStateRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcLookupStateRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMOrcLookupStateRef)}: {Handle:X}";
}
