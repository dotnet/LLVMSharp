// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct thinlto_code_gen_t(IntPtr handle) : IEquatable<thinlto_code_gen_t>
{
    public IntPtr Handle = handle;

    public static implicit operator thinlto_code_gen_t(LLVMOpaqueThinLTOCodeGenerator* Comdat) => new thinlto_code_gen_t((IntPtr)Comdat);

    public static implicit operator LLVMOpaqueThinLTOCodeGenerator*(thinlto_code_gen_t Comdat) => (LLVMOpaqueThinLTOCodeGenerator*)Comdat.Handle;

    public static bool operator ==(thinlto_code_gen_t left, thinlto_code_gen_t right) => left.Handle == right.Handle;

    public static bool operator !=(thinlto_code_gen_t left, thinlto_code_gen_t right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is thinlto_code_gen_t other) && Equals(other);

    public readonly bool Equals(thinlto_code_gen_t other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(thinlto_code_gen_t)}: {Handle:X}";
}
