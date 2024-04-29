// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMRemarkStringRef(IntPtr handle) : IEquatable<LLVMRemarkStringRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMRemarkStringRef(LLVMRemarkOpaqueString* value) => new LLVMRemarkStringRef((IntPtr)value);

    public static implicit operator LLVMRemarkOpaqueString*(LLVMRemarkStringRef value) => (LLVMRemarkOpaqueString*)value.Handle;

    public static bool operator ==(LLVMRemarkStringRef left, LLVMRemarkStringRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMRemarkStringRef left, LLVMRemarkStringRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMRemarkStringRef other) && Equals(other);

    public readonly bool Equals(LLVMRemarkStringRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMRemarkStringRef)}: {Handle:X}";
}
