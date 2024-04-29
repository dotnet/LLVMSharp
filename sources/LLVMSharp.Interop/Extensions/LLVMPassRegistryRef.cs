// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMPassRegistryRef(IntPtr handle) : IEquatable<LLVMPassRegistryRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMPassRegistryRef(LLVMOpaquePassRegistry* value) => new LLVMPassRegistryRef((IntPtr)value);

    public static implicit operator LLVMOpaquePassRegistry*(LLVMPassRegistryRef value) => (LLVMOpaquePassRegistry*)value.Handle;

    public static bool operator ==(LLVMPassRegistryRef left, LLVMPassRegistryRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMPassRegistryRef left, LLVMPassRegistryRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMPassRegistryRef other) && Equals(other);

    public readonly bool Equals(LLVMPassRegistryRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMPassRegistryRef)}: {Handle:X}";
}
