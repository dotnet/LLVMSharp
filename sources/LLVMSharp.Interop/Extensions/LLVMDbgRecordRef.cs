// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMDbgRecordRef(IntPtr handle) : IEquatable<LLVMDbgRecordRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMDbgRecordRef(LLVMOpaqueDbgRecord* Comdat) => new LLVMDbgRecordRef((IntPtr)Comdat);

    public static implicit operator LLVMOpaqueDbgRecord*(LLVMDbgRecordRef Comdat) => (LLVMOpaqueDbgRecord*)Comdat.Handle;

    public static bool operator ==(LLVMDbgRecordRef left, LLVMDbgRecordRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMDbgRecordRef left, LLVMDbgRecordRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMDbgRecordRef other) && Equals(other);

    public readonly bool Equals(LLVMDbgRecordRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMDbgRecordRef)}: {Handle:X}";
}
