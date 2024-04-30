// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMPassManagerRef(IntPtr handle) : IDisposable, IEquatable<LLVMPassManagerRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMPassManagerRef(LLVMOpaquePassManager* value) => new LLVMPassManagerRef((IntPtr)value);

    public static implicit operator LLVMOpaquePassManager*(LLVMPassManagerRef value) => (LLVMOpaquePassManager*)value.Handle;

    public static bool operator ==(LLVMPassManagerRef left, LLVMPassManagerRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMPassManagerRef left, LLVMPassManagerRef right) => !(left == right);

    public static LLVMPassManagerRef Create() => LLVM.CreatePassManager();

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposePassManager(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMPassManagerRef other) && Equals(other);

    public readonly bool Equals(LLVMPassManagerRef other) => this == other;

    public readonly bool FinalizeFunctionPassManager() => LLVM.FinalizeFunctionPassManager(this) != 0;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly bool InitializeFunctionPassManager() => LLVM.InitializeFunctionPassManager(this) != 0;

    public readonly bool Run(LLVMModuleRef M) => LLVM.RunPassManager(this, M) != 0;

    public readonly bool RunFunctionPassManager(LLVMValueRef F) => LLVM.RunFunctionPassManager(this, F) != 0;

    public override readonly string ToString() => $"{nameof(LLVMPassManagerRef)}: {Handle:X}";
}
