// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class TargetMachine : IEquatable<TargetMachine>
{
    internal TargetMachine(LLVMTargetMachineRef handle)
    {
        Handle = handle;
    }

    public LLVMTargetMachineRef Handle { get; }

    public string CPU => Handle.CPU;

    public string FeatureString => Handle.FeatureString;

    public Target Target => new Target(Handle.Target);

    public string Triple => Handle.Triple;

    public DataLayout CreateTargetDataLayout() => new DataLayout(Handle.CreateTargetDataLayout());

    public void EmitToFile(Module module, string fileName, LLVMCodeGenFileType codegen)
    {
        ArgumentNullException.ThrowIfNull(module);
        Handle.EmitToFile(module.Handle, fileName, codegen);
    }

    public bool TryEmitToFile(Module module, string fileName, LLVMCodeGenFileType codegen, out string message)
    {
        ArgumentNullException.ThrowIfNull(module);
        return Handle.TryEmitToFile(module.Handle, fileName, codegen, out message);
    }

    public static bool operator ==(TargetMachine? left, TargetMachine? right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

    public static bool operator !=(TargetMachine? left, TargetMachine? right) => !(left == right);

    public override bool Equals(object? obj) => (obj is TargetMachine other) && Equals(other);

    public bool Equals(TargetMachine? other) => this == other;

    public override int GetHashCode() => Handle.GetHashCode();

    public override string ToString() => Handle.ToString();
}
