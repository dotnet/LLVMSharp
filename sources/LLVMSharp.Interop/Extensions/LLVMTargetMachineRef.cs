// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMTargetMachineRef(IntPtr handle) : IEquatable<LLVMTargetMachineRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMTargetMachineRef(LLVMOpaqueTargetMachine* value) => new LLVMTargetMachineRef((IntPtr)value);

    public static implicit operator LLVMOpaqueTargetMachine*(LLVMTargetMachineRef value) => (LLVMOpaqueTargetMachine*)value.Handle;

    public static bool operator ==(LLVMTargetMachineRef left, LLVMTargetMachineRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMTargetMachineRef left, LLVMTargetMachineRef right) => !(left == right);

    public readonly string CPU
    {
        get
        {
            var pCPU = LLVM.GetTargetMachineCPU(this);

            if (pCPU == null)
            {
                return string.Empty;
            }

            var result = SpanExtensions.AsString(pCPU);
            LLVM.DisposeMessage(pCPU);
            return result;
        }
    }

    public readonly string FeatureString
    {
        get
        {
            var pFeatureString = LLVM.GetTargetMachineFeatureString(this);

            if (pFeatureString == null)
            {
                return string.Empty;
            }

            var result = SpanExtensions.AsString(pFeatureString);
            LLVM.DisposeMessage(pFeatureString);
            return result;
        }
    }

    public readonly LLVMTargetRef Target => (Handle != IntPtr.Zero) ? LLVM.GetTargetMachineTarget(this) : default;

    public readonly string Triple
    {
        get
        {
            var pTriple = LLVM.GetTargetMachineTriple(this);

            if (pTriple == null)
            {
                return string.Empty;
            }

            var result = SpanExtensions.AsString(pTriple);
            LLVM.DisposeMessage(pTriple);
            return result;
        }
    }

    public readonly LLVMTargetDataRef CreateTargetDataLayout() => LLVM.CreateTargetDataLayout(this);

    public readonly void EmitToFile(LLVMModuleRef module, string fileName, LLVMCodeGenFileType codegen) => EmitToFile(module, fileName.AsSpan(), codegen);

    public readonly void EmitToFile(LLVMModuleRef module, ReadOnlySpan<char> fileName, LLVMCodeGenFileType codegen)
    {
        if (!TryEmitToFile(module, fileName, codegen, out string Error))
        {
            throw new ExternalException(Error);
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMTargetMachineRef other) && Equals(other);

    public readonly bool Equals(LLVMTargetMachineRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMTargetMachineRef)}: {Handle:X}";

    public readonly bool TryEmitToFile(LLVMModuleRef module, string fileName, LLVMCodeGenFileType codegen, out string message) => TryEmitToFile(module, fileName.AsSpan(), codegen, out message);

    public readonly bool TryEmitToFile(LLVMModuleRef module, ReadOnlySpan<char> fileName, LLVMCodeGenFileType codegen, out string message)
    {
        using var marshaledFileName = new MarshaledString(fileName);

        sbyte* errorMessage = null;
        int result = LLVM.TargetMachineEmitToFile(this, module, marshaledFileName, codegen, &errorMessage);

        if (errorMessage == null)
        {
            message = string.Empty;
        }
        else
        {
            message = SpanExtensions.AsString(errorMessage);
            LLVM.DisposeErrorMessage(errorMessage);
        }

        return result == 0;
    }
}
