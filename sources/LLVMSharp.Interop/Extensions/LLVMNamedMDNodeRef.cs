// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMNamedMDNodeRef(IntPtr handle) : IEquatable<LLVMNamedMDNodeRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMNamedMDNodeRef(LLVMOpaqueNamedMDNode* value) => new LLVMNamedMDNodeRef((IntPtr)value);

    public static implicit operator LLVMOpaqueNamedMDNode*(LLVMNamedMDNodeRef value) => (LLVMOpaqueNamedMDNode*)value.Handle;

    public static bool operator ==(LLVMNamedMDNodeRef left, LLVMNamedMDNodeRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMNamedMDNodeRef left, LLVMNamedMDNodeRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMNamedMDNodeRef other) && Equals(other);

    public readonly bool Equals(LLVMNamedMDNodeRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMNamedMDNodeRef)}: {Handle:X}";
}
