// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMSymbolIteratorRef : IEquatable<LLVMSymbolIteratorRef>
    {
        public IntPtr Handle;

        public LLVMSymbolIteratorRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMSymbolIteratorRef(LLVMOpaqueSymbolIterator* value) => new LLVMSymbolIteratorRef((IntPtr)value);

        public static implicit operator LLVMOpaqueSymbolIterator*(LLVMSymbolIteratorRef value) => (LLVMOpaqueSymbolIterator*)value.Handle;

        public static bool operator ==(LLVMSymbolIteratorRef left, LLVMSymbolIteratorRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMSymbolIteratorRef left, LLVMSymbolIteratorRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMSymbolIteratorRef other) && Equals(other);

        public bool Equals(LLVMSymbolIteratorRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMSymbolIteratorRef)}: {Handle:X}";
    }
}
