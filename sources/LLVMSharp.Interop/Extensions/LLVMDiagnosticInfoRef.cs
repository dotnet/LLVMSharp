// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMDiagnosticInfoRef(IntPtr handle) : IEquatable<LLVMDiagnosticInfoRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMDiagnosticInfoRef(LLVMOpaqueDiagnosticInfo* value) => new LLVMDiagnosticInfoRef((IntPtr)value);

    public static implicit operator LLVMOpaqueDiagnosticInfo*(LLVMDiagnosticInfoRef value) => (LLVMOpaqueDiagnosticInfo*)value.Handle;

    public static bool operator ==(LLVMDiagnosticInfoRef left, LLVMDiagnosticInfoRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMDiagnosticInfoRef left, LLVMDiagnosticInfoRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMDiagnosticInfoRef other) && Equals(other);

    public readonly bool Equals(LLVMDiagnosticInfoRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMDiagnosticInfoRef)}: {Handle:X}";
}
