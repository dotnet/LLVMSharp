// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

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
