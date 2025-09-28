// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMPassRef(IntPtr handle) : IEquatable<LLVMPassRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMPassRef(LLVMOpaquePass* value) => new LLVMPassRef((IntPtr)value);

    public static implicit operator LLVMOpaquePass*(LLVMPassRef value) => (LLVMOpaquePass*)value.Handle;

    public static bool operator ==(LLVMPassRef left, LLVMPassRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMPassRef left, LLVMPassRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMPassRef other) && Equals(other);

    public readonly bool Equals(LLVMPassRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMPassRef)}: {Handle:X}";
}
