// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMTargetMachineOptionsRef(IntPtr handle) : IEquatable<LLVMTargetMachineOptionsRef>, IDisposable
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMTargetMachineOptionsRef(LLVMOpaqueTargetMachineOptions* value) => new LLVMTargetMachineOptionsRef((IntPtr)value);

    public static implicit operator LLVMOpaqueTargetMachineOptions*(LLVMTargetMachineOptionsRef value) => (LLVMOpaqueTargetMachineOptions*)value.Handle;

    public static bool operator ==(LLVMTargetMachineOptionsRef left, LLVMTargetMachineOptionsRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMTargetMachineOptionsRef left, LLVMTargetMachineOptionsRef right) => !(left == right);

    public static LLVMTargetMachineOptionsRef Create() => LLVM.CreateTargetMachineOptions();

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposeTargetMachineOptions(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMTargetMachineOptionsRef other) && Equals(other);

    public readonly bool Equals(LLVMTargetMachineOptionsRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void SetABI(string abi) => SetABI(abi.AsSpan());

    public readonly void SetABI(ReadOnlySpan<char> abi)
    {
        using var marshaledABI = new MarshaledString(abi);
        LLVM.TargetMachineOptionsSetABI(this, marshaledABI);
    }

    public readonly void SetCodeGenOptLevel(LLVMCodeGenOptLevel level) => LLVM.TargetMachineOptionsSetCodeGenOptLevel(this, level);

    public readonly void SetCodeModel(LLVMCodeModel codeModel) => LLVM.TargetMachineOptionsSetCodeModel(this, codeModel);

    public readonly void SetCPU(string cpu) => SetCPU(cpu.AsSpan());

    public readonly void SetCPU(ReadOnlySpan<char> cpu)
    {
        using var marshaledCPU = new MarshaledString(cpu);
        LLVM.TargetMachineOptionsSetCPU(this, marshaledCPU);
    }

    public readonly void SetFeatures(string features) => SetFeatures(features.AsSpan());

    public readonly void SetFeatures(ReadOnlySpan<char> features)
    {
        using var marshaledFeatures = new MarshaledString(features);
        LLVM.TargetMachineOptionsSetFeatures(this, marshaledFeatures);
    }

    public readonly void SetRelocMode(LLVMRelocMode reloc) => LLVM.TargetMachineOptionsSetRelocMode(this, reloc);

    public override readonly string ToString() => $"{nameof(LLVMTargetMachineOptionsRef)}: {Handle:X}";
}
