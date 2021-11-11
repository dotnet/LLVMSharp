// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMComdatRef : IEquatable<LLVMComdatRef>
    {
        public IntPtr Handle;

        public LLVMComdatRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMComdatRef(LLVMComdat* Comdat) => new LLVMComdatRef((IntPtr)Comdat);

        public static implicit operator LLVMComdat*(LLVMComdatRef Comdat) => (LLVMComdat*)Comdat.Handle;

        public static bool operator ==(LLVMComdatRef left, LLVMComdatRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMComdatRef left, LLVMComdatRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMComdatRef other) && Equals(other);

        public bool Equals(LLVMComdatRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMComdatRef)}: {Handle:X}";
    }
}
