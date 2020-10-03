// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMTargetLibraryInfoRef : IEquatable<LLVMTargetLibraryInfoRef>
    {
        public IntPtr Handle;

        public LLVMTargetLibraryInfoRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMTargetLibraryInfoRef(LLVMOpaqueTargetLibraryInfotData* value) => new LLVMTargetLibraryInfoRef((IntPtr)value);

        public static implicit operator LLVMOpaqueTargetLibraryInfotData*(LLVMTargetLibraryInfoRef value) => (LLVMOpaqueTargetLibraryInfotData*)value.Handle;

        public static bool operator ==(LLVMTargetLibraryInfoRef left, LLVMTargetLibraryInfoRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMTargetLibraryInfoRef left, LLVMTargetLibraryInfoRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMTargetLibraryInfoRef other) && Equals(other);

        public bool Equals(LLVMTargetLibraryInfoRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMTargetLibraryInfoRef)}: {Handle:X}";
    }
}
