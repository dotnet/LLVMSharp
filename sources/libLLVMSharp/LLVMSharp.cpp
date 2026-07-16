// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

#include "LLVMSharp.h"
// Other project includes

#ifdef _MSC_VER
#pragma warning(push)
#pragma warning(disable : 4146 4244 4267 4291 4624 4996)
#endif

// Library includes (<> instead of "")
#include <llvm/Analysis/ConstantFolding.h>
#include <llvm/Analysis/InstructionSimplify.h>
#include <llvm/Analysis/LoopInfo.h>
#include <llvm/Analysis/PostDominators.h>
#include <llvm/Analysis/TargetTransformInfo.h>
#include <llvm/ExecutionEngine/Orc/Core.h>
#include <llvm/ExecutionEngine/Orc/Layer.h>
#include <llvm/ExecutionEngine/Orc/ObjectLinkingLayer.h>
#include <llvm/IR/Constants.h>
#include <llvm/IR/DebugInfoMetadata.h>
#include <llvm/IR/DerivedTypes.h>
#include <llvm/IR/Dominators.h>
#include <llvm/IR/Function.h>
#include <llvm/IR/GlobalValue.h>
#include <llvm/IR/GlobalVariable.h>
#include <llvm/IR/InstrTypes.h>
#include <llvm/IR/LegacyPassManager.h>
#include <llvm/IR/Mangler.h>
#include <llvm/IR/Module.h>
#include <llvm/IR/Operator.h>
#include <llvm-c/Core.h>
#include <llvm-c/Orc.h>
#include <llvm/IR/Instructions.h>
#include <llvm/Demangle/Demangle.h>
#include <llvm/Support/CBindingWrapping.h>
#include <llvm/Support/raw_ostream.h>
#include <llvm/Support/TypeSize.h>
#include <llvm/Target/TargetMachine.h>
#include <cstddef>
#include <cstring>
#include <string>
#include <string_view>
#include <llvm/Transforms/Scalar.h>
#include <llvm/Transforms/Utils.h>
#include <llvm/Transforms/Utils/Cloning.h>
#include <llvm/BinaryFormat/Dwarf.h>

#ifdef _MSC_VER
#pragma warning(pop)
#endif

// Namespace usings
using namespace llvm;

// Create wrappers for C Binding types (see CBindingWrapping.h).
DEFINE_ISA_CONVERSION_FUNCTIONS(Pass, LLVMPassRef)
DEFINE_SIMPLE_CONVERSION_FUNCTIONS(orc::ExecutionSession, LLVMOrcExecutionSessionRef)
DEFINE_SIMPLE_CONVERSION_FUNCTIONS(orc::ObjectLayer, LLVMOrcObjectLayerRef)
DEFINE_SIMPLE_CONVERSION_FUNCTIONS(DominatorTree, LLVMSharpDominatorTreeRef)
DEFINE_SIMPLE_CONVERSION_FUNCTIONS(Loop, LLVMSharpLoopRef)
DEFINE_SIMPLE_CONVERSION_FUNCTIONS(LoopInfo, LLVMSharpLoopInfoRef)
DEFINE_SIMPLE_CONVERSION_FUNCTIONS(PostDominatorTree, LLVMSharpPostDominatorTreeRef)
DEFINE_SIMPLE_CONVERSION_FUNCTIONS(TargetMachine, LLVMTargetMachineRef)
DEFINE_SIMPLE_CONVERSION_FUNCTIONS(TargetTransformInfo, LLVMSharpTargetTransformInfoRef)

// Implementation code

uint8_t llvmsharp_CallBase_isIndirectCall(LLVMValueRef call)
{
    CallBase* unwrapped = unwrap<CallBase>(call);
    return unwrapped->isIndirectCall() ? 1 : 0;
}

LLVMValueRef llvmsharp_CloneFunction(LLVMValueRef function)
{
    Function* unwrapped = unwrap<Function>(function);
    ValueToValueMapTy valueMap;
    return wrap(CloneFunction(unwrapped, valueMap));
}

int32_t llvmsharp_CmpInst_getInversePredicate(LLVMValueRef instruction)
{
    CmpInst* unwrapped = unwrap<CmpInst>(instruction);
    return (int32_t)unwrapped->getInversePredicate();
}

const char* llvmsharp_CmpInst_getPredicateName(LLVMValueRef instruction, int32_t* out_size)
{
    CmpInst* unwrapped = unwrap<CmpInst>(instruction);
    StringRef name = CmpInst::getPredicateName(unwrapped->getPredicate());
    *out_size = (int32_t)name.size();
    return name.data();
}

int32_t llvmsharp_CmpInst_getSwappedPredicate(LLVMValueRef instruction)
{
    CmpInst* unwrapped = unwrap<CmpInst>(instruction);
    return (int32_t)unwrapped->getSwappedPredicate();
}

uint8_t llvmsharp_CmpInst_isFalseWhenEqual(LLVMValueRef instruction)
{
    CmpInst* unwrapped = unwrap<CmpInst>(instruction);
    return unwrapped->isFalseWhenEqual() ? 1 : 0;
}

uint8_t llvmsharp_CmpInst_isSigned(LLVMValueRef instruction)
{
    CmpInst* unwrapped = unwrap<CmpInst>(instruction);
    return unwrapped->isSigned() ? 1 : 0;
}

uint8_t llvmsharp_CmpInst_isTrueWhenEqual(LLVMValueRef instruction)
{
    CmpInst* unwrapped = unwrap<CmpInst>(instruction);
    return unwrapped->isTrueWhenEqual() ? 1 : 0;
}

uint8_t llvmsharp_CmpInst_isUnsigned(LLVMValueRef instruction)
{
    CmpInst* unwrapped = unwrap<CmpInst>(instruction);
    return unwrapped->isUnsigned() ? 1 : 0;
}

const char* llvmsharp_ConstantDataArray_getData(LLVMValueRef array, int32_t* out_size)
{
    ConstantDataArray* unwrapped = unwrap<ConstantDataArray>(array);
    StringRef stringRef = unwrapped->getRawDataValues();
    *out_size = (int32_t)stringRef.size();
    return stringRef.data();
}

LLVMValueRef llvmsharp_ConstantFoldCompareInstOperands(int32_t predicate, LLVMValueRef lhs, LLVMValueRef rhs, LLVMModuleRef module)
{
    Constant* lhsConstant = unwrap<Constant>(lhs);
    Constant* rhsConstant = unwrap<Constant>(rhs);
    const DataLayout& dataLayout = unwrap(module)->getDataLayout();
    return wrap(ConstantFoldCompareInstOperands((unsigned)predicate, lhsConstant, rhsConstant, dataLayout));
}

LLVMValueRef llvmsharp_ConstantFoldConstant(LLVMValueRef constant, LLVMModuleRef module)
{
    Constant* unwrapped = unwrap<Constant>(constant);
    const DataLayout& dataLayout = unwrap(module)->getDataLayout();
    return wrap(ConstantFoldConstant(unwrapped, dataLayout));
}

LLVMValueRef llvmsharp_ConstantFoldInstruction(LLVMValueRef instruction, LLVMModuleRef module)
{
    Instruction* unwrapped = unwrap<Instruction>(instruction);
    const DataLayout& dataLayout = unwrap(module)->getDataLayout();
    return wrap(ConstantFoldInstruction(unwrapped, dataLayout));
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

const char* llvmsharp_DICompositeType_getIdentifier(LLVMMetadataRef type, int32_t* out_size)
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

const char* llvmsharp_DIEnumerator_getName(LLVMMetadataRef enumerator, int32_t* out_size)
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

const char* llvmsharp_DINamespace_getName(LLVMMetadataRef node, int32_t* out_size)
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

const char* llvmsharp_DINode_getTagString(LLVMMetadataRef node, int32_t* out_size)
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

const char* llvmsharp_DISubprogram_getLinkageName(LLVMMetadataRef subprogram, int32_t* out_size)
{
    DISubprogram* unwrapped = unwrap<DISubprogram>(subprogram);
    StringRef name = unwrapped->getLinkageName();
    *out_size = (int32_t)name.size();
    return name.data();
}

const char* llvmsharp_DISubprogram_getName(LLVMMetadataRef subprogram, int32_t* out_size)
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

LLVMValueRef llvmsharp_DISubrange_getCount(LLVMMetadataRef subrange)
{
    DISubrange* unwrapped = unwrap<DISubrange>(subrange);
    Metadata* countNode = unwrapped->getRawCountNode();
    if (isa<ConstantAsMetadata>(countNode))
    {
        ConstantAsMetadata* constantAsMetadata = cast<ConstantAsMetadata>(countNode);
        Constant* constant = constantAsMetadata->getValue();
        return wrap(constant);
    }
    return nullptr;
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

const char* llvmsharp_DIVariable_getName(LLVMMetadataRef variable, int32_t* out_size)
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

LLVMSharpDominatorTreeRef llvmsharp_DominatorTree_create(LLVMValueRef function)
{
    Function* unwrapped = unwrap<Function>(function);
    return wrap(new DominatorTree(*unwrapped));
}

void llvmsharp_DominatorTree_dispose(LLVMSharpDominatorTreeRef dominator_tree)
{
    delete unwrap(dominator_tree);
}

uint8_t llvmsharp_DominatorTree_dominatesBlock(LLVMSharpDominatorTreeRef dominator_tree, LLVMBasicBlockRef a, LLVMBasicBlockRef b)
{
    DominatorTree* unwrapped = unwrap(dominator_tree);
    return unwrapped->dominates(unwrap(a), unwrap(b)) ? 1 : 0;
}

uint8_t llvmsharp_DominatorTree_dominatesInstruction(LLVMSharpDominatorTreeRef dominator_tree, LLVMValueRef def, LLVMValueRef user)
{
    DominatorTree* unwrapped = unwrap(dominator_tree);
    return unwrapped->dominates(unwrap<Value>(def), unwrap<Instruction>(user)) ? 1 : 0;
}

LLVMBasicBlockRef llvmsharp_DominatorTree_getIDom(LLVMSharpDominatorTreeRef dominator_tree, LLVMBasicBlockRef block)
{
    DominatorTree* unwrapped = unwrap(dominator_tree);
    DomTreeNode* node = unwrapped->getNode(unwrap(block));
    if (node == nullptr)
    {
        return nullptr;
    }
    DomTreeNode* immediateDominator = node->getIDom();
    if (immediateDominator == nullptr)
    {
        return nullptr;
    }
    return wrap(immediateDominator->getBlock());
}

uint8_t llvmsharp_DominatorTree_properlyDominatesBlock(LLVMSharpDominatorTreeRef dominator_tree, LLVMBasicBlockRef a, LLVMBasicBlockRef b)
{
    DominatorTree* unwrapped = unwrap(dominator_tree);
    return unwrapped->properlyDominates(unwrap(a), unwrap(b)) ? 1 : 0;
}

LLVMTypeRef llvmsharp_Function_getFunctionType(LLVMValueRef function)
{
    Function* unwrapped = unwrap<Function>(function);
    Type* type = unwrapped->getFunctionType();
    return wrap(type);
}

LLVMTypeRef llvmsharp_Function_getReturnType(LLVMValueRef function)
{
    Function* unwrapped = unwrap<Function>(function);
    Type* type = unwrapped->getReturnType();
    return wrap(type);
}

uint8_t llvmsharp_GEPOperator_accumulateConstantOffset(LLVMValueRef gep, LLVMModuleRef module, int64_t* out_offset)
{
    GEPOperator* unwrapped = unwrap<GEPOperator>(gep);
    const DataLayout& dataLayout = unwrap(module)->getDataLayout();
    unsigned bitWidth = dataLayout.getIndexTypeSizeInBits(unwrapped->getType());
    APInt offset(bitWidth, 0);
    if (!unwrapped->accumulateConstantOffset(dataLayout, offset))
    {
        *out_offset = 0;
        return 0;
    }
    *out_offset = offset.getSExtValue();
    return 1;
}

uint32_t llvmsharp_GlobalValue_getAddressSpace(LLVMValueRef global_value)
{
    GlobalValue* unwrapped = unwrap<GlobalValue>(global_value);
    return unwrapped->getAddressSpace();
}

uint8_t llvmsharp_GlobalValue_isDSOLocal(LLVMValueRef global_value)
{
    GlobalValue* unwrapped = unwrap<GlobalValue>(global_value);
    return unwrapped->isDSOLocal() ? 1 : 0;
}

LLVMMetadataRef llvmsharp_GlobalVariable_getGlobalVariableExpression(LLVMValueRef global_variable)
{
    LLVMMetadataRef unwrapped = llvmsharp_GlobalVariable_getMetadata(global_variable, LLVMContext::MD_dbg);
    if (isa<Metadata, DIGlobalVariableExpression>(unwrap<Metadata>(unwrapped)))
    {
        return unwrapped;
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

uint8_t llvmsharp_InlineFunction(LLVMValueRef call_base)
{
    CallBase* unwrapped = unwrap<CallBase>(call_base);
    InlineFunctionInfo inlineFunctionInfo;
    InlineResult result = InlineFunction(*unwrapped, inlineFunctionInfo);
    return result.isSuccess() ? 1 : 0;
}

uint8_t llvmsharp_Instruction_comesBefore(LLVMValueRef instruction, LLVMValueRef other)
{
    Instruction* unwrapped = unwrap<Instruction>(instruction);
    return unwrapped->comesBefore(unwrap<Instruction>(other)) ? 1 : 0;
}

const char* llvmsharp_Instruction_getOpcodeName(LLVMValueRef instruction, int32_t* out_size)
{
    Instruction* unwrapped = unwrap<Instruction>(instruction);
    const char* name = unwrapped->getOpcodeName();
    *out_size = (int32_t)strlen(name);
    return name;
}

uint8_t llvmsharp_Instruction_isCommutative(LLVMValueRef instruction)
{
    Instruction* unwrapped = unwrap<Instruction>(instruction);
    return unwrapped->isCommutative() ? 1 : 0;
}

uint8_t llvmsharp_Instruction_mayHaveSideEffects(LLVMValueRef instruction)
{
    Instruction* unwrapped = unwrap<Instruction>(instruction);
    return unwrapped->mayHaveSideEffects() ? 1 : 0;
}

uint8_t llvmsharp_Instruction_mayReadFromMemory(LLVMValueRef instruction)
{
    Instruction* unwrapped = unwrap<Instruction>(instruction);
    return unwrapped->mayReadFromMemory() ? 1 : 0;
}

uint8_t llvmsharp_Instruction_mayWriteToMemory(LLVMValueRef instruction)
{
    Instruction* unwrapped = unwrap<Instruction>(instruction);
    return unwrapped->mayWriteToMemory() ? 1 : 0;
}

void llvmsharp_Instruction_moveAfter(LLVMValueRef instruction, LLVMValueRef position)
{
    Instruction* unwrapped = unwrap<Instruction>(instruction);
    unwrapped->moveAfter(unwrap<Instruction>(position));
}

void llvmsharp_Instruction_moveBefore(LLVMValueRef instruction, LLVMValueRef position)
{
    Instruction* unwrapped = unwrap<Instruction>(instruction);
    Instruction* positionInstruction = unwrap<Instruction>(position);
    unwrapped->moveBefore(positionInstruction->getIterator());
}

LLVMSharpLoopInfoRef llvmsharp_LoopInfo_create(LLVMSharpDominatorTreeRef dominator_tree)
{
    DominatorTree* unwrapped = unwrap(dominator_tree);
    return wrap(new LoopInfo(*unwrapped));
}

void llvmsharp_LoopInfo_dispose(LLVMSharpLoopInfoRef loop_info)
{
    delete unwrap(loop_info);
}

uint32_t llvmsharp_LoopInfo_getLoopDepth(LLVMSharpLoopInfoRef loop_info, LLVMBasicBlockRef block)
{
    LoopInfo* unwrapped = unwrap(loop_info);
    return unwrapped->getLoopDepth(unwrap(block));
}

LLVMSharpLoopRef llvmsharp_LoopInfo_getLoopFor(LLVMSharpLoopInfoRef loop_info, LLVMBasicBlockRef block)
{
    LoopInfo* unwrapped = unwrap(loop_info);
    return wrap(unwrapped->getLoopFor(unwrap(block)));
}

uint8_t llvmsharp_Loop_containsBlock(LLVMSharpLoopRef loop, LLVMBasicBlockRef block)
{
    Loop* unwrapped = unwrap(loop);
    return unwrapped->contains(unwrap(block)) ? 1 : 0;
}

LLVMBasicBlockRef llvmsharp_Loop_getExitBlock(LLVMSharpLoopRef loop)
{
    Loop* unwrapped = unwrap(loop);
    return wrap(unwrapped->getExitBlock());
}

LLVMBasicBlockRef llvmsharp_Loop_getHeader(LLVMSharpLoopRef loop)
{
    Loop* unwrapped = unwrap(loop);
    return wrap(unwrapped->getHeader());
}

uint32_t llvmsharp_Loop_getLoopDepth(LLVMSharpLoopRef loop)
{
    Loop* unwrapped = unwrap(loop);
    return unwrapped->getLoopDepth();
}

LLVMBasicBlockRef llvmsharp_Loop_getLoopLatch(LLVMSharpLoopRef loop)
{
    Loop* unwrapped = unwrap(loop);
    return wrap(unwrapped->getLoopLatch());
}

LLVMBasicBlockRef llvmsharp_Loop_getLoopPreheader(LLVMSharpLoopRef loop)
{
    Loop* unwrapped = unwrap(loop);
    return wrap(unwrapped->getLoopPreheader());
}

LLVMSharpLoopRef llvmsharp_Loop_getParentLoop(LLVMSharpLoopRef loop)
{
    Loop* unwrapped = unwrap(loop);
    return wrap(unwrapped->getParentLoop());
}

const char* llvmsharp_Mangler_getNameWithPrefix(LLVMValueRef global_value, int32_t* out_size)
{
    GlobalValue* unwrapped = unwrap<GlobalValue>(global_value);
    std::string result;
    raw_string_ostream stream(result);
    Mangler mangler;
    mangler.getNameWithPrefix(stream, unwrapped, false);
    stream.flush();

    int32_t size = (int32_t)result.size();
    char* buffer = (char*)malloc((size_t)size + 1);
    if (buffer == nullptr)
    {
        *out_size = 0;
        return nullptr; // Memory allocation failed
    }

    memcpy(buffer, result.data(), size);
    buffer[size] = '\0';
    *out_size = size;
    return buffer;
}

uint32_t llvmsharp_MDNode_getNumOperands(LLVMMetadataRef metadata)
{
    MDNode* unwrapped = unwrap<MDNode>(metadata);
    return unwrapped->getNumOperands();
}

LLVMMetadataRef llvmsharp_MDNode_getOperand(LLVMMetadataRef metadata, uint32_t index)
{
    MDNode* unwrapped = unwrap<MDNode>(metadata);
    if (index >= unwrapped->getNumOperands())
    {
        return nullptr; // Index out of bounds
    }
    return wrap(unwrapped->getOperand(index));
}

const char* llvmsharp_MDString_getString(LLVMMetadataRef mdstring, int32_t* out_size)
{
    MDString* unwrapped = unwrap<MDString>(mdstring);
    StringRef str = unwrapped->getString();
    *out_size = (int32_t)str.size();
    return str.data();
}

#define LLVMSHARP_METADATA_ISA(CPP_TYPE) \
LLVMMetadataRef llvmsharp_Metadata_IsA##CPP_TYPE(LLVMMetadataRef metadata) \
{ \
    return wrap(static_cast<Metadata*>(dyn_cast_or_null<CPP_TYPE>(unwrap(metadata)))); \
}

LLVM_FOR_EACH_METADATA_SUBCLASS(LLVMSHARP_METADATA_ISA)

#undef LLVMSHARP_METADATA_ISA

void llvmsharp_Module_GetIdentifiedStructTypes(LLVMModuleRef module, LLVMTypeRef** out_buffer, int32_t* out_size)
{
    Module* unwrapped = unwrap(module);
    std::vector<StructType*> types = unwrapped->getIdentifiedStructTypes();

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

LLVMOrcObjectLayerRef llvmsharp_OrcCreateObjectLinkingLayer(LLVMOrcExecutionSessionRef execution_session)
{
    orc::ExecutionSession* unwrapped = unwrap(execution_session);
    orc::ObjectLinkingLayer* layer = new orc::ObjectLinkingLayer(*unwrapped);
    return wrap(static_cast<orc::ObjectLayer*>(layer));
}

void llvmsharp_PassManager_add(LLVMPassManagerRef pass_manager, LLVMPassRef pass)
{
    unwrap(pass_manager)->add(unwrap(pass));
}

LLVMSharpPostDominatorTreeRef llvmsharp_PostDominatorTree_create(LLVMValueRef function)
{
    Function* unwrapped = unwrap<Function>(function);
    return wrap(new PostDominatorTree(*unwrapped));
}

void llvmsharp_PostDominatorTree_dispose(LLVMSharpPostDominatorTreeRef post_dominator_tree)
{
    delete unwrap(post_dominator_tree);
}

uint8_t llvmsharp_PostDominatorTree_dominatesBlock(LLVMSharpPostDominatorTreeRef post_dominator_tree, LLVMBasicBlockRef a, LLVMBasicBlockRef b)
{
    PostDominatorTree* unwrapped = unwrap(post_dominator_tree);
    return unwrapped->dominates(unwrap(a), unwrap(b)) ? 1 : 0;
}

LLVMValueRef llvmsharp_simplifyInstruction(LLVMValueRef instruction, LLVMModuleRef module)
{
    Instruction* unwrapped = unwrap<Instruction>(instruction);
    const DataLayout& dataLayout = unwrap(module)->getDataLayout();
    return wrap(simplifyInstruction(unwrapped, SimplifyQuery(dataLayout)));
}

LLVMSharpTargetTransformInfoRef llvmsharp_TargetTransformInfo_create(LLVMTargetMachineRef target_machine, LLVMValueRef function)
{
    TargetMachine* targetMachine = unwrap(target_machine);
    Function* unwrapped = unwrap<Function>(function);
    return wrap(new TargetTransformInfo(targetMachine->getTargetTransformInfo(*unwrapped)));
}

void llvmsharp_TargetTransformInfo_dispose(LLVMSharpTargetTransformInfoRef target_transform_info)
{
    delete unwrap(target_transform_info);
}

uint8_t llvmsharp_TargetTransformInfo_getInstructionCost(LLVMSharpTargetTransformInfoRef target_transform_info, LLVMValueRef user, int32_t cost_kind, int64_t* out_cost)
{
    TargetTransformInfo* unwrapped = unwrap(target_transform_info);
    InstructionCost cost = unwrapped->getInstructionCost(unwrap<User>(user), (TargetTransformInfo::TargetCostKind)cost_kind);
    if (!cost.isValid())
    {
        *out_cost = 0;
        return 0;
    }
    *out_cost = cost.getValue();
    return 1;
}

uint32_t llvmsharp_TargetTransformInfo_getNumberOfRegisters(LLVMSharpTargetTransformInfoRef target_transform_info, uint32_t class_id)
{
    TargetTransformInfo* unwrapped = unwrap(target_transform_info);
    return unwrapped->getNumberOfRegisters(class_id);
}

uint32_t llvmsharp_TargetTransformInfo_getRegisterBitWidth(LLVMSharpTargetTransformInfoRef target_transform_info, int32_t register_kind, uint8_t* out_isScalable)
{
    TargetTransformInfo* unwrapped = unwrap(target_transform_info);
    TypeSize size = unwrapped->getRegisterBitWidth((TargetTransformInfo::RegisterKind)register_kind);
    *out_isScalable = size.isScalable() ? 1 : 0;
    return (uint32_t)size.getKnownMinValue();
}

uint64_t llvmsharp_Type_getPrimitiveSizeInBits(LLVMTypeRef type, uint8_t* out_isScalable)
{
    Type* unwrapped = unwrap(type);
    TypeSize size = unwrapped->getPrimitiveSizeInBits();
    *out_isScalable = size.isScalable() ? 1 : 0;
    return size.getKnownMinValue();
}

uint32_t llvmsharp_Type_getScalarSizeInBits(LLVMTypeRef type)
{
    Type* unwrapped = unwrap(type);
    return unwrapped->getScalarSizeInBits();
}

uint32_t llvmsharp_Value_getNumUses(LLVMValueRef value)
{
    Value* unwrapped = unwrap<Value>(value);
    return (uint32_t)unwrapped->getNumUses();
}

uint64_t llvmsharp_Value_getPointerAlignment(LLVMValueRef value, LLVMModuleRef module)
{
    Value* unwrapped = unwrap<Value>(value);
    const DataLayout& dataLayout = unwrap(module)->getDataLayout();
    return unwrapped->getPointerAlignment(dataLayout).value();
}

LLVMValueRef llvmsharp_Value_stripInBoundsOffsets(LLVMValueRef value)
{
    Value* unwrapped = unwrap<Value>(value);
    return wrap(unwrapped->stripInBoundsOffsets());
}

LLVMValueRef llvmsharp_Value_stripPointerCasts(LLVMValueRef value)
{
    Value* unwrapped = unwrap<Value>(value);
    return wrap(unwrapped->stripPointerCasts());
}

LLVMValueRef llvmsharp_Value_stripPointerCastsAndAliases(LLVMValueRef value)
{
    Value* unwrapped = unwrap<Value>(value);
    return wrap(unwrapped->stripPointerCastsAndAliases());
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

LLVMPassRef llvmsharp_createPromoteMemoryToRegisterPass()
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

int32_t llvmsharp_Demangle(const char* mangled_string, int32_t mangled_string_size, char* buffer, int32_t buffer_size)
{
    std::string result = llvm::demangle(std::string_view(mangled_string, mangled_string_size));
    int32_t length = (int32_t)result.length();
    int32_t size = length < buffer_size ? length : buffer_size;
    memcpy(buffer, result.c_str(), size);
    return length;
}

void llvmsharp_Free(void* obj)
{
    free(obj);
}
