// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMDIBuilderRef(IntPtr handle) : IDisposable, IEquatable<LLVMDIBuilderRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMDIBuilderRef(LLVMOpaqueDIBuilder* value) => new LLVMDIBuilderRef((IntPtr)value);

    public static implicit operator LLVMOpaqueDIBuilder*(LLVMDIBuilderRef value) => (LLVMOpaqueDIBuilder*)value.Handle;

    public static bool operator ==(LLVMDIBuilderRef left, LLVMDIBuilderRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMDIBuilderRef left, LLVMDIBuilderRef right) => !(left == right);

    public readonly LLVMMetadataRef CreateCompileUnit(LLVMDWARFSourceLanguage SourceLanguage, LLVMMetadataRef FileMetadata, string Producer, int IsOptimized, string Flags, uint RuntimeVersion,
        string SplitName, LLVMDWARFEmissionKind DwarfEmissionKind, uint DWOld, int SplitDebugInlining, int DebugInfoForProfiling, string SysRoot, string SDK) => CreateCompileUnit(SourceLanguage, FileMetadata, Producer.AsSpan(), IsOptimized, Flags.AsSpan(), RuntimeVersion, SplitName.AsSpan(), DwarfEmissionKind, DWOld, SplitDebugInlining, DebugInfoForProfiling, SysRoot.AsSpan(), SDK.AsSpan());

    public readonly LLVMMetadataRef CreateCompileUnit(LLVMDWARFSourceLanguage SourceLanguage, LLVMMetadataRef FileMetadata, ReadOnlySpan<char> Producer, int IsOptimized, ReadOnlySpan<char> Flags, uint RuntimeVersion,
        ReadOnlySpan<char> SplitName, LLVMDWARFEmissionKind DwarfEmissionKind, uint DWOld, int SplitDebugInlining, int DebugInfoForProfiling, ReadOnlySpan<char> SysRoot, ReadOnlySpan<char> SDK)
    {
        using var marshaledProducer= new MarshaledString(Producer);
        using var marshaledFlags = new MarshaledString(Flags);
        using var marshaledSplitNameFlags = new MarshaledString(SplitName);
        using var marshaledSysRoot = new MarshaledString(SysRoot);
        using var marshaledSDK = new MarshaledString(SDK);

        return LLVM.DIBuilderCreateCompileUnit(this, SourceLanguage, FileMetadata, marshaledProducer, (UIntPtr)marshaledProducer.Length, IsOptimized, marshaledFlags, (UIntPtr)marshaledFlags.Length,
            RuntimeVersion, marshaledSplitNameFlags, (UIntPtr)marshaledSplitNameFlags.Length, DwarfEmissionKind, DWOld, SplitDebugInlining, DebugInfoForProfiling, marshaledSysRoot, (UIntPtr)marshaledSysRoot.Length, marshaledSDK, (UIntPtr)marshaledSDK.Length);
    }

    public readonly LLVMMetadataRef CreateFile(string FullPath, string Directory) => CreateFile(FullPath.AsSpan(), Directory.AsSpan());

    public readonly LLVMMetadataRef CreateFile(ReadOnlySpan<char> FullPath, ReadOnlySpan<char> Directory)
    {
        using var marshaledFullPath = new MarshaledString(FullPath);
        using var marshaledDirectory = new MarshaledString(Directory);
        return LLVM.DIBuilderCreateFile(this, marshaledFullPath, (UIntPtr)marshaledFullPath.Length, marshaledDirectory, (UIntPtr)marshaledDirectory.Length);
    }

    public readonly LLVMMetadataRef CreateFunction(LLVMMetadataRef Scope, string Name, string LinkageName, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Type, int IsLocalToUnit, int IsDefinition,
        uint ScopeLine, LLVMDIFlags Flags, int IsOptimized) => CreateFunction(Scope, Name.AsSpan(), LinkageName.AsSpan(), File, LineNo, Type, IsLocalToUnit, IsDefinition, ScopeLine, Flags, IsOptimized);

    public readonly LLVMMetadataRef CreateFunction(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, ReadOnlySpan<char> LinkageName, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Type, int IsLocalToUnit, int IsDefinition,
        uint ScopeLine, LLVMDIFlags Flags, int IsOptimized)
    {
        using var marshaledName = new MarshaledString(Name);
        using var marshaledLinkageName = new MarshaledString(LinkageName);
        var methodNameLength = (uint)marshaledName.Length;
        var linkageNameLength = (uint)marshaledLinkageName.Length;

        return LLVM.DIBuilderCreateFunction(this, Scope, marshaledName, (UIntPtr)(methodNameLength), marshaledLinkageName, (UIntPtr)(linkageNameLength), File,
            LineNo, Type, IsLocalToUnit, IsDefinition, ScopeLine, Flags, IsOptimized);
    }

    public readonly LLVMMetadataRef CreateMacro(LLVMMetadataRef ParentMacroFile, uint Line, LLVMDWARFMacinfoRecordType RecordType, string Name, string Value) => CreateMacro(ParentMacroFile, Line, RecordType, Name.AsSpan(), Value.AsSpan());

    public readonly LLVMMetadataRef CreateMacro(LLVMMetadataRef ParentMacroFile, uint Line, LLVMDWARFMacinfoRecordType RecordType, ReadOnlySpan<char> Name, ReadOnlySpan<char> Value)
    {
        using var marshaledName = new MarshaledString(Name);
        using var marshaledValue = new MarshaledString(Value);
        var nameLength = (uint)marshaledName.Length;
        var valueLength = (uint)marshaledValue.Length;

        return LLVM.DIBuilderCreateMacro(this, ParentMacroFile, Line, RecordType, marshaledName, (UIntPtr)nameLength, marshaledValue, (UIntPtr)valueLength);
    }

    public readonly LLVMMetadataRef CreateModule(LLVMMetadataRef ParentScope, string Name, string ConfigMacros, string IncludePath, string SysRoot) => CreateModule(ParentScope, Name.AsSpan(), ConfigMacros.AsSpan(), IncludePath.AsSpan(), SysRoot.AsSpan());

    public readonly LLVMMetadataRef CreateModule(LLVMMetadataRef ParentScope, ReadOnlySpan<char> Name, ReadOnlySpan<char> ConfigMacros, ReadOnlySpan<char> IncludePath, ReadOnlySpan<char> SysRoot)
    {
        using var marshaledName = new MarshaledString(Name);
        using var marshaledConfigMacros = new MarshaledString(ConfigMacros);
        using var marshaledIncludePath = new MarshaledString(IncludePath);
        using var marshaledSysRoot = new MarshaledString(SysRoot);
        var nameLength = (uint)marshaledName.Length;
        var configMacrosLength = (uint)marshaledConfigMacros.Length;
        var includePathLength = (uint)marshaledIncludePath.Length;
        var sysRootLength = (uint)marshaledSysRoot.Length;

        return LLVM.DIBuilderCreateModule(this, ParentScope, marshaledName, (UIntPtr)nameLength, marshaledConfigMacros, (UIntPtr)configMacrosLength, marshaledIncludePath, (UIntPtr)includePathLength, marshaledSysRoot, (UIntPtr)sysRootLength);
    }

    public readonly LLVMMetadataRef CreateSubroutineType(LLVMMetadataRef File, LLVMMetadataRef[] ParameterTypes, LLVMDIFlags Flags) => CreateSubroutineType(File, ParameterTypes.AsSpan(), Flags);

    public readonly LLVMMetadataRef CreateSubroutineType(LLVMMetadataRef File, ReadOnlySpan<LLVMMetadataRef> ParameterTypes, LLVMDIFlags Flags)
    {
        fixed (LLVMMetadataRef* pParameterTypes = ParameterTypes)
        {
            return LLVM.DIBuilderCreateSubroutineType(this, File, (LLVMOpaqueMetadata**)pParameterTypes, (uint)ParameterTypes.Length, Flags);
        }
    }

    public readonly LLVMMetadataRef CreateTempMacroFile(LLVMMetadataRef ParentMacroFile, uint Line, LLVMMetadataRef File) => LLVM.DIBuilderCreateTempMacroFile(this, ParentMacroFile, Line, File);

    public readonly LLVMMetadataRef CreateTypedef(LLVMMetadataRef Type, string Name, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Scope, uint AlignInBits) => CreateTypedef(Type, Name.AsSpan(), File, LineNo, Scope, AlignInBits);

    public readonly LLVMMetadataRef CreateTypedef(LLVMMetadataRef Type, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Scope, uint AlignInBits)
    {
        using var marshaledName = new MarshaledString(Name);
        var nameLength = (uint)marshaledName.Length;

        return LLVM.DIBuilderCreateTypedef(this, Type, marshaledName, (UIntPtr)nameLength, File, LineNo, Scope, AlignInBits);
    }

    public readonly LLVMMetadataRef CreateArrayType(ulong Size, uint AlignInBits, LLVMMetadataRef Ty, LLVMMetadataRef[] Subscripts) => CreateArrayType(Size, AlignInBits, Ty, Subscripts.AsSpan());

    public readonly LLVMMetadataRef CreateArrayType(ulong Size, uint AlignInBits, LLVMMetadataRef Ty, ReadOnlySpan<LLVMMetadataRef> Subscripts)
    {
        fixed (LLVMMetadataRef* pSubscripts = Subscripts)
        {
            return LLVM.DIBuilderCreateArrayType(this, Size, AlignInBits, Ty, (LLVMOpaqueMetadata**)pSubscripts, (uint)Subscripts.Length);
        }
    }

    public readonly LLVMMetadataRef CreateArtificialType(LLVMMetadataRef Type) => LLVM.DIBuilderCreateArtificialType(this, Type);

    public readonly LLVMMetadataRef CreateAutoVariable(LLVMMetadataRef Scope, string Name, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Ty, int AlwaysPreserve, LLVMDIFlags Flags, uint AlignInBits) => CreateAutoVariable(Scope, Name.AsSpan(), File, LineNo, Ty, AlwaysPreserve, Flags, AlignInBits);

    public readonly LLVMMetadataRef CreateAutoVariable(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Ty, int AlwaysPreserve, LLVMDIFlags Flags, uint AlignInBits)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateAutoVariable(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, File, LineNo, Ty, AlwaysPreserve, Flags, AlignInBits);
    }

    public readonly LLVMMetadataRef CreateBasicType(string Name, ulong SizeInBits, uint Encoding, LLVMDIFlags Flags) => CreateBasicType(Name.AsSpan(), SizeInBits, Encoding, Flags);

    public readonly LLVMMetadataRef CreateBasicType(ReadOnlySpan<char> Name, ulong SizeInBits, uint Encoding, LLVMDIFlags Flags)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateBasicType(this, marshaledName, (UIntPtr)marshaledName.Length, SizeInBits, Encoding, Flags);
    }

    public readonly LLVMMetadataRef CreateBitFieldMemberType(LLVMMetadataRef Scope, string Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, ulong OffsetInBits, ulong StorageOffsetInBits, LLVMDIFlags Flags, LLVMMetadataRef Type) => CreateBitFieldMemberType(Scope, Name.AsSpan(), File, LineNumber, SizeInBits, OffsetInBits, StorageOffsetInBits, Flags, Type);

    public readonly LLVMMetadataRef CreateBitFieldMemberType(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, ulong OffsetInBits, ulong StorageOffsetInBits, LLVMDIFlags Flags, LLVMMetadataRef Type)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateBitFieldMemberType(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, File, LineNumber, SizeInBits, OffsetInBits, StorageOffsetInBits, Flags, Type);
    }

    public readonly LLVMMetadataRef CreateClassType(LLVMMetadataRef Scope, string Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, uint AlignInBits, ulong OffsetInBits, LLVMDIFlags Flags, LLVMMetadataRef DerivedFrom, LLVMMetadataRef[] Elements, LLVMMetadataRef VTableHolder, LLVMMetadataRef TemplateParamsNode, string UniqueIdentifier) => CreateClassType(Scope, Name.AsSpan(), File, LineNumber, SizeInBits, AlignInBits, OffsetInBits, Flags, DerivedFrom, Elements.AsSpan(), VTableHolder, TemplateParamsNode, UniqueIdentifier.AsSpan());

    public readonly LLVMMetadataRef CreateClassType(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, uint AlignInBits, ulong OffsetInBits, LLVMDIFlags Flags, LLVMMetadataRef DerivedFrom, ReadOnlySpan<LLVMMetadataRef> Elements, LLVMMetadataRef VTableHolder, LLVMMetadataRef TemplateParamsNode, ReadOnlySpan<char> UniqueIdentifier)
    {
        using var marshaledName = new MarshaledString(Name);
        using var marshaledUniqueIdentifier = new MarshaledString(UniqueIdentifier);

        fixed (LLVMMetadataRef* pElements = Elements)
        {
            return LLVM.DIBuilderCreateClassType(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, File, LineNumber, SizeInBits, AlignInBits, OffsetInBits, Flags, DerivedFrom, (LLVMOpaqueMetadata**)pElements, (uint)Elements.Length, VTableHolder, TemplateParamsNode, marshaledUniqueIdentifier, (UIntPtr)marshaledUniqueIdentifier.Length);
        }
    }

    public readonly LLVMMetadataRef CreateConstantValueExpression(ulong Value) => LLVM.DIBuilderCreateConstantValueExpression(this, Value);

    public readonly LLVMMetadataRef CreateDynamicArrayType(LLVMMetadataRef Scope, string Name, uint LineNo, LLVMMetadataRef File, ulong Size, uint AlignInBits, LLVMMetadataRef Ty, LLVMMetadataRef[] Subscripts, LLVMMetadataRef DataLocation, LLVMMetadataRef Associated, LLVMMetadataRef Allocated, LLVMMetadataRef Rank, LLVMMetadataRef BitStride) => CreateDynamicArrayType(Scope, Name.AsSpan(), LineNo, File, Size, AlignInBits, Ty, Subscripts.AsSpan(), DataLocation, Associated, Allocated, Rank, BitStride);

    public readonly LLVMMetadataRef CreateDynamicArrayType(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, uint LineNo, LLVMMetadataRef File, ulong Size, uint AlignInBits, LLVMMetadataRef Ty, ReadOnlySpan<LLVMMetadataRef> Subscripts, LLVMMetadataRef DataLocation, LLVMMetadataRef Associated, LLVMMetadataRef Allocated, LLVMMetadataRef Rank, LLVMMetadataRef BitStride)
    {
        using var marshaledName = new MarshaledString(Name);

        fixed (LLVMMetadataRef* pSubscripts = Subscripts)
        {
            return LLVM.DIBuilderCreateDynamicArrayType(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, LineNo, File, Size, AlignInBits, Ty, (LLVMOpaqueMetadata**)pSubscripts, (uint)Subscripts.Length, DataLocation, Associated, Allocated, Rank, BitStride);
        }
    }

    public readonly LLVMMetadataRef CreateEnumerationType(LLVMMetadataRef Scope, string Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, uint AlignInBits, LLVMMetadataRef[] Elements, LLVMMetadataRef ClassTy) => CreateEnumerationType(Scope, Name.AsSpan(), File, LineNumber, SizeInBits, AlignInBits, Elements.AsSpan(), ClassTy);

    public readonly LLVMMetadataRef CreateEnumerationType(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, uint AlignInBits, ReadOnlySpan<LLVMMetadataRef> Elements, LLVMMetadataRef ClassTy)
    {
        using var marshaledName = new MarshaledString(Name);

        fixed (LLVMMetadataRef* pElements = Elements)
        {
            return LLVM.DIBuilderCreateEnumerationType(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, File, LineNumber, SizeInBits, AlignInBits, (LLVMOpaqueMetadata**)pElements, (uint)Elements.Length, ClassTy);
        }
    }

    public readonly LLVMMetadataRef CreateEnumerator(string Name, long Value, int IsUnsigned) => CreateEnumerator(Name.AsSpan(), Value, IsUnsigned);

    public readonly LLVMMetadataRef CreateEnumerator(ReadOnlySpan<char> Name, long Value, int IsUnsigned)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateEnumerator(this, marshaledName, (UIntPtr)marshaledName.Length, Value, IsUnsigned);
    }

    public readonly LLVMMetadataRef CreateEnumeratorOfArbitraryPrecision(string Name, ulong SizeInBits, ReadOnlySpan<ulong> Words, int IsUnsigned) => CreateEnumeratorOfArbitraryPrecision(Name.AsSpan(), SizeInBits, Words, IsUnsigned);

    public readonly LLVMMetadataRef CreateEnumeratorOfArbitraryPrecision(ReadOnlySpan<char> Name, ulong SizeInBits, ReadOnlySpan<ulong> Words, int IsUnsigned)
    {
        using var marshaledName = new MarshaledString(Name);

        fixed (ulong* pWords = Words)
        {
            return LLVM.DIBuilderCreateEnumeratorOfArbitraryPrecision(this, marshaledName, (UIntPtr)marshaledName.Length, SizeInBits, pWords, IsUnsigned);
        }
    }

    public readonly LLVMMetadataRef CreateExpression(ulong[] Addr) => CreateExpression(Addr.AsSpan());

    public readonly LLVMMetadataRef CreateExpression(ReadOnlySpan<ulong> Addr)
    {
        fixed (ulong* pAddr = Addr)
        {
            return LLVM.DIBuilderCreateExpression(this, pAddr, (UIntPtr)Addr.Length);
        }
    }

    public readonly LLVMMetadataRef CreateForwardDecl(uint Tag, string Name, LLVMMetadataRef Scope, LLVMMetadataRef File, uint Line, uint RuntimeLang, ulong SizeInBits, uint AlignInBits, string UniqueIdentifier) => CreateForwardDecl(Tag, Name.AsSpan(), Scope, File, Line, RuntimeLang, SizeInBits, AlignInBits, UniqueIdentifier.AsSpan());

    public readonly LLVMMetadataRef CreateForwardDecl(uint Tag, ReadOnlySpan<char> Name, LLVMMetadataRef Scope, LLVMMetadataRef File, uint Line, uint RuntimeLang, ulong SizeInBits, uint AlignInBits, ReadOnlySpan<char> UniqueIdentifier)
    {
        using var marshaledName = new MarshaledString(Name);
        using var marshaledUniqueIdentifier = new MarshaledString(UniqueIdentifier);
        return LLVM.DIBuilderCreateForwardDecl(this, Tag, marshaledName, (UIntPtr)marshaledName.Length, Scope, File, Line, RuntimeLang, SizeInBits, AlignInBits, marshaledUniqueIdentifier, (UIntPtr)marshaledUniqueIdentifier.Length);
    }

    public readonly LLVMMetadataRef CreateGlobalVariableExpression(LLVMMetadataRef Scope, string Name, string Linkage, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Ty, int LocalToUnit, LLVMMetadataRef Expr, LLVMMetadataRef Decl, uint AlignInBits) => CreateGlobalVariableExpression(Scope, Name.AsSpan(), Linkage.AsSpan(), File, LineNo, Ty, LocalToUnit, Expr, Decl, AlignInBits);

    public readonly LLVMMetadataRef CreateGlobalVariableExpression(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, ReadOnlySpan<char> Linkage, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Ty, int LocalToUnit, LLVMMetadataRef Expr, LLVMMetadataRef Decl, uint AlignInBits)
    {
        using var marshaledName = new MarshaledString(Name);
        using var marshaledLinkage = new MarshaledString(Linkage);
        return LLVM.DIBuilderCreateGlobalVariableExpression(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, marshaledLinkage, (UIntPtr)marshaledLinkage.Length, File, LineNo, Ty, LocalToUnit, Expr, Decl, AlignInBits);
    }

    public readonly LLVMMetadataRef CreateImportedDeclaration(LLVMMetadataRef Scope, LLVMMetadataRef Decl, LLVMMetadataRef File, uint Line, string Name, LLVMMetadataRef[] Elements) => CreateImportedDeclaration(Scope, Decl, File, Line, Name.AsSpan(), Elements.AsSpan());

    public readonly LLVMMetadataRef CreateImportedDeclaration(LLVMMetadataRef Scope, LLVMMetadataRef Decl, LLVMMetadataRef File, uint Line, ReadOnlySpan<char> Name, ReadOnlySpan<LLVMMetadataRef> Elements)
    {
        using var marshaledName = new MarshaledString(Name);

        fixed (LLVMMetadataRef* pElements = Elements)
        {
            return LLVM.DIBuilderCreateImportedDeclaration(this, Scope, Decl, File, Line, marshaledName, (UIntPtr)marshaledName.Length, (LLVMOpaqueMetadata**)pElements, (uint)Elements.Length);
        }
    }

    public readonly LLVMMetadataRef CreateImportedModuleFromAlias(LLVMMetadataRef Scope, LLVMMetadataRef ImportedEntity, LLVMMetadataRef File, uint Line, LLVMMetadataRef[] Elements) => CreateImportedModuleFromAlias(Scope, ImportedEntity, File, Line, Elements.AsSpan());

    public readonly LLVMMetadataRef CreateImportedModuleFromAlias(LLVMMetadataRef Scope, LLVMMetadataRef ImportedEntity, LLVMMetadataRef File, uint Line, ReadOnlySpan<LLVMMetadataRef> Elements)
    {
        fixed (LLVMMetadataRef* pElements = Elements)
        {
            return LLVM.DIBuilderCreateImportedModuleFromAlias(this, Scope, ImportedEntity, File, Line, (LLVMOpaqueMetadata**)pElements, (uint)Elements.Length);
        }
    }

    public readonly LLVMMetadataRef CreateImportedModuleFromModule(LLVMMetadataRef Scope, LLVMMetadataRef M, LLVMMetadataRef File, uint Line, LLVMMetadataRef[] Elements) => CreateImportedModuleFromModule(Scope, M, File, Line, Elements.AsSpan());

    public readonly LLVMMetadataRef CreateImportedModuleFromModule(LLVMMetadataRef Scope, LLVMMetadataRef M, LLVMMetadataRef File, uint Line, ReadOnlySpan<LLVMMetadataRef> Elements)
    {
        fixed (LLVMMetadataRef* pElements = Elements)
        {
            return LLVM.DIBuilderCreateImportedModuleFromModule(this, Scope, M, File, Line, (LLVMOpaqueMetadata**)pElements, (uint)Elements.Length);
        }
    }

    public readonly LLVMMetadataRef CreateImportedModuleFromNamespace(LLVMMetadataRef Scope, LLVMMetadataRef NS, LLVMMetadataRef File, uint Line) => LLVM.DIBuilderCreateImportedModuleFromNamespace(this, Scope, NS, File, Line);

    public readonly LLVMMetadataRef CreateInheritance(LLVMMetadataRef Ty, LLVMMetadataRef BaseTy, ulong BaseOffset, uint VBPtrOffset, LLVMDIFlags Flags) => LLVM.DIBuilderCreateInheritance(this, Ty, BaseTy, BaseOffset, VBPtrOffset, Flags);

    public readonly LLVMMetadataRef CreateLabel(LLVMMetadataRef Context, string Name, LLVMMetadataRef File, uint LineNo, int AlwaysPreserve) => CreateLabel(Context, Name.AsSpan(), File, LineNo, AlwaysPreserve);

    public readonly LLVMMetadataRef CreateLabel(LLVMMetadataRef Context, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNo, int AlwaysPreserve)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateLabel(this, Context, marshaledName, (UIntPtr)marshaledName.Length, File, LineNo, AlwaysPreserve);
    }

    public readonly LLVMMetadataRef CreateLexicalBlock(LLVMMetadataRef Scope, LLVMMetadataRef File, uint Line, uint Column) => LLVM.DIBuilderCreateLexicalBlock(this, Scope, File, Line, Column);

    public readonly LLVMMetadataRef CreateLexicalBlockFile(LLVMMetadataRef Scope, LLVMMetadataRef File, uint Discriminator) => LLVM.DIBuilderCreateLexicalBlockFile(this, Scope, File, Discriminator);

    public readonly LLVMMetadataRef CreateMemberPointerType(LLVMMetadataRef PointeeType, LLVMMetadataRef ClassType, ulong SizeInBits, uint AlignInBits, LLVMDIFlags Flags) => LLVM.DIBuilderCreateMemberPointerType(this, PointeeType, ClassType, SizeInBits, AlignInBits, Flags);

    public readonly LLVMMetadataRef CreateMemberType(LLVMMetadataRef Scope, string Name, LLVMMetadataRef File, uint LineNo, ulong SizeInBits, uint AlignInBits, ulong OffsetInBits, LLVMDIFlags Flags, LLVMMetadataRef Ty) => CreateMemberType(Scope, Name.AsSpan(), File, LineNo, SizeInBits, AlignInBits, OffsetInBits, Flags, Ty);

    public readonly LLVMMetadataRef CreateMemberType(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNo, ulong SizeInBits, uint AlignInBits, ulong OffsetInBits, LLVMDIFlags Flags, LLVMMetadataRef Ty)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateMemberType(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, File, LineNo, SizeInBits, AlignInBits, OffsetInBits, Flags, Ty);
    }

    public readonly LLVMMetadataRef CreateNameSpace(LLVMMetadataRef ParentScope, string Name, int ExportSymbols) => CreateNameSpace(ParentScope, Name.AsSpan(), ExportSymbols);

    public readonly LLVMMetadataRef CreateNameSpace(LLVMMetadataRef ParentScope, ReadOnlySpan<char> Name, int ExportSymbols)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateNameSpace(this, ParentScope, marshaledName, (UIntPtr)marshaledName.Length, ExportSymbols);
    }

    public readonly LLVMMetadataRef CreateNullPtrType() => LLVM.DIBuilderCreateNullPtrType(this);

    public readonly LLVMMetadataRef CreateObjCIVar(string Name, LLVMMetadataRef File, uint LineNo, ulong SizeInBits, uint AlignInBits, ulong OffsetInBits, LLVMDIFlags Flags, LLVMMetadataRef Ty, LLVMMetadataRef PropertyNode) => CreateObjCIVar(Name.AsSpan(), File, LineNo, SizeInBits, AlignInBits, OffsetInBits, Flags, Ty, PropertyNode);

    public readonly LLVMMetadataRef CreateObjCIVar(ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNo, ulong SizeInBits, uint AlignInBits, ulong OffsetInBits, LLVMDIFlags Flags, LLVMMetadataRef Ty, LLVMMetadataRef PropertyNode)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateObjCIVar(this, marshaledName, (UIntPtr)marshaledName.Length, File, LineNo, SizeInBits, AlignInBits, OffsetInBits, Flags, Ty, PropertyNode);
    }

    public readonly LLVMMetadataRef CreateObjCProperty(string Name, LLVMMetadataRef File, uint LineNo, string GetterName, string SetterName, uint PropertyAttributes, LLVMMetadataRef Ty) => CreateObjCProperty(Name.AsSpan(), File, LineNo, GetterName.AsSpan(), SetterName.AsSpan(), PropertyAttributes, Ty);

    public readonly LLVMMetadataRef CreateObjCProperty(ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNo, ReadOnlySpan<char> GetterName, ReadOnlySpan<char> SetterName, uint PropertyAttributes, LLVMMetadataRef Ty)
    {
        using var marshaledName = new MarshaledString(Name);
        using var marshaledGetterName = new MarshaledString(GetterName);
        using var marshaledSetterName = new MarshaledString(SetterName);
        return LLVM.DIBuilderCreateObjCProperty(this, marshaledName, (UIntPtr)marshaledName.Length, File, LineNo, marshaledGetterName, (UIntPtr)marshaledGetterName.Length, marshaledSetterName, (UIntPtr)marshaledSetterName.Length, PropertyAttributes, Ty);
    }

    public readonly LLVMMetadataRef CreateObjectPointerType(LLVMMetadataRef Type, int Implicit) => LLVM.DIBuilderCreateObjectPointerType(this, Type, Implicit);

    public readonly LLVMMetadataRef CreateParameterVariable(LLVMMetadataRef Scope, string Name, uint ArgNo, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Ty, int AlwaysPreserve, LLVMDIFlags Flags) => CreateParameterVariable(Scope, Name.AsSpan(), ArgNo, File, LineNo, Ty, AlwaysPreserve, Flags);

    public readonly LLVMMetadataRef CreateParameterVariable(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, uint ArgNo, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Ty, int AlwaysPreserve, LLVMDIFlags Flags)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateParameterVariable(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, ArgNo, File, LineNo, Ty, AlwaysPreserve, Flags);
    }

    public readonly LLVMMetadataRef CreatePointerType(LLVMMetadataRef PointeeTy, ulong SizeInBits, uint AlignInBits, uint AddressSpace, string Name) => CreatePointerType(PointeeTy, SizeInBits, AlignInBits, AddressSpace, Name.AsSpan());

    public readonly LLVMMetadataRef CreatePointerType(LLVMMetadataRef PointeeTy, ulong SizeInBits, uint AlignInBits, uint AddressSpace, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreatePointerType(this, PointeeTy, SizeInBits, AlignInBits, AddressSpace, marshaledName, (UIntPtr)marshaledName.Length);
    }

    public readonly LLVMMetadataRef CreateQualifiedType(uint Tag, LLVMMetadataRef Type) => LLVM.DIBuilderCreateQualifiedType(this, Tag, Type);

    public readonly LLVMMetadataRef CreateReferenceType(uint Tag, LLVMMetadataRef Type) => LLVM.DIBuilderCreateReferenceType(this, Tag, Type);

    public readonly LLVMMetadataRef CreateReplaceableCompositeType(uint Tag, string Name, LLVMMetadataRef Scope, LLVMMetadataRef File, uint Line, uint RuntimeLang, ulong SizeInBits, uint AlignInBits, LLVMDIFlags Flags, string UniqueIdentifier) => CreateReplaceableCompositeType(Tag, Name.AsSpan(), Scope, File, Line, RuntimeLang, SizeInBits, AlignInBits, Flags, UniqueIdentifier.AsSpan());

    public readonly LLVMMetadataRef CreateReplaceableCompositeType(uint Tag, ReadOnlySpan<char> Name, LLVMMetadataRef Scope, LLVMMetadataRef File, uint Line, uint RuntimeLang, ulong SizeInBits, uint AlignInBits, LLVMDIFlags Flags, ReadOnlySpan<char> UniqueIdentifier)
    {
        using var marshaledName = new MarshaledString(Name);
        using var marshaledUniqueIdentifier = new MarshaledString(UniqueIdentifier);
        return LLVM.DIBuilderCreateReplaceableCompositeType(this, Tag, marshaledName, (UIntPtr)marshaledName.Length, Scope, File, Line, RuntimeLang, SizeInBits, AlignInBits, Flags, marshaledUniqueIdentifier, (UIntPtr)marshaledUniqueIdentifier.Length);
    }

    public readonly LLVMMetadataRef CreateSetType(LLVMMetadataRef Scope, string Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, uint AlignInBits, LLVMMetadataRef BaseTy) => CreateSetType(Scope, Name.AsSpan(), File, LineNumber, SizeInBits, AlignInBits, BaseTy);

    public readonly LLVMMetadataRef CreateSetType(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, uint AlignInBits, LLVMMetadataRef BaseTy)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateSetType(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, File, LineNumber, SizeInBits, AlignInBits, BaseTy);
    }

    public readonly LLVMMetadataRef CreateStaticMemberType(LLVMMetadataRef Scope, string Name, LLVMMetadataRef File, uint LineNumber, LLVMMetadataRef Type, LLVMDIFlags Flags, LLVMValueRef ConstantVal, uint AlignInBits) => CreateStaticMemberType(Scope, Name.AsSpan(), File, LineNumber, Type, Flags, ConstantVal, AlignInBits);

    public readonly LLVMMetadataRef CreateStaticMemberType(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNumber, LLVMMetadataRef Type, LLVMDIFlags Flags, LLVMValueRef ConstantVal, uint AlignInBits)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateStaticMemberType(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, File, LineNumber, Type, Flags, ConstantVal, AlignInBits);
    }

    public readonly LLVMMetadataRef CreateStructType(LLVMMetadataRef Scope, string Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, uint AlignInBits, LLVMDIFlags Flags, LLVMMetadataRef DerivedFrom, LLVMMetadataRef[] Elements, uint RunTimeLang, LLVMMetadataRef VTableHolder, string UniqueId) => CreateStructType(Scope, Name.AsSpan(), File, LineNumber, SizeInBits, AlignInBits, Flags, DerivedFrom, Elements.AsSpan(), RunTimeLang, VTableHolder, UniqueId.AsSpan());

    public readonly LLVMMetadataRef CreateStructType(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, uint AlignInBits, LLVMDIFlags Flags, LLVMMetadataRef DerivedFrom, ReadOnlySpan<LLVMMetadataRef> Elements, uint RunTimeLang, LLVMMetadataRef VTableHolder, ReadOnlySpan<char> UniqueId)
    {
        using var marshaledName = new MarshaledString(Name);
        using var marshaledUniqueId = new MarshaledString(UniqueId);

        fixed (LLVMMetadataRef* pElements = Elements)
        {
            return LLVM.DIBuilderCreateStructType(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, File, LineNumber, SizeInBits, AlignInBits, Flags, DerivedFrom, (LLVMOpaqueMetadata**)pElements, (uint)Elements.Length, RunTimeLang, VTableHolder, marshaledUniqueId, (UIntPtr)marshaledUniqueId.Length);
        }
    }

    public readonly LLVMMetadataRef CreateSubrangeType(LLVMMetadataRef Scope, string Name, uint LineNo, LLVMMetadataRef File, ulong SizeInBits, uint AlignInBits, LLVMDIFlags Flags, LLVMMetadataRef BaseTy, LLVMMetadataRef LowerBound, LLVMMetadataRef UpperBound, LLVMMetadataRef Stride, LLVMMetadataRef Bias) => CreateSubrangeType(Scope, Name.AsSpan(), LineNo, File, SizeInBits, AlignInBits, Flags, BaseTy, LowerBound, UpperBound, Stride, Bias);

    public readonly LLVMMetadataRef CreateSubrangeType(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, uint LineNo, LLVMMetadataRef File, ulong SizeInBits, uint AlignInBits, LLVMDIFlags Flags, LLVMMetadataRef BaseTy, LLVMMetadataRef LowerBound, LLVMMetadataRef UpperBound, LLVMMetadataRef Stride, LLVMMetadataRef Bias)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateSubrangeType(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, LineNo, File, SizeInBits, AlignInBits, Flags, BaseTy, LowerBound, UpperBound, Stride, Bias);
    }

    public readonly LLVMMetadataRef CreateTempGlobalVariableFwdDecl(LLVMMetadataRef Scope, string Name, string Linkage, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Ty, int LocalToUnit, LLVMMetadataRef Decl, uint AlignInBits) => CreateTempGlobalVariableFwdDecl(Scope, Name.AsSpan(), Linkage.AsSpan(), File, LineNo, Ty, LocalToUnit, Decl, AlignInBits);

    public readonly LLVMMetadataRef CreateTempGlobalVariableFwdDecl(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, ReadOnlySpan<char> Linkage, LLVMMetadataRef File, uint LineNo, LLVMMetadataRef Ty, int LocalToUnit, LLVMMetadataRef Decl, uint AlignInBits)
    {
        using var marshaledName = new MarshaledString(Name);
        using var marshaledLinkage = new MarshaledString(Linkage);
        return LLVM.DIBuilderCreateTempGlobalVariableFwdDecl(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, marshaledLinkage, (UIntPtr)marshaledLinkage.Length, File, LineNo, Ty, LocalToUnit, Decl, AlignInBits);
    }

    public readonly LLVMMetadataRef CreateUnionType(LLVMMetadataRef Scope, string Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, uint AlignInBits, LLVMDIFlags Flags, LLVMMetadataRef[] Elements, uint RunTimeLang, string UniqueId) => CreateUnionType(Scope, Name.AsSpan(), File, LineNumber, SizeInBits, AlignInBits, Flags, Elements.AsSpan(), RunTimeLang, UniqueId.AsSpan());

    public readonly LLVMMetadataRef CreateUnionType(LLVMMetadataRef Scope, ReadOnlySpan<char> Name, LLVMMetadataRef File, uint LineNumber, ulong SizeInBits, uint AlignInBits, LLVMDIFlags Flags, ReadOnlySpan<LLVMMetadataRef> Elements, uint RunTimeLang, ReadOnlySpan<char> UniqueId)
    {
        using var marshaledName = new MarshaledString(Name);
        using var marshaledUniqueId = new MarshaledString(UniqueId);

        fixed (LLVMMetadataRef* pElements = Elements)
        {
            return LLVM.DIBuilderCreateUnionType(this, Scope, marshaledName, (UIntPtr)marshaledName.Length, File, LineNumber, SizeInBits, AlignInBits, Flags, (LLVMOpaqueMetadata**)pElements, (uint)Elements.Length, RunTimeLang, marshaledUniqueId, (UIntPtr)marshaledUniqueId.Length);
        }
    }

    public readonly LLVMMetadataRef CreateUnspecifiedType(string Name) => CreateUnspecifiedType(Name.AsSpan());

    public readonly LLVMMetadataRef CreateUnspecifiedType(ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.DIBuilderCreateUnspecifiedType(this, marshaledName, (UIntPtr)marshaledName.Length);
    }

    public readonly LLVMMetadataRef CreateVectorType(ulong Size, uint AlignInBits, LLVMMetadataRef Ty, LLVMMetadataRef[] Subscripts) => CreateVectorType(Size, AlignInBits, Ty, Subscripts.AsSpan());

    public readonly LLVMMetadataRef CreateVectorType(ulong Size, uint AlignInBits, LLVMMetadataRef Ty, ReadOnlySpan<LLVMMetadataRef> Subscripts)
    {
        fixed (LLVMMetadataRef* pSubscripts = Subscripts)
        {
            return LLVM.DIBuilderCreateVectorType(this, Size, AlignInBits, Ty, (LLVMOpaqueMetadata**)pSubscripts, (uint)Subscripts.Length);
        }
    }

    public readonly void DIBuilderFinalize() => LLVM.DIBuilderFinalize(this);

    public readonly void FinalizeSubprogram(LLVMMetadataRef Subprogram) => LLVM.DIBuilderFinalizeSubprogram(this, Subprogram);

    public readonly LLVMMetadataRef GetOrCreateArray(LLVMMetadataRef[] Data) => GetOrCreateArray(Data.AsSpan());

    public readonly LLVMMetadataRef GetOrCreateArray(ReadOnlySpan<LLVMMetadataRef> Data)
    {
        fixed (LLVMMetadataRef* pData = Data)
        {
            return LLVM.DIBuilderGetOrCreateArray(this, (LLVMOpaqueMetadata**)pData, (UIntPtr)Data.Length);
        }
    }

    public readonly LLVMMetadataRef GetOrCreateSubrange(long LowerBound, long Count) => LLVM.DIBuilderGetOrCreateSubrange(this, LowerBound, Count);

    public readonly LLVMMetadataRef GetOrCreateTypeArray(LLVMMetadataRef[] Data) => GetOrCreateTypeArray(Data.AsSpan());

    public readonly LLVMMetadataRef GetOrCreateTypeArray(ReadOnlySpan<LLVMMetadataRef> Data)
    {
        fixed (LLVMMetadataRef* pData = Data)
        {
            return LLVM.DIBuilderGetOrCreateTypeArray(this, (LLVMOpaqueMetadata**)pData, (UIntPtr)Data.Length);
        }
    }

    public readonly LLVMDbgRecordRef InsertDbgValueRecordAtEnd(LLVMValueRef Val, LLVMMetadataRef VarInfo, LLVMMetadataRef Expr, LLVMMetadataRef DebugLoc, LLVMBasicBlockRef Block) => LLVM.DIBuilderInsertDbgValueRecordAtEnd(this, Val, VarInfo, Expr, DebugLoc, Block);

    public readonly LLVMDbgRecordRef InsertDbgValueRecordBefore(LLVMValueRef Val, LLVMMetadataRef VarInfo, LLVMMetadataRef Expr, LLVMMetadataRef DebugLoc, LLVMValueRef Instr) => LLVM.DIBuilderInsertDbgValueRecordBefore(this, Val, VarInfo, Expr, DebugLoc, Instr);

    public readonly LLVMDbgRecordRef InsertDeclareRecordAtEnd(LLVMValueRef Storage, LLVMMetadataRef VarInfo, LLVMMetadataRef Expr, LLVMMetadataRef DebugLoc, LLVMBasicBlockRef Block) => LLVM.DIBuilderInsertDeclareRecordAtEnd(this, Storage, VarInfo, Expr, DebugLoc, Block);

    public readonly LLVMDbgRecordRef InsertDeclareRecordBefore(LLVMValueRef Storage, LLVMMetadataRef VarInfo, LLVMMetadataRef Expr, LLVMMetadataRef DebugLoc, LLVMValueRef Instr) => LLVM.DIBuilderInsertDeclareRecordBefore(this, Storage, VarInfo, Expr, DebugLoc, Instr);

    public readonly LLVMDbgRecordRef InsertLabelAtEnd(LLVMMetadataRef LabelInfo, LLVMMetadataRef Location, LLVMBasicBlockRef InsertAtEnd) => LLVM.DIBuilderInsertLabelAtEnd(this, LabelInfo, Location, InsertAtEnd);

    public readonly LLVMDbgRecordRef InsertLabelBefore(LLVMMetadataRef LabelInfo, LLVMMetadataRef Location, LLVMValueRef InsertBefore) => LLVM.DIBuilderInsertLabelBefore(this, LabelInfo, Location, InsertBefore);

    public readonly void ReplaceArrays(ref LLVMMetadataRef T, LLVMMetadataRef[] Elements) => ReplaceArrays(ref T, Elements.AsSpan());

    public readonly void ReplaceArrays(ref LLVMMetadataRef T, ReadOnlySpan<LLVMMetadataRef> Elements)
    {
        fixed (LLVMMetadataRef* pT = &T)
        fixed (LLVMMetadataRef* pElements = Elements)
        {
            LLVM.ReplaceArrays(this, (LLVMOpaqueMetadata**)pT, (LLVMOpaqueMetadata**)pElements, (uint)Elements.Length);
        }
    }

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposeDIBuilder(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMDIBuilderRef other) && Equals(other);

    public readonly bool Equals(LLVMDIBuilderRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public override readonly string ToString() => $"{nameof(LLVMDIBuilderRef)}: {Handle:X}";
}
