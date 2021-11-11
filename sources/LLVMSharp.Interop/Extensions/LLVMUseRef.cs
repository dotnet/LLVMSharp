// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMUseRef : IEquatable<LLVMUseRef>
    {
        public IntPtr Handle;

        public LLVMUseRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMUseRef(LLVMOpaqueUse* Use) => new LLVMUseRef((IntPtr)Use);

        public static implicit operator LLVMOpaqueUse*(LLVMUseRef Use) => (LLVMOpaqueUse*)Use.Handle;

        public static bool operator ==(LLVMUseRef left, LLVMUseRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMUseRef left, LLVMUseRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMUseRef other) && Equals(other);

        public bool Equals(LLVMUseRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMUseRef)}: {Handle:X}";
    }
}
