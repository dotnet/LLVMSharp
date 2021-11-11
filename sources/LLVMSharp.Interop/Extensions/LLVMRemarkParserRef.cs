// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMRemarkParserRef : IEquatable<LLVMRemarkParserRef>
    {
        public IntPtr Handle;

        public LLVMRemarkParserRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMRemarkParserRef(LLVMRemarkOpaqueParser* value) => new LLVMRemarkParserRef((IntPtr)value);

        public static implicit operator LLVMRemarkOpaqueParser*(LLVMRemarkParserRef value) => (LLVMRemarkOpaqueParser*)value.Handle;

        public static bool operator ==(LLVMRemarkParserRef left, LLVMRemarkParserRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMRemarkParserRef left, LLVMRemarkParserRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMRemarkParserRef other) && Equals(other);

        public bool Equals(LLVMRemarkParserRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMRemarkParserRef)}: {Handle:X}";
    }
}
