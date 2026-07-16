// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class DataLayout : IEquatable<DataLayout>
{
    public DataLayout(ReadOnlySpan<char> stringRep)
    {
        Handle = LLVMTargetDataRef.FromStringRepresentation(stringRep);
    }

    internal DataLayout(LLVMTargetDataRef handle)
    {
        Handle = handle;
    }

    public LLVMTargetDataRef Handle { get; }

    public StructLayout GetStructLayout(StructType structType) => new StructLayout(this, structType);

    public uint GetABITypeAlignment(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        return Handle.ABIAlignmentOfType(type.Handle);
    }

    public uint GetCallFrameTypeAlignment(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        return Handle.CallFrameAlignmentOfType(type.Handle);
    }

    public uint GetElementContainingOffset(StructType structType, ulong offset)
    {
        ArgumentNullException.ThrowIfNull(structType);
        return (uint)Handle.ElementAtOffset(structType.Handle, offset);
    }

    public ulong GetOffsetOfElement(StructType structType, uint element)
    {
        ArgumentNullException.ThrowIfNull(structType);
        return Handle.OffsetOfElement(structType.Handle, element);
    }

    public ulong GetTypeSizeInBits(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        return Handle.SizeOfTypeInBits(type.Handle);
    }

    public ulong GetTypeStoreSize(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        return Handle.StoreSizeOfType(type.Handle);
    }

    public ulong GetTypeAllocSize(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        return Handle.ABISizeOfType(type.Handle);
    }

    public uint GetPrefTypeAlignment(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        return Handle.PreferredAlignmentOfType(type.Handle);
    }

    public uint GetPreferredAlign(Value value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return Handle.PreferredAlignmentOfGlobal(value.Handle);
    }

    public static bool operator ==(DataLayout? left, DataLayout? right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

    public static bool operator !=(DataLayout? left, DataLayout? right) => !(left == right);

    public override bool Equals(object? obj) => (obj is DataLayout other) && Equals(other);

    public bool Equals(DataLayout? other) => this == other;

    public override int GetHashCode() => Handle.GetHashCode();

    public override string ToString() => Handle.ToString();
}
