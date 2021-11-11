// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

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
