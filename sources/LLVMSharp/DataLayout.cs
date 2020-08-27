// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class DataLayout : IEquatable<DataLayout>
    {
        public DataLayout(ReadOnlySpan<char> stringRep)
        {
            Handle = LLVMTargetDataRef.FromStringRepresentation(stringRep);
        }

        public LLVMTargetDataRef Handle { get; }

        public StructLayout GetStructLayout(StructType structType)
        {
            return new StructLayout(this, structType);
        }

        public ulong GetTypeSizeInBits(Type type)
        {
            return Handle.SizeOfTypeInBits(type.Handle);
        }

        public ulong GetTypeStoreSize(Type type)
        {
            return Handle.StoreSizeOfType(type.Handle);
        }

        public ulong GetTypeAllocSize(Type type)
        {
            return Handle.ABISizeOfType(type.Handle);
        }

        public uint GetABITypeAlignment(Type type)
        {
            return Handle.ABIAlignmentOfType(type.Handle);
        }

        public uint GetPrefTypeAlignment(Type type)
        {
            return Handle.PreferredAlignmentOfType(type.Handle);
        }

        public uint GetPreferredAlign(Value value)
        {
            return Handle.PreferredAlignmentOfGlobal(value.Handle);
        }

        public static bool operator ==(DataLayout left, DataLayout right) => (left is object) ? ((right is object) && (left.Handle == right.Handle)) : (right is null);

        public static bool operator !=(DataLayout left, DataLayout right) => (left is object) ? ((right is null) || (left.Handle != right.Handle)) : (right is object);

        public override bool Equals(object obj) => (obj is DataLayout other) && Equals(other);

        public bool Equals(DataLayout other) => this == other;

        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }
    }
}
