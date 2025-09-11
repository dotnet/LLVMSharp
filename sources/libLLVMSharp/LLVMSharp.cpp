// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

#include "LLVMSharp.h"
// Other project includes

#ifdef _MSC_VER
#pragma warning(push)
#pragma warning(disable : 4146 4244 4267 4291 4624 4996)
#endif

// Library includes (<> instead of "")
#include <llvm/IR/Constants.h>
#include <llvm/IR/DebugInfoMetadata.h>
#include <llvm/IR/DerivedTypes.h>
#include <llvm/IR/Function.h>
#include <llvm/IR/LegacyPassManager.h>
#include <llvm/IR/Module.h>
#include <llvm-c/Core.h>
#include <llvm/IR/Instructions.h>
#include <llvm/Demangle/Demangle.h>
#include <cstddef>
#include <string>
#include <string_view>
#include <llvm/Transforms/Scalar.h>
#include <llvm/Transforms/Utils.h>

#ifdef _MSC_VER
#pragma warning(pop)
#endif

// Namespace usings
using namespace llvm;

// Create wrappers for C Binding types (see CBindingWrapping.h).
DEFINE_ISA_CONVERSION_FUNCTIONS(Pass, LLVMPassRef)

// Implementation code

const char* llvmsharp_ConstantDataArray_getData(LLVMValueRef ConstantDataArrayRef, int32_t* out_size)
{
    Constant* constant = unwrap<Constant>(ConstantDataArrayRef);
    if (ConstantDataArray* value = dyn_cast<ConstantDataArray>(constant))
    {
        StringRef stringRef = value->getRawDataValues();
        *out_size = (int32_t)stringRef.size();
        return stringRef.data();
    }
    else
    {
        *out_size = 0;
        return nullptr;
    }
}

LLVMMetadataRef llvmsharp_DICompositeType_getBaseType(LLVMMetadataRef type)
{
    DICompositeType* unwrapped = unwrap<DICompositeType>(type);
    if (unwrapped == nullptr)
        return nullptr;

    return wrap(unwrapped->getBaseType());
}

void llvmsharp_DICompositeType_getElements(LLVMMetadataRef type, LLVMMetadataRef** out_buffer, int32_t* out_size)
{
    DICompositeType* unwrapped = unwrap<DICompositeType>(type);
    if (unwrapped == nullptr)
    {
        *out_buffer = nullptr;
        *out_size = 0;
        return;
    }

    DINodeArray nodeArray = unwrapped->getElements();
    int32_t size = nodeArray.size();

    LLVMMetadataRef* buffer = (LLVMMetadataRef*)malloc(size * sizeof(LLVMMetadataRef));
    if (buffer == nullptr)
    {
        *out_buffer = nullptr;
        *out_size = 0;
        return; // Memory allocation failed
    }

    for (int32_t i = 0; i < size; ++i)
    {
        buffer[i] = wrap(nodeArray[i]);
    }

    *out_buffer = buffer;
    *out_size = size;
}

const char* llvmsharp_DICompositeType_getIdentifier(LLVMMetadataRef type, size_t* out_size)
{
    DICompositeType* unwrapped = unwrap<DICompositeType>(type);
    if (unwrapped == nullptr)
    {
        *out_size = 0;
        return nullptr;
    }

    StringRef identifier = unwrapped->getIdentifier();
    *out_size = (int32_t)identifier.size();
    return identifier.data();
}

LLVMMetadataRef llvmsharp_DIDerivedType_getBaseType(LLVMMetadataRef type)
{
    DIDerivedType* unwrapped = unwrap<DIDerivedType>(type);
    if (unwrapped == nullptr)
        return nullptr;

    return wrap(unwrapped->getBaseType());
}

uint32_t llvmsharp_DIDerivedType_getEncoding(LLVMMetadataRef type)
{
    DIBasicType* unwrapped = unwrap<DIBasicType>(type);
    if (unwrapped == nullptr)
        return 0;

    return unwrapped->getEncoding();
}

LLVMMetadataRef llvmsharp_DISubprogram_getType(LLVMMetadataRef subprogram)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    if (unwrapped == nullptr)
        return nullptr;

    return wrap(unwrapped->getType());
}

uint32_t llvmsharp_DISubprogram_getFlags(LLVMMetadataRef subprogram)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    if (unwrapped == nullptr)
        return 0;

    return unwrapped->getFlags();
}

const char* llvmsharp_DISubprogram_getName(LLVMMetadataRef subprogram, size_t* out_size)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    if (unwrapped == nullptr)
    {
        *out_size = 0;
        return nullptr;
    }

    StringRef name = unwrapped->getName();
    *out_size = (int32_t)name.size();
    return name.data();
}

uint32_t llvmsharp_DISubprogram_getSPFlags(LLVMMetadataRef subprogram)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    if (unwrapped == nullptr)
        return 0;

    return unwrapped->getSPFlags();
}

void llvmsharp_DISubroutineType_getTypeArray(LLVMMetadataRef subroutine_type, LLVMMetadataRef** out_buffer, int32_t* out_size)
{
    DISubroutineType* unwrapped = unwrap<DISubroutineType>(subroutine_type);
    if (unwrapped == nullptr)
    {
        *out_buffer = nullptr;
        *out_size = 0;
        return;
    }

    DITypeRefArray typeArray = unwrapped->getTypeArray();
    int32_t size = typeArray.size();

    LLVMMetadataRef* buffer = (LLVMMetadataRef*)malloc(size * sizeof(LLVMMetadataRef));
    if (buffer == nullptr)
    {
        *out_buffer = nullptr;
        *out_size = 0;
        return; // Memory allocation failed
    }

    for (int32_t i = 0; i < size; ++i)
    {
        buffer[i] = wrap(typeArray[i]);
    }

    *out_buffer = buffer;
    *out_size = size;
}

LLVMMetadataRef llvmsharp_DITemplateParameter_getType(LLVMMetadataRef parameter)
{
    DITemplateParameter* unwrapped = unwrap<DITemplateParameter>(parameter);
    if (unwrapped == nullptr)
        return nullptr;

    return wrap(unwrapped->getType());
}

LLVMMetadataRef llvmsharp_DITemplateValueParameter_getValue(LLVMMetadataRef parameter)
{
    DITemplateValueParameter* unwrapped = unwrap<DITemplateValueParameter>(parameter);
    if (unwrapped == nullptr)
        return nullptr;

    return wrap(unwrapped->getValue());
}

const char* llvmsharp_DIVariable_getName(LLVMMetadataRef variable, size_t* out_size)
{
    DIVariable* unwrapped = unwrap<DIVariable>(variable);
    if (unwrapped == nullptr)
    {
        *out_size = 0;
        return nullptr;
    }

    StringRef name = unwrapped->getName();
    *out_size = (int32_t)name.size();
    return name.data();
}

LLVMMetadataRef llvmsharp_DIVariable_getType(LLVMMetadataRef variable)
{
    DIVariable* unwrapped = unwrap<DIVariable>(variable);
    if (unwrapped == nullptr)
        return nullptr;

    return wrap(unwrapped->getType());
}

LLVMTypeRef llvmsharp_Function_getFunctionType(LLVMValueRef FnRef)
{
    Function* Fn = unwrap<Function>(FnRef);
    Type* type = Fn->getFunctionType();
    return wrap(type);
}

LLVMTypeRef llvmsharp_Function_getReturnType(LLVMValueRef FnRef)
{
    Function* Fn = unwrap<Function>(FnRef);
    Type* type = Fn->getReturnType();
    return wrap(type);
}

uint8_t llvmsharp_Instruction_hasNoSignedWrap(LLVMValueRef InstructionRef)
{
    Instruction* instruction = unwrap<Instruction>(InstructionRef);
    return instruction->hasNoSignedWrap() ? 1 : 0;
}

uint8_t llvmsharp_Instruction_hasNoUnsignedWrap(LLVMValueRef InstructionRef)
{
    Instruction* instruction = unwrap<Instruction>(InstructionRef);
    return instruction->hasNoUnsignedWrap() ? 1 : 0;
}

void llvmsharp_Module_GetIdentifiedStructTypes(LLVMModuleRef module, LLVMTypeRef** out_buffer, int32_t* out_size)
{
    Module* M = unwrap(module);
    std::vector<StructType*> types = M->getIdentifiedStructTypes();

    LLVMTypeRef* buffer = (LLVMTypeRef*)malloc(types.size() * sizeof(LLVMTypeRef));
    if (buffer == nullptr)
    {
        *out_buffer = nullptr;
        *out_size = 0;
        return; // Memory allocation failed
    }

    for (size_t i = 0; i < types.size(); ++i)
    {
        buffer[i] = wrap(types[i]);
    }

    *out_buffer = buffer;
    *out_size = (int32_t)types.size();
}

void llvmsharp_PassManager_add(LLVMPassManagerRef pass_manager, LLVMPassRef pass)
{
    unwrap(pass_manager)->add(unwrap(pass));
}

int32_t llvmsharp_Value_getDemangledName(LLVMValueRef ValueRef, char* buffer, int32_t buffer_size)
{
    const char* mangled = LLVMGetValueName(ValueRef);
    std::string result = llvm::demangle(std::string_view(mangled));
    int32_t length = (int32_t)result.length();
    int32_t size = length < buffer_size ? length : buffer_size;
    memcpy(buffer, result.c_str(), size);
    return size;
}

LLVMPassRef llvmsharp_createDeadCodeEliminationPass()
{
    return wrap((Pass*)createDeadCodeEliminationPass());
}

LLVMPassRef llvmsharp_createSROAPass(uint8_t PreserveCFG)
{
    return wrap((Pass*)createSROAPass((bool)PreserveCFG));
}

LLVMPassRef llvmsharp_createLICMPass()
{
    return wrap(createLICMPass());
}

LLVMPassRef llvmsharp_createLoopStrengthReducePass()
{
    return wrap(createLoopStrengthReducePass());
}

LLVMPassRef llvmsharp_createReassociatePass()
{
    return wrap((Pass*)createReassociatePass());
}

LLVMPassRef llvmsharp_createFlattenCFGPass()
{
    return wrap((Pass*)createFlattenCFGPass());
}

LLVMPassRef llvmsharp_createCFGSimplificationPass()
{
    return wrap((Pass*)createCFGSimplificationPass());
}

LLVMPassRef llvmsharp_createTailCallEliminationPass()
{
    return wrap((Pass*)createTailCallEliminationPass());
}

LLVMPassRef llvmsharp_createConstantHoistingPass()
{
    return wrap((Pass*)createConstantHoistingPass());
}

LLVMPassRef llvmsharp_createLowerInvokePass()
{
    return wrap((Pass*)createLowerInvokePass());
}

LLVMPassRef llvmsharp_createLowerSwitchPass()
{
    return wrap((Pass*)createLowerSwitchPass());
}

LLVMPassRef llvmsharp_createBreakCriticalEdgesPass()
{
    return wrap((Pass*)createBreakCriticalEdgesPass());
}

LLVMPassRef llvmsharp_createLCSSAPass()
{
    return wrap(createLCSSAPass());
}

LLVMPassRef llvmsharp_createPromoteMemoryToRegisterPass(uint8_t IsForced)
{
    return wrap((Pass*)createPromoteMemoryToRegisterPass());
}

LLVMPassRef llvmsharp_createLoopSimplifyPass()
{
    return wrap(createLoopSimplifyPass());
}

LLVMPassRef llvmsharp_createUnifyLoopExitsPass()
{
    return wrap((Pass*)createUnifyLoopExitsPass());
}

void llvmsharp_Free(void* obj)
{
    free(obj);
}
