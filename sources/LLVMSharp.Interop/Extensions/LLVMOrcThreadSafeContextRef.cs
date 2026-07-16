// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcThreadSafeContextRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcThreadSafeContextRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcThreadSafeContextRef(LLVMOrcOpaqueThreadSafeContext* value) => new LLVMOrcThreadSafeContextRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueThreadSafeContext*(LLVMOrcThreadSafeContextRef value) => (LLVMOrcOpaqueThreadSafeContext*)value.Handle;

    public static bool operator ==(LLVMOrcThreadSafeContextRef left, LLVMOrcThreadSafeContextRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcThreadSafeContextRef left, LLVMOrcThreadSafeContextRef right) => !(left == right);

    public static LLVMOrcThreadSafeContextRef Create() => LLVM.OrcCreateNewThreadSafeContext();

    public static LLVMOrcThreadSafeContextRef CreateFromContext(LLVMContextRef Ctx) => LLVM.OrcCreateNewThreadSafeContextFromLLVMContext(Ctx);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.OrcDisposeThreadSafeContext(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcThreadSafeContextRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcThreadSafeContextRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMOrcThreadSafeContextRef)}: {Handle:X}";
}
