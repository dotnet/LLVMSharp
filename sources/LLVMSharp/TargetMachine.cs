// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class TargetMachine : IEquatable<TargetMachine>
    {
        public LLVMTargetMachineRef Handle { get; }

        public static bool operator ==(TargetMachine left, TargetMachine right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

        public static bool operator !=(TargetMachine left, TargetMachine right) => !(left == right);

        public override bool Equals(object obj) => (obj is TargetMachine other) && Equals(other);

        public bool Equals(TargetMachine other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => Handle.ToString();
    }
}
