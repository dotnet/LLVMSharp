// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMMemoryBufferRef(IntPtr handle) : IEquatable<LLVMMemoryBufferRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMMemoryBufferRef(LLVMOpaqueMemoryBuffer* MemoryBuffer) => new LLVMMemoryBufferRef((IntPtr)MemoryBuffer);

    public static implicit operator LLVMOpaqueMemoryBuffer*(LLVMMemoryBufferRef MemoryBuffer) => (LLVMOpaqueMemoryBuffer*)MemoryBuffer.Handle;

    public static bool operator ==(LLVMMemoryBufferRef left, LLVMMemoryBufferRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMMemoryBufferRef left, LLVMMemoryBufferRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMMemoryBufferRef other) && Equals(other);

    public readonly bool Equals(LLVMMemoryBufferRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMMemoryBufferRef)}: {Handle:X}";
}
