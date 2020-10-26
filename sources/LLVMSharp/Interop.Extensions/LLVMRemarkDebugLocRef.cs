// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMRemarkDebugLocRef : IEquatable<LLVMRemarkDebugLocRef>
    {
        public IntPtr Handle;

        public LLVMRemarkDebugLocRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMRemarkDebugLocRef(LLVMRemarkOpaqueDebugLoc* value) => new LLVMRemarkDebugLocRef((IntPtr)value);

        public static implicit operator LLVMRemarkOpaqueDebugLoc*(LLVMRemarkDebugLocRef value) => (LLVMRemarkOpaqueDebugLoc*)value.Handle;

        public static bool operator ==(LLVMRemarkDebugLocRef left, LLVMRemarkDebugLocRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMRemarkDebugLocRef left, LLVMRemarkDebugLocRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMRemarkDebugLocRef other) && Equals(other);

        public bool Equals(LLVMRemarkDebugLocRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMRemarkDebugLocRef)}: {Handle:X}";
    }
}
