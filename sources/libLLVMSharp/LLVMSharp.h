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

// Need: getReturnType, getFunctionType, getStructsFromModule?, and demangling

LLVMSHARP_LINKAGE LLVMTypeRef llvmsharp_Function_getReturnType(LLVMValueRef FnRef);

LLVMSHARP_LINKAGE LLVMTypeRef llvmsharp_Function_getFunctionType(LLVMValueRef FnRef);

LLVMSHARP_LINKAGE uint8_t llvmsharp_Instruction_hasNoSignedWrap(LLVMValueRef InstructionRef);

LLVMSHARP_LINKAGE uint8_t llvmsharp_Instruction_hasNoUnsignedWrap(LLVMValueRef InstructionRef);

LLVMSHARP_LINKAGE const char* llvmsharp_ConstantDataArray_getData(LLVMValueRef ConstantDataArrayRef, int32_t* out_size);

LLVMSHARP_LINKAGE int32_t llvmsharp_Value_getDemangledName(LLVMValueRef ValueRef, char* buffer, int32_t buffer_size);

LLVMSHARP_LINKAGE void llvmsharp_PassManager_add(LLVMPassManagerRef pass_manager, LLVMPassRef pass);

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

LLVMSHARP_LINKAGE void llvmsharp_Module_GetIdentifiedStructTypes(LLVMModuleRef module, LLVMTypeRef** out_buffer, int32_t* out_size);

LLVMSHARP_LINKAGE void llvmsharp_FreeTypeBuffer(LLVMTypeRef* buffer);

LLVM_CLANG_C_EXTERN_C_END

#endif
