// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMRemarkStringRef : IEquatable<LLVMRemarkStringRef>
    {
        public IntPtr Handle;

        public LLVMRemarkStringRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMRemarkStringRef(LLVMRemarkOpaqueString* value) => new LLVMRemarkStringRef((IntPtr)value);

        public static implicit operator LLVMRemarkOpaqueString*(LLVMRemarkStringRef value) => (LLVMRemarkOpaqueString*)value.Handle;

        public static bool operator ==(LLVMRemarkStringRef left, LLVMRemarkStringRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMRemarkStringRef left, LLVMRemarkStringRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMRemarkStringRef other) && Equals(other);

        public bool Equals(LLVMRemarkStringRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMRemarkStringRef)}: {Handle:X}";
    }
}
