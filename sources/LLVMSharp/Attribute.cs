// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class Attribute : IEquatable<Attribute>
    {
        public LLVMAttributeRef Handle { get; }

        public static bool operator ==(Attribute left, Attribute right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

        public static bool operator !=(Attribute left, Attribute right) => !(left == right);

        public override bool Equals(object obj) => (obj is Attribute other) && Equals(other);

        public bool Equals(Attribute other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => Handle.ToString();
    }
}
