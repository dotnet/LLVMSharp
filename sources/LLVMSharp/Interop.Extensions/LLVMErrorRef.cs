// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMErrorRef : IEquatable<LLVMErrorRef>
    {
        public IntPtr Handle;

        public LLVMErrorRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMErrorRef(LLVMOpaqueError* value) =>new LLVMErrorRef((IntPtr)value);

        public static implicit operator LLVMOpaqueError*(LLVMErrorRef value) => (LLVMOpaqueError*)value.Handle;

        public static bool operator ==(LLVMErrorRef left, LLVMErrorRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMErrorRef left, LLVMErrorRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMErrorRef other) && Equals(other);

        public bool Equals(LLVMErrorRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMErrorRef)}: {Handle:X}";
    }
}
