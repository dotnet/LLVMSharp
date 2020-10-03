// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct thinlto_code_gen_t : IEquatable<thinlto_code_gen_t>
    {
        public IntPtr Handle;

        public thinlto_code_gen_t(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator thinlto_code_gen_t(LLVMOpaqueThinLTOCodeGenerator* Comdat) => new thinlto_code_gen_t((IntPtr)Comdat);

        public static implicit operator LLVMOpaqueThinLTOCodeGenerator*(thinlto_code_gen_t Comdat) => (LLVMOpaqueThinLTOCodeGenerator*)Comdat.Handle;

        public static bool operator ==(thinlto_code_gen_t left, thinlto_code_gen_t right) => left.Handle == right.Handle;

        public static bool operator !=(thinlto_code_gen_t left, thinlto_code_gen_t right) => !(left == right);

        public override bool Equals(object obj) => (obj is thinlto_code_gen_t other) && Equals(other);

        public bool Equals(thinlto_code_gen_t other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(thinlto_code_gen_t)}: {Handle:X}";
    }
}
