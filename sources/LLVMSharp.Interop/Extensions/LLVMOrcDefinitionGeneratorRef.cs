// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMOrcDefinitionGeneratorRef(IntPtr handle) : IDisposable, IEquatable<LLVMOrcDefinitionGeneratorRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMOrcDefinitionGeneratorRef(LLVMOrcOpaqueDefinitionGenerator* value) => new LLVMOrcDefinitionGeneratorRef((IntPtr)value);

    public static implicit operator LLVMOrcOpaqueDefinitionGenerator*(LLVMOrcDefinitionGeneratorRef value) => (LLVMOrcOpaqueDefinitionGenerator*)value.Handle;

    public static bool operator ==(LLVMOrcDefinitionGeneratorRef left, LLVMOrcDefinitionGeneratorRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMOrcDefinitionGeneratorRef left, LLVMOrcDefinitionGeneratorRef right) => !(left == right);

    public static LLVMOrcDefinitionGeneratorRef CreateCustomCAPIDefinitionGenerator(delegate* unmanaged[Cdecl]<LLVMOrcOpaqueDefinitionGenerator*, void*, LLVMOrcOpaqueLookupState**, LLVMOrcLookupKind, LLVMOrcOpaqueJITDylib*, LLVMOrcJITDylibLookupFlags, LLVMOrcCLookupSetElement*, nuint, LLVMOpaqueError*> F, void* Ctx, delegate* unmanaged[Cdecl]<void*, void> Dispose)
        => LLVM.OrcCreateCustomCAPIDefinitionGenerator(F, Ctx, Dispose);

    public static LLVMErrorRef CreateDynamicLibrarySearchGeneratorForProcess(out LLVMOrcDefinitionGeneratorRef Result, sbyte GlobalPrefix, delegate* unmanaged[Cdecl]<void*, LLVMOrcOpaqueSymbolStringPoolEntry*, int> Filter, void* FilterCtx)
    {
        fixed (LLVMOrcDefinitionGeneratorRef* pResult = &Result)
        {
            return LLVM.OrcCreateDynamicLibrarySearchGeneratorForProcess((LLVMOrcOpaqueDefinitionGenerator**)pResult, GlobalPrefix, Filter, FilterCtx);
        }
    }

    public static LLVMErrorRef CreateDynamicLibrarySearchGeneratorForPath(out LLVMOrcDefinitionGeneratorRef Result, ReadOnlySpan<char> FileName, sbyte GlobalPrefix, delegate* unmanaged[Cdecl]<void*, LLVMOrcOpaqueSymbolStringPoolEntry*, int> Filter, void* FilterCtx)
    {
        using var marshaledFileName = new MarshaledString(FileName);

        fixed (LLVMOrcDefinitionGeneratorRef* pResult = &Result)
        {
            return LLVM.OrcCreateDynamicLibrarySearchGeneratorForPath((LLVMOrcOpaqueDefinitionGenerator**)pResult, marshaledFileName, GlobalPrefix, Filter, FilterCtx);
        }
    }

    public static LLVMErrorRef CreateStaticLibrarySearchGeneratorForPath(out LLVMOrcDefinitionGeneratorRef Result, LLVMOrcObjectLayerRef ObjLayer, ReadOnlySpan<char> FileName)
    {
        using var marshaledFileName = new MarshaledString(FileName);

        fixed (LLVMOrcDefinitionGeneratorRef* pResult = &Result)
        {
            return LLVM.OrcCreateStaticLibrarySearchGeneratorForPath((LLVMOrcOpaqueDefinitionGenerator**)pResult, ObjLayer, marshaledFileName);
        }
    }

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.OrcDisposeDefinitionGenerator(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMOrcDefinitionGeneratorRef other) && Equals(other);

    public readonly bool Equals(LLVMOrcDefinitionGeneratorRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMOrcDefinitionGeneratorRef)}: {Handle:X}";
}
