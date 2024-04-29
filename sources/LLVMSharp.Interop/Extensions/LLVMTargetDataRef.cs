// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMTargetDataRef(IntPtr handle) : IEquatable<LLVMTargetDataRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMTargetDataRef(LLVMOpaqueTargetData* TargetData) => new LLVMTargetDataRef((IntPtr)TargetData);

    public static implicit operator LLVMOpaqueTargetData*(LLVMTargetDataRef TargetData) => (LLVMOpaqueTargetData*)TargetData.Handle;

    public static bool operator ==(LLVMTargetDataRef left, LLVMTargetDataRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMTargetDataRef left, LLVMTargetDataRef right) => !(left == right);

    public static LLVMTargetDataRef FromStringRepresentation(ReadOnlySpan<char> stringRep) => LLVM.CreateTargetData(new MarshaledString(stringRep));

    public override readonly bool Equals(object? obj) => (obj is LLVMTargetDataRef other) && Equals(other);

    public readonly bool Equals(LLVMTargetDataRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly ulong OffsetOfElement(LLVMTypeRef type, uint element) => LLVM.OffsetOfElement(this, type, element);

    public readonly ulong ElementAtOffset(LLVMTypeRef type, ulong offset) => LLVM.ElementAtOffset(this, type, offset);

    public readonly ulong SizeOfTypeInBits(LLVMTypeRef type) => LLVM.SizeOfTypeInBits(this, type);

    public readonly ulong StoreSizeOfType(LLVMTypeRef type) => LLVM.StoreSizeOfType(this, type);

    public readonly ulong ABISizeOfType(LLVMTypeRef type) => LLVM.ABISizeOfType(this, type);

    public readonly uint ABIAlignmentOfType(LLVMTypeRef type) => LLVM.ABIAlignmentOfType(this, type);

    public readonly uint CallFrameAlignmentOfType(LLVMTypeRef type) => LLVM.CallFrameAlignmentOfType(this, type);

    public readonly uint PreferredAlignmentOfType(LLVMTypeRef type) => LLVM.PreferredAlignmentOfType(this, type);

    public readonly uint PreferredAlignmentOfGlobal(LLVMValueRef globalVar) => LLVM.PreferredAlignmentOfGlobal(this, globalVar);

    public override readonly string ToString() => $"{nameof(LLVMTargetDataRef)}: {Handle:X}";
}
