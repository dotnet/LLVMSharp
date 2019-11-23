// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMSymbolIteratorRef : IEquatable<LLVMSymbolIteratorRef>
    {
        public LLVMSymbolIteratorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMSymbolIteratorRef(LLVMOpaqueSymbolIterator* value)
        {
            return new LLVMSymbolIteratorRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueSymbolIterator*(LLVMSymbolIteratorRef value)
        {
            return (LLVMOpaqueSymbolIterator*)value.Pointer;
        }

        public static bool operator ==(LLVMSymbolIteratorRef left, LLVMSymbolIteratorRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMSymbolIteratorRef left, LLVMSymbolIteratorRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMSymbolIteratorRef other && Equals(other);

        public bool Equals(LLVMSymbolIteratorRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
