// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

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
