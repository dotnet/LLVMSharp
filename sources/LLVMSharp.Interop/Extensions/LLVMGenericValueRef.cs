// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMGenericValueRef(IntPtr handle) : IEquatable<LLVMGenericValueRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMGenericValueRef(LLVMOpaqueGenericValue* GenericValue) => new LLVMGenericValueRef((IntPtr)GenericValue);

    public static implicit operator LLVMOpaqueGenericValue*(LLVMGenericValueRef GenericValue) => (LLVMOpaqueGenericValue*)GenericValue.Handle;

    public static bool operator ==(LLVMGenericValueRef left, LLVMGenericValueRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMGenericValueRef left, LLVMGenericValueRef right) => !(left == right);

    public static LLVMGenericValueRef CreateInt(LLVMTypeRef Ty, ulong N, bool IsSigned) => LLVM.CreateGenericValueOfInt(Ty, N, IsSigned ? 1 : 0);

    public static LLVMGenericValueRef CreateFloat(LLVMTypeRef Ty, double N) => LLVM.CreateGenericValueOfFloat(Ty, N);

    public override readonly bool Equals(object? obj) => (obj is LLVMGenericValueRef other) && Equals(other);

    public readonly bool Equals(LLVMGenericValueRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMGenericValueRef)}: {Handle:X}";
}
