// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

#ifndef LIBLLVMSHARP_LLVMSHARP_H
#define LIBLLVMSHARP_LLVMSHARP_H

#ifdef _MSC_VER
#pragma warning(push)
#pragma warning(disable : 4146 4244 4267 4291 4624 4996)
#endif

// Include headers
#include <clang-c/ExternC.h>
#include <llvm-c/Orc.h>
#include <llvm-c/TargetMachine.h>
#include <llvm/IR/DerivedTypes.h>

#ifdef _MSC_VER
#pragma warning(pop)
#endif

#include "LLVMSharp_export.h"

// Copied from the LLVMMetadataKind enum
#define LLVM_FOR_EACH_METADATA_SUBCLASS(macro) \
    macro(MDNode) \
    macro(DINode) \
    macro(DIScope) \
    macro(DITemplateParameter) \
    macro(DIType) \
    macro(DIVariable) \
    macro(MDString) \
    macro(ConstantAsMetadata) \
    macro(LocalAsMetadata) \
    macro(DistinctMDOperandPlaceholder) \
    macro(MDTuple) \
    macro(DILocation) \
    macro(DIExpression) \
    macro(DIGlobalVariableExpression) \
    macro(GenericDINode) \
    macro(DISubrange) \
    macro(DIEnumerator) \
    macro(DIBasicType) \
    macro(DIDerivedType) \
    macro(DICompositeType) \
    macro(DISubroutineType) \
    macro(DIFile) \
    macro(DICompileUnit) \
    macro(DISubprogram) \
    macro(DILexicalBlock) \
    macro(DILexicalBlockFile) \
    macro(DINamespace) \
    macro(DIModule) \
    macro(DITemplateTypeParameter) \
    macro(DITemplateValueParameter) \
    macro(DIGlobalVariable) \
    macro(DILocalVariable) \
    macro(DILabel) \
    macro(DIObjCProperty) \
    macro(DIImportedEntity) \
    macro(DIMacro) \
    macro(DIMacroFile) \
    macro(DICommonBlock) \
    macro(DIStringType) \
    macro(DIGenericSubrange) \
    macro(DIArgList) \
    macro(DIAssignID) \

/**
 * Represents an individual value in LLVM IR.
 *
 * This models llvm::Value.
 */
typedef struct LLVMOpaquePass* LLVMPassRef;

typedef struct LLVMSharpOpaqueDominatorTree* LLVMSharpDominatorTreeRef;
typedef struct LLVMSharpOpaqueLoop* LLVMSharpLoopRef;
typedef struct LLVMSharpOpaqueLoopInfo* LLVMSharpLoopInfoRef;
typedef struct LLVMSharpOpaquePostDominatorTree* LLVMSharpPostDominatorTreeRef;
typedef struct LLVMSharpOpaqueTargetTransformInfo* LLVMSharpTargetTransformInfoRef;

// Enum definitions

// Struct definitions

LLVM_CLANG_C_EXTERN_C_BEGIN

// Function declarations

LLVMSHARP_LINKAGE uint8_t llvmsharp_CallBase_isIndirectCall(LLVMValueRef call);

LLVMSHARP_LINKAGE LLVMValueRef llvmsharp_CloneFunction(LLVMValueRef function);

LLVMSHARP_LINKAGE int32_t llvmsharp_CmpInst_getInversePredicate(LLVMValueRef instruction);

LLVMSHARP_LINKAGE const char* llvmsharp_CmpInst_getPredicateName(LLVMValueRef instruction, int32_t* out_size);

LLVMSHARP_LINKAGE int32_t llvmsharp_CmpInst_getSwappedPredicate(LLVMValueRef instruction);

LLVMSHARP_LINKAGE uint8_t llvmsharp_CmpInst_isFalseWhenEqual(LLVMValueRef instruction);

LLVMSHARP_LINKAGE uint8_t llvmsharp_CmpInst_isSigned(LLVMValueRef instruction);

LLVMSHARP_LINKAGE uint8_t llvmsharp_CmpInst_isTrueWhenEqual(LLVMValueRef instruction);

LLVMSHARP_LINKAGE uint8_t llvmsharp_CmpInst_isUnsigned(LLVMValueRef instruction);

LLVMSHARP_LINKAGE const char* llvmsharp_ConstantDataArray_getData(LLVMValueRef array, int32_t* out_size);

LLVMSHARP_LINKAGE LLVMValueRef llvmsharp_ConstantFoldCompareInstOperands(int32_t predicate, LLVMValueRef lhs, LLVMValueRef rhs, LLVMModuleRef module);

LLVMSHARP_LINKAGE LLVMValueRef llvmsharp_ConstantFoldConstant(LLVMValueRef constant, LLVMModuleRef module);

LLVMSHARP_LINKAGE LLVMValueRef llvmsharp_ConstantFoldInstruction(LLVMValueRef instruction, LLVMModuleRef module);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DIBasicType_getEncoding(LLVMMetadataRef type);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DICompositeType_getBaseType(LLVMMetadataRef type);

LLVMSHARP_LINKAGE void llvmsharp_DICompositeType_getElements(LLVMMetadataRef type, LLVMMetadataRef** out_buffer, int32_t* out_size);

LLVMSHARP_LINKAGE const char* llvmsharp_DICompositeType_getIdentifier(LLVMMetadataRef type, int32_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIDerivedType_getBaseType(LLVMMetadataRef type);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIDerivedType_getExtraData(LLVMMetadataRef type);

LLVMSHARP_LINKAGE const char* llvmsharp_DIEnumerator_getName(LLVMMetadataRef enumerator, int32_t* out_size);

LLVMSHARP_LINKAGE int64_t llvmsharp_DIEnumerator_getValue_SExt(LLVMMetadataRef enumerator);

LLVMSHARP_LINKAGE uint64_t llvmsharp_DIEnumerator_getValue_ZExt(LLVMMetadataRef enumerator);

LLVMSHARP_LINKAGE uint8_t llvmsharp_DIEnumerator_isUnsigned(LLVMMetadataRef enumerator);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIImportedEntity_getEntity(LLVMMetadataRef node);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIImportedEntity_getFile(LLVMMetadataRef node);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DIImportedEntity_getLine(LLVMMetadataRef node);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIImportedEntity_getScope(LLVMMetadataRef node);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DILexicalBlock_getLine(LLVMMetadataRef block);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DILexicalBlock_getScope(LLVMMetadataRef block);

LLVMSHARP_LINKAGE const char* llvmsharp_DINamespace_getName(LLVMMetadataRef node, int32_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DINamespace_getScope(LLVMMetadataRef node);

LLVMSHARP_LINKAGE const char* llvmsharp_DINode_getTagString(LLVMMetadataRef node, int32_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DISubprogram_getContainingType(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DISubprogram_getFlags(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE const char* llvmsharp_DISubprogram_getLinkageName(LLVMMetadataRef subprogram, int32_t* out_size);

LLVMSHARP_LINKAGE const char* llvmsharp_DISubprogram_getName(LLVMMetadataRef subprogram, int32_t* out_size);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DISubprogram_getScopeLine(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DISubprogram_getSPFlags(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE void llvmsharp_DISubprogram_getTemplateParams(LLVMMetadataRef subprogram, LLVMMetadataRef** out_buffer, int32_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DISubprogram_getType(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE uint32_t llvmsharp_DISubprogram_getVirtualIndex(LLVMMetadataRef subprogram);

LLVMSHARP_LINKAGE LLVMValueRef llvmsharp_DISubrange_getCount(LLVMMetadataRef subrange);

LLVMSHARP_LINKAGE void llvmsharp_DISubroutineType_getTypeArray(LLVMMetadataRef subroutine_type, LLVMMetadataRef** out_buffer, int32_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DITemplateParameter_getType(LLVMMetadataRef parameter);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DITemplateValueParameter_getValue(LLVMMetadataRef parameter);

LLVMSHARP_LINKAGE const char* llvmsharp_DIVariable_getName(LLVMMetadataRef variable, int32_t* out_size);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_DIVariable_getType(LLVMMetadataRef variable);

LLVMSHARP_LINKAGE LLVMSharpDominatorTreeRef llvmsharp_DominatorTree_create(LLVMValueRef function);

LLVMSHARP_LINKAGE void llvmsharp_DominatorTree_dispose(LLVMSharpDominatorTreeRef dominator_tree);

LLVMSHARP_LINKAGE uint8_t llvmsharp_DominatorTree_dominatesBlock(LLVMSharpDominatorTreeRef dominator_tree, LLVMBasicBlockRef a, LLVMBasicBlockRef b);

LLVMSHARP_LINKAGE uint8_t llvmsharp_DominatorTree_dominatesInstruction(LLVMSharpDominatorTreeRef dominator_tree, LLVMValueRef def, LLVMValueRef user);

LLVMSHARP_LINKAGE LLVMBasicBlockRef llvmsharp_DominatorTree_getIDom(LLVMSharpDominatorTreeRef dominator_tree, LLVMBasicBlockRef block);

LLVMSHARP_LINKAGE uint8_t llvmsharp_DominatorTree_properlyDominatesBlock(LLVMSharpDominatorTreeRef dominator_tree, LLVMBasicBlockRef a, LLVMBasicBlockRef b);

LLVMSHARP_LINKAGE LLVMTypeRef llvmsharp_Function_getFunctionType(LLVMValueRef function);

LLVMSHARP_LINKAGE LLVMTypeRef llvmsharp_Function_getReturnType(LLVMValueRef function);

LLVMSHARP_LINKAGE uint32_t llvmsharp_GlobalValue_getAddressSpace(LLVMValueRef global_value);

LLVMSHARP_LINKAGE uint8_t llvmsharp_GlobalValue_isDSOLocal(LLVMValueRef global_value);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_GlobalVariable_getGlobalVariableExpression(LLVMValueRef global_variable);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_GlobalVariable_getMetadata(LLVMValueRef global_variable, uint32_t KindID);

LLVMSHARP_LINKAGE uint8_t llvmsharp_InlineFunction(LLVMValueRef call_base);

LLVMSHARP_LINKAGE const char* llvmsharp_Instruction_getOpcodeName(LLVMValueRef instruction, int32_t* out_size);

LLVMSHARP_LINKAGE uint8_t llvmsharp_Instruction_isCommutative(LLVMValueRef instruction);

LLVMSHARP_LINKAGE uint8_t llvmsharp_Instruction_mayHaveSideEffects(LLVMValueRef instruction);

LLVMSHARP_LINKAGE uint8_t llvmsharp_Instruction_mayReadFromMemory(LLVMValueRef instruction);

LLVMSHARP_LINKAGE uint8_t llvmsharp_Instruction_mayWriteToMemory(LLVMValueRef instruction);

LLVMSHARP_LINKAGE LLVMSharpLoopInfoRef llvmsharp_LoopInfo_create(LLVMSharpDominatorTreeRef dominator_tree);

LLVMSHARP_LINKAGE void llvmsharp_LoopInfo_dispose(LLVMSharpLoopInfoRef loop_info);

LLVMSHARP_LINKAGE uint32_t llvmsharp_LoopInfo_getLoopDepth(LLVMSharpLoopInfoRef loop_info, LLVMBasicBlockRef block);

LLVMSHARP_LINKAGE LLVMSharpLoopRef llvmsharp_LoopInfo_getLoopFor(LLVMSharpLoopInfoRef loop_info, LLVMBasicBlockRef block);

LLVMSHARP_LINKAGE uint8_t llvmsharp_Loop_containsBlock(LLVMSharpLoopRef loop, LLVMBasicBlockRef block);

LLVMSHARP_LINKAGE LLVMBasicBlockRef llvmsharp_Loop_getExitBlock(LLVMSharpLoopRef loop);

LLVMSHARP_LINKAGE LLVMBasicBlockRef llvmsharp_Loop_getHeader(LLVMSharpLoopRef loop);

LLVMSHARP_LINKAGE uint32_t llvmsharp_Loop_getLoopDepth(LLVMSharpLoopRef loop);

LLVMSHARP_LINKAGE LLVMBasicBlockRef llvmsharp_Loop_getLoopLatch(LLVMSharpLoopRef loop);

LLVMSHARP_LINKAGE LLVMBasicBlockRef llvmsharp_Loop_getLoopPreheader(LLVMSharpLoopRef loop);

LLVMSHARP_LINKAGE LLVMSharpLoopRef llvmsharp_Loop_getParentLoop(LLVMSharpLoopRef loop);

LLVMSHARP_LINKAGE uint32_t llvmsharp_MDNode_getNumOperands(LLVMMetadataRef metadata);

LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_MDNode_getOperand(LLVMMetadataRef metadata, uint32_t index);

LLVMSHARP_LINKAGE const char* llvmsharp_MDString_getString(LLVMMetadataRef mdstring, int32_t* out_size);

#define LLVMSHARP_METADATA_ISA(CPP_TYPE) LLVMSHARP_LINKAGE LLVMMetadataRef llvmsharp_Metadata_IsA##CPP_TYPE(LLVMMetadataRef metadata);

LLVM_FOR_EACH_METADATA_SUBCLASS(LLVMSHARP_METADATA_ISA)

#undef LLVMSHARP_METADATA_ISA

LLVMSHARP_LINKAGE void llvmsharp_Module_GetIdentifiedStructTypes(LLVMModuleRef module, LLVMTypeRef** out_buffer, int32_t* out_size);

LLVMSHARP_LINKAGE LLVMOrcObjectLayerRef llvmsharp_OrcCreateObjectLinkingLayer(LLVMOrcExecutionSessionRef execution_session);

LLVMSHARP_LINKAGE void llvmsharp_PassManager_add(LLVMPassManagerRef pass_manager, LLVMPassRef pass);

LLVMSHARP_LINKAGE LLVMSharpPostDominatorTreeRef llvmsharp_PostDominatorTree_create(LLVMValueRef function);

LLVMSHARP_LINKAGE void llvmsharp_PostDominatorTree_dispose(LLVMSharpPostDominatorTreeRef post_dominator_tree);

LLVMSHARP_LINKAGE uint8_t llvmsharp_PostDominatorTree_dominatesBlock(LLVMSharpPostDominatorTreeRef post_dominator_tree, LLVMBasicBlockRef a, LLVMBasicBlockRef b);

LLVMSHARP_LINKAGE LLVMValueRef llvmsharp_simplifyInstruction(LLVMValueRef instruction, LLVMModuleRef module);

LLVMSHARP_LINKAGE LLVMSharpTargetTransformInfoRef llvmsharp_TargetTransformInfo_create(LLVMTargetMachineRef target_machine, LLVMValueRef function);

LLVMSHARP_LINKAGE void llvmsharp_TargetTransformInfo_dispose(LLVMSharpTargetTransformInfoRef target_transform_info);

LLVMSHARP_LINKAGE uint8_t llvmsharp_TargetTransformInfo_getInstructionCost(LLVMSharpTargetTransformInfoRef target_transform_info, LLVMValueRef user, int32_t cost_kind, int64_t* out_cost);

LLVMSHARP_LINKAGE uint32_t llvmsharp_TargetTransformInfo_getNumberOfRegisters(LLVMSharpTargetTransformInfoRef target_transform_info, uint32_t class_id);

LLVMSHARP_LINKAGE uint32_t llvmsharp_TargetTransformInfo_getRegisterBitWidth(LLVMSharpTargetTransformInfoRef target_transform_info, int32_t register_kind, uint8_t* out_isScalable);

LLVMSHARP_LINKAGE uint64_t llvmsharp_Type_getPrimitiveSizeInBits(LLVMTypeRef type, uint8_t* out_isScalable);

LLVMSHARP_LINKAGE uint32_t llvmsharp_Type_getScalarSizeInBits(LLVMTypeRef type);

LLVMSHARP_LINKAGE uint32_t llvmsharp_Value_getNumUses(LLVMValueRef value);

LLVMSHARP_LINKAGE LLVMValueRef llvmsharp_Value_stripPointerCasts(LLVMValueRef value);

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

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createPromoteMemoryToRegisterPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createLoopSimplifyPass();

LLVMSHARP_LINKAGE LLVMPassRef llvmsharp_createUnifyLoopExitsPass();

LLVMSHARP_LINKAGE int32_t llvmsharp_Demangle(const char* mangled_string, int32_t mangled_string_size, char* buffer, int32_t buffer_size);

LLVMSHARP_LINKAGE void llvmsharp_Free(void* obj);

LLVM_CLANG_C_EXTERN_C_END

#endif
