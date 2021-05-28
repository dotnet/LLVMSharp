// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

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
