// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMRemarkParserRef(IntPtr handle) : IEquatable<LLVMRemarkParserRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMRemarkParserRef(LLVMRemarkOpaqueParser* value) => new LLVMRemarkParserRef((IntPtr)value);

    public static implicit operator LLVMRemarkOpaqueParser*(LLVMRemarkParserRef value) => (LLVMRemarkOpaqueParser*)value.Handle;

    public static bool operator ==(LLVMRemarkParserRef left, LLVMRemarkParserRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMRemarkParserRef left, LLVMRemarkParserRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMRemarkParserRef other) && Equals(other);

    public readonly bool Equals(LLVMRemarkParserRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMRemarkParserRef)}: {Handle:X}";
}
