// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMPassManagerBuilderRef(IntPtr handle) : IEquatable<LLVMPassManagerBuilderRef>, IDisposable
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMPassManagerBuilderRef(LLVMOpaquePassManagerBuilder* value) => new LLVMPassManagerBuilderRef((IntPtr)value);

    public static implicit operator LLVMOpaquePassManagerBuilder*(LLVMPassManagerBuilderRef value) => (LLVMOpaquePassManagerBuilder*)value.Handle;

    public static bool operator ==(LLVMPassManagerBuilderRef left, LLVMPassManagerBuilderRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMPassManagerBuilderRef left, LLVMPassManagerBuilderRef right) => !(left == right);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.PassManagerBuilderDispose(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMPassManagerBuilderRef other) && Equals(other);

    public readonly bool Equals(LLVMPassManagerBuilderRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void PopulateFunctionPassManager(LLVMPassManagerRef PM) => LLVM.PassManagerBuilderPopulateFunctionPassManager(this, PM);

    public readonly void PopulateModulePassManager(LLVMPassManagerRef PM) => LLVM.PassManagerBuilderPopulateModulePassManager(this, PM);

    public readonly void SetSizeLevel(uint SizeLevel) => LLVM.PassManagerBuilderSetSizeLevel(this, SizeLevel);

    public readonly void SetDisableUnitAtATime(int Value) => LLVM.PassManagerBuilderSetDisableUnitAtATime(this, Value);

    public readonly void SetDisableUnrollLoops(int Value) => LLVM.PassManagerBuilderSetDisableUnrollLoops(this, Value);

    public readonly void SetDisableSimplifyLibCalls(int Value) => LLVM.PassManagerBuilderSetDisableSimplifyLibCalls(this, Value);

    public override readonly string ToString() => $"{nameof(LLVMPassManagerBuilderRef)}: {Handle:X}";

    public readonly void UseInlinerWithThreshold(uint Threshold) => LLVM.PassManagerBuilderUseInlinerWithThreshold(this, Threshold);
}
