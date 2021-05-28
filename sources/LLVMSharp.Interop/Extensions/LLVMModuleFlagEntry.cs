// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMModuleFlagEntry : IEquatable<LLVMModuleFlagEntry>
    {
        public IntPtr Handle;

        public LLVMModuleFlagEntry(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMModuleFlagEntry(LLVMOpaqueModuleFlagEntry* Comdat) => new LLVMModuleFlagEntry((IntPtr)Comdat);

        public static implicit operator LLVMOpaqueModuleFlagEntry*(LLVMModuleFlagEntry Comdat) => (LLVMOpaqueModuleFlagEntry*)Comdat.Handle;

        public static bool operator ==(LLVMModuleFlagEntry left, LLVMModuleFlagEntry right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMModuleFlagEntry left, LLVMModuleFlagEntry right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMModuleFlagEntry other) && Equals(other);

        public bool Equals(LLVMModuleFlagEntry other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMModuleFlagEntry)}: {Handle:X}";
    }
}
