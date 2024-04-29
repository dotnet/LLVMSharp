// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMMetadataRef(IntPtr handle) : IEquatable<LLVMMetadataRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMMetadataRef(LLVMOpaqueMetadata* value) => new LLVMMetadataRef((IntPtr)value);

    public static implicit operator LLVMOpaqueMetadata*(LLVMMetadataRef value) => (LLVMOpaqueMetadata*)value.Handle;

    public static bool operator ==(LLVMMetadataRef left, LLVMMetadataRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMMetadataRef left, LLVMMetadataRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMMetadataRef other) && Equals(other);

    public readonly bool Equals(LLVMMetadataRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMMetadataRef)}: {Handle:X}";
}
