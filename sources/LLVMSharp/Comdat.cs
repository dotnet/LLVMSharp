// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class Comdat(LLVMComdatRef handle) : IEquatable<Comdat>
{
    public LLVMComdatRef Handle { get; } = handle;

    public LLVMComdatSelectionKind SelectionKind
    {
        get
        {
            return Handle.SelectionKind;
        }

        set
        {
            var handle = Handle;
            handle.SelectionKind = value;
        }
    }

    public static bool operator ==(Comdat? left, Comdat? right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

    public static bool operator !=(Comdat? left, Comdat? right) => !(left == right);

    public override bool Equals(object? obj) => (obj is Comdat other) && Equals(other);

    public bool Equals(Comdat? other) => this == other;

    public override int GetHashCode() => Handle.GetHashCode();

    public override string ToString() => Handle.ToString();
}
