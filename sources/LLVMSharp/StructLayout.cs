// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public sealed class StructLayout : IEquatable<StructLayout>
    {
        private readonly DataLayout _dataLayout;
        private readonly StructType _structType;

        internal StructLayout(DataLayout dataLayout, StructType structType)
        {
            _dataLayout = dataLayout;
            _structType = structType;
        }

        public ulong OffsetOfElement(uint element)
        {
            return _dataLayout.Handle.OffsetOfElement(_structType.Handle, element);
        }

        public ulong ElementAtOffset(ulong offset)
        {
                return _dataLayout.Handle.ElementAtOffset(_structType.Handle, offset);
        }

        public static bool operator ==(StructLayout left, StructLayout right) => (left is object) ? ((right is object) && (left._dataLayout == right._dataLayout && left._structType == right._structType)) : (right is null);

        public static bool operator !=(StructLayout left, StructLayout right) => (left is object) ? ((right is null) || (left._dataLayout != right._dataLayout || left._structType != right._structType)) : (right is object);

        public override bool Equals(object obj) => (obj is StructLayout other) && Equals(other);

        public bool Equals(StructLayout other) => this == other;

        public override int GetHashCode()
        {
            return _structType.GetHashCode() * 397 ^ _dataLayout.GetHashCode();
        }
    }
}
