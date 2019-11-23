// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMRelocationIteratorRef : IEquatable<LLVMRelocationIteratorRef>
    {
        public LLVMRelocationIteratorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMRelocationIteratorRef(LLVMOpaqueRelocationIterator* value)
        {
            return new LLVMRelocationIteratorRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueRelocationIterator*(LLVMRelocationIteratorRef value)
        {
            return (LLVMOpaqueRelocationIterator*)value.Pointer;
        }

        public static bool operator ==(LLVMRelocationIteratorRef left, LLVMRelocationIteratorRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMRelocationIteratorRef left, LLVMRelocationIteratorRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMRelocationIteratorRef other && Equals(other);

        public bool Equals(LLVMRelocationIteratorRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
