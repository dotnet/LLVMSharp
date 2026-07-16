// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Collections.Generic;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class Target : IEquatable<Target>
{
    internal Target(LLVMTargetRef handle)
    {
        Handle = handle;
    }

    public LLVMTargetRef Handle { get; }

    public static string DefaultTriple => LLVMTargetRef.DefaultTriple;

    public static IEnumerable<Target> Targets
    {
        get
        {
            foreach (var handle in LLVMTargetRef.Targets)
            {
                yield return new Target(handle);
            }
        }
    }

    public string Description => Handle.Description;

    public bool HasAsmBackend => Handle.HasAsmBackend;

    public bool HasJIT => Handle.HasJIT;

    public bool HasTargetMachine => Handle.HasTargetMachine;

    public string Name => Handle.Name;

    public static Target GetTargetFromTriple(string triple) => new Target(LLVMTargetRef.GetTargetFromTriple(triple));

    public static bool TryGetTargetFromTriple(string triple, out Target target, out string error)
    {
        if (LLVMTargetRef.TryGetTargetFromTriple(triple.AsSpan(), out var handle, out error))
        {
            target = new Target(handle);
            return true;
        }

        target = null!;
        return false;
    }

    public TargetMachine CreateTargetMachine(string triple, string cpu, string features, LLVMCodeGenOptLevel level, LLVMRelocMode reloc, LLVMCodeModel codeModel)
    {
        return new TargetMachine(Handle.CreateTargetMachine(triple, cpu, features, level, reloc, codeModel));
    }

    public static bool operator ==(Target? left, Target? right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

    public static bool operator !=(Target? left, Target? right) => !(left == right);

    public override bool Equals(object? obj) => (obj is Target other) && Equals(other);

    public bool Equals(Target? other) => this == other;

    public override int GetHashCode() => Handle.GetHashCode();

    public override string ToString() => Handle.ToString();
}
