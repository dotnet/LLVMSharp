// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

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

        public ulong OffsetOfElement(uint element) => _dataLayout.Handle.OffsetOfElement(_structType.Handle, element);

        public ulong ElementAtOffset(ulong offset) => _dataLayout.Handle.ElementAtOffset(_structType.Handle, offset);

        public static bool operator ==(StructLayout left, StructLayout right) => ReferenceEquals(left, right) || ((left?._dataLayout == right._dataLayout) && (left?._structType == right?._structType));

        public static bool operator !=(StructLayout left, StructLayout right) => !(left == right);

        public override bool Equals(object obj) => (obj is StructLayout other) && Equals(other);

        public bool Equals(StructLayout other) => this == other;

        public override int GetHashCode() => HashCode.Combine(_structType, _dataLayout);
    }
}
