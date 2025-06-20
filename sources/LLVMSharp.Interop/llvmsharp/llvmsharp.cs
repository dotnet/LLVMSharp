// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.
// Ported from https://github.com/dotnet/llvmsharp/blob/main/sources/libLLVMSharp

using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public static unsafe partial class llvmsharp
{
    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Function_getReturnType", ExactSpelling = true)]
    [return: NativeTypeName("LLVMTypeRef")]
    public static extern LLVMOpaqueType* Function_getReturnType([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* FnRef);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Function_getFunctionType", ExactSpelling = true)]
    [return: NativeTypeName("LLVMTypeRef")]
    public static extern LLVMOpaqueType* Function_getFunctionType([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* FnRef);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Instruction_hasNoSignedWrap", ExactSpelling = true)]
    [return: NativeTypeName("uint8_t")]
    public static extern byte Instruction_hasNoSignedWrap([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InstructionRef);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Instruction_hasNoUnsignedWrap", ExactSpelling = true)]
    [return: NativeTypeName("uint8_t")]
    public static extern byte Instruction_hasNoUnsignedWrap([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InstructionRef);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_ConstantDataArray_getData", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ConstantDataArray_getData([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantDataArrayRef, [NativeTypeName("int32_t *")] int* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Value_getDemangledName", ExactSpelling = true)]
    [return: NativeTypeName("int32_t")]
    public static extern int Value_getDemangledName([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ValueRef, [NativeTypeName("char *")] sbyte* buffer, [NativeTypeName("int32_t")] int buffer_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_PassManager_add", ExactSpelling = true)]
    public static extern void PassManager_add([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* pass_manager, [NativeTypeName("LLVMPassRef")] LLVMOpaquePass* pass);

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

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_Module_GetIdentifiedStructTypes", ExactSpelling = true)]
    public static extern void Module_GetIdentifiedStructTypes([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* module, [NativeTypeName("LLVMTypeRef **")] LLVMOpaqueType*** out_buffer, [NativeTypeName("int32_t *")] int* out_size);

    [DllImport("libLLVMSharp", CallingConvention = CallingConvention.Cdecl, EntryPoint = "llvmsharp_FreeTypeBuffer", ExactSpelling = true)]
    public static extern void FreeTypeBuffer([NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** buffer);
}
