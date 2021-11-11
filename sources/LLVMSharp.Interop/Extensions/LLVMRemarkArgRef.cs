// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMRemarkArgRef : IEquatable<LLVMRemarkArgRef>
    {
        public IntPtr Handle;

        public LLVMRemarkArgRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMRemarkArgRef(LLVMRemarkOpaqueArg* value) => new LLVMRemarkArgRef((IntPtr)value);

        public static implicit operator LLVMRemarkOpaqueArg*(LLVMRemarkArgRef value) => (LLVMRemarkOpaqueArg*)value.Handle;

        public static bool operator ==(LLVMRemarkArgRef left, LLVMRemarkArgRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMRemarkArgRef left, LLVMRemarkArgRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMRemarkArgRef other) && Equals(other);

        public bool Equals(LLVMRemarkArgRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMRemarkArgRef)}: {Handle:X}";
    }
}
