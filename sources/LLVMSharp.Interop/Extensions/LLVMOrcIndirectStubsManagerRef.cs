// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcIndirectStubsManagerRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcIndirectStubsManagerRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcIndirectStubsManagerRef(LLVMOrcOpaqueIndirectStubsManager* value) => new LLVMOrcIndirectStubsManagerRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueIndirectStubsManager*(LLVMOrcIndirectStubsManagerRef value) => (LLVMOrcOpaqueIndirectStubsManager*)value.Handle;

    public static bool operator ==(LLVMOrcIndirectStubsManagerRef left, LLVMOrcIndirectStubsManagerRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcIndirectStubsManagerRef left, LLVMOrcIndirectStubsManagerRef right) => !(left == right);

    public static LLVMOrcIndirectStubsManagerRef CreateLocal(string TargetTriple) => CreateLocal(TargetTriple.AsSpan());

    public static LLVMOrcIndirectStubsManagerRef CreateLocal(ReadOnlySpan<char> TargetTriple)
    {
        using var marshaledTriple = new MarshaledString(TargetTriple);
        return LLVM.OrcCreateLocalIndirectStubsManager(marshaledTriple);
    }

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.OrcDisposeIndirectStubsManager(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcIndirectStubsManagerRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcIndirectStubsManagerRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMOrcIndirectStubsManagerRef)}: {Handle:X}";
}
