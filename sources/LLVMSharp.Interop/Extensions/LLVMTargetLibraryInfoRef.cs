// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMTargetLibraryInfoRef(IntPtr handle) : IEquatable<LLVMTargetLibraryInfoRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMTargetLibraryInfoRef(LLVMOpaqueTargetLibraryInfotData* value) => new LLVMTargetLibraryInfoRef((IntPtr)value);

    public static implicit operator LLVMOpaqueTargetLibraryInfotData*(LLVMTargetLibraryInfoRef value) => (LLVMOpaqueTargetLibraryInfotData*)value.Handle;

    public static bool operator ==(LLVMTargetLibraryInfoRef left, LLVMTargetLibraryInfoRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMTargetLibraryInfoRef left, LLVMTargetLibraryInfoRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMTargetLibraryInfoRef other) && Equals(other);

    public readonly bool Equals(LLVMTargetLibraryInfoRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMTargetLibraryInfoRef)}: {Handle:X}";
}
