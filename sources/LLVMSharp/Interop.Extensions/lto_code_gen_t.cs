// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct lto_code_gen_t : IEquatable<lto_code_gen_t>
    {
        public IntPtr Handle;

        public lto_code_gen_t(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator lto_code_gen_t(LLVMOpaqueLTOCodeGenerator* Comdat) => new lto_code_gen_t((IntPtr)Comdat);

        public static implicit operator LLVMOpaqueLTOCodeGenerator*(lto_code_gen_t Comdat) => (LLVMOpaqueLTOCodeGenerator*)Comdat.Handle;

        public static bool operator ==(lto_code_gen_t left, lto_code_gen_t right) => left.Handle == right.Handle;

        public static bool operator !=(lto_code_gen_t left, lto_code_gen_t right) => !(left == right);

        public override bool Equals(object obj) => (obj is lto_code_gen_t other) && Equals(other);

        public bool Equals(lto_code_gen_t other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(lto_code_gen_t)}: {Handle:X}";
    }
}
