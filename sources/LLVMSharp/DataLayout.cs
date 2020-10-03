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

        public StructLayout GetStructLayout(StructType structType) => new StructLayout(this, structType);

        public ulong GetTypeSizeInBits(Type type) => Handle.SizeOfTypeInBits(type.Handle);

        public ulong GetTypeStoreSize(Type type) => Handle.StoreSizeOfType(type.Handle);

        public ulong GetTypeAllocSize(Type type) => Handle.ABISizeOfType(type.Handle);

        public uint GetABITypeAlignment(Type type) => Handle.ABIAlignmentOfType(type.Handle);

        public uint GetPrefTypeAlignment(Type type) => Handle.PreferredAlignmentOfType(type.Handle);

        public uint GetPreferredAlign(Value value) => Handle.PreferredAlignmentOfGlobal(value.Handle);

        public static bool operator ==(DataLayout left, DataLayout right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

        public static bool operator !=(DataLayout left, DataLayout right) => !(left == right);

        public override bool Equals(object obj) => (obj is DataLayout other) && Equals(other);

        public bool Equals(DataLayout other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => Handle.ToString();
    }
}
