// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMOrcJITStackRef : IEquatable<LLVMOrcJITStackRef>
    {
        public IntPtr Handle;

        public LLVMOrcJITStackRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMOrcJITStackRef(LLVMOrcOpaqueJITStack* value) => new LLVMOrcJITStackRef((IntPtr)value);

        public static implicit operator LLVMOrcOpaqueJITStack*(LLVMOrcJITStackRef value) => (LLVMOrcOpaqueJITStack*)value.Handle;

        public static bool operator ==(LLVMOrcJITStackRef left, LLVMOrcJITStackRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMOrcJITStackRef left, LLVMOrcJITStackRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMOrcJITStackRef other) && Equals(other);

        public bool Equals(LLVMOrcJITStackRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMOrcJITStackRef)}: {Handle:X}";
    }
}
