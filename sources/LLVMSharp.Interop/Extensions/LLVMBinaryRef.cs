// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMBinaryRef : IEquatable<LLVMBinaryRef>
    {
        public IntPtr Handle;

        public LLVMBinaryRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMBinaryRef(LLVMOpaqueBinary* Comdat) => new LLVMBinaryRef((IntPtr)Comdat);

        public static implicit operator LLVMOpaqueBinary*(LLVMBinaryRef Comdat) => (LLVMOpaqueBinary*)Comdat.Handle;

        public static bool operator ==(LLVMBinaryRef left, LLVMBinaryRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMBinaryRef left, LLVMBinaryRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMBinaryRef other) && Equals(other);

        public bool Equals(LLVMBinaryRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMBinaryRef)}: {Handle:X}";
    }
}
