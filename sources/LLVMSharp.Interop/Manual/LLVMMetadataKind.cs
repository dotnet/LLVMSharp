// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-15.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

namespace LLVMSharp.Interop;

public enum LLVMMetadataKind
{
    LLVMMDStringMetadataKind = 0,
    LLVMConstantAsMetadataMetadataKind = 1,
    LLVMLocalAsMetadataMetadataKind = 2,
    LLVMDistinctMDOperandPlaceholderMetadataKind = 3,
    LLVMMDTupleMetadataKind = 4,
    LLVMDILocationMetadataKind = 5,
    LLVMDIExpressionMetadataKind = 6,
    LLVMDIGlobalVariableExpressionMetadataKind = 7,
    LLVMGenericDINodeMetadataKind = 8,
    LLVMDISubrangeMetadataKind = 9,
    LLVMDIEnumeratorMetadataKind = 10,
    LLVMDIBasicTypeMetadataKind = 11,
    LLVMDIDerivedTypeMetadataKind = 12,
    LLVMDICompositeTypeMetadataKind = 13,
    LLVMDISubroutineTypeMetadataKind = 14,
    LLVMDIFileMetadataKind = 15,
    LLVMDICompileUnitMetadataKind = 16,
    LLVMDISubprogramMetadataKind = 17,
    LLVMDILexicalBlockMetadataKind = 18,
    LLVMDILexicalBlockFileMetadataKind = 19,
    LLVMDINamespaceMetadataKind = 20,
    LLVMDIModuleMetadataKind = 21,
    LLVMDITemplateTypeParameterMetadataKind = 22,
    LLVMDITemplateValueParameterMetadataKind = 23,
    LLVMDIGlobalVariableMetadataKind = 24,
    LLVMDILocalVariableMetadataKind = 25,
    LLVMDILabelMetadataKind = 26,
    LLVMDIObjCPropertyMetadataKind = 27,
    LLVMDIImportedEntityMetadataKind = 28,
    LLVMDIMacroMetadataKind = 29,
    LLVMDIMacroFileMetadataKind = 30,
    LLVMDICommonBlockMetadataKind = 31,
    LLVMDIStringTypeMetadataKind = 32,
    LLVMDIGenericSubrangeMetadataKind = 33,
    LLVMDIArgListMetadataKind = 34,
}
