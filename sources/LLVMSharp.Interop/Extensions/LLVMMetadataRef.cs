// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMMetadataRef(IntPtr handle) : IEquatable<LLVMMetadataRef>
{
    public IntPtr Handle = handle;

    public readonly uint AlignInBits => (IsADIType != null) ? LLVM.DITypeGetAlignInBits(this) : default;

    public readonly uint AlignInBytes => AlignInBits / 8;

    public readonly LLVMMetadataRef BaseType
    {
        get
        {
            if (IsADIDerivedType != null)
            {
                return llvmsharp.DIDerivedType_getBaseType(this);
            }
            if (IsADICompositeType != null)
            {
                return llvmsharp.DICompositeType_getBaseType(this);
            }
            return default;
        }
    }

    public readonly uint Column => (IsADILocation != null) ? LLVM.DILocationGetColumn(this) : default;

    public readonly LLVMMetadataRef ContainingType => (IsADISubprogram != null) ? llvmsharp.DISubprogram_getContainingType(this) : default;

    public readonly LLVMValueRef Count => (IsADISubrange != null) ? llvmsharp.DISubrange_getCount(this) : default;

    public readonly string Directory => (IsADIFile != null) ? LLVM.DIFileGetDirectory(this) : "";

    public readonly uint Encoding => (IsADIBasicType != null) ? llvmsharp.DIBasicType_getEncoding(this) : default;

    public readonly LLVMMetadataRef Entity => (IsADIImportedEntity != null) ? llvmsharp.DIImportedEntity_getEntity(this) : default;

    public readonly LLVMMetadataRef Expression => (IsADIGlobalVariableExpression != null) ? LLVM.DIGlobalVariableExpressionGetExpression(this) : default;

    public readonly LLVMMetadataRef ExtraData => (IsADIDerivedType != null) ? llvmsharp.DIDerivedType_getExtraData(this) : default;

    public readonly LLVMMetadataRef File
    {
        get
        {
            if (IsADIScope != null)
            {
                return LLVM.DIScopeGetFile(this);
            }
            if (IsADIVariable != null)
            {
                return LLVM.DIVariableGetFile(this);
            }
            if (IsADIImportedEntity != null)
            {
                return llvmsharp.DIImportedEntity_getFile(this);
            }
            return default;
        }
    }

    public readonly string Filename => (IsADIFile != null) ? LLVM.DIFileGetFilename(this) : "";

    public readonly LLVMDIFlags Flags
    {
        get
        {
            if (IsADIType != null)
            {
                return LLVM.DITypeGetFlags(this);
            }
            if (IsADISubprogram != null)
            {
                return (LLVMDIFlags)llvmsharp.DISubprogram_getFlags(this);
            }
            return default;
        }
    }

    public readonly string Identifier => (IsADICompositeType != null) ? llvmsharp.DICompositeType_getIdentifier(this) : "";

    public readonly LLVMMetadataRef InlinedAt => (IsADILocation != null) ? LLVM.DILocationGetInlinedAt(this) : default;

    #region IsA* Properties
    public readonly LLVMMetadataRef IsAConstantAsMetadata => llvmsharp.Metadata_IsAConstantAsMetadata(this);

    public readonly LLVMMetadataRef IsADIArgList => llvmsharp.Metadata_IsADIArgList(this);

    public readonly LLVMMetadataRef IsADIAssignID => llvmsharp.Metadata_IsADIAssignID(this);

    public readonly LLVMMetadataRef IsADIBasicType => llvmsharp.Metadata_IsADIBasicType(this);

    public readonly LLVMMetadataRef IsADICommonBlock => llvmsharp.Metadata_IsADICommonBlock(this);

    public readonly LLVMMetadataRef IsADICompileUnit => llvmsharp.Metadata_IsADICompileUnit(this);

    public readonly LLVMMetadataRef IsADICompositeType => llvmsharp.Metadata_IsADICompositeType(this);

    public readonly LLVMMetadataRef IsADIDerivedType => llvmsharp.Metadata_IsADIDerivedType(this);

    public readonly LLVMMetadataRef IsADIEnumerator => llvmsharp.Metadata_IsADIEnumerator(this);

    public readonly LLVMMetadataRef IsADIExpression => llvmsharp.Metadata_IsADIExpression(this);

    public readonly LLVMMetadataRef IsADIFile => llvmsharp.Metadata_IsADIFile(this);

    public readonly LLVMMetadataRef IsADIGenericSubrange => llvmsharp.Metadata_IsADIGenericSubrange(this);

    public readonly LLVMMetadataRef IsAGenericDINode => llvmsharp.Metadata_IsAGenericDINode(this);

    public readonly LLVMMetadataRef IsADIGlobalVariable => llvmsharp.Metadata_IsADIGlobalVariable(this);

    public readonly LLVMMetadataRef IsADIGlobalVariableExpression => llvmsharp.Metadata_IsADIGlobalVariableExpression(this);

    public readonly LLVMMetadataRef IsADIImportedEntity => llvmsharp.Metadata_IsADIImportedEntity(this);

    public readonly LLVMMetadataRef IsADILabel => llvmsharp.Metadata_IsADILabel(this);

    public readonly LLVMMetadataRef IsADILexicalBlock => llvmsharp.Metadata_IsADILexicalBlock(this);

    public readonly LLVMMetadataRef IsADILexicalBlockFile => llvmsharp.Metadata_IsADILexicalBlockFile(this);

    public readonly LLVMMetadataRef IsADILocation => llvmsharp.Metadata_IsADILocation(this);

    public readonly LLVMMetadataRef IsADILocalVariable => llvmsharp.Metadata_IsADILocalVariable(this);

    public readonly LLVMMetadataRef IsADIMacro => llvmsharp.Metadata_IsADIMacro(this);

    public readonly LLVMMetadataRef IsADIMacroFile => llvmsharp.Metadata_IsADIMacroFile(this);

    public readonly LLVMMetadataRef IsADIModule => llvmsharp.Metadata_IsADIModule(this);

    public readonly LLVMMetadataRef IsADINamespace => llvmsharp.Metadata_IsADINamespace(this);

    public readonly LLVMMetadataRef IsADINode => llvmsharp.Metadata_IsADINode(this);

    public readonly LLVMMetadataRef IsADIObjCProperty => llvmsharp.Metadata_IsADIObjCProperty(this);

    public readonly LLVMMetadataRef IsADistinctMDOperandPlaceholder => llvmsharp.Metadata_IsADistinctMDOperandPlaceholder(this);

    public readonly LLVMMetadataRef IsADIScope => llvmsharp.Metadata_IsADIScope(this);

    public readonly LLVMMetadataRef IsADIStringType => llvmsharp.Metadata_IsADIStringType(this);

    public readonly LLVMMetadataRef IsADISubprogram => llvmsharp.Metadata_IsADISubprogram(this);

    public readonly LLVMMetadataRef IsADISubrange => llvmsharp.Metadata_IsADISubrange(this);

    public readonly LLVMMetadataRef IsADISubroutineType => llvmsharp.Metadata_IsADISubroutineType(this);

    public readonly LLVMMetadataRef IsADITemplateParameter => llvmsharp.Metadata_IsADITemplateParameter(this);

    public readonly LLVMMetadataRef IsADITemplateTypeParameter => llvmsharp.Metadata_IsADITemplateTypeParameter(this);

    public readonly LLVMMetadataRef IsADITemplateValueParameter => llvmsharp.Metadata_IsADITemplateValueParameter(this);

    public readonly LLVMMetadataRef IsADIType => llvmsharp.Metadata_IsADIType(this);

    public readonly LLVMMetadataRef IsADIVariable => llvmsharp.Metadata_IsADIVariable(this);

    public readonly LLVMMetadataRef IsALocalAsMetadata => llvmsharp.Metadata_IsALocalAsMetadata(this);

    public readonly LLVMMetadataRef IsAMDNode => llvmsharp.Metadata_IsAMDNode(this);

    public readonly LLVMMetadataRef IsAMDString => llvmsharp.Metadata_IsAMDString(this);

    public readonly LLVMMetadataRef IsAMDTuple => llvmsharp.Metadata_IsAMDTuple(this);
    #endregion

    public readonly bool IsUnsigned => (IsADIEnumerator != null) && (llvmsharp.DIEnumerator_isUnsigned(this) != 0);

    public readonly LLVMMetadataKind Kind => (Handle != default) ? (LLVMMetadataKind)LLVM.GetMetadataKind(this) : default;

    public readonly uint Line
    {
        get
        {
            if (IsADISubprogram != null)
            {
                return LLVM.DISubprogramGetLine(this);
            }
            if (IsADILocation != null)
            {
                return LLVM.DILocationGetLine(this);
            }
            if (IsADIType != null)
            {
                return LLVM.DITypeGetLine(this);
            }
            if (IsADIVariable != null)
            {
                return LLVM.DIVariableGetLine(this);
            }
            if (IsADIImportedEntity != null)
            {
                return llvmsharp.DIImportedEntity_getLine(this);
            }
            if (IsADILexicalBlock != null)
            {
                return llvmsharp.DILexicalBlock_getLine(this);
            }
            return default;
        }
    }

    public readonly string LinkageName => (IsADISubprogram != null) ? llvmsharp.DISubprogram_getLinkageName(this) : "";

    public readonly string Name
    {
        get
        {
            if (IsADIType != null)
            {
                return LLVM.DITypeGetName(this);
            }
            if (IsADISubprogram != null)
            {
                return llvmsharp.DISubprogram_getName(this);
            }
            if (IsADIVariable != null)
            {
                return llvmsharp.DIVariable_getName(this);
            }
            if (IsADINamespace != null)
            {
                return llvmsharp.DINamespace_getName(this);
            }
            if (IsADIEnumerator != null)
            {
                return llvmsharp.DIEnumerator_getName(this);
            }
            return "";
        }
    }

    public readonly uint NumOperands => (IsAMDNode != null) ? llvmsharp.MDNode_getNumOperands(this) : 0;

    public readonly ulong OffsetInBits => (IsADIType != null) ? LLVM.DITypeGetOffsetInBits(this) : default;

    public readonly ulong OffsetInBytes => OffsetInBits / 8;

    public readonly LLVMMetadataRef Scope
    {
        get
        {
            if (IsADILocation != null)
            {
                return LLVM.DILocationGetScope(this);
            }
            if (IsADIVariable != null)
            {
                return LLVM.DIVariableGetScope(this);
            }
            if (IsADILexicalBlock != null)
            {
                return llvmsharp.DILexicalBlock_getScope(this);
            }
            if (IsADIImportedEntity != null)
            {
                return llvmsharp.DIImportedEntity_getScope(this);
            }
            if (IsADINamespace != null)
            {
                return llvmsharp.DINamespace_getScope(this);
            }
            return default;
        }
    }

    public readonly uint ScopeLine => (IsADISubprogram != null) ? llvmsharp.DISubprogram_getScopeLine(this) : default;

    public readonly ulong SizeInBits => (IsADIType != null) ? LLVM.DITypeGetSizeInBits(this) : default;

    public readonly ulong SizeInBytes => SizeInBits / 8;

    public readonly uint SPFlags => (IsADISubprogram != null) ? llvmsharp.DISubprogram_getSPFlags(this) : default;

    public readonly string String => (IsAMDString != null) ? llvmsharp.MDString_getString(this) : "";

    public readonly ushort Tag => (IsADINode != null) ? LLVM.GetDINodeTag(this) : default;

    public readonly string TagString => (IsADINode != null) ? llvmsharp.DINode_getTagString(this) : "";

    public readonly LLVMMetadataRef Type
    {
        get
        {
            if (IsADIVariable != null)
            {
                return llvmsharp.DIVariable_getType(this);
            }
            if (IsADISubprogram != null)
            {
                return llvmsharp.DISubprogram_getType(this);
            }
            if (IsADITemplateParameter != null)
            {
                return llvmsharp.DITemplateParameter_getType(this);
            }
            return default;
        }
    }

    public readonly LLVMMetadataRef Value => (IsADITemplateValueParameter != null) ? llvmsharp.DITemplateValueParameter_getValue(this) : default;

    public readonly long ValueSExt => (IsADIEnumerator != null) ? llvmsharp.DIEnumerator_getValue_SExt(this) : default;

    public readonly ulong ValueZExt => (IsADIEnumerator != null) ? llvmsharp.DIEnumerator_getValue_ZExt(this) : default;

    public readonly uint VirtualIndex => (IsADISubprogram != null) ? llvmsharp.DISubprogram_getVirtualIndex(this) : default;

    public readonly LLVMMetadataRef Variable => (IsADIGlobalVariableExpression != null) ? LLVM.DIGlobalVariableExpressionGetVariable(this) : default;

    public static implicit operator LLVMMetadataRef(LLVMOpaqueMetadata* value) => new LLVMMetadataRef((IntPtr)value);

    public static implicit operator LLVMOpaqueMetadata*(LLVMMetadataRef value) => (LLVMOpaqueMetadata*)value.Handle;

    public static bool operator ==(LLVMMetadataRef left, LLVMMetadataRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMMetadataRef left, LLVMMetadataRef right) => !(left == right);

    public readonly LLVMValueRef AsValue(LLVMContextRef context) => context.MetadataAsValue(this);

    public override readonly bool Equals(object? obj) => (obj is LLVMMetadataRef other) && Equals(other);

    public readonly bool Equals(LLVMMetadataRef other) => this == other;

    public readonly LLVMMetadataRef[] GetElements()
    {
        return (IsADICompositeType != null) ? llvmsharp.DICompositeType_getElements(this) : [];
    }

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly LLVMMetadataRef GetOperand(uint index)
    {
        return llvmsharp.MDNode_getOperand(this, index);
    }

    public readonly LLVMMetadataRef[] GetOperands()
    {
        uint numOperands = NumOperands;
        if (numOperands == 0)
        {
            return [];
        }

        var operands = new LLVMMetadataRef[numOperands];
        for (uint i = 0; i < numOperands; i++)
        {
            operands[i] = GetOperand(i);
        }
        return operands;
    }

    public readonly LLVMMetadataRef[] GetTemplateParams()
    {
        return (IsADISubprogram != null) ? llvmsharp.DISubprogram_getTemplateParams(this) : [];
    }

    public readonly LLVMMetadataRef[] GetTypeArray()
    {
        return (IsADISubroutineType != null) ? llvmsharp.DISubroutineType_getTypeArray(this) : [];
    }

    public override readonly string ToString() => $"{nameof(LLVMMetadataRef)}: {Handle:X}";
}
