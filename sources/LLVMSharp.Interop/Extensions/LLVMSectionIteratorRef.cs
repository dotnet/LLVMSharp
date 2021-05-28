// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMSectionIteratorRef : IEquatable<LLVMSectionIteratorRef>
    {
        public IntPtr Handle;

        public LLVMSectionIteratorRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMSectionIteratorRef(LLVMOpaqueSectionIterator* value) => new LLVMSectionIteratorRef((IntPtr)value);

        public static implicit operator LLVMOpaqueSectionIterator*(LLVMSectionIteratorRef value) => (LLVMOpaqueSectionIterator*)value.Handle;

        public static bool operator ==(LLVMSectionIteratorRef left, LLVMSectionIteratorRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMSectionIteratorRef left, LLVMSectionIteratorRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMSectionIteratorRef other) && Equals(other);

        public bool Equals(LLVMSectionIteratorRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMSectionIteratorRef)}: {Handle:X}";
    }
}
