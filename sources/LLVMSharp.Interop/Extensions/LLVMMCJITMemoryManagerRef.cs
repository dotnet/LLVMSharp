// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMMCJITMemoryManagerRef : IEquatable<LLVMMCJITMemoryManagerRef>
    {
        public IntPtr Handle;

        public LLVMMCJITMemoryManagerRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMMCJITMemoryManagerRef(LLVMOpaqueMCJITMemoryManager* value) => new LLVMMCJITMemoryManagerRef((IntPtr)value);

        public static implicit operator LLVMOpaqueMCJITMemoryManager*(LLVMMCJITMemoryManagerRef value) => (LLVMOpaqueMCJITMemoryManager*)value.Handle;

        public static bool operator ==(LLVMMCJITMemoryManagerRef left, LLVMMCJITMemoryManagerRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMMCJITMemoryManagerRef left, LLVMMCJITMemoryManagerRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMMCJITMemoryManagerRef other) && Equals(other);

        public bool Equals(LLVMMCJITMemoryManagerRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMMCJITMemoryManagerRef)}: {Handle:X}";
    }
}
