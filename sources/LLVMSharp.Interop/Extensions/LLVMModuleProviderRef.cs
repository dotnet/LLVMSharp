// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMModuleProviderRef(IntPtr handle) : IEquatable<LLVMModuleProviderRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMModuleProviderRef(LLVMOpaqueModuleProvider* value) => new LLVMModuleProviderRef((IntPtr)value);

    public static implicit operator LLVMOpaqueModuleProvider*(LLVMModuleProviderRef value) => (LLVMOpaqueModuleProvider*)value.Handle;

    public static bool operator ==(LLVMModuleProviderRef left, LLVMModuleProviderRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMModuleProviderRef left, LLVMModuleProviderRef right) => !(left == right);

    public readonly LLVMPassManagerRef CreateFunctionPassManager() => LLVM.CreateFunctionPassManager(this);

    public override readonly bool Equals(object? obj) => (obj is LLVMModuleProviderRef other) && Equals(other);

    public readonly bool Equals(LLVMModuleProviderRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMModuleProviderRef)}: {Handle:X}";
}
