// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcExecutionSessionRef(IntPtr handle) : IEquatable<LLVMOrcExecutionSessionRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcExecutionSessionRef(LLVMOrcOpaqueExecutionSession* value) => new LLVMOrcExecutionSessionRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueExecutionSession*(LLVMOrcExecutionSessionRef value) => (LLVMOrcOpaqueExecutionSession*)value.Handle;

    public static bool operator ==(LLVMOrcExecutionSessionRef left, LLVMOrcExecutionSessionRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcExecutionSessionRef left, LLVMOrcExecutionSessionRef right) => !(left == right);

    public readonly LLVMOrcSymbolStringPoolRef SymbolStringPool => (Handle != IntPtr.Zero) ? LLVM.OrcExecutionSessionGetSymbolStringPool(this) : default;

    public readonly LLVMOrcJITDylibRef CreateBareJITDylib(string Name) => CreateBareJITDylib(Name.AsSpan());

    public readonly LLVMOrcJITDylibRef CreateBareJITDylib(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.OrcExecutionSessionCreateBareJITDylib(this, marshaledName);
    }

    public readonly LLVMErrorRef CreateJITDylib(out LLVMOrcJITDylibRef Result, string Name) => CreateJITDylib(out Result, Name.AsSpan());

    public readonly LLVMErrorRef CreateJITDylib(out LLVMOrcJITDylibRef Result, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);

        fixed (LLVMOrcJITDylibRef* pResult = &Result)
        {
            return LLVM.OrcExecutionSessionCreateJITDylib(this, (LLVMOrcOpaqueJITDylib**)pResult, marshaledName);
        }
    }

    public readonly LLVMOrcObjectLayerRef CreateRTDyldObjectLinkingLayerWithSectionMemoryManager() => LLVM.OrcCreateRTDyldObjectLinkingLayerWithSectionMemoryManager(this);

    public readonly LLVMOrcObjectLayerRef CreateRTDyldObjectLinkingLayerWithMCJITMemoryManagerLikeCallbacks(void* CreateContextCtx, delegate* unmanaged[Cdecl]<void*, void*> CreateContext, delegate* unmanaged[Cdecl]<void*, void> NotifyTerminating, delegate* unmanaged[Cdecl]<void*, nuint, uint, uint, sbyte*, byte*> AllocateCodeSection, delegate* unmanaged[Cdecl]<void*, nuint, uint, uint, sbyte*, int, byte*> AllocateDataSection, delegate* unmanaged[Cdecl]<void*, sbyte**, int> FinalizeMemory, delegate* unmanaged[Cdecl]<void*, void> Destroy)
        => LLVM.OrcCreateRTDyldObjectLinkingLayerWithMCJITMemoryManagerLikeCallbacks(this, CreateContextCtx, CreateContext, NotifyTerminating, AllocateCodeSection, AllocateDataSection, FinalizeMemory, Destroy);

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcExecutionSessionRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcExecutionSessionRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly LLVMOrcJITDylibRef GetJITDylibByName(string Name) => GetJITDylibByName(Name.AsSpan());

    public readonly LLVMOrcJITDylibRef GetJITDylibByName(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.OrcExecutionSessionGetJITDylibByName(this, marshaledName);
    }

    public readonly LLVMOrcSymbolStringPoolEntryRef Intern(string Name) => Intern(Name.AsSpan());

    public readonly LLVMOrcSymbolStringPoolEntryRef Intern(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.OrcExecutionSessionIntern(this, marshaledName);
    }

    // Takes ownership of the symbols in the lookup set. HandleResult is called with the result.
    public readonly void Lookup(LLVMOrcLookupKind K, LLVMOrcCJITDylibSearchOrderElement* SearchOrder, nuint SearchOrderSize, LLVMOrcCLookupSetElement* Symbols, nuint SymbolsSize, delegate* unmanaged[Cdecl]<LLVMOpaqueError*, LLVMOrcCSymbolMapPair*, nuint, void*, void> HandleResult, void* Ctx)
        => LLVM.OrcExecutionSessionLookup(this, K, SearchOrder, SearchOrderSize, Symbols, SymbolsSize, HandleResult, Ctx);

    public readonly void SetErrorReporter(delegate* unmanaged[Cdecl]<void*, LLVMOpaqueError*, void> ReportError, void* Ctx) => LLVM.OrcExecutionSessionSetErrorReporter(this, ReportError, Ctx);

    public override readonly string ToString() => $"{nameof(LLVMOrcExecutionSessionRef)}: {Handle:X}";
}
