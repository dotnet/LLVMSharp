// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMErrorTypeId : IEquatable<LLVMErrorTypeId>
    {
        public IntPtr Handle;

        public LLVMErrorTypeId(IntPtr handle)
        {
            Handle = handle;
        }

        public static explicit operator LLVMErrorTypeId(void* value) => new LLVMErrorTypeId((IntPtr)value);

        public static implicit operator void*(LLVMErrorTypeId value) => (void*)value.Handle;

        public static bool operator ==(LLVMErrorTypeId left, LLVMErrorTypeId right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMErrorTypeId left, LLVMErrorTypeId right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMErrorTypeId other) && Equals(other);

        public bool Equals(LLVMErrorTypeId other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMErrorTypeId)}: {Handle:X}";
    }
}
