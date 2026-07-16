// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcJITTargetMachineBuilderRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcJITTargetMachineBuilderRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcJITTargetMachineBuilderRef(LLVMOrcOpaqueJITTargetMachineBuilder* value) => new LLVMOrcJITTargetMachineBuilderRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueJITTargetMachineBuilder*(LLVMOrcJITTargetMachineBuilderRef value) => (LLVMOrcOpaqueJITTargetMachineBuilder*)value.Handle;

    public static bool operator ==(LLVMOrcJITTargetMachineBuilderRef left, LLVMOrcJITTargetMachineBuilderRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcJITTargetMachineBuilderRef left, LLVMOrcJITTargetMachineBuilderRef right) => !(left == right);

    public readonly string TargetTriple
    {
        get
        {
            if (Handle == IntPtr.Zero)
            {
                return string.Empty;
            }

            var pTriple = LLVM.OrcJITTargetMachineBuilderGetTargetTriple(this);

            // The caller owns the returned string and must free it with LLVM.DisposeMessage.
            var result = SpanExtensions.AsString(pTriple);
            LLVM.DisposeMessage(pTriple);
            return result;
        }
    }

    public static LLVMErrorRef DetectHost(out LLVMOrcJITTargetMachineBuilderRef Result)
    {
        fixed (LLVMOrcJITTargetMachineBuilderRef* pResult = &Result)
        {
            return LLVM.OrcJITTargetMachineBuilderDetectHost((LLVMOrcOpaqueJITTargetMachineBuilder**)pResult);
        }
    }

    // Takes ownership of TM.
    public static LLVMOrcJITTargetMachineBuilderRef CreateFromTargetMachine(LLVMTargetMachineRef TM) => LLVM.OrcJITTargetMachineBuilderCreateFromTargetMachine(TM);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.OrcDisposeJITTargetMachineBuilder(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcJITTargetMachineBuilderRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcJITTargetMachineBuilderRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void SetTargetTriple(string TargetTriple) => SetTargetTriple(TargetTriple.AsSpan());

    public readonly void SetTargetTriple(ReadOnlySpan<char> TargetTriple)
    {
        using var marshaledTriple = new MarshaledString(TargetTriple);
        LLVM.OrcJITTargetMachineBuilderSetTargetTriple(this, marshaledTriple);
    }

    public override readonly string ToString() => $"{nameof(LLVMOrcJITTargetMachineBuilderRef)}: {Handle:X}";
}
