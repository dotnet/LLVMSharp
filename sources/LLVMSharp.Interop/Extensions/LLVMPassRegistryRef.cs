// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMPassRegistryRef : IEquatable<LLVMPassRegistryRef>
    {
        public IntPtr Handle;

        public LLVMPassRegistryRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMPassRegistryRef(LLVMOpaquePassRegistry* value) => new LLVMPassRegistryRef((IntPtr)value);

        public static implicit operator LLVMOpaquePassRegistry*(LLVMPassRegistryRef value) => (LLVMOpaquePassRegistry*)value.Handle;

        public static bool operator ==(LLVMPassRegistryRef left, LLVMPassRegistryRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMPassRegistryRef left, LLVMPassRegistryRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMPassRegistryRef other) && Equals(other);

        public bool Equals(LLVMPassRegistryRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMPassRegistryRef)}: {Handle:X}";
    }
}
