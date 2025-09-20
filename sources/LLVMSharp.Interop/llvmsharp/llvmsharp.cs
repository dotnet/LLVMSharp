// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.
// Ported from https://github.com/dotnet/llvmsharp/blob/main/sources/libLLVMSharp

using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public static unsafe partial class llvmsharp
{
    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_ConstantDataArray_getData", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ConstantDataArray_getData([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantDataArrayRef, [NativeTypeName("int32_t *")] int* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIBasicType_getEncoding", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint DIBasicType_getEncoding([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* type);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DICompositeType_getBaseType", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DICompositeType_getBaseType([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* type);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DICompositeType_getElements", ExactSpelling = true)]
    public static extern void DICompositeType_getElements([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* type, [NativeTypeName("LLVMMetadataRef **")] LLVMOpaqueMetadata*** out_buffer, [NativeTypeName("int32_t *")] int* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DICompositeType_getIdentifier", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* DICompositeType_getIdentifier([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* type, [NativeTypeName("size_t *")] nuint* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIDerivedType_getBaseType", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DIDerivedType_getBaseType([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* type);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIDerivedType_getExtraData", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DIDerivedType_getExtraData([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* type);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIEnumerator_getName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* DIEnumerator_getName([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* enumerator, [NativeTypeName("size_t *")] nuint* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIEnumerator_getValue_SExt", ExactSpelling = true)]
    [return: NativeTypeName("int64_t")]
    public static extern long DIEnumerator_getValue_SExt([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* enumerator);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIEnumerator_getValue_ZExt", ExactSpelling = true)]
    [return: NativeTypeName("uint64_t")]
    public static extern ulong DIEnumerator_getValue_ZExt([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* enumerator);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIEnumerator_isUnsigned", ExactSpelling = true)]
    [return: NativeTypeName("uint8_t")]
    public static extern byte DIEnumerator_isUnsigned([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* enumerator);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIFile_getDirectory", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* DIFile_getDirectory([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* file, [NativeTypeName("size_t *")] nuint* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIFile_getFilename", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* DIFile_getFilename([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* file, [NativeTypeName("size_t *")] nuint* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIImportedEntity_getEntity", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DIImportedEntity_getEntity([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* node);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIImportedEntity_getFile", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DIImportedEntity_getFile([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* node);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIImportedEntity_getLine", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint DIImportedEntity_getLine([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* node);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIImportedEntity_getScope", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DIImportedEntity_getScope([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* node);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DILexicalBlock_getLine", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint DILexicalBlock_getLine([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* block);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DILexicalBlock_getScope", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DILexicalBlock_getScope([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* block);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DINamespace_getName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* DINamespace_getName([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* node, [NativeTypeName("size_t *")] nuint* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DINamespace_getScope", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DINamespace_getScope([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* node);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DINode_getTagString", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* DINode_getTagString([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* node, [NativeTypeName("size_t *")] nuint* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DISubprogram_getContainingType", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DISubprogram_getContainingType([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* subprogram);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DISubprogram_getFlags", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint DISubprogram_getFlags([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* subprogram);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DISubprogram_getLinkageName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* DISubprogram_getLinkageName([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* subprogram, [NativeTypeName("size_t *")] nuint* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DISubprogram_getName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* DISubprogram_getName([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* subprogram, [NativeTypeName("size_t *")] nuint* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DISubprogram_getScopeLine", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint DISubprogram_getScopeLine([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* subprogram);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DISubprogram_getSPFlags", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint DISubprogram_getSPFlags([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* subprogram);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DISubprogram_getTemplateParams", ExactSpelling = true)]
    public static extern void DISubprogram_getTemplateParams([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* subprogram, [NativeTypeName("LLVMMetadataRef **")] LLVMOpaqueMetadata*** out_buffer, [NativeTypeName("int32_t *")] int* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DISubprogram_getType", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DISubprogram_getType([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* subprogram);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DISubprogram_getVirtualIndex", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint DISubprogram_getVirtualIndex([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* subprogram);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DISubrange_getCount", ExactSpelling = true)]
    [return: NativeTypeName("LLVMValueRef")]
    public static extern LLVMOpaqueValue* DISubrange_getCount([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* subrange);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DISubroutineType_getTypeArray", ExactSpelling = true)]
    public static extern void DISubroutineType_getTypeArray([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* subroutine_type, [NativeTypeName("LLVMMetadataRef **")] LLVMOpaqueMetadata*** out_buffer, [NativeTypeName("int32_t *")] int* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DITemplateParameter_getType", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DITemplateParameter_getType([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* parameter);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DITemplateValueParameter_getValue", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DITemplateValueParameter_getValue([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* parameter);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIVariable_getName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* DIVariable_getName([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* variable, [NativeTypeName("size_t *")] nuint* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_DIVariable_getType", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* DIVariable_getType([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* variable);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Function_getFunctionType", ExactSpelling = true)]
    [return: NativeTypeName("LLVMTypeRef")]
    public static extern LLVMOpaqueType* Function_getFunctionType([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* FnRef);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Function_getReturnType", ExactSpelling = true)]
    [return: NativeTypeName("LLVMTypeRef")]
    public static extern LLVMOpaqueType* Function_getReturnType([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* FnRef);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_GlobalVariable_getGlobalVariableExpression", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* GlobalVariable_getGlobalVariableExpression([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* global_variable);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_GlobalVariable_getMetadata", ExactSpelling = true)]
    [return: NativeTypeName("LLVMMetadataRef")]
    public static extern LLVMOpaqueMetadata* GlobalVariable_getMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* global_variable, [NativeTypeName("uint32_t")] uint KindID);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Instruction_hasNoSignedWrap", ExactSpelling = true)]
    [return: NativeTypeName("uint8_t")]
    public static extern byte Instruction_hasNoSignedWrap([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InstructionRef);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Instruction_hasNoUnsignedWrap", ExactSpelling = true)]
    [return: NativeTypeName("uint8_t")]
    public static extern byte Instruction_hasNoUnsignedWrap([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InstructionRef);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Module_GetIdentifiedStructTypes", ExactSpelling = true)]
    public static extern void Module_GetIdentifiedStructTypes([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* module, [NativeTypeName("LLVMTypeRef **")] LLVMOpaqueType*** out_buffer, [NativeTypeName("int32_t *")] int* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_PassManager_add", ExactSpelling = true)]
    public static extern void PassManager_add([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* pass_manager, [NativeTypeName("LLVMPassRef")] LLVMOpaquePass* pass);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Value_getDemangledName", ExactSpelling = true)]
    [return: NativeTypeName("int32_t")]
    public static extern int Value_getDemangledName([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ValueRef, [NativeTypeName("char *")] sbyte* buffer, [NativeTypeName("int32_t")] int buffer_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createDeadCodeEliminationPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createDeadCodeEliminationPass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createSROAPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createSROAPass([NativeTypeName("uint8_t")] byte PreserveCFG);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createLICMPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createLICMPass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createLoopStrengthReducePass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createLoopStrengthReducePass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createReassociatePass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createReassociatePass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createFlattenCFGPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createFlattenCFGPass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createCFGSimplificationPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createCFGSimplificationPass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createTailCallEliminationPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createTailCallEliminationPass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createConstantHoistingPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createConstantHoistingPass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createLowerInvokePass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createLowerInvokePass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createLowerSwitchPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createLowerSwitchPass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createBreakCriticalEdgesPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createBreakCriticalEdgesPass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createLCSSAPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createLCSSAPass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createPromoteMemoryToRegisterPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createPromoteMemoryToRegisterPass([NativeTypeName("uint8_t")] byte IsForced);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createLoopSimplifyPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createLoopSimplifyPass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_createUnifyLoopExitsPass", ExactSpelling = true)]
    [return: NativeTypeName("LLVMPassRef")]
    public static extern LLVMOpaquePass* createUnifyLoopExitsPass();

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Free", ExactSpelling = true)]
    public static extern void Free(void* obj);
}
