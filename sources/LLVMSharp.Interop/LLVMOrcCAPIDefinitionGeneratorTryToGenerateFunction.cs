// Copyright (c) .NET Foundation and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-12.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: NativeTypeName("LLVMErrorRef")]
    public unsafe delegate LLVMOpaqueError* LLVMOrcCAPIDefinitionGeneratorTryToGenerateFunction([NativeTypeName("LLVMOrcDefinitionGeneratorRef")] LLVMOrcOpaqueDefinitionGenerator* GeneratorObj, void* Ctx, [NativeTypeName("LLVMOrcLookupStateRef *")] LLVMOrcOpaqueLookupState** LookupState, LLVMOrcLookupKind Kind, [NativeTypeName("LLVMOrcJITDylibRef")] LLVMOrcOpaqueJITDylib* JD, LLVMOrcJITDylibLookupFlags JDLookupFlags, [NativeTypeName("LLVMOrcCLookupSet")] LLVMOrcCLookupSetElement* LookupSet, [NativeTypeName("size_t")] UIntPtr LookupSetSize);
}
