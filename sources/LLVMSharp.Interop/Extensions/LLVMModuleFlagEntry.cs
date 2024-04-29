// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMModuleFlagEntry(IntPtr handle) : IEquatable<LLVMModuleFlagEntry>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMModuleFlagEntry(LLVMOpaqueModuleFlagEntry* Comdat) => new LLVMModuleFlagEntry((IntPtr)Comdat);

    public static implicit operator LLVMOpaqueModuleFlagEntry*(LLVMModuleFlagEntry Comdat) => (LLVMOpaqueModuleFlagEntry*)Comdat.Handle;

    public static bool operator ==(LLVMModuleFlagEntry left, LLVMModuleFlagEntry right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMModuleFlagEntry left, LLVMModuleFlagEntry right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMModuleFlagEntry other) && Equals(other);

    public readonly bool Equals(LLVMModuleFlagEntry other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMModuleFlagEntry)}: {Handle:X}";
}
