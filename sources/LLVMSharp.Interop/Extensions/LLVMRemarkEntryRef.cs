// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMRemarkEntryRef : IEquatable<LLVMRemarkEntryRef>
    {
        public IntPtr Handle;

        public LLVMRemarkEntryRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMRemarkEntryRef(LLVMRemarkOpaqueEntry* value) => new LLVMRemarkEntryRef((IntPtr)value);

        public static implicit operator LLVMRemarkOpaqueEntry*(LLVMRemarkEntryRef value) => (LLVMRemarkOpaqueEntry*)value.Handle;

        public static bool operator ==(LLVMRemarkEntryRef left, LLVMRemarkEntryRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMRemarkEntryRef left, LLVMRemarkEntryRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMRemarkEntryRef other) && Equals(other);

        public bool Equals(LLVMRemarkEntryRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMRemarkEntryRef)}: {Handle:X}";
    }
}
