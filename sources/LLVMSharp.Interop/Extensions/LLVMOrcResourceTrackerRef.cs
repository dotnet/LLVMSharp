// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcResourceTrackerRef(IntPtr handle) : IEquatable<LLVMOrcResourceTrackerRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcResourceTrackerRef(LLVMOrcOpaqueResourceTracker* value) => new LLVMOrcResourceTrackerRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueResourceTracker*(LLVMOrcResourceTrackerRef value) => (LLVMOrcOpaqueResourceTracker*)value.Handle;

    public static bool operator ==(LLVMOrcResourceTrackerRef left, LLVMOrcResourceTrackerRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcResourceTrackerRef left, LLVMOrcResourceTrackerRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcResourceTrackerRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcResourceTrackerRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void Release() => LLVM.OrcReleaseResourceTracker(this);

    public readonly LLVMErrorRef Remove() => LLVM.OrcResourceTrackerRemove(this);

    public readonly void TransferTo(LLVMOrcResourceTrackerRef DstRT) => LLVM.OrcResourceTrackerTransferTo(this, DstRT);

    public override readonly string ToString() => $"{nameof(LLVMOrcResourceTrackerRef)}: {Handle:X}";
}
