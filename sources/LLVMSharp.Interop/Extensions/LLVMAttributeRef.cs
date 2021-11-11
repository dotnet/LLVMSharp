// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMAttributeRef : IEquatable<LLVMAttributeRef>
    {
        public IntPtr Handle;

        public LLVMAttributeRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMAttributeRef(LLVMOpaqueAttributeRef* value) => new LLVMAttributeRef((IntPtr)value);

        public static implicit operator LLVMOpaqueAttributeRef*(LLVMAttributeRef value) => (LLVMOpaqueAttributeRef*)value.Handle;

        public static bool operator ==(LLVMAttributeRef left, LLVMAttributeRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMAttributeRef left, LLVMAttributeRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMAttributeRef other) && Equals(other);

        public bool Equals(LLVMAttributeRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMAttributeRef)}: {Handle:X}";
    }
}
