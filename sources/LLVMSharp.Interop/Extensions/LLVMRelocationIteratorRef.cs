// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMRelocationIteratorRef(IntPtr handle) : IEquatable<LLVMRelocationIteratorRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMRelocationIteratorRef(LLVMOpaqueRelocationIterator* value) => new LLVMRelocationIteratorRef((IntPtr)value);

    public static implicit operator LLVMOpaqueRelocationIterator*(LLVMRelocationIteratorRef value) => (LLVMOpaqueRelocationIterator*)value.Handle;

    public static bool operator ==(LLVMRelocationIteratorRef left, LLVMRelocationIteratorRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMRelocationIteratorRef left, LLVMRelocationIteratorRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMRelocationIteratorRef other) && Equals(other);

    public readonly bool Equals(LLVMRelocationIteratorRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMRelocationIteratorRef)}: {Handle:X}";
}
