// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMSectionIteratorRef : IEquatable<LLVMSectionIteratorRef>
    {
        public LLVMSectionIteratorRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMSectionIteratorRef(LLVMOpaqueSectionIterator* value)
        {
            return new LLVMSectionIteratorRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueSectionIterator*(LLVMSectionIteratorRef value)
        {
            return (LLVMOpaqueSectionIterator*)value.Pointer;
        }

        public static bool operator ==(LLVMSectionIteratorRef left, LLVMSectionIteratorRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMSectionIteratorRef left, LLVMSectionIteratorRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMSectionIteratorRef other && Equals(other);

        public bool Equals(LLVMSectionIteratorRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
