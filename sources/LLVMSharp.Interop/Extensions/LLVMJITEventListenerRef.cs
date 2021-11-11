// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMJITEventListenerRef : IEquatable<LLVMJITEventListenerRef>
    {
        public IntPtr Handle;

        public LLVMJITEventListenerRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMJITEventListenerRef(LLVMOpaqueJITEventListener* value) => new LLVMJITEventListenerRef((IntPtr)value);

        public static implicit operator LLVMOpaqueJITEventListener*(LLVMJITEventListenerRef value) => (LLVMOpaqueJITEventListener*)value.Handle;

        public static bool operator ==(LLVMJITEventListenerRef left, LLVMJITEventListenerRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMJITEventListenerRef left, LLVMJITEventListenerRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMJITEventListenerRef other) && Equals(other);

        public bool Equals(LLVMJITEventListenerRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMJITEventListenerRef)}: {Handle:X}";
    }
}
