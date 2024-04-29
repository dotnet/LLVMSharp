// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMDisasmContextRef(IntPtr handle) : IEquatable<LLVMDisasmContextRef>
{
    public IntPtr Handle = handle;

    public static explicit operator LLVMDisasmContextRef(void* value) => new LLVMDisasmContextRef((IntPtr)value);

    public static implicit operator void*(LLVMDisasmContextRef value) => (void*)value.Handle;

    public static bool operator ==(LLVMDisasmContextRef left, LLVMDisasmContextRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMDisasmContextRef left, LLVMDisasmContextRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMDisasmContextRef other) && Equals(other);

    public readonly bool Equals(LLVMDisasmContextRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMDisasmContextRef)}: {Handle:X}";
}
