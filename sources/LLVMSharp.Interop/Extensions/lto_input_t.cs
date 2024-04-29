// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct lto_input_t(IntPtr handle) : IEquatable<lto_input_t>
{
    public IntPtr Handle = handle;

    public static implicit operator lto_input_t(LLVMOpaqueLTOInput* Comdat) => new lto_input_t((IntPtr)Comdat);

    public static implicit operator LLVMOpaqueLTOInput*(lto_input_t Comdat) => (LLVMOpaqueLTOInput*)Comdat.Handle;

    public static bool operator ==(lto_input_t left, lto_input_t right) => left.Handle == right.Handle;

    public static bool operator !=(lto_input_t left, lto_input_t right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is lto_input_t other) && Equals(other);

    public readonly bool Equals(lto_input_t other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(lto_input_t)}: {Handle:X}";
}
