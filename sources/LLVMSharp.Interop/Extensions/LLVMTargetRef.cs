// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMTargetRef(IntPtr handle) : IEquatable<LLVMTargetRef>
{
    public IntPtr Handle = handle;

    public static string DefaultTriple
    {
        get
        {
            var pDefaultTriple = LLVM.GetDefaultTargetTriple();

            if (pDefaultTriple == null)
            {
                return string.Empty;
            }

            return SpanExtensions.AsString(pDefaultTriple);
        }
    }

    public static bool TryGetTargetFromTriple(ReadOnlySpan<char> triple, out LLVMTargetRef outTarget, out string outError)
    {
        using var marshaledTriple = new MarshaledString(triple);

        fixed (LLVMTargetRef* pOutTarget = &outTarget)
        {
            sbyte* pError = null;
            var result = LLVM.GetTargetFromTriple(marshaledTriple, (LLVMTarget**)pOutTarget, &pError);

            if (pError == null)
            {
                outError = string.Empty;
            }
            else
            {
                outError = SpanExtensions.AsString(pError);
            }

            return result == 0;
        }
    }

    public static LLVMTargetRef GetTargetFromTriple(string triple) => GetTargetFromTriple(triple.AsSpan());

    public static LLVMTargetRef GetTargetFromTriple(ReadOnlySpan<char> triple)
    {
        if (!TryGetTargetFromTriple(triple, out LLVMTargetRef target, out string message))
        {
            throw new ExternalException(message);
        }

        return target;
    }

    public static LLVMTargetRef First => LLVM.GetFirstTarget();

    public static IEnumerable<LLVMTargetRef> Targets
    {
        get
        {
            var target = First;

            while (target != null)
            {
                yield return target;
                target = target.GetNext();
            }
        }
    }

    public readonly string Name
    {
        get
        {
            if (Handle == IntPtr.Zero)
            {
                return string.Empty;
            }

            var pName = LLVM.GetTargetName(this);

            if (pName == null)
            {
                return string.Empty;
            }

            return SpanExtensions.AsString(pName);
        }
    }

    public static implicit operator LLVMTargetRef(LLVMTarget* value) => new LLVMTargetRef((IntPtr)value);

    public static implicit operator LLVMTarget*(LLVMTargetRef value) => (LLVMTarget*)value.Handle;

    public static bool operator ==(LLVMTargetRef left, LLVMTargetRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMTargetRef left, LLVMTargetRef right) => !(left == right);

    public override readonly bool Equals(object? obj) => (obj is LLVMTargetRef other) && Equals(other);

    public readonly bool Equals(LLVMTargetRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly LLVMTargetRef GetNext() => LLVM.GetNextTarget(this);

    public readonly LLVMTargetMachineRef CreateTargetMachine(string triple, string cpu, string features, LLVMCodeGenOptLevel level, LLVMRelocMode reloc, LLVMCodeModel codeModel) => CreateTargetMachine(triple.AsSpan(), cpu.AsSpan(), features.AsSpan(), level, reloc, codeModel);

    public readonly LLVMTargetMachineRef CreateTargetMachine(ReadOnlySpan<char> triple, ReadOnlySpan<char> cpu, ReadOnlySpan<char> features, LLVMCodeGenOptLevel level, LLVMRelocMode reloc, LLVMCodeModel codeModel)
    {
        using var marshaledTriple = new MarshaledString(triple);
        using var marshaledCPU = new MarshaledString(cpu);
        using var marshaledFeatures = new MarshaledString(features);
        return LLVM.CreateTargetMachine(this, marshaledTriple, marshaledCPU, marshaledFeatures, level, reloc, codeModel);
    }

    public override readonly string ToString() => $"{nameof(LLVMTargetRef)}: {Handle:X}";
}
