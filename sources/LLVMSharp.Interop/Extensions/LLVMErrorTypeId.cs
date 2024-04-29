// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMErrorTypeId(IntPtr handle) : IEquatable<LLVMErrorTypeId>
{
    public IntPtr Handle = handle;

    public static explicit operator LLVMErrorTypeId(void* value) => new LLVMErrorTypeId((IntPtr)value);

    public static implicit operator void*(LLVMErrorTypeId value) => (void*)value.Handle;

    public static bool operator ==(LLVMErrorTypeId left, LLVMErrorTypeId right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMErrorTypeId left, LLVMErrorTypeId right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMErrorTypeId other) && Equals(other);

    public readonly bool Equals(LLVMErrorTypeId other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMErrorTypeId)}: {Handle:X}";
}
