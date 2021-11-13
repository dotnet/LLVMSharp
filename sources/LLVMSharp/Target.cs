// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class Target : IEquatable<Target>
    {
        public LLVMTargetRef Handle { get; }

        public static bool operator ==(Target left, Target right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

        public static bool operator !=(Target left, Target right) => !(left == right);

        public override bool Equals(object obj) => (obj is Target other) && Equals(other);

        public bool Equals(Target other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => Handle.ToString();
    }
}
