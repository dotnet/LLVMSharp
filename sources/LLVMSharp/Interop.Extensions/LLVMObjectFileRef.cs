// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMObjectFileRef : IEquatable<LLVMObjectFileRef>
    {
        public LLVMObjectFileRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMObjectFileRef(LLVMOpaqueObjectFile* value)
        {
            return new LLVMObjectFileRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueObjectFile*(LLVMObjectFileRef value)
        {
            return (LLVMOpaqueObjectFile*)value.Pointer;
        }

        public static bool operator ==(LLVMObjectFileRef left, LLVMObjectFileRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMObjectFileRef left, LLVMObjectFileRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMObjectFileRef other && Equals(other);

        public bool Equals(LLVMObjectFileRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();
    }
}
