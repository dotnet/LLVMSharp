// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMDiagnosticInfoRef : IEquatable<LLVMDiagnosticInfoRef>
    {
        public IntPtr Handle;

        public LLVMDiagnosticInfoRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMDiagnosticInfoRef(LLVMOpaqueDiagnosticInfo* value) => new LLVMDiagnosticInfoRef((IntPtr)value);

        public static implicit operator LLVMOpaqueDiagnosticInfo*(LLVMDiagnosticInfoRef value) => (LLVMOpaqueDiagnosticInfo*)value.Handle;

        public static bool operator ==(LLVMDiagnosticInfoRef left, LLVMDiagnosticInfoRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMDiagnosticInfoRef left, LLVMDiagnosticInfoRef right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMDiagnosticInfoRef other) && Equals(other);

        public bool Equals(LLVMDiagnosticInfoRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMDiagnosticInfoRef)}: {Handle:X}";
    }
}
