// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct lto_module_t : IEquatable<lto_module_t>
    {
        public IntPtr Handle;

        public lto_module_t(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator lto_module_t(LLVMOpaqueLTOModule* Comdat) => new lto_module_t((IntPtr)Comdat);

        public static implicit operator LLVMOpaqueLTOModule*(lto_module_t Comdat) => (LLVMOpaqueLTOModule*)Comdat.Handle;

        public static bool operator ==(lto_module_t left, lto_module_t right) => left.Handle == right.Handle;

        public static bool operator !=(lto_module_t left, lto_module_t right) => !(left == right);

        public override bool Equals(object obj) => (obj is lto_module_t other) && Equals(other);

        public bool Equals(lto_module_t other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(lto_module_t)}: {Handle:X}";
    }
}
