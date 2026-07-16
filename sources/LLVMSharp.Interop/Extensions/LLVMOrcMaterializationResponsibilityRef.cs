// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcMaterializationResponsibilityRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcMaterializationResponsibilityRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcMaterializationResponsibilityRef(LLVMOrcOpaqueMaterializationResponsibility* value) => new LLVMOrcMaterializationResponsibilityRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueMaterializationResponsibility*(LLVMOrcMaterializationResponsibilityRef value) => (LLVMOrcOpaqueMaterializationResponsibility*)value.Handle;

    public static bool operator ==(LLVMOrcMaterializationResponsibilityRef left, LLVMOrcMaterializationResponsibilityRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcMaterializationResponsibilityRef left, LLVMOrcMaterializationResponsibilityRef right) => !(left == right);

    public readonly LLVMOrcExecutionSessionRef ExecutionSession => (Handle != IntPtr.Zero) ? LLVM.OrcMaterializationResponsibilityGetExecutionSession(this) : default;

    public readonly LLVMOrcSymbolStringPoolEntryRef InitializerSymbol => (Handle != IntPtr.Zero) ? LLVM.OrcMaterializationResponsibilityGetInitializerSymbol(this) : default;

    public readonly LLVMOrcJITDylibRef TargetDylib => (Handle != IntPtr.Zero) ? LLVM.OrcMaterializationResponsibilityGetTargetDylib(this) : default;

    // Frees a symbol flags map returned by GetSymbols.
    public static void DisposeCSymbolFlagsMap(LLVMOrcCSymbolFlagsMapPair* Pairs) => LLVM.OrcDisposeCSymbolFlagsMap(Pairs);

    // Frees a symbols array returned by GetRequestedSymbols.
    public static void DisposeSymbols(LLVMOrcOpaqueSymbolStringPoolEntry** Symbols) => LLVM.OrcDisposeSymbols(Symbols);

    // Takes ownership of the flags in Pairs.
    public readonly LLVMErrorRef DefineMaterializing(LLVMOrcCSymbolFlagsMapPair* Pairs, nuint NumPairs) => LLVM.OrcMaterializationResponsibilityDefineMaterializing(this, Pairs, NumPairs);

    // Transfers the given symbols to a new MaterializationResponsibility returned through Result.
    public readonly LLVMErrorRef Delegate(LLVMOrcOpaqueSymbolStringPoolEntry** Symbols, nuint NumSymbols, out LLVMOrcMaterializationResponsibilityRef Result)
    {
        fixed (LLVMOrcMaterializationResponsibilityRef* pResult = &Result)
        {
            return LLVM.OrcMaterializationResponsibilityDelegate(this, Symbols, NumSymbols, (LLVMOrcOpaqueMaterializationResponsibility**)pResult);
        }
    }

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.OrcDisposeMaterializationResponsibility(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcMaterializationResponsibilityRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcMaterializationResponsibilityRef other) => this == other;

    public readonly void FailMaterialization() => LLVM.OrcMaterializationResponsibilityFailMaterialization(this);

    public override readonly int GetHashCode() => Handle.GetHashCode();

    // The returned map is owned by the caller and must be freed with DisposeCSymbolFlagsMap.
    public readonly LLVMOrcCSymbolFlagsMapPair* GetSymbols(out nuint NumPairs)
    {
        fixed (nuint* pNumPairs = &NumPairs)
        {
            return LLVM.OrcMaterializationResponsibilityGetSymbols(this, pNumPairs);
        }
    }

    // The returned array is owned by the caller and must be freed with DisposeSymbols.
    public readonly LLVMOrcOpaqueSymbolStringPoolEntry** GetRequestedSymbols(out nuint NumSymbols)
    {
        fixed (nuint* pNumSymbols = &NumSymbols)
        {
            return LLVM.OrcMaterializationResponsibilityGetRequestedSymbols(this, pNumSymbols);
        }
    }

    public readonly LLVMErrorRef NotifyEmitted(LLVMOrcCSymbolDependenceGroup* SymbolDepGroups, nuint NumSymbolDepGroups) => LLVM.OrcMaterializationResponsibilityNotifyEmitted(this, SymbolDepGroups, NumSymbolDepGroups);

    public readonly LLVMErrorRef NotifyResolved(LLVMOrcCSymbolMapPair* Symbols, nuint NumPairs) => LLVM.OrcMaterializationResponsibilityNotifyResolved(this, Symbols, NumPairs);

    // Takes ownership of MU.
    public readonly LLVMErrorRef Replace(LLVMOrcMaterializationUnitRef MU) => LLVM.OrcMaterializationResponsibilityReplace(this, MU);

    public override readonly string ToString() => $"{nameof(LLVMOrcMaterializationResponsibilityRef)}: {Handle:X}";
}
