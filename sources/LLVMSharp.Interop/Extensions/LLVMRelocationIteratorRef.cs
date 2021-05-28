// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMRelocationIteratorRef : IEquatable<LLVMRelocationIteratorRef>
    {
        public IntPtr Handle;

        public LLVMRelocationIteratorRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMRelocationIteratorRef(LLVMOpaqueRelocationIterator* value) => new LLVMRelocationIteratorRef((IntPtr)value);

        public static implicit operator LLVMOpaqueRelocationIterator*(LLVMRelocationIteratorRef value) => (LLVMOpaqueRelocationIterator*)value.Handle;

        public static bool operator ==(LLVMRelocationIteratorRef left, LLVMRelocationIteratorRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMRelocationIteratorRef left, LLVMRelocationIteratorRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMRelocationIteratorRef other) && Equals(other);

        public bool Equals(LLVMRelocationIteratorRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMRelocationIteratorRef)}: {Handle:X}";
    }
}
