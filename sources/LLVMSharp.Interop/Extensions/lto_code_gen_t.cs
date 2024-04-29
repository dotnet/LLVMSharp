// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct lto_code_gen_t(IntPtr handle) : IEquatable<lto_code_gen_t>
{
    public IntPtr Handle = handle;

    public static implicit operator lto_code_gen_t(LLVMOpaqueLTOCodeGenerator* Comdat) => new lto_code_gen_t((IntPtr)Comdat);

    public static implicit operator LLVMOpaqueLTOCodeGenerator*(lto_code_gen_t Comdat) => (LLVMOpaqueLTOCodeGenerator*)Comdat.Handle;

    public static bool operator ==(lto_code_gen_t left, lto_code_gen_t right) => left.Handle == right.Handle;

    public static bool operator !=(lto_code_gen_t left, lto_code_gen_t right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is lto_code_gen_t other) && Equals(other);

    public readonly bool Equals(lto_code_gen_t other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(lto_code_gen_t)}: {Handle:X}";
}
