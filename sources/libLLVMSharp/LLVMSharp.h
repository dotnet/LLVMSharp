// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

#ifndef LIBLLVMSHARP_LLVMSHARP_H
#define LIBLLVMSHARP_LLVMSHARP_H

#ifdef _MSC_VER
#pragma warning(push)
#pragma warning(disable : 4146 4244 4267 4291 4624 4996)
#endif

// Include headers
#include <clang-c/ExternC.h>
#include <llvm/IR/DerivedTypes.h>

#ifdef _MSC_VER
#pragma warning(pop)
#endif

#include "LLVMSharp_export.h"

/**
 * Represents an individual value in LLVM IR.
 *
 * This models llvm::Value.
 */
typedef struct LLVMOpaquePass* LLVMPassRef;

// Enum definitions

// Struct definitions

LLVM_CLANG_C_EXTERN_C_BEGIN

// Function declarations

LLVMSHARP_LINKAGE const char* llvmsharp_ConstantDataArray_getData(LLVMValueRef ConstantDataArrayRef, int32_t* out_size);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DIBasicType_getEncoding(LLVMMetadataRef type);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DICompositeType_getBaseType(LLVMMetadataRef type);

LLVMSHARP_LINKAGE void llvmsharp_DICompositeType_getElements(LLVMMetadataRef type, LLVMMetadataRef** out_buffer, int32_t* out_size);

LLVMSHARP_LINKAGE const char* llvmsharp_DICompositeType_getIdentifier(LLVMMetadataRef type, size_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIDerivedType_getBaseType(LLVMMetadataRef type);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIDerivedType_getExtraData(LLVMMetadataRef type);

LLVMSHARP_LINKAGE const char* llvmsharp_DIEnumerator_getName(LLVMMetadataRef enumerator, size_t* out_size);

LLVMSHARP_LINKAGE int64_t llvmsharp_DIEnumerator_getValue_SExt(LLVMMetadataRef enumerator);

LLVMSHARP_LINKAGE uint64_t llvmsharp_DIEnumerator_getValue_ZExt(LLVMMetadataRef enumerator);

LLVMSHARP_LINKAGE uint8_t llvmsharp_DIEnumerator_isUnsigned(LLVMMetadataRef enumerator);

LLVMSHARP_LINKAGE const char* llvmsharp_DIFile_getDirectory(LLVMMetadataRef file, size_t* out_size);

LLVMSHARP_LINKAGE const char* llvmsharp_DIFile_getFilename(LLVMMetadataRef file, size_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIImportedEntity_getEntity(LLVMMetadataRef node);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIImportedEntity_getFile(LLVMMetadataRef node);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DIImportedEntity_getLine(LLVMMetadataRef node);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIImportedEntity_getScope(LLVMMetadataRef node);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DILexicalBlock_getLine(LLVMMetadataRef block);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DILexicalBlock_getScope(LLVMMetadataRef block);

LLVMSHARP_LINKAGE const char* llvmsharp_DINamespace_getName(LLVMMetadataRef node, size_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DINamespace_getScope(LLVMMetadataRef node);

LLVMSHARP_LINKAGE const char* llvmsharp_DINode_getTagString(LLVMMetadataRef node, size_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DISubprogram_getContainingType(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DISubprogram_getFlags(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE const char* llvmsharp_DISubprogram_getLinkageName(LLVMMetadataRef subprogram, size_t* out_size);

LLVMSHARP_LINKAGE const char* llvmsharp_DISubprogram_getName(LLVMMetadataRef subprogram, size_t* out_size);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DISubprogram_getScopeLine(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DISubprogram_getSPFlags(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE void llvmsharp_DISubprogram_getTemplateParams(LLVMMetadataRef subprogram, LLVMMetadataRef** out_buffer, int32_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DISubprogram_getType(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DISubprogram_getVirtualIndex(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE void llvmsharp_DISubroutineType_getTypeArray(LLVMMetadataRef subroutine_type, LLVMMetadataRef** out_buffer, int32_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DITemplateParameter_getType(LLVMMetadataRef parameter);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DITemplateValueParameter_getValue(LLVMMetadataRef parameter);

LLVMSHARP_LINKAGE const char* llvmsharp_DIVariable_getName(LLVMMetadataRef variable, size_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIVariable_getType(LLVMMetadataRef variable);

LLVMSHARP_LINKAGE LLVMTypeRef llvmsharp_Function_getFunctionType(LLVMValueRef FnRef);

LLVMSHARP_LINKAGE LLVMTypeRef llvmsharp_Function_getReturnType(LLVMValueRef FnRef);

LLVMSHARP_LINKAGE uint8_t llvmsharp_Instruction_hasNoSignedWrap(LLVMValueRef InstructionRef);

LLVMSHARP_LINKAGE uint8_t llvmsharp_Instruction_hasNoUnsignedWrap(LLVMValueRef InstructionRef);

LLVMSHARP_LINKAGE void llvmsharp_Module_GetIdentifiedStructTypes(LLVMModuleRef module, LLVMTypeRef** out_buffer, int32_t* out_size);

LLVMSHARP_LINKAGE void llvmsharp_PassManager_add(LLVMPassManagerRef pass_manager, LLVMPassRef pass);

LLVMSHARP_LINKAGE int32_t llvmsharp_Value_getDemangledName(LLVMValueRef ValueRef, char* buffer, int32_t buffer_size);

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createDeadCodeEliminationPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createSROAPass(uint8_t PreserveCFG);

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createLICMPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createLoopStrengthReducePass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createReassociatePass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createFlattenCFGPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createCFGSimplificationPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createTailCallEliminationPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createConstantHoistingPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createLowerInvokePass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createLowerSwitchPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createBreakCriticalEdgesPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createLCSSAPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createPromoteMemoryToRegisterPass(uint8_t IsForced);

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createLoopSimplifyPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createUnifyLoopExitsPass();

LLVMSHARP_LINKAGE void llvmsharp_Free(void* obj);

LLVM_CLANG_C_EXTERN_C_END

#endif
