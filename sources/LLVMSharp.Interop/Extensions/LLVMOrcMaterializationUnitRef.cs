// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcMaterializationUnitRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcMaterializationUnitRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcMaterializationUnitRef(LLVMOrcOpaqueMaterializationUnit* value) => new LLVMOrcMaterializationUnitRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueMaterializationUnit*(LLVMOrcMaterializationUnitRef value) => (LLVMOrcOpaqueMaterializationUnit*)value.Handle;

    public static bool operator ==(LLVMOrcMaterializationUnitRef left, LLVMOrcMaterializationUnitRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcMaterializationUnitRef left, LLVMOrcMaterializationUnitRef right) => !(left == right);

    // Takes ownership of the pairs in Syms and of InitSym.
    public static LLVMOrcMaterializationUnitRef CreateCustom(ReadOnlySpan<char> Name, void* Ctx, LLVMOrcCSymbolFlagsMapPair* Syms, nuint NumSyms, LLVMOrcSymbolStringPoolEntryRef InitSym, delegate* unmanaged[Cdecl]<void*, LLVMOrcOpaqueMaterializationResponsibility*, void> Materialize, delegate* unmanaged[Cdecl]<void*, LLVMOrcOpaqueJITDylib*, LLVMOrcOpaqueSymbolStringPoolEntry*, void> Discard, delegate* unmanaged[Cdecl]<void*, void> Destroy)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.OrcCreateCustomMaterializationUnit(marshaledName, Ctx, Syms, NumSyms, InitSym, Materialize, Discard, Destroy);
    }

    // Takes ownership of the pairs in Syms.
    public static LLVMOrcMaterializationUnitRef AbsoluteSymbols(LLVMOrcCSymbolMapPair* Syms, nuint NumPairs) => LLVM.OrcAbsoluteSymbols(Syms, NumPairs);

    // Takes ownership of the aliases in CallableAliases.
    public static LLVMOrcMaterializationUnitRef LazyReexports(LLVMOrcLazyCallThroughManagerRef LCTM, LLVMOrcIndirectStubsManagerRef ISM, LLVMOrcJITDylibRef SourceRef, LLVMOrcCSymbolAliasMapPair* CallableAliases, nuint NumPairs) => LLVM.OrcLazyReexports(LCTM, ISM, SourceRef, CallableAliases, NumPairs);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.OrcDisposeMaterializationUnit(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcMaterializationUnitRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcMaterializationUnitRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMOrcMaterializationUnitRef)}: {Handle:X}";
}
