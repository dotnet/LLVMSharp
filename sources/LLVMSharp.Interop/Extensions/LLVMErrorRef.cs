// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMErrorRef(IntPtr handle) : IEquatable<LLVMErrorRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMErrorRef(LLVMOpaqueError* value) =>new LLVMErrorRef((IntPtr)value);

    public static implicit operator LLVMOpaqueError*(LLVMErrorRef value) => (LLVMOpaqueError*)value.Handle;

    public static bool operator ==(LLVMErrorRef left, LLVMErrorRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMErrorRef left, LLVMErrorRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMErrorRef other) && Equals(other);

    public readonly bool Equals(LLVMErrorRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMErrorRef)}: {Handle:X}";
}
