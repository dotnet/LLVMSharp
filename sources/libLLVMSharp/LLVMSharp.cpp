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
#include <llvm/IR/GlobalVariable.h>
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
#include <llvm/BinaryFormat/Dwarf.h>

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

uint32_t llvmsharp_DIBasicType_getEncoding(LLVMMetadataRef type)
{
    DIBasicType* unwrapped = unwrap<DIBasicType>(type);
    return unwrapped->getEncoding();
}

LLVMMetadataRef llvmsharp_DICompositeType_getBaseType(LLVMMetadataRef type)
{
    DICompositeType* unwrapped = unwrap<DICompositeType>(type);
    return wrap(unwrapped->getBaseType());
}

void llvmsharp_DICompositeType_getElements(LLVMMetadataRef type, LLVMMetadataRef** out_buffer, int32_t* out_size)
{
    DICompositeType* unwrapped = unwrap<DICompositeType>(type);
    DINodeArray array = unwrapped->getElements();
    int32_t size = array.size();

    LLVMMetadataRef* buffer = (LLVMMetadataRef*)malloc(size * sizeof(LLVMMetadataRef));
    if (buffer == nullptr)
    {
        *out_buffer = nullptr;
        *out_size = 0;
        return; // Memory allocation failed
    }

    for (int32_t i = 0; i < size; ++i)
    {
        buffer[i] = wrap(array[i]);
    }

    *out_buffer = buffer;
    *out_size = size;
}

const char* llvmsharp_DICompositeType_getIdentifier(LLVMMetadataRef type, size_t* out_size)
{
    DICompositeType* unwrapped = unwrap<DICompositeType>(type);
    StringRef identifier = unwrapped->getIdentifier();
    *out_size = (int32_t)identifier.size();
    return identifier.data();
}

LLVMMetadataRef llvmsharp_DIDerivedType_getBaseType(LLVMMetadataRef type)
{
    DIDerivedType* unwrapped = unwrap<DIDerivedType>(type);
    return wrap(unwrapped->getBaseType());
}

LLVMMetadataRef llvmsharp_DIDerivedType_getExtraData(LLVMMetadataRef type)
{
    DIDerivedType* unwrapped = unwrap<DIDerivedType>(type);
    return wrap(unwrapped->getExtraData());
}

const char* llvmsharp_DIEnumerator_getName(LLVMMetadataRef enumerator, size_t* out_size)
{
    DIEnumerator* unwrapped = unwrap<DIEnumerator>(enumerator);
    StringRef name = unwrapped->getName();
    *out_size = (int32_t)name.size();
    return name.data();
}

int64_t llvmsharp_DIEnumerator_getValue_SExt(LLVMMetadataRef enumerator)
{
    DIEnumerator* unwrapped = unwrap<DIEnumerator>(enumerator);
    return unwrapped->getValue().getSExtValue();
}

uint64_t llvmsharp_DIEnumerator_getValue_ZExt(LLVMMetadataRef enumerator)
{
    DIEnumerator* unwrapped = unwrap<DIEnumerator>(enumerator);
    return unwrapped->getValue().getZExtValue();
}

uint8_t llvmsharp_DIEnumerator_isUnsigned(LLVMMetadataRef enumerator)
{
    DIEnumerator* unwrapped = unwrap<DIEnumerator>(enumerator);
    return unwrapped->isUnsigned();
}

const char* llvmsharp_DIFile_getDirectory(LLVMMetadataRef file, size_t* out_size)
{
    DIFile* unwrapped = unwrap<DIFile>(file);
    StringRef name = unwrapped->getDirectory();
    *out_size = (int32_t)name.size();
    return name.data();
}

const char* llvmsharp_DIFile_getFilename(LLVMMetadataRef file, size_t* out_size)
{
    DIFile* unwrapped = unwrap<DIFile>(file);
    StringRef name = unwrapped->getFilename();
    *out_size = (int32_t)name.size();
    return name.data();
}

LLVMMetadataRef llvmsharp_DIImportedEntity_getEntity(LLVMMetadataRef node)
{
    DIImportedEntity* unwrapped = unwrap<DIImportedEntity>(node);
    return wrap(unwrapped->getEntity());
}

LLVMMetadataRef llvmsharp_DIImportedEntity_getFile(LLVMMetadataRef node)
{
    DIImportedEntity* unwrapped = unwrap<DIImportedEntity>(node);
    return wrap(unwrapped->getFile());
}

uint32_t llvmsharp_DIImportedEntity_getLine(LLVMMetadataRef node)
{
    DIImportedEntity* unwrapped = unwrap<DIImportedEntity>(node);
    return unwrapped->getLine();
}

LLVMMetadataRef llvmsharp_DIImportedEntity_getScope(LLVMMetadataRef node)
{
    DIImportedEntity* unwrapped = unwrap<DIImportedEntity>(node);
    return wrap(unwrapped->getScope());
}

uint32_t llvmsharp_DILexicalBlock_getLine(LLVMMetadataRef block)
{
    DILexicalBlock* unwrapped = unwrap<DILexicalBlock>(block);
    return unwrapped->getLine();
}

LLVMMetadataRef llvmsharp_DILexicalBlock_getScope(LLVMMetadataRef block)
{
    DILexicalBlock* unwrapped = unwrap<DILexicalBlock>(block);
    return wrap(unwrapped->getScope());
}

const char* llvmsharp_DINamespace_getName(LLVMMetadataRef node, size_t* out_size)
{
    DINamespace* unwrapped = unwrap<DINamespace>(node);
    StringRef name = unwrapped->getName();
    *out_size = (int32_t)name.size();
    return name.data();
}

LLVMMetadataRef llvmsharp_DINamespace_getScope(LLVMMetadataRef node)
{
    DINamespace* unwrapped = unwrap<DINamespace>(node);
    return wrap(unwrapped->getScope());
}

const char* llvmsharp_DINode_getTagString(LLVMMetadataRef node, size_t* out_size)
{
    DINode* unwrapped = unwrap<DINode>(node);
    uint16_t tag = unwrapped->getTag();
    StringRef name = dwarf::TagString(tag);
    *out_size = (int32_t)name.size();
    return name.data();
}

LLVMMetadataRef llvmsharp_DISubprogram_getContainingType(LLVMMetadataRef subprogram)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    return wrap(unwrapped->getContainingType());
}

uint32_t llvmsharp_DISubprogram_getFlags(LLVMMetadataRef subprogram)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    return unwrapped->getFlags();
}

const char* llvmsharp_DISubprogram_getLinkageName(LLVMMetadataRef subprogram, size_t* out_size)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    StringRef name = unwrapped->getLinkageName();
    *out_size = (int32_t)name.size();
    return name.data();
}

const char* llvmsharp_DISubprogram_getName(LLVMMetadataRef subprogram, size_t* out_size)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    StringRef name = unwrapped->getName();
    *out_size = (int32_t)name.size();
    return name.data();
}

uint32_t llvmsharp_DISubprogram_getScopeLine(LLVMMetadataRef subprogram)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    return unwrapped->getScopeLine();
}

uint32_t llvmsharp_DISubprogram_getSPFlags(LLVMMetadataRef subprogram)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    return unwrapped->getSPFlags();
}

void llvmsharp_DISubprogram_getTemplateParams(LLVMMetadataRef subprogram, LLVMMetadataRef** out_buffer, int32_t* out_size)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    DITemplateParameterArray array = unwrapped->getTemplateParams();
    int32_t size = array.size();

    LLVMMetadataRef* buffer = (LLVMMetadataRef*)malloc(size * sizeof(LLVMMetadataRef));
    if (buffer == nullptr)
    {
        *out_buffer = nullptr;
        *out_size = 0;
        return; // Memory allocation failed
    }

    for (int32_t i = 0; i < size; ++i)
    {
        buffer[i] = wrap(array[i]);
    }

    *out_buffer = buffer;
    *out_size = size;
}

LLVMMetadataRef llvmsharp_DISubprogram_getType(LLVMMetadataRef subprogram)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    return wrap(unwrapped->getType());
}

uint32_t llvmsharp_DISubprogram_getVirtualIndex(LLVMMetadataRef subprogram)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    return unwrapped->getVirtualIndex();
}

void llvmsharp_DISubroutineType_getTypeArray(LLVMMetadataRef subroutine_type, LLVMMetadataRef** out_buffer, int32_t* out_size)
{
    DISubroutineType* unwrapped = unwrap<DISubroutineType>(subroutine_type);
    DITypeRefArray array = unwrapped->getTypeArray();
    int32_t size = array.size();

    LLVMMetadataRef* buffer = (LLVMMetadataRef*)malloc(size * sizeof(LLVMMetadataRef));
    if (buffer == nullptr)
    {
        *out_buffer = nullptr;
        *out_size = 0;
        return; // Memory allocation failed
    }

    for (int32_t i = 0; i < size; ++i)
    {
        buffer[i] = wrap(array[i]);
    }

    *out_buffer = buffer;
    *out_size = size;
}

LLVMMetadataRef llvmsharp_DITemplateParameter_getType(LLVMMetadataRef parameter)
{
    DITemplateParameter* unwrapped = unwrap<DITemplateParameter>(parameter);
    return wrap(unwrapped->getType());
}

LLVMMetadataRef llvmsharp_DITemplateValueParameter_getValue(LLVMMetadataRef parameter)
{
    DITemplateValueParameter* unwrapped = unwrap<DITemplateValueParameter>(parameter);
    return wrap(unwrapped->getValue());
}

const char* llvmsharp_DIVariable_getName(LLVMMetadataRef variable, size_t* out_size)
{
    DIVariable* unwrapped = unwrap<DIVariable>(variable);
    StringRef name = unwrapped->getName();
    *out_size = (int32_t)name.size();
    return name.data();
}

LLVMMetadataRef llvmsharp_DIVariable_getType(LLVMMetadataRef variable)
{
    DIVariable* unwrapped = unwrap<DIVariable>(variable);
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

LLVMMetadataRef llvmsharp_GlobalVariable_getGlobalVariableExpression(LLVMValueRef global_variable)
{
    LLVMMetadataRef metadataRef = llvmsharp_GlobalVariable_getMetadata(global_variable, LLVMContext::MD_dbg);
    if (isa<Metadata, DIGlobalVariableExpression>(unwrap<Metadata>(metadataRef)))
    {
        return metadataRef;
    }
    else
    {
        return nullptr;
    }
}

LLVMMetadataRef llvmsharp_GlobalVariable_getMetadata(LLVMValueRef global_variable, uint32_t KindID)
{
    GlobalVariable* unwrapped = unwrap<GlobalVariable>(global_variable);
    return wrap(unwrapped->getMetadata(KindID));
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
