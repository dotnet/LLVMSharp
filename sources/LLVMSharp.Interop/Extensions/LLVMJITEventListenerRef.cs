// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMJITEventListenerRef(IntPtr handle) : IEquatable<LLVMJITEventListenerRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMJITEventListenerRef(LLVMOpaqueJITEventListener* value) => new LLVMJITEventListenerRef((IntPtr)value);

    public static implicit operator LLVMOpaqueJITEventListener*(LLVMJITEventListenerRef value) => (LLVMOpaqueJITEventListener*)value.Handle;

    public static bool operator ==(LLVMJITEventListenerRef left, LLVMJITEventListenerRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMJITEventListenerRef left, LLVMJITEventListenerRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMJITEventListenerRef other) && Equals(other);

    public readonly bool Equals(LLVMJITEventListenerRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMJITEventListenerRef)}: {Handle:X}";
}
