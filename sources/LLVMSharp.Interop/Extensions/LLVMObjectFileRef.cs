// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMObjectFileRef : IEquatable<LLVMObjectFileRef>
    {
        public IntPtr Handle;

        public LLVMObjectFileRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMObjectFileRef(LLVMOpaqueObjectFile* value) => new LLVMObjectFileRef((IntPtr)value);

        public static implicit operator LLVMOpaqueObjectFile*(LLVMObjectFileRef value) => (LLVMOpaqueObjectFile*)value.Handle;

        public static bool operator ==(LLVMObjectFileRef left, LLVMObjectFileRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMObjectFileRef left, LLVMObjectFileRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMObjectFileRef other) && Equals(other);

        public bool Equals(LLVMObjectFileRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMObjectFileRef)}: {Handle:X}";
    }
}
