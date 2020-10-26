// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class Module : IEquatable<Module>
    {
        public LLVMModuleRef Handle { get; }

        public static bool operator ==(Module left, Module right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

        public static bool operator !=(Module left, Module right) => !(left == right);

        public override bool Equals(object obj) => (obj is Module other) && Equals(other);

        public bool Equals(Module other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => Handle.ToString();
    }
}
