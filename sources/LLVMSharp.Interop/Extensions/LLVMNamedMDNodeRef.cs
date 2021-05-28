// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMNamedMDNodeRef : IEquatable<LLVMNamedMDNodeRef>
    {
        public IntPtr Handle;

        public LLVMNamedMDNodeRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMNamedMDNodeRef(LLVMOpaqueNamedMDNode* value) => new LLVMNamedMDNodeRef((IntPtr)value);

        public static implicit operator LLVMOpaqueNamedMDNode*(LLVMNamedMDNodeRef value) => (LLVMOpaqueNamedMDNode*)value.Handle;

        public static bool operator ==(LLVMNamedMDNodeRef left, LLVMNamedMDNodeRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMNamedMDNodeRef left, LLVMNamedMDNodeRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMNamedMDNodeRef other) && Equals(other);

        public bool Equals(LLVMNamedMDNodeRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMNamedMDNodeRef)}: {Handle:X}";
    }
}
