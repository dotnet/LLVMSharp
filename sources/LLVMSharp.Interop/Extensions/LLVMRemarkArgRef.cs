// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMRemarkArgRef(IntPtr handle) : IEquatable<LLVMRemarkArgRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMRemarkArgRef(LLVMRemarkOpaqueArg* value) => new LLVMRemarkArgRef((IntPtr)value);

    public static implicit operator LLVMRemarkOpaqueArg*(LLVMRemarkArgRef value) => (LLVMRemarkOpaqueArg*)value.Handle;

    public static bool operator ==(LLVMRemarkArgRef left, LLVMRemarkArgRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMRemarkArgRef left, LLVMRemarkArgRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMRemarkArgRef other) && Equals(other);

    public readonly bool Equals(LLVMRemarkArgRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMRemarkArgRef)}: {Handle:X}";
}
