// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcLLJITRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcLLJITRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcLLJITRef(LLVMOrcOpaqueLLJIT* value) => new LLVMOrcLLJITRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueLLJIT*(LLVMOrcLLJITRef value) => (LLVMOrcOpaqueLLJIT*)value.Handle;

    public static bool operator ==(LLVMOrcLLJITRef left, LLVMOrcLLJITRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcLLJITRef left, LLVMOrcLLJITRef right) => !(left == right);

    public readonly LLVMOrcExecutionSessionRef ExecutionSession => (Handle != IntPtr.Zero) ? LLVM.OrcLLJITGetExecutionSession(this) : default;

    public readonly LLVMOrcJITDylibRef MainJITDylib => (Handle != IntPtr.Zero) ? LLVM.OrcLLJITGetMainJITDylib(this) : default;

    public readonly LLVMOrcObjectLayerRef ObjLinkingLayer => (Handle != IntPtr.Zero) ? LLVM.OrcLLJITGetObjLinkingLayer(this) : default;

    public readonly LLVMOrcObjectTransformLayerRef ObjTransformLayer => (Handle != IntPtr.Zero) ? LLVM.OrcLLJITGetObjTransformLayer(this) : default;

    public readonly LLVMOrcIRTransformLayerRef IRTransformLayer => (Handle != IntPtr.Zero) ? LLVM.OrcLLJITGetIRTransformLayer(this) : default;

    public readonly sbyte GlobalPrefix => (Handle != IntPtr.Zero) ? LLVM.OrcLLJITGetGlobalPrefix(this) : default;

    // The returned string is owned by the LLJIT instance and must not be freed by the caller.
    public readonly string TripleString => (Handle != IntPtr.Zero) ? SpanExtensions.AsString(LLVM.OrcLLJITGetTripleString(this)) : string.Empty;

    // The returned string is owned by the LLJIT instance and must not be freed by the caller.
    public readonly string DataLayoutStr => (Handle != IntPtr.Zero) ? SpanExtensions.AsString(LLVM.OrcLLJITGetDataLayoutStr(this)) : string.Empty;

    public static LLVMErrorRef Create(out LLVMOrcLLJITRef Result, LLVMOrcLLJITBuilderRef Builder)
    {
        fixed (LLVMOrcLLJITRef* pResult = &Result)
        {
            return LLVM.OrcCreateLLJIT((LLVMOrcOpaqueLLJIT**)pResult, Builder);
        }
    }

    public readonly LLVMErrorRef AddObjectFile(LLVMOrcJITDylibRef JD, LLVMMemoryBufferRef ObjBuffer) => LLVM.OrcLLJITAddObjectFile(this, JD, ObjBuffer);

    public readonly LLVMErrorRef AddObjectFileWithRT(LLVMOrcResourceTrackerRef RT, LLVMMemoryBufferRef ObjBuffer) => LLVM.OrcLLJITAddObjectFileWithRT(this, RT, ObjBuffer);

    // Takes ownership of TSM.
    public readonly LLVMErrorRef AddLLVMIRModule(LLVMOrcJITDylibRef JD, LLVMOrcThreadSafeModuleRef TSM) => LLVM.OrcLLJITAddLLVMIRModule(this, JD, TSM);

    // Takes ownership of TSM.
    public readonly LLVMErrorRef AddLLVMIRModuleWithRT(LLVMOrcResourceTrackerRef RT, LLVMOrcThreadSafeModuleRef TSM) => LLVM.OrcLLJITAddLLVMIRModuleWithRT(this, RT, TSM);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            _ = LLVM.OrcDisposeLLJIT(this);
            Handle = IntPtr.Zero;
        }
    }

    public readonly LLVMErrorRef EnableDebugSupport() => LLVM.OrcLLJITEnableDebugSupport(this);

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcLLJITRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcLLJITRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly LLVMErrorRef Lookup(out ulong Result, string Name) => Lookup(out Result, Name.AsSpan());

    public readonly LLVMErrorRef Lookup(out ulong Result, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);

        fixed (ulong* pResult = &Result)
        {
            return LLVM.OrcLLJITLookup(this, pResult, marshaledName);
        }
    }

    public readonly LLVMOrcSymbolStringPoolEntryRef MangleAndIntern(string UnmangledName) => MangleAndIntern(UnmangledName.AsSpan());

    public readonly LLVMOrcSymbolStringPoolEntryRef MangleAndIntern(ReadOnlySpan<char> UnmangledName)
    {
        using var marshaledName = new MarshaledString(UnmangledName);
        return LLVM.OrcLLJITMangleAndIntern(this, marshaledName);
    }

    public override readonly string ToString() => $"{nameof(LLVMOrcLLJITRef)}: {Handle:X}";
}
