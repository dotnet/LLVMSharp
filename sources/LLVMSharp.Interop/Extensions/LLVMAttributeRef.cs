// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMAttributeRef(IntPtr handle) : IEquatable<LLVMAttributeRef>
{
    public IntPtr Handle = handle;

    public readonly uint Kind => LLVM.GetEnumAttributeKind(this);

    public readonly ulong Value => LLVM.GetEnumAttributeValue(this);

    public static implicit operator LLVMAttributeRef(LLVMOpaqueAttributeRef* value) => new LLVMAttributeRef((IntPtr)value);

    public static implicit operator LLVMOpaqueAttributeRef*(LLVMAttributeRef value) => (LLVMOpaqueAttributeRef*)value.Handle;

    public static bool operator ==(LLVMAttributeRef left, LLVMAttributeRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMAttributeRef left, LLVMAttributeRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMAttributeRef other) && Equals(other);

    public readonly bool Equals(LLVMAttributeRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMAttributeRef)}: {Handle:X}";
}
