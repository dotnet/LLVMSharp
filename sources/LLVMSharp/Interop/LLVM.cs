// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-11.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop
{
    public static unsafe partial class LLVM
    {
        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMVerifyModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int VerifyModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, LLVMVerifierFailureAction Action, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMVerifyFunction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int VerifyFunction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, LLVMVerifierFailureAction Action);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMViewFunctionCFG", ExactSpelling = true)]
        public static extern void ViewFunctionCFG([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMViewFunctionCFGOnly", ExactSpelling = true)]
        public static extern void ViewFunctionCFGOnly([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMParseBitcode", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ParseBitcode([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutModule, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMParseBitcode2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ParseBitcode2([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutModule);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMParseBitcodeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ParseBitcodeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* ContextRef, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutModule, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMParseBitcodeInContext2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ParseBitcodeInContext2([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* ContextRef, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutModule);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetBitcodeModuleInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetBitcodeModuleInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* ContextRef, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutM, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetBitcodeModuleInContext2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetBitcodeModuleInContext2([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* ContextRef, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetBitcodeModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetBitcodeModule([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutM, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetBitcodeModule2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetBitcodeModule2([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMWriteBitcodeToFile", ExactSpelling = true)]
        public static extern int WriteBitcodeToFile([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Path);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMWriteBitcodeToFD", ExactSpelling = true)]
        public static extern int WriteBitcodeToFD([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, int FD, int ShouldClose, int Unbuffered);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMWriteBitcodeToFileHandle", ExactSpelling = true)]
        public static extern int WriteBitcodeToFileHandle([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, int Handle);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMWriteBitcodeToMemoryBuffer", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMemoryBufferRef")]
        public static extern LLVMOpaqueMemoryBuffer* WriteBitcodeToMemoryBuffer([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetOrInsertComdat", ExactSpelling = true)]
        [return: NativeTypeName("LLVMComdatRef")]
        public static extern LLVMComdat* GetOrInsertComdat([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetComdat", ExactSpelling = true)]
        [return: NativeTypeName("LLVMComdatRef")]
        public static extern LLVMComdat* GetComdat([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetComdat", ExactSpelling = true)]
        public static extern void SetComdat([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("LLVMComdatRef")] LLVMComdat* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetComdatSelectionKind", ExactSpelling = true)]
        public static extern LLVMComdatSelectionKind GetComdatSelectionKind([NativeTypeName("LLVMComdatRef")] LLVMComdat* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetComdatSelectionKind", ExactSpelling = true)]
        public static extern void SetComdatSelectionKind([NativeTypeName("LLVMComdatRef")] LLVMComdat* C, LLVMComdatSelectionKind Kind);

        public const int LLVMAttributeReturnIndex = 0;
        public const int LLVMAttributeFunctionIndex = -1;

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeCore", ExactSpelling = true)]
        public static extern void InitializeCore([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMShutdown", ExactSpelling = true)]
        public static extern void Shutdown();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateMessage", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* CreateMessage([NativeTypeName("const char *")] sbyte* Message);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeMessage", ExactSpelling = true)]
        public static extern void DisposeMessage([NativeTypeName("char *")] sbyte* Message);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMContextCreate", ExactSpelling = true)]
        [return: NativeTypeName("LLVMContextRef")]
        public static extern LLVMOpaqueContext* ContextCreate();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetGlobalContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMContextRef")]
        public static extern LLVMOpaqueContext* GetGlobalContext();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMContextSetDiagnosticHandler", ExactSpelling = true)]
        public static extern void ContextSetDiagnosticHandler([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMDiagnosticHandler")] IntPtr Handler, [NativeTypeName("void *")] void* DiagnosticContext);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMContextGetDiagnosticHandler", ExactSpelling = true)]
        [return: NativeTypeName("LLVMDiagnosticHandler")]
        public static extern IntPtr ContextGetDiagnosticHandler([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMContextGetDiagnosticContext", ExactSpelling = true)]
        [return: NativeTypeName("void *")]
        public static extern void* ContextGetDiagnosticContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMContextSetYieldCallback", ExactSpelling = true)]
        public static extern void ContextSetYieldCallback([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMYieldCallback")] IntPtr Callback, [NativeTypeName("void *")] void* OpaqueHandle);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMContextShouldDiscardValueNames", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ContextShouldDiscardValueNames([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMContextSetDiscardValueNames", ExactSpelling = true)]
        public static extern void ContextSetDiscardValueNames([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMBool")] int Discard);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMContextDispose", ExactSpelling = true)]
        public static extern void ContextDispose([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetDiagInfoDescription", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetDiagInfoDescription([NativeTypeName("LLVMDiagnosticInfoRef")] LLVMOpaqueDiagnosticInfo* DI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetDiagInfoSeverity", ExactSpelling = true)]
        public static extern LLVMDiagnosticSeverity GetDiagInfoSeverity([NativeTypeName("LLVMDiagnosticInfoRef")] LLVMOpaqueDiagnosticInfo* DI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetMDKindIDInContext", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetMDKindIDInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("unsigned int")] uint SLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetMDKindID", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetMDKindID([NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("unsigned int")] uint SLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetEnumAttributeKindForName", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetEnumAttributeKindForName([NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr SLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetLastEnumAttributeKind", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetLastEnumAttributeKind();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateEnumAttribute", ExactSpelling = true)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* CreateEnumAttribute([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("unsigned int")] uint KindID, [NativeTypeName("uint64_t")] ulong Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetEnumAttributeKind", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetEnumAttributeKind([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetEnumAttributeValue", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetEnumAttributeValue([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateStringAttribute", ExactSpelling = true)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* CreateStringAttribute([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* K, [NativeTypeName("unsigned int")] uint KLength, [NativeTypeName("const char *")] sbyte* V, [NativeTypeName("unsigned int")] uint VLength);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetStringAttributeKind", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetStringAttributeKind([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A, [NativeTypeName("unsigned int *")] uint* Length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetStringAttributeValue", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetStringAttributeValue([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A, [NativeTypeName("unsigned int *")] uint* Length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsEnumAttribute", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsEnumAttribute([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsStringAttribute", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsStringAttribute([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMModuleCreateWithName", ExactSpelling = true)]
        [return: NativeTypeName("LLVMModuleRef")]
        public static extern LLVMOpaqueModule* ModuleCreateWithName([NativeTypeName("const char *")] sbyte* ModuleID);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMModuleCreateWithNameInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMModuleRef")]
        public static extern LLVMOpaqueModule* ModuleCreateWithNameInContext([NativeTypeName("const char *")] sbyte* ModuleID, [NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCloneModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMModuleRef")]
        public static extern LLVMOpaqueModule* CloneModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeModule", ExactSpelling = true)]
        public static extern void DisposeModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetModuleIdentifier", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetModuleIdentifier([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("size_t *")] UIntPtr* Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetModuleIdentifier", ExactSpelling = true)]
        public static extern void SetModuleIdentifier([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Ident, [NativeTypeName("size_t")] UIntPtr Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSourceFileName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetSourceFileName([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("size_t *")] UIntPtr* Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetSourceFileName", ExactSpelling = true)]
        public static extern void SetSourceFileName([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetDataLayoutStr", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetDataLayoutStr([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetDataLayout", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetDataLayout([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetDataLayout", ExactSpelling = true)]
        public static extern void SetDataLayout([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* DataLayoutStr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTarget", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetTarget([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetTarget", ExactSpelling = true)]
        public static extern void SetTarget([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Triple);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCopyModuleFlagsMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMModuleFlagEntry *")]
        public static extern LLVMOpaqueModuleFlagEntry* CopyModuleFlagsMetadata([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("size_t *")] UIntPtr* Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeModuleFlagsMetadata", ExactSpelling = true)]
        public static extern void DisposeModuleFlagsMetadata([NativeTypeName("LLVMModuleFlagEntry *")] LLVMOpaqueModuleFlagEntry* Entries);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMModuleFlagEntriesGetFlagBehavior", ExactSpelling = true)]
        public static extern LLVMModuleFlagBehavior ModuleFlagEntriesGetFlagBehavior([NativeTypeName("LLVMModuleFlagEntry *")] LLVMOpaqueModuleFlagEntry* Entries, [NativeTypeName("unsigned int")] uint Index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMModuleFlagEntriesGetKey", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ModuleFlagEntriesGetKey([NativeTypeName("LLVMModuleFlagEntry *")] LLVMOpaqueModuleFlagEntry* Entries, [NativeTypeName("unsigned int")] uint Index, [NativeTypeName("size_t *")] UIntPtr* Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMModuleFlagEntriesGetMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* ModuleFlagEntriesGetMetadata([NativeTypeName("LLVMModuleFlagEntry *")] LLVMOpaqueModuleFlagEntry* Entries, [NativeTypeName("unsigned int")] uint Index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetModuleFlag", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* GetModuleFlag([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Key, [NativeTypeName("size_t")] UIntPtr KeyLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddModuleFlag", ExactSpelling = true)]
        public static extern void AddModuleFlag([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, LLVMModuleFlagBehavior Behavior, [NativeTypeName("const char *")] sbyte* Key, [NativeTypeName("size_t")] UIntPtr KeyLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDumpModule", ExactSpelling = true)]
        public static extern void DumpModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPrintModuleToFile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int PrintModuleToFile([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Filename, [NativeTypeName("char **")] sbyte** ErrorMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPrintModuleToString", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* PrintModuleToString([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetModuleInlineAsm", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetModuleInlineAsm([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("size_t *")] UIntPtr* Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetModuleInlineAsm2", ExactSpelling = true)]
        public static extern void SetModuleInlineAsm2([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Asm, [NativeTypeName("size_t")] UIntPtr Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAppendModuleInlineAsm", ExactSpelling = true)]
        public static extern void AppendModuleInlineAsm([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Asm, [NativeTypeName("size_t")] UIntPtr Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetInlineAsm", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetInlineAsm([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("char *")] sbyte* AsmString, [NativeTypeName("size_t")] UIntPtr AsmStringSize, [NativeTypeName("char *")] sbyte* Constraints, [NativeTypeName("size_t")] UIntPtr ConstraintsSize, [NativeTypeName("LLVMBool")] int HasSideEffects, [NativeTypeName("LLVMBool")] int IsAlignStack, LLVMInlineAsmDialect Dialect);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetModuleContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMContextRef")]
        public static extern LLVMOpaqueContext* GetModuleContext([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTypeByName", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GetTypeByName([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFirstNamedMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetFirstNamedMetadata([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetLastNamedMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetLastNamedMetadata([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNextNamedMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetNextNamedMetadata([NativeTypeName("LLVMNamedMDNodeRef")] LLVMOpaqueNamedMDNode* NamedMDNode);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetPreviousNamedMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetPreviousNamedMetadata([NativeTypeName("LLVMNamedMDNodeRef")] LLVMOpaqueNamedMDNode* NamedMDNode);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNamedMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetNamedMetadata([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetOrInsertNamedMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetOrInsertNamedMetadata([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNamedMetadataName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetNamedMetadataName([NativeTypeName("LLVMNamedMDNodeRef")] LLVMOpaqueNamedMDNode* NamedMD, [NativeTypeName("size_t *")] UIntPtr* NameLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNamedMetadataNumOperands", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNamedMetadataNumOperands([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNamedMetadataOperands", ExactSpelling = true)]
        public static extern void GetNamedMetadataOperands([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Dest);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddNamedMetadataOperand", ExactSpelling = true)]
        public static extern void AddNamedMetadataOperand([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetDebugLocDirectory", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetDebugLocDirectory([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int *")] uint* Length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetDebugLocFilename", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetDebugLocFilename([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int *")] uint* Length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetDebugLocLine", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetDebugLocLine([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetDebugLocColumn", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetDebugLocColumn([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddFunction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AddFunction([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* FunctionTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNamedFunction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNamedFunction([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFirstFunction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetFirstFunction([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetLastFunction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetLastFunction([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNextFunction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNextFunction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetPreviousFunction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPreviousFunction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetModuleInlineAsm", ExactSpelling = true)]
        public static extern void SetModuleInlineAsm([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Asm);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTypeKind", ExactSpelling = true)]
        public static extern LLVMTypeKind GetTypeKind([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMTypeIsSized", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TypeIsSized([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTypeContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMContextRef")]
        public static extern LLVMOpaqueContext* GetTypeContext([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDumpType", ExactSpelling = true)]
        public static extern void DumpType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPrintTypeToString", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* PrintTypeToString([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt1TypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int1TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt8TypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int8TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt16TypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int16TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt32TypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int32TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt64TypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int64TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt128TypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int128TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIntTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("unsigned int")] uint NumBits);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt1Type", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int1Type();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt8Type", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int8Type();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt16Type", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int16Type();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt32Type", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int32Type();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt64Type", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int64Type();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInt128Type", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int128Type();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIntType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntType([NativeTypeName("unsigned int")] uint NumBits);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetIntTypeWidth", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetIntTypeWidth([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* IntegerTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMHalfTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* HalfTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBFloatTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* BFloatTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMFloatTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* FloatTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDoubleTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* DoubleTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMX86FP80TypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* X86FP80TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMFP128TypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* FP128TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPPCFP128TypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* PPCFP128TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMHalfType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* HalfType();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBFloatType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* BFloatType();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMFloatType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* FloatType();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDoubleType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* DoubleType();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMX86FP80Type", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* X86FP80Type();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMFP128Type", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* FP128Type();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPPCFP128Type", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* PPCFP128Type();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMFunctionType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* FunctionType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ReturnType, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ParamTypes, [NativeTypeName("unsigned int")] uint ParamCount, [NativeTypeName("LLVMBool")] int IsVarArg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsFunctionVarArg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsFunctionVarArg([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* FunctionTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetReturnType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GetReturnType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* FunctionTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCountParamTypes", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CountParamTypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* FunctionTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetParamTypes", ExactSpelling = true)]
        public static extern void GetParamTypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* FunctionTy, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** Dest);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMStructTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* StructTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ElementTypes, [NativeTypeName("unsigned int")] uint ElementCount, [NativeTypeName("LLVMBool")] int Packed);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMStructType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* StructType([NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ElementTypes, [NativeTypeName("unsigned int")] uint ElementCount, [NativeTypeName("LLVMBool")] int Packed);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMStructCreateNamed", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* StructCreateNamed([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetStructName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetStructName([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMStructSetBody", ExactSpelling = true)]
        public static extern void StructSetBody([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ElementTypes, [NativeTypeName("unsigned int")] uint ElementCount, [NativeTypeName("LLVMBool")] int Packed);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCountStructElementTypes", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CountStructElementTypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetStructElementTypes", ExactSpelling = true)]
        public static extern void GetStructElementTypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** Dest);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMStructGetTypeAtIndex", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* StructGetTypeAtIndex([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("unsigned int")] uint i);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsPackedStruct", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsPackedStruct([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsOpaqueStruct", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsOpaqueStruct([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsLiteralStruct", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsLiteralStruct([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetElementType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GetElementType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSubtypes", ExactSpelling = true)]
        public static extern void GetSubtypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Tp, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** Arr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNumContainedTypes", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumContainedTypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Tp);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMArrayType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* ArrayType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ElementType, [NativeTypeName("unsigned int")] uint ElementCount);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetArrayLength", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetArrayLength([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ArrayTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPointerType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* PointerType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ElementType, [NativeTypeName("unsigned int")] uint AddressSpace);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetPointerAddressSpace", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetPointerAddressSpace([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* PointerTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMVectorType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* VectorType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ElementType, [NativeTypeName("unsigned int")] uint ElementCount);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetVectorSize", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetVectorSize([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* VectorTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMVoidTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* VoidTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMLabelTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* LabelTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMX86MMXTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* X86MMXTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMTokenTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* TokenTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMetadataTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* MetadataTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMVoidType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* VoidType();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMLabelType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* LabelType();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMX86MMXType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* X86MMXType();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMTypeOf", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* TypeOf([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetValueKind", ExactSpelling = true)]
        public static extern LLVMValueKind GetValueKind([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetValueName2", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetValueName2([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("size_t *")] UIntPtr* Length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetValueName2", ExactSpelling = true)]
        public static extern void SetValueName2([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDumpValue", ExactSpelling = true)]
        public static extern void DumpValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPrintValueToString", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* PrintValueToString([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMReplaceAllUsesWith", ExactSpelling = true)]
        public static extern void ReplaceAllUsesWith([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* OldVal, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* NewVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsConstant", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsConstant([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsUndef", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsUndef([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAArgument", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAArgument([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsABasicBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsABasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAInlineAsm", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAInlineAsm([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAUser", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAUser([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstant", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstant([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsABlockAddress", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsABlockAddress([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantAggregateZero", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantAggregateZero([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantArray", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantArray([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantDataSequential", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantDataSequential([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantDataArray", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantDataArray([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantDataVector", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantDataVector([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantExpr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantExpr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantFP", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantFP([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantInt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantInt([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantPointerNull", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantPointerNull([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantStruct", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantStruct([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantTokenNone", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantTokenNone([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAConstantVector", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantVector([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAGlobalValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGlobalValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAGlobalAlias", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGlobalAlias([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAGlobalIFunc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGlobalIFunc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAGlobalObject", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGlobalObject([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAFunction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFunction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAGlobalVariable", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGlobalVariable([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAUndefValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAUndefValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAInstruction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAInstruction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAUnaryOperator", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAUnaryOperator([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsABinaryOperator", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsABinaryOperator([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsACallInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACallInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAIntrinsicInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAIntrinsicInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsADbgInfoIntrinsic", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsADbgInfoIntrinsic([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsADbgVariableIntrinsic", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsADbgVariableIntrinsic([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsADbgDeclareInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsADbgDeclareInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsADbgLabelInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsADbgLabelInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAMemIntrinsic", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMemIntrinsic([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAMemCpyInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMemCpyInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAMemMoveInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMemMoveInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAMemSetInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMemSetInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsACmpInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACmpInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAFCmpInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFCmpInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAICmpInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAICmpInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAExtractElementInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAExtractElementInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAGetElementPtrInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGetElementPtrInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAInsertElementInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAInsertElementInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAInsertValueInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAInsertValueInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsALandingPadInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsALandingPadInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAPHINode", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAPHINode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsASelectInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsASelectInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAShuffleVectorInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAShuffleVectorInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAStoreInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAStoreInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsABranchInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsABranchInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAIndirectBrInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAIndirectBrInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAInvokeInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAInvokeInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAReturnInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAReturnInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsASwitchInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsASwitchInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAUnreachableInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAUnreachableInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAResumeInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAResumeInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsACleanupReturnInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACleanupReturnInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsACatchReturnInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACatchReturnInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsACatchSwitchInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACatchSwitchInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsACallBrInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACallBrInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAFuncletPadInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFuncletPadInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsACatchPadInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACatchPadInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsACleanupPadInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACleanupPadInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAUnaryInstruction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAUnaryInstruction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAAllocaInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAAllocaInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsACastInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACastInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAAddrSpaceCastInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAAddrSpaceCastInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsABitCastInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsABitCastInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAFPExtInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFPExtInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAFPToSIInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFPToSIInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAFPToUIInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFPToUIInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAFPTruncInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFPTruncInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAIntToPtrInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAIntToPtrInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAPtrToIntInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAPtrToIntInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsASExtInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsASExtInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsASIToFPInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsASIToFPInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsATruncInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsATruncInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAUIToFPInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAUIToFPInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAZExtInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAZExtInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAExtractValueInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAExtractValueInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsALoadInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsALoadInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAVAArgInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAVAArgInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAFreezeInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFreezeInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAAtomicCmpXchgInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAAtomicCmpXchgInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAAtomicRMWInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAAtomicRMWInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAFenceInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFenceInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAMDNode", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMDNode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAMDString", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMDString([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetValueName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetValueName([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetValueName", ExactSpelling = true)]
        public static extern void SetValueName([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFirstUse", ExactSpelling = true)]
        [return: NativeTypeName("LLVMUseRef")]
        public static extern LLVMOpaqueUse* GetFirstUse([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNextUse", ExactSpelling = true)]
        [return: NativeTypeName("LLVMUseRef")]
        public static extern LLVMOpaqueUse* GetNextUse([NativeTypeName("LLVMUseRef")] LLVMOpaqueUse* U);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetUser", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetUser([NativeTypeName("LLVMUseRef")] LLVMOpaqueUse* U);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetUsedValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetUsedValue([NativeTypeName("LLVMUseRef")] LLVMOpaqueUse* U);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetOperand", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetOperand([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int")] uint Index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetOperandUse", ExactSpelling = true)]
        [return: NativeTypeName("LLVMUseRef")]
        public static extern LLVMOpaqueUse* GetOperandUse([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int")] uint Index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetOperand", ExactSpelling = true)]
        public static extern void SetOperand([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* User, [NativeTypeName("unsigned int")] uint Index, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNumOperands", ExactSpelling = true)]
        public static extern int GetNumOperands([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNull", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNull([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstAllOnes", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstAllOnes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetUndef", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetUndef([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsNull", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsNull([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstPointerNull", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstPointerNull([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstInt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInt([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* IntTy, [NativeTypeName("unsigned long long")] ulong N, [NativeTypeName("LLVMBool")] int SignExtend);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstIntOfArbitraryPrecision", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstIntOfArbitraryPrecision([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* IntTy, [NativeTypeName("unsigned int")] uint NumWords, [NativeTypeName("const uint64_t []")] ulong* Words);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstIntOfString", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstIntOfString([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* IntTy, [NativeTypeName("const char *")] sbyte* Text, [NativeTypeName("uint8_t")] byte Radix);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstIntOfStringAndSize", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstIntOfStringAndSize([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* IntTy, [NativeTypeName("const char *")] sbyte* Text, [NativeTypeName("unsigned int")] uint SLen, [NativeTypeName("uint8_t")] byte Radix);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstReal", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstReal([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* RealTy, double N);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstRealOfString", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstRealOfString([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* RealTy, [NativeTypeName("const char *")] sbyte* Text);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstRealOfStringAndSize", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstRealOfStringAndSize([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* RealTy, [NativeTypeName("const char *")] sbyte* Text, [NativeTypeName("unsigned int")] uint SLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstIntGetZExtValue", ExactSpelling = true)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong ConstIntGetZExtValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstIntGetSExtValue", ExactSpelling = true)]
        [return: NativeTypeName("long long")]
        public static extern long ConstIntGetSExtValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstRealGetDouble", ExactSpelling = true)]
        public static extern double ConstRealGetDouble([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMBool *")] int* losesInfo);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstStringInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstStringInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("unsigned int")] uint Length, [NativeTypeName("LLVMBool")] int DontNullTerminate);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstString", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstString([NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("unsigned int")] uint Length, [NativeTypeName("LLVMBool")] int DontNullTerminate);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsConstantString", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsConstantString([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* c);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetAsString", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetAsString([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* c, [NativeTypeName("size_t *")] UIntPtr* Length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstStructInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstStructInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantVals, [NativeTypeName("unsigned int")] uint Count, [NativeTypeName("LLVMBool")] int Packed);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstStruct", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstStruct([NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantVals, [NativeTypeName("unsigned int")] uint Count, [NativeTypeName("LLVMBool")] int Packed);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstArray", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstArray([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ElementTy, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantVals, [NativeTypeName("unsigned int")] uint Length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNamedStruct", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNamedStruct([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantVals, [NativeTypeName("unsigned int")] uint Count);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetElementAsConstant", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetElementAsConstant([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("unsigned int")] uint idx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstVector", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstVector([NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ScalarConstantVals, [NativeTypeName("unsigned int")] uint Size);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetConstOpcode", ExactSpelling = true)]
        public static extern LLVMOpcode GetConstOpcode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAlignOf", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AlignOf([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSizeOf", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* SizeOf([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNeg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNeg([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNSWNeg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNSWNeg([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNUWNeg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNUWNeg([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFNeg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFNeg([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNot", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNot([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstAdd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstAdd([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNSWAdd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNSWAdd([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNUWAdd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNUWAdd([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFAdd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFAdd([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstSub", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSub([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNSWSub", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNSWSub([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNUWSub", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNUWSub([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFSub", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFSub([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstMul", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstMul([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNSWMul", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNSWMul([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstNUWMul", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNUWMul([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFMul", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFMul([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstUDiv", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstUDiv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstExactUDiv", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstExactUDiv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstSDiv", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSDiv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstExactSDiv", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstExactSDiv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFDiv", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFDiv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstURem", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstURem([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstSRem", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSRem([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFRem", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFRem([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstAnd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstAnd([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstOr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstOr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstXor", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstXor([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstICmp", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstICmp(LLVMIntPredicate Predicate, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFCmp", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFCmp(LLVMRealPredicate Predicate, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstShl", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstShl([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstLShr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstLShr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstAShr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstAShr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstGEP", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstGEP([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantIndices, [NativeTypeName("unsigned int")] uint NumIndices);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstGEP2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstGEP2([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantIndices, [NativeTypeName("unsigned int")] uint NumIndices);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstInBoundsGEP", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInBoundsGEP([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantIndices, [NativeTypeName("unsigned int")] uint NumIndices);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstInBoundsGEP2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInBoundsGEP2([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantIndices, [NativeTypeName("unsigned int")] uint NumIndices);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstTrunc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstTrunc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstSExt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSExt([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstZExt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstZExt([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFPTrunc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFPTrunc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFPExt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFPExt([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstUIToFP", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstUIToFP([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstSIToFP", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSIToFP([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFPToUI", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFPToUI([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFPToSI", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFPToSI([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstPtrToInt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstPtrToInt([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstIntToPtr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstIntToPtr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstBitCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstBitCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstAddrSpaceCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstAddrSpaceCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstZExtOrBitCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstZExtOrBitCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstSExtOrBitCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSExtOrBitCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstTruncOrBitCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstTruncOrBitCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstPointerCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstPointerCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstIntCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstIntCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType, [NativeTypeName("LLVMBool")] int isSigned);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstFPCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFPCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstSelect", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSelect([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantCondition, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantIfTrue, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantIfFalse);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstExtractElement", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstExtractElement([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VectorConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IndexConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstInsertElement", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInsertElement([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VectorConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ElementValueConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IndexConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstShuffleVector", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstShuffleVector([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VectorAConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VectorBConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* MaskConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstExtractValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstExtractValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AggConstant, [NativeTypeName("unsigned int *")] uint* IdxList, [NativeTypeName("unsigned int")] uint NumIdx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstInsertValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInsertValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AggConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ElementValueConstant, [NativeTypeName("unsigned int *")] uint* IdxList, [NativeTypeName("unsigned int")] uint NumIdx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBlockAddress", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BlockAddress([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConstInlineAsm", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInlineAsm([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* AsmString, [NativeTypeName("const char *")] sbyte* Constraints, [NativeTypeName("LLVMBool")] int HasSideEffects, [NativeTypeName("LLVMBool")] int IsAlignStack);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetGlobalParent", ExactSpelling = true)]
        [return: NativeTypeName("LLVMModuleRef")]
        public static extern LLVMOpaqueModule* GetGlobalParent([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsDeclaration", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsDeclaration([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetLinkage", ExactSpelling = true)]
        public static extern LLVMLinkage GetLinkage([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetLinkage", ExactSpelling = true)]
        public static extern void SetLinkage([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, LLVMLinkage Linkage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSection", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetSection([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetSection", ExactSpelling = true)]
        public static extern void SetSection([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, [NativeTypeName("const char *")] sbyte* Section);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetVisibility", ExactSpelling = true)]
        public static extern LLVMVisibility GetVisibility([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetVisibility", ExactSpelling = true)]
        public static extern void SetVisibility([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, LLVMVisibility Viz);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetDLLStorageClass", ExactSpelling = true)]
        public static extern LLVMDLLStorageClass GetDLLStorageClass([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetDLLStorageClass", ExactSpelling = true)]
        public static extern void SetDLLStorageClass([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, LLVMDLLStorageClass Class);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetUnnamedAddress", ExactSpelling = true)]
        public static extern LLVMUnnamedAddr GetUnnamedAddress([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetUnnamedAddress", ExactSpelling = true)]
        public static extern void SetUnnamedAddress([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, LLVMUnnamedAddr UnnamedAddr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGlobalGetValueType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GlobalGetValueType([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMHasUnnamedAddr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int HasUnnamedAddr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetUnnamedAddr", ExactSpelling = true)]
        public static extern void SetUnnamedAddr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, [NativeTypeName("LLVMBool")] int HasUnnamedAddr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetAlignment", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetAlignment([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetAlignment", ExactSpelling = true)]
        public static extern void SetAlignment([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("unsigned int")] uint Bytes);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGlobalSetMetadata", ExactSpelling = true)]
        public static extern void GlobalSetMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, [NativeTypeName("unsigned int")] uint Kind, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* MD);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGlobalEraseMetadata", ExactSpelling = true)]
        public static extern void GlobalEraseMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, [NativeTypeName("unsigned int")] uint Kind);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGlobalClearMetadata", ExactSpelling = true)]
        public static extern void GlobalClearMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGlobalCopyAllMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueMetadataEntry *")]
        public static extern LLVMOpaqueValueMetadataEntry* GlobalCopyAllMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Value, [NativeTypeName("size_t *")] UIntPtr* NumEntries);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeValueMetadataEntries", ExactSpelling = true)]
        public static extern void DisposeValueMetadataEntries([NativeTypeName("LLVMValueMetadataEntry *")] LLVMOpaqueValueMetadataEntry* Entries);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMValueMetadataEntriesGetKind", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint ValueMetadataEntriesGetKind([NativeTypeName("LLVMValueMetadataEntry *")] LLVMOpaqueValueMetadataEntry* Entries, [NativeTypeName("unsigned int")] uint Index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMValueMetadataEntriesGetMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* ValueMetadataEntriesGetMetadata([NativeTypeName("LLVMValueMetadataEntry *")] LLVMOpaqueValueMetadataEntry* Entries, [NativeTypeName("unsigned int")] uint Index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddGlobal", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AddGlobal([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddGlobalInAddressSpace", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AddGlobalInAddressSpace([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("unsigned int")] uint AddressSpace);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNamedGlobal", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNamedGlobal([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFirstGlobal", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetFirstGlobal([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetLastGlobal", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetLastGlobal([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNextGlobal", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNextGlobal([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetPreviousGlobal", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPreviousGlobal([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDeleteGlobal", ExactSpelling = true)]
        public static extern void DeleteGlobal([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetInitializer", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetInitializer([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetInitializer", ExactSpelling = true)]
        public static extern void SetInitializer([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsThreadLocal", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsThreadLocal([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetThreadLocal", ExactSpelling = true)]
        public static extern void SetThreadLocal([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar, [NativeTypeName("LLVMBool")] int IsThreadLocal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsGlobalConstant", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsGlobalConstant([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetGlobalConstant", ExactSpelling = true)]
        public static extern void SetGlobalConstant([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar, [NativeTypeName("LLVMBool")] int IsConstant);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetThreadLocalMode", ExactSpelling = true)]
        public static extern LLVMThreadLocalMode GetThreadLocalMode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetThreadLocalMode", ExactSpelling = true)]
        public static extern void SetThreadLocalMode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar, LLVMThreadLocalMode Mode);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsExternallyInitialized", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsExternallyInitialized([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetExternallyInitialized", ExactSpelling = true)]
        public static extern void SetExternallyInitialized([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar, [NativeTypeName("LLVMBool")] int IsExtInit);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddAlias", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AddAlias([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Aliasee, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNamedGlobalAlias", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNamedGlobalAlias([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFirstGlobalAlias", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetFirstGlobalAlias([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetLastGlobalAlias", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetLastGlobalAlias([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNextGlobalAlias", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNextGlobalAlias([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GA);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetPreviousGlobalAlias", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPreviousGlobalAlias([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GA);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAliasGetAliasee", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AliasGetAliasee([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Alias);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAliasSetAliasee", ExactSpelling = true)]
        public static extern void AliasSetAliasee([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Alias, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Aliasee);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDeleteFunction", ExactSpelling = true)]
        public static extern void DeleteFunction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMHasPersonalityFn", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int HasPersonalityFn([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetPersonalityFn", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPersonalityFn([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetPersonalityFn", ExactSpelling = true)]
        public static extern void SetPersonalityFn([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PersonalityFn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMLookupIntrinsicID", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint LookupIntrinsicID([NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetIntrinsicID", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetIntrinsicID([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetIntrinsicDeclaration", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetIntrinsicDeclaration([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Mod, [NativeTypeName("unsigned int")] uint ID, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ParamTypes, [NativeTypeName("size_t")] UIntPtr ParamCount);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIntrinsicGetType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntrinsicGetType([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* Ctx, [NativeTypeName("unsigned int")] uint ID, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ParamTypes, [NativeTypeName("size_t")] UIntPtr ParamCount);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIntrinsicGetName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* IntrinsicGetName([NativeTypeName("unsigned int")] uint ID, [NativeTypeName("size_t *")] UIntPtr* NameLength);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIntrinsicCopyOverloadedName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* IntrinsicCopyOverloadedName([NativeTypeName("unsigned int")] uint ID, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ParamTypes, [NativeTypeName("size_t")] UIntPtr ParamCount, [NativeTypeName("size_t *")] UIntPtr* NameLength);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIntrinsicIsOverloaded", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IntrinsicIsOverloaded([NativeTypeName("unsigned int")] uint ID);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFunctionCallConv", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetFunctionCallConv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetFunctionCallConv", ExactSpelling = true)]
        public static extern void SetFunctionCallConv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("unsigned int")] uint CC);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetGC", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetGC([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetGC", ExactSpelling = true)]
        public static extern void SetGC([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddAttributeAtIndex", ExactSpelling = true)]
        public static extern void AddAttributeAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetAttributeCountAtIndex", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetAttributeCountAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetAttributesAtIndex", ExactSpelling = true)]
        public static extern void GetAttributesAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("LLVMAttributeRef *")] LLVMOpaqueAttributeRef** Attrs);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetEnumAttributeAtIndex", ExactSpelling = true)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* GetEnumAttributeAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("unsigned int")] uint KindID);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetStringAttributeAtIndex", ExactSpelling = true)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* GetStringAttributeAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("const char *")] sbyte* K, [NativeTypeName("unsigned int")] uint KLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemoveEnumAttributeAtIndex", ExactSpelling = true)]
        public static extern void RemoveEnumAttributeAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("unsigned int")] uint KindID);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemoveStringAttributeAtIndex", ExactSpelling = true)]
        public static extern void RemoveStringAttributeAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("const char *")] sbyte* K, [NativeTypeName("unsigned int")] uint KLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddTargetDependentFunctionAttr", ExactSpelling = true)]
        public static extern void AddTargetDependentFunctionAttr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("const char *")] sbyte* A, [NativeTypeName("const char *")] sbyte* V);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCountParams", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CountParams([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetParams", ExactSpelling = true)]
        public static extern void GetParams([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Params);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetParam", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetParam([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("unsigned int")] uint Index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetParamParent", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetParamParent([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFirstParam", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetFirstParam([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetLastParam", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetLastParam([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNextParam", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNextParam([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Arg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetPreviousParam", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPreviousParam([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Arg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetParamAlignment", ExactSpelling = true)]
        public static extern void SetParamAlignment([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Arg, [NativeTypeName("unsigned int")] uint Align);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddGlobalIFunc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AddGlobalIFunc([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("unsigned int")] uint AddrSpace, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Resolver);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNamedGlobalIFunc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNamedGlobalIFunc([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFirstGlobalIFunc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetFirstGlobalIFunc([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetLastGlobalIFunc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetLastGlobalIFunc([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNextGlobalIFunc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNextGlobalIFunc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IFunc);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetPreviousGlobalIFunc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPreviousGlobalIFunc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IFunc);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetGlobalIFuncResolver", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetGlobalIFuncResolver([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IFunc);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetGlobalIFuncResolver", ExactSpelling = true)]
        public static extern void SetGlobalIFuncResolver([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IFunc, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Resolver);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMEraseGlobalIFunc", ExactSpelling = true)]
        public static extern void EraseGlobalIFunc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IFunc);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemoveGlobalIFunc", ExactSpelling = true)]
        public static extern void RemoveGlobalIFunc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IFunc);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMDStringInContext2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* MDStringInContext2([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("size_t")] UIntPtr SLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMDNodeInContext2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* MDNodeInContext2([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** MDs, [NativeTypeName("size_t")] UIntPtr Count);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMetadataAsValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* MetadataAsValue([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* MD);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMValueAsMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* ValueAsMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetMDString", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetMDString([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("unsigned int *")] uint* Length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetMDNodeNumOperands", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetMDNodeNumOperands([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetMDNodeOperands", ExactSpelling = true)]
        public static extern void GetMDNodeOperands([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Dest);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMDStringInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* MDStringInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("unsigned int")] uint SLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMDString", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* MDString([NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("unsigned int")] uint SLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMDNodeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* MDNodeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Vals, [NativeTypeName("unsigned int")] uint Count);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMDNode", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* MDNode([NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Vals, [NativeTypeName("unsigned int")] uint Count);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBasicBlockAsValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BasicBlockAsValue([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMValueIsBasicBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ValueIsBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMValueAsBasicBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* ValueAsBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetBasicBlockName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetBasicBlockName([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetBasicBlockParent", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetBasicBlockParent([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetBasicBlockTerminator", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetBasicBlockTerminator([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCountBasicBlocks", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CountBasicBlocks([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetBasicBlocks", ExactSpelling = true)]
        public static extern void GetBasicBlocks([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMBasicBlockRef *")] LLVMOpaqueBasicBlock** BasicBlocks);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFirstBasicBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetFirstBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetLastBasicBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetLastBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNextBasicBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetNextBasicBlock([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetPreviousBasicBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetPreviousBasicBlock([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetEntryBasicBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetEntryBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInsertExistingBasicBlockAfterInsertBlock", ExactSpelling = true)]
        public static extern void InsertExistingBasicBlockAfterInsertBlock([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAppendExistingBasicBlock", ExactSpelling = true)]
        public static extern void AppendExistingBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateBasicBlockInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* CreateBasicBlockInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAppendBasicBlockInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* AppendBasicBlockInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAppendBasicBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* AppendBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInsertBasicBlockInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* InsertBasicBlockInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInsertBasicBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* InsertBasicBlock([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* InsertBeforeBB, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDeleteBasicBlock", ExactSpelling = true)]
        public static extern void DeleteBasicBlock([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemoveBasicBlockFromParent", ExactSpelling = true)]
        public static extern void RemoveBasicBlockFromParent([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMoveBasicBlockBefore", ExactSpelling = true)]
        public static extern void MoveBasicBlockBefore([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* MovePos);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMoveBasicBlockAfter", ExactSpelling = true)]
        public static extern void MoveBasicBlockAfter([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* MovePos);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFirstInstruction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetFirstInstruction([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetLastInstruction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetLastInstruction([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMHasMetadata", ExactSpelling = true)]
        public static extern int HasMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetMetadata", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int")] uint KindID);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetMetadata", ExactSpelling = true)]
        public static extern void SetMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int")] uint KindID, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Node);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInstructionGetAllMetadataOtherThanDebugLoc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueMetadataEntry *")]
        public static extern LLVMOpaqueValueMetadataEntry* InstructionGetAllMetadataOtherThanDebugLoc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr, [NativeTypeName("size_t *")] UIntPtr* NumEntries);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetInstructionParent", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetInstructionParent([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNextInstruction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNextInstruction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetPreviousInstruction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPreviousInstruction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInstructionRemoveFromParent", ExactSpelling = true)]
        public static extern void InstructionRemoveFromParent([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInstructionEraseFromParent", ExactSpelling = true)]
        public static extern void InstructionEraseFromParent([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetInstructionOpcode", ExactSpelling = true)]
        public static extern LLVMOpcode GetInstructionOpcode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetICmpPredicate", ExactSpelling = true)]
        public static extern LLVMIntPredicate GetICmpPredicate([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFCmpPredicate", ExactSpelling = true)]
        public static extern LLVMRealPredicate GetFCmpPredicate([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInstructionClone", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* InstructionClone([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsATerminatorInst", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsATerminatorInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNumArgOperands", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumArgOperands([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetInstructionCallConv", ExactSpelling = true)]
        public static extern void SetInstructionCallConv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr, [NativeTypeName("unsigned int")] uint CC);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetInstructionCallConv", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetInstructionCallConv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetInstrParamAlignment", ExactSpelling = true)]
        public static extern void SetInstrParamAlignment([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr, [NativeTypeName("unsigned int")] uint index, [NativeTypeName("unsigned int")] uint Align);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddCallSiteAttribute", ExactSpelling = true)]
        public static extern void AddCallSiteAttribute([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetCallSiteAttributeCount", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetCallSiteAttributeCount([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetCallSiteAttributes", ExactSpelling = true)]
        public static extern void GetCallSiteAttributes([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("LLVMAttributeRef *")] LLVMOpaqueAttributeRef** Attrs);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetCallSiteEnumAttribute", ExactSpelling = true)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* GetCallSiteEnumAttribute([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("unsigned int")] uint KindID);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetCallSiteStringAttribute", ExactSpelling = true)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* GetCallSiteStringAttribute([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("const char *")] sbyte* K, [NativeTypeName("unsigned int")] uint KLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemoveCallSiteEnumAttribute", ExactSpelling = true)]
        public static extern void RemoveCallSiteEnumAttribute([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("unsigned int")] uint KindID);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemoveCallSiteStringAttribute", ExactSpelling = true)]
        public static extern void RemoveCallSiteStringAttribute([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("const char *")] sbyte* K, [NativeTypeName("unsigned int")] uint KLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetCalledFunctionType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GetCalledFunctionType([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetCalledValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetCalledValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsTailCall", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsTailCall([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CallInst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetTailCall", ExactSpelling = true)]
        public static extern void SetTailCall([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CallInst, [NativeTypeName("LLVMBool")] int IsTailCall);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNormalDest", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetNormalDest([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InvokeInst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetUnwindDest", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetUnwindDest([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InvokeInst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetNormalDest", ExactSpelling = true)]
        public static extern void SetNormalDest([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InvokeInst, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* B);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetUnwindDest", ExactSpelling = true)]
        public static extern void SetUnwindDest([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InvokeInst, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* B);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNumSuccessors", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumSuccessors([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Term);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSuccessor", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetSuccessor([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Term, [NativeTypeName("unsigned int")] uint i);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetSuccessor", ExactSpelling = true)]
        public static extern void SetSuccessor([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Term, [NativeTypeName("unsigned int")] uint i, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* block);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsConditional", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsConditional([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Branch);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetCondition", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetCondition([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Branch);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetCondition", ExactSpelling = true)]
        public static extern void SetCondition([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Branch, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Cond);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSwitchDefaultDest", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetSwitchDefaultDest([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* SwitchInstr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetAllocatedType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GetAllocatedType([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Alloca);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsInBounds", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsInBounds([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GEP);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetIsInBounds", ExactSpelling = true)]
        public static extern void SetIsInBounds([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GEP, [NativeTypeName("LLVMBool")] int InBounds);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddIncoming", ExactSpelling = true)]
        public static extern void AddIncoming([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PhiNode, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** IncomingValues, [NativeTypeName("LLVMBasicBlockRef *")] LLVMOpaqueBasicBlock** IncomingBlocks, [NativeTypeName("unsigned int")] uint Count);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCountIncoming", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CountIncoming([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PhiNode);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetIncomingValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetIncomingValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PhiNode, [NativeTypeName("unsigned int")] uint Index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetIncomingBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetIncomingBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PhiNode, [NativeTypeName("unsigned int")] uint Index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNumIndices", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumIndices([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetIndices", ExactSpelling = true)]
        [return: NativeTypeName("const unsigned int *")]
        public static extern uint* GetIndices([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateBuilderInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBuilderRef")]
        public static extern LLVMOpaqueBuilder* CreateBuilderInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateBuilder", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBuilderRef")]
        public static extern LLVMOpaqueBuilder* CreateBuilder();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPositionBuilder", ExactSpelling = true)]
        public static extern void PositionBuilder([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Block, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPositionBuilderBefore", ExactSpelling = true)]
        public static extern void PositionBuilderBefore([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPositionBuilderAtEnd", ExactSpelling = true)]
        public static extern void PositionBuilderAtEnd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Block);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetInsertBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetInsertBlock([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMClearInsertionPosition", ExactSpelling = true)]
        public static extern void ClearInsertionPosition([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInsertIntoBuilder", ExactSpelling = true)]
        public static extern void InsertIntoBuilder([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInsertIntoBuilderWithName", ExactSpelling = true)]
        public static extern void InsertIntoBuilderWithName([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeBuilder", ExactSpelling = true)]
        public static extern void DisposeBuilder([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetCurrentDebugLocation2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* GetCurrentDebugLocation2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetCurrentDebugLocation2", ExactSpelling = true)]
        public static extern void SetCurrentDebugLocation2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Loc);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetInstDebugLocation", ExactSpelling = true)]
        public static extern void SetInstDebugLocation([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuilderGetDefaultFPMathTag", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* BuilderGetDefaultFPMathTag([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuilderSetDefaultFPMathTag", ExactSpelling = true)]
        public static extern void BuilderSetDefaultFPMathTag([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* FPMathTag);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetCurrentDebugLocation", ExactSpelling = true)]
        public static extern void SetCurrentDebugLocation([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* L);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetCurrentDebugLocation", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetCurrentDebugLocation([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildRetVoid", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildRetVoid([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildRet", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildRet([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildAggregateRet", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAggregateRet([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** RetVals, [NativeTypeName("unsigned int")] uint N);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildBr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildBr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Dest);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildCondBr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCondBr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* If, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Then, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Else);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildSwitch", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSwitch([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Else, [NativeTypeName("unsigned int")] uint NumCases);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildIndirectBr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIndirectBr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Addr, [NativeTypeName("unsigned int")] uint NumDests);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildInvoke", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInvoke([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Then, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Catch, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildInvoke2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInvoke2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Then, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Catch, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildUnreachable", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildUnreachable([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildResume", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildResume([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Exn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildLandingPad", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildLandingPad([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PersFn, [NativeTypeName("unsigned int")] uint NumClauses, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildCleanupRet", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCleanupRet([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchPad, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildCatchRet", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCatchRet([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchPad, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildCatchPad", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCatchPad([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ParentPad, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildCleanupPad", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCleanupPad([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ParentPad, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildCatchSwitch", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCatchSwitch([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ParentPad, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* UnwindBB, [NativeTypeName("unsigned int")] uint NumHandlers, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddCase", ExactSpelling = true)]
        public static extern void AddCase([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Switch, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* OnVal, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Dest);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddDestination", ExactSpelling = true)]
        public static extern void AddDestination([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IndirectBr, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Dest);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNumClauses", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumClauses([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LandingPad);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetClause", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetClause([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LandingPad, [NativeTypeName("unsigned int")] uint Idx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddClause", ExactSpelling = true)]
        public static extern void AddClause([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LandingPad, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ClauseVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsCleanup", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsCleanup([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LandingPad);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetCleanup", ExactSpelling = true)]
        public static extern void SetCleanup([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LandingPad, [NativeTypeName("LLVMBool")] int Val);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddHandler", ExactSpelling = true)]
        public static extern void AddHandler([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchSwitch, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Dest);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNumHandlers", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumHandlers([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchSwitch);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetHandlers", ExactSpelling = true)]
        public static extern void GetHandlers([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchSwitch, [NativeTypeName("LLVMBasicBlockRef *")] LLVMOpaqueBasicBlock** Handlers);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetArgOperand", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetArgOperand([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Funclet, [NativeTypeName("unsigned int")] uint i);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetArgOperand", ExactSpelling = true)]
        public static extern void SetArgOperand([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Funclet, [NativeTypeName("unsigned int")] uint i, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* value);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetParentCatchSwitch", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetParentCatchSwitch([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchPad);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetParentCatchSwitch", ExactSpelling = true)]
        public static extern void SetParentCatchSwitch([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchPad, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchSwitch);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildAdd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAdd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildNSWAdd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNSWAdd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildNUWAdd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNUWAdd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFAdd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFAdd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildSub", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSub([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildNSWSub", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNSWSub([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildNUWSub", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNUWSub([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFSub", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFSub([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildMul", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildMul([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildNSWMul", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNSWMul([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildNUWMul", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNUWMul([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFMul", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFMul([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildUDiv", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildUDiv([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildExactUDiv", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildExactUDiv([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildSDiv", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSDiv([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildExactSDiv", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildExactSDiv([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFDiv", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFDiv([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildURem", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildURem([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildSRem", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSRem([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFRem", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFRem([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildShl", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildShl([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildLShr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildLShr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildAShr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAShr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildAnd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAnd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildOr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildOr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildXor", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildXor([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildBinOp", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildBinOp([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, LLVMOpcode Op, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildNeg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNeg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildNSWNeg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNSWNeg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildNUWNeg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNUWNeg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFNeg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFNeg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildNot", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNot([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildMalloc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildMalloc([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildArrayMalloc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildArrayMalloc([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildMemSet", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildMemSet([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Ptr, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Len, [NativeTypeName("unsigned int")] uint Align);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildMemCpy", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildMemCpy([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Dst, [NativeTypeName("unsigned int")] uint DstAlign, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Src, [NativeTypeName("unsigned int")] uint SrcAlign, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Size);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildMemMove", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildMemMove([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Dst, [NativeTypeName("unsigned int")] uint DstAlign, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Src, [NativeTypeName("unsigned int")] uint SrcAlign, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Size);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildAlloca", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAlloca([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildArrayAlloca", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildArrayAlloca([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFree", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFree([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PointerVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildLoad", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildLoad([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PointerVal, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildLoad2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildLoad2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PointerVal, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildStore", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildStore([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Ptr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildGEP", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildGEP([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Indices, [NativeTypeName("unsigned int")] uint NumIndices, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildInBoundsGEP", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInBoundsGEP([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Indices, [NativeTypeName("unsigned int")] uint NumIndices, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildStructGEP", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildStructGEP([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("unsigned int")] uint Idx, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildGEP2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildGEP2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Indices, [NativeTypeName("unsigned int")] uint NumIndices, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildInBoundsGEP2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInBoundsGEP2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Indices, [NativeTypeName("unsigned int")] uint NumIndices, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildStructGEP2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildStructGEP2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("unsigned int")] uint Idx, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildGlobalString", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildGlobalString([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildGlobalStringPtr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildGlobalStringPtr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetVolatile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetVolatile([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* MemoryAccessInst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetVolatile", ExactSpelling = true)]
        public static extern void SetVolatile([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* MemoryAccessInst, [NativeTypeName("LLVMBool")] int IsVolatile);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetWeak", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetWeak([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CmpXchgInst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetWeak", ExactSpelling = true)]
        public static extern void SetWeak([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CmpXchgInst, [NativeTypeName("LLVMBool")] int IsWeak);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetOrdering", ExactSpelling = true)]
        public static extern LLVMAtomicOrdering GetOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* MemoryAccessInst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetOrdering", ExactSpelling = true)]
        public static extern void SetOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* MemoryAccessInst, LLVMAtomicOrdering Ordering);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetAtomicRMWBinOp", ExactSpelling = true)]
        public static extern LLVMAtomicRMWBinOp GetAtomicRMWBinOp([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AtomicRMWInst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetAtomicRMWBinOp", ExactSpelling = true)]
        public static extern void SetAtomicRMWBinOp([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AtomicRMWInst, LLVMAtomicRMWBinOp BinOp);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildTrunc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildTrunc([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildZExt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildZExt([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildSExt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSExt([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFPToUI", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFPToUI([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFPToSI", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFPToSI([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildUIToFP", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildUIToFP([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildSIToFP", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSIToFP([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFPTrunc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFPTrunc([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFPExt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFPExt([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildPtrToInt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildPtrToInt([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildIntToPtr", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIntToPtr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildBitCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildBitCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildAddrSpaceCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAddrSpaceCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildZExtOrBitCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildZExtOrBitCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildSExtOrBitCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSExtOrBitCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildTruncOrBitCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildTruncOrBitCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, LLVMOpcode Op, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildPointerCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildPointerCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildIntCast2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIntCast2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("LLVMBool")] int IsSigned, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFPCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFPCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildIntCast", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIntCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildICmp", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildICmp([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, LLVMIntPredicate Op, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFCmp", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFCmp([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, LLVMRealPredicate Op, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildPhi", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildPhi([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildCall", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCall([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildCall2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCall2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* param1, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildSelect", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSelect([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* If, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Then, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Else, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildVAArg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildVAArg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* List, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildExtractElement", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildExtractElement([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VecVal, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Index, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildInsertElement", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInsertElement([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VecVal, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* EltVal, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Index, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildShuffleVector", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildShuffleVector([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V1, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V2, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Mask, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildExtractValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildExtractValue([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AggVal, [NativeTypeName("unsigned int")] uint Index, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildInsertValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInsertValue([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AggVal, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* EltVal, [NativeTypeName("unsigned int")] uint Index, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFreeze", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFreeze([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildIsNull", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIsNull([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildIsNotNull", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIsNotNull([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildPtrDiff", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildPtrDiff([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildFence", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFence([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, LLVMAtomicOrdering ordering, [NativeTypeName("LLVMBool")] int singleThread, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildAtomicRMW", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAtomicRMW([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, LLVMAtomicRMWBinOp op, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PTR, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, LLVMAtomicOrdering ordering, [NativeTypeName("LLVMBool")] int singleThread);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBuildAtomicCmpXchg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAtomicCmpXchg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Ptr, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Cmp, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* New, LLVMAtomicOrdering SuccessOrdering, LLVMAtomicOrdering FailureOrdering, [NativeTypeName("LLVMBool")] int SingleThread);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNumMaskElements", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumMaskElements([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ShuffleVectorInst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetUndefMaskElem", ExactSpelling = true)]
        public static extern int GetUndefMaskElem();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetMaskValue", ExactSpelling = true)]
        public static extern int GetMaskValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ShuffleVectorInst, [NativeTypeName("unsigned int")] uint Elt);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsAtomicSingleThread", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsAtomicSingleThread([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AtomicInst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetAtomicSingleThread", ExactSpelling = true)]
        public static extern void SetAtomicSingleThread([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AtomicInst, [NativeTypeName("LLVMBool")] int SingleThread);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetCmpXchgSuccessOrdering", ExactSpelling = true)]
        public static extern LLVMAtomicOrdering GetCmpXchgSuccessOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CmpXchgInst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetCmpXchgSuccessOrdering", ExactSpelling = true)]
        public static extern void SetCmpXchgSuccessOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CmpXchgInst, LLVMAtomicOrdering Ordering);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetCmpXchgFailureOrdering", ExactSpelling = true)]
        public static extern LLVMAtomicOrdering GetCmpXchgFailureOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CmpXchgInst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetCmpXchgFailureOrdering", ExactSpelling = true)]
        public static extern void SetCmpXchgFailureOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CmpXchgInst, LLVMAtomicOrdering Ordering);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateModuleProviderForExistingModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMModuleProviderRef")]
        public static extern LLVMOpaqueModuleProvider* CreateModuleProviderForExistingModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeModuleProvider", ExactSpelling = true)]
        public static extern void DisposeModuleProvider([NativeTypeName("LLVMModuleProviderRef")] LLVMOpaqueModuleProvider* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateMemoryBufferWithContentsOfFile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateMemoryBufferWithContentsOfFile([NativeTypeName("const char *")] sbyte* Path, [NativeTypeName("LLVMMemoryBufferRef *")] LLVMOpaqueMemoryBuffer** OutMemBuf, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateMemoryBufferWithSTDIN", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateMemoryBufferWithSTDIN([NativeTypeName("LLVMMemoryBufferRef *")] LLVMOpaqueMemoryBuffer** OutMemBuf, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateMemoryBufferWithMemoryRange", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMemoryBufferRef")]
        public static extern LLVMOpaqueMemoryBuffer* CreateMemoryBufferWithMemoryRange([NativeTypeName("const char *")] sbyte* InputData, [NativeTypeName("size_t")] UIntPtr InputDataLength, [NativeTypeName("const char *")] sbyte* BufferName, [NativeTypeName("LLVMBool")] int RequiresNullTerminator);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateMemoryBufferWithMemoryRangeCopy", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMemoryBufferRef")]
        public static extern LLVMOpaqueMemoryBuffer* CreateMemoryBufferWithMemoryRangeCopy([NativeTypeName("const char *")] sbyte* InputData, [NativeTypeName("size_t")] UIntPtr InputDataLength, [NativeTypeName("const char *")] sbyte* BufferName);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetBufferStart", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetBufferStart([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetBufferSize", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern UIntPtr GetBufferSize([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeMemoryBuffer", ExactSpelling = true)]
        public static extern void DisposeMemoryBuffer([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetGlobalPassRegistry", ExactSpelling = true)]
        [return: NativeTypeName("LLVMPassRegistryRef")]
        public static extern LLVMOpaquePassRegistry* GetGlobalPassRegistry();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreatePassManager", ExactSpelling = true)]
        [return: NativeTypeName("LLVMPassManagerRef")]
        public static extern LLVMOpaquePassManager* CreatePassManager();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateFunctionPassManagerForModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMPassManagerRef")]
        public static extern LLVMOpaquePassManager* CreateFunctionPassManagerForModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateFunctionPassManager", ExactSpelling = true)]
        [return: NativeTypeName("LLVMPassManagerRef")]
        public static extern LLVMOpaquePassManager* CreateFunctionPassManager([NativeTypeName("LLVMModuleProviderRef")] LLVMOpaqueModuleProvider* MP);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRunPassManager", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int RunPassManager([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeFunctionPassManager", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int InitializeFunctionPassManager([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* FPM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRunFunctionPassManager", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int RunFunctionPassManager([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* FPM, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMFinalizeFunctionPassManager", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int FinalizeFunctionPassManager([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* FPM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposePassManager", ExactSpelling = true)]
        public static extern void DisposePassManager([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMStartMultithreaded", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int StartMultithreaded();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMStopMultithreaded", ExactSpelling = true)]
        public static extern void StopMultithreaded();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsMultithreaded", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsMultithreaded();

        public const int LLVMMDStringMetadataKind = 0;
        public const int LLVMConstantAsMetadataMetadataKind = 1;
        public const int LLVMLocalAsMetadataMetadataKind = 2;
        public const int LLVMDistinctMDOperandPlaceholderMetadataKind = 3;
        public const int LLVMMDTupleMetadataKind = 4;
        public const int LLVMDILocationMetadataKind = 5;
        public const int LLVMDIExpressionMetadataKind = 6;
        public const int LLVMDIGlobalVariableExpressionMetadataKind = 7;
        public const int LLVMGenericDINodeMetadataKind = 8;
        public const int LLVMDISubrangeMetadataKind = 9;
        public const int LLVMDIEnumeratorMetadataKind = 10;
        public const int LLVMDIBasicTypeMetadataKind = 11;
        public const int LLVMDIDerivedTypeMetadataKind = 12;
        public const int LLVMDICompositeTypeMetadataKind = 13;
        public const int LLVMDISubroutineTypeMetadataKind = 14;
        public const int LLVMDIFileMetadataKind = 15;
        public const int LLVMDICompileUnitMetadataKind = 16;
        public const int LLVMDISubprogramMetadataKind = 17;
        public const int LLVMDILexicalBlockMetadataKind = 18;
        public const int LLVMDILexicalBlockFileMetadataKind = 19;
        public const int LLVMDINamespaceMetadataKind = 20;
        public const int LLVMDIModuleMetadataKind = 21;
        public const int LLVMDITemplateTypeParameterMetadataKind = 22;
        public const int LLVMDITemplateValueParameterMetadataKind = 23;
        public const int LLVMDIGlobalVariableMetadataKind = 24;
        public const int LLVMDILocalVariableMetadataKind = 25;
        public const int LLVMDILabelMetadataKind = 26;
        public const int LLVMDIObjCPropertyMetadataKind = 27;
        public const int LLVMDIImportedEntityMetadataKind = 28;
        public const int LLVMDIMacroMetadataKind = 29;
        public const int LLVMDIMacroFileMetadataKind = 30;
        public const int LLVMDICommonBlockMetadataKind = 31;

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDebugMetadataVersion", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint DebugMetadataVersion();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetModuleDebugMetadataVersion", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetModuleDebugMetadataVersion([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Module);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMStripModuleDebugInfo", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int StripModuleDebugInfo([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Module);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateDIBuilderDisallowUnresolved", ExactSpelling = true)]
        [return: NativeTypeName("LLVMDIBuilderRef")]
        public static extern LLVMOpaqueDIBuilder* CreateDIBuilderDisallowUnresolved([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateDIBuilder", ExactSpelling = true)]
        [return: NativeTypeName("LLVMDIBuilderRef")]
        public static extern LLVMOpaqueDIBuilder* CreateDIBuilder([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeDIBuilder", ExactSpelling = true)]
        public static extern void DisposeDIBuilder([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderFinalize", ExactSpelling = true)]
        public static extern void DIBuilderFinalize([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateCompileUnit", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateCompileUnit([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, LLVMDWARFSourceLanguage Lang, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* FileRef, [NativeTypeName("const char *")] sbyte* Producer, [NativeTypeName("size_t")] UIntPtr ProducerLen, [NativeTypeName("LLVMBool")] int isOptimized, [NativeTypeName("const char *")] sbyte* Flags, [NativeTypeName("size_t")] UIntPtr FlagsLen, [NativeTypeName("unsigned int")] uint RuntimeVer, [NativeTypeName("const char *")] sbyte* SplitName, [NativeTypeName("size_t")] UIntPtr SplitNameLen, LLVMDWARFEmissionKind Kind, [NativeTypeName("unsigned int")] uint DWOId, [NativeTypeName("LLVMBool")] int SplitDebugInlining, [NativeTypeName("LLVMBool")] int DebugInfoForProfiling, [NativeTypeName("const char *")] sbyte* SysRoot, [NativeTypeName("size_t")] UIntPtr SysRootLen, [NativeTypeName("const char *")] sbyte* SDK, [NativeTypeName("size_t")] UIntPtr SDKLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateFile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateFile([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("const char *")] sbyte* Filename, [NativeTypeName("size_t")] UIntPtr FilenameLen, [NativeTypeName("const char *")] sbyte* Directory, [NativeTypeName("size_t")] UIntPtr DirectoryLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateModule([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ParentScope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("const char *")] sbyte* ConfigMacros, [NativeTypeName("size_t")] UIntPtr ConfigMacrosLen, [NativeTypeName("const char *")] sbyte* IncludePath, [NativeTypeName("size_t")] UIntPtr IncludePathLen, [NativeTypeName("const char *")] sbyte* APINotesFile, [NativeTypeName("size_t")] UIntPtr APINotesFileLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateNameSpace", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateNameSpace([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ParentScope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMBool")] int ExportSymbols);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateFunction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateFunction([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("const char *")] sbyte* LinkageName, [NativeTypeName("size_t")] UIntPtr LinkageNameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMBool")] int IsLocalToUnit, [NativeTypeName("LLVMBool")] int IsDefinition, [NativeTypeName("unsigned int")] uint ScopeLine, LLVMDIFlags Flags, [NativeTypeName("LLVMBool")] int IsOptimized);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateLexicalBlock", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateLexicalBlock([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line, [NativeTypeName("unsigned int")] uint Column);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateLexicalBlockFile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateLexicalBlockFile([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Discriminator);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateImportedModuleFromNamespace", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateImportedModuleFromNamespace([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* NS, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateImportedModuleFromAlias", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateImportedModuleFromAlias([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ImportedEntity, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateImportedModuleFromModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateImportedModuleFromModule([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* M, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateImportedDeclaration", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateImportedDeclaration([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Decl, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateDebugLocation", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateDebugLocation([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* Ctx, [NativeTypeName("unsigned int")] uint Line, [NativeTypeName("unsigned int")] uint Column, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* InlinedAt);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDILocationGetLine", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint DILocationGetLine([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Location);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDILocationGetColumn", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint DILocationGetColumn([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Location);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDILocationGetScope", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DILocationGetScope([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Location);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDILocationGetInlinedAt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DILocationGetInlinedAt([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Location);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIScopeGetFile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIScopeGetFile([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIFileGetDirectory", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* DIFileGetDirectory([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int *")] uint* Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIFileGetFilename", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* DIFileGetFilename([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int *")] uint* Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIFileGetSource", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* DIFileGetSource([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int *")] uint* Len);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderGetOrCreateTypeArray", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderGetOrCreateTypeArray([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Data, [NativeTypeName("size_t")] UIntPtr NumElements);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateSubroutineType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateSubroutineType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** ParameterTypes, [NativeTypeName("unsigned int")] uint NumParameterTypes, LLVMDIFlags Flags);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateMacro", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateMacro([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ParentMacroFile, [NativeTypeName("unsigned int")] uint Line, LLVMDWARFMacinfoRecordType RecordType, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("const char *")] sbyte* Value, [NativeTypeName("size_t")] UIntPtr ValueLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateTempMacroFile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateTempMacroFile([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ParentMacroFile, [NativeTypeName("unsigned int")] uint Line, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateEnumerator", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateEnumerator([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("int64_t")] long Value, [NativeTypeName("LLVMBool")] int IsUnsigned);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateEnumerationType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateEnumerationType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Elements, [NativeTypeName("unsigned int")] uint NumElements, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ClassTy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateUnionType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateUnionType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Elements, [NativeTypeName("unsigned int")] uint NumElements, [NativeTypeName("unsigned int")] uint RunTimeLang, [NativeTypeName("const char *")] sbyte* UniqueId, [NativeTypeName("size_t")] UIntPtr UniqueIdLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateArrayType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateArrayType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("uint64_t")] ulong Size, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Subscripts, [NativeTypeName("unsigned int")] uint NumSubscripts);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateVectorType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateVectorType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("uint64_t")] ulong Size, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Subscripts, [NativeTypeName("unsigned int")] uint NumSubscripts);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateUnspecifiedType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateUnspecifiedType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateBasicType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateBasicType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("LLVMDWARFTypeEncoding")] uint Encoding, LLVMDIFlags Flags);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreatePointerType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreatePointerType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* PointeeTy, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("unsigned int")] uint AddressSpace, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateStructType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateStructType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DerivedFrom, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Elements, [NativeTypeName("unsigned int")] uint NumElements, [NativeTypeName("unsigned int")] uint RunTimeLang, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VTableHolder, [NativeTypeName("const char *")] sbyte* UniqueId, [NativeTypeName("size_t")] UIntPtr UniqueIdLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateMemberType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateMemberType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("uint64_t")] ulong OffsetInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateStaticMemberType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateStaticMemberType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type, LLVMDIFlags Flags, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("uint32_t")] uint AlignInBits);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateMemberPointerType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateMemberPointerType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* PointeeType, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ClassType, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, LLVMDIFlags Flags);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateObjCIVar", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateObjCIVar([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("uint64_t")] ulong OffsetInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* PropertyNode);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateObjCProperty", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateObjCProperty([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("const char *")] sbyte* GetterName, [NativeTypeName("size_t")] UIntPtr GetterNameLen, [NativeTypeName("const char *")] sbyte* SetterName, [NativeTypeName("size_t")] UIntPtr SetterNameLen, [NativeTypeName("unsigned int")] uint PropertyAttributes, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateObjectPointerType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateObjectPointerType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateQualifiedType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateQualifiedType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("unsigned int")] uint Tag, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateReferenceType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateReferenceType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("unsigned int")] uint Tag, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateNullPtrType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateNullPtrType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateTypedef", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateTypedef([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("uint32_t")] uint AlignInBits);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateInheritance", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateInheritance([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* BaseTy, [NativeTypeName("uint64_t")] ulong BaseOffset, [NativeTypeName("uint32_t")] uint VBPtrOffset, LLVMDIFlags Flags);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateForwardDecl", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateForwardDecl([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("unsigned int")] uint Tag, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line, [NativeTypeName("unsigned int")] uint RuntimeLang, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("const char *")] sbyte* UniqueIdentifier, [NativeTypeName("size_t")] UIntPtr UniqueIdentifierLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateReplaceableCompositeType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateReplaceableCompositeType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("unsigned int")] uint Tag, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line, [NativeTypeName("unsigned int")] uint RuntimeLang, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, LLVMDIFlags Flags, [NativeTypeName("const char *")] sbyte* UniqueIdentifier, [NativeTypeName("size_t")] UIntPtr UniqueIdentifierLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateBitFieldMemberType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateBitFieldMemberType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint64_t")] ulong OffsetInBits, [NativeTypeName("uint64_t")] ulong StorageOffsetInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateClassType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateClassType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("uint64_t")] ulong OffsetInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DerivedFrom, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Elements, [NativeTypeName("unsigned int")] uint NumElements, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VTableHolder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* TemplateParamsNode, [NativeTypeName("const char *")] sbyte* UniqueIdentifier, [NativeTypeName("size_t")] UIntPtr UniqueIdentifierLen);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateArtificialType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateArtificialType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDITypeGetName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* DITypeGetName([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType, [NativeTypeName("size_t *")] UIntPtr* Length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDITypeGetSizeInBits", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong DITypeGetSizeInBits([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDITypeGetOffsetInBits", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong DITypeGetOffsetInBits([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDITypeGetAlignInBits", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint DITypeGetAlignInBits([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDITypeGetLine", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint DITypeGetLine([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDITypeGetFlags", ExactSpelling = true)]
        public static extern LLVMDIFlags DITypeGetFlags([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderGetOrCreateSubrange", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderGetOrCreateSubrange([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("int64_t")] long LowerBound, [NativeTypeName("int64_t")] long Count);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderGetOrCreateArray", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderGetOrCreateArray([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Data, [NativeTypeName("size_t")] UIntPtr NumElements);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateExpression", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateExpression([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("int64_t *")] long* Addr, [NativeTypeName("size_t")] UIntPtr Length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateConstantValueExpression", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateConstantValueExpression([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("int64_t")] long Value);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateGlobalVariableExpression", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateGlobalVariableExpression([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("const char *")] sbyte* Linkage, [NativeTypeName("size_t")] UIntPtr LinkLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMBool")] int LocalToUnit, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Expr, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Decl, [NativeTypeName("uint32_t")] uint AlignInBits);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIGlobalVariableExpressionGetVariable", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIGlobalVariableExpressionGetVariable([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* GVE);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIGlobalVariableExpressionGetExpression", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIGlobalVariableExpressionGetExpression([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* GVE);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIVariableGetFile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIVariableGetFile([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Var);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIVariableGetScope", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIVariableGetScope([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Var);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIVariableGetLine", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint DIVariableGetLine([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Var);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMTemporaryMDNode", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* TemporaryMDNode([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* Ctx, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Data, [NativeTypeName("size_t")] UIntPtr NumElements);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeTemporaryMDNode", ExactSpelling = true)]
        public static extern void DisposeTemporaryMDNode([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* TempNode);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMetadataReplaceAllUsesWith", ExactSpelling = true)]
        public static extern void MetadataReplaceAllUsesWith([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* TempTargetMetadata, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Replacement);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateTempGlobalVariableFwdDecl", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateTempGlobalVariableFwdDecl([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("const char *")] sbyte* Linkage, [NativeTypeName("size_t")] UIntPtr LnkLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMBool")] int LocalToUnit, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Decl, [NativeTypeName("uint32_t")] uint AlignInBits);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderInsertDeclareBefore", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* DIBuilderInsertDeclareBefore([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Storage, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VarInfo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Expr, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DebugLoc, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderInsertDeclareAtEnd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* DIBuilderInsertDeclareAtEnd([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Storage, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VarInfo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Expr, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DebugLoc, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Block);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderInsertDbgValueBefore", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* DIBuilderInsertDbgValueBefore([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VarInfo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Expr, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DebugLoc, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderInsertDbgValueAtEnd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* DIBuilderInsertDbgValueAtEnd([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VarInfo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Expr, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DebugLoc, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Block);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateAutoVariable", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateAutoVariable([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMBool")] int AlwaysPreserve, LLVMDIFlags Flags, [NativeTypeName("uint32_t")] uint AlignInBits);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDIBuilderCreateParameterVariable", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateParameterVariable([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("unsigned int")] uint ArgNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMBool")] int AlwaysPreserve, LLVMDIFlags Flags);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSubprogram", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* GetSubprogram([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Func);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetSubprogram", ExactSpelling = true)]
        public static extern void SetSubprogram([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Func, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* SP);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDISubprogramGetLine", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint DISubprogramGetLine([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Subprogram);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInstructionGetDebugLoc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* InstructionGetDebugLoc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInstructionSetDebugLoc", ExactSpelling = true)]
        public static extern void InstructionSetDebugLoc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Loc);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetMetadataKind", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMetadataKind")]
        public static extern uint GetMetadataKind([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Metadata);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateDisasm", ExactSpelling = true)]
        [return: NativeTypeName("LLVMDisasmContextRef")]
        public static extern void* CreateDisasm([NativeTypeName("const char *")] sbyte* TripleName, [NativeTypeName("void *")] void* DisInfo, int TagType, [NativeTypeName("LLVMOpInfoCallback")] IntPtr GetOpInfo, [NativeTypeName("LLVMSymbolLookupCallback")] IntPtr SymbolLookUp);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateDisasmCPU", ExactSpelling = true)]
        [return: NativeTypeName("LLVMDisasmContextRef")]
        public static extern void* CreateDisasmCPU([NativeTypeName("const char *")] sbyte* Triple, [NativeTypeName("const char *")] sbyte* CPU, [NativeTypeName("void *")] void* DisInfo, int TagType, [NativeTypeName("LLVMOpInfoCallback")] IntPtr GetOpInfo, [NativeTypeName("LLVMSymbolLookupCallback")] IntPtr SymbolLookUp);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateDisasmCPUFeatures", ExactSpelling = true)]
        [return: NativeTypeName("LLVMDisasmContextRef")]
        public static extern void* CreateDisasmCPUFeatures([NativeTypeName("const char *")] sbyte* Triple, [NativeTypeName("const char *")] sbyte* CPU, [NativeTypeName("const char *")] sbyte* Features, [NativeTypeName("void *")] void* DisInfo, int TagType, [NativeTypeName("LLVMOpInfoCallback")] IntPtr GetOpInfo, [NativeTypeName("LLVMSymbolLookupCallback")] IntPtr SymbolLookUp);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetDisasmOptions", ExactSpelling = true)]
        public static extern int SetDisasmOptions([NativeTypeName("LLVMDisasmContextRef")] void* DC, [NativeTypeName("uint64_t")] ulong Options);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisasmDispose", ExactSpelling = true)]
        public static extern void DisasmDispose([NativeTypeName("LLVMDisasmContextRef")] void* DC);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisasmInstruction", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern UIntPtr DisasmInstruction([NativeTypeName("LLVMDisasmContextRef")] void* DC, [NativeTypeName("uint8_t *")] byte* Bytes, [NativeTypeName("uint64_t")] ulong BytesSize, [NativeTypeName("uint64_t")] ulong PC, [NativeTypeName("char *")] sbyte* OutString, [NativeTypeName("size_t")] UIntPtr OutStringSize);

        [NativeTypeName("#define LLVMDisassembler_Option_UseMarkup 1")]
        public const int LLVMDisassembler_Option_UseMarkup = 1;

        [NativeTypeName("#define LLVMDisassembler_Option_PrintImmHex 2")]
        public const int LLVMDisassembler_Option_PrintImmHex = 2;

        [NativeTypeName("#define LLVMDisassembler_Option_AsmPrinterVariant 4")]
        public const int LLVMDisassembler_Option_AsmPrinterVariant = 4;

        [NativeTypeName("#define LLVMDisassembler_Option_SetInstrComments 8")]
        public const int LLVMDisassembler_Option_SetInstrComments = 8;

        [NativeTypeName("#define LLVMDisassembler_Option_PrintLatency 16")]
        public const int LLVMDisassembler_Option_PrintLatency = 16;

        [NativeTypeName("#define LLVMDisassembler_VariantKind_None 0")]
        public const int LLVMDisassembler_VariantKind_None = 0;

        [NativeTypeName("#define LLVMDisassembler_VariantKind_ARM_HI16 1")]
        public const int LLVMDisassembler_VariantKind_ARM_HI16 = 1;

        [NativeTypeName("#define LLVMDisassembler_VariantKind_ARM_LO16 2")]
        public const int LLVMDisassembler_VariantKind_ARM_LO16 = 2;

        [NativeTypeName("#define LLVMDisassembler_VariantKind_ARM64_PAGE 1")]
        public const int LLVMDisassembler_VariantKind_ARM64_PAGE = 1;

        [NativeTypeName("#define LLVMDisassembler_VariantKind_ARM64_PAGEOFF 2")]
        public const int LLVMDisassembler_VariantKind_ARM64_PAGEOFF = 2;

        [NativeTypeName("#define LLVMDisassembler_VariantKind_ARM64_GOTPAGE 3")]
        public const int LLVMDisassembler_VariantKind_ARM64_GOTPAGE = 3;

        [NativeTypeName("#define LLVMDisassembler_VariantKind_ARM64_GOTPAGEOFF 4")]
        public const int LLVMDisassembler_VariantKind_ARM64_GOTPAGEOFF = 4;

        [NativeTypeName("#define LLVMDisassembler_VariantKind_ARM64_TLVP 5")]
        public const int LLVMDisassembler_VariantKind_ARM64_TLVP = 5;

        [NativeTypeName("#define LLVMDisassembler_VariantKind_ARM64_TLVOFF 6")]
        public const int LLVMDisassembler_VariantKind_ARM64_TLVOFF = 6;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_InOut_None 0")]
        public const int LLVMDisassembler_ReferenceType_InOut_None = 0;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_In_Branch 1")]
        public const int LLVMDisassembler_ReferenceType_In_Branch = 1;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_In_PCrel_Load 2")]
        public const int LLVMDisassembler_ReferenceType_In_PCrel_Load = 2;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_In_ARM64_ADRP 0x100000001")]
        public const long LLVMDisassembler_ReferenceType_In_ARM64_ADRP = 0x100000001;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_In_ARM64_ADDXri 0x100000002")]
        public const long LLVMDisassembler_ReferenceType_In_ARM64_ADDXri = 0x100000002;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_In_ARM64_LDRXui 0x100000003")]
        public const long LLVMDisassembler_ReferenceType_In_ARM64_LDRXui = 0x100000003;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_In_ARM64_LDRXl 0x100000004")]
        public const long LLVMDisassembler_ReferenceType_In_ARM64_LDRXl = 0x100000004;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_In_ARM64_ADR 0x100000005")]
        public const long LLVMDisassembler_ReferenceType_In_ARM64_ADR = 0x100000005;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_Out_SymbolStub 1")]
        public const int LLVMDisassembler_ReferenceType_Out_SymbolStub = 1;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_Out_LitPool_SymAddr 2")]
        public const int LLVMDisassembler_ReferenceType_Out_LitPool_SymAddr = 2;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_Out_LitPool_CstrAddr 3")]
        public const int LLVMDisassembler_ReferenceType_Out_LitPool_CstrAddr = 3;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_Out_Objc_CFString_Ref 4")]
        public const int LLVMDisassembler_ReferenceType_Out_Objc_CFString_Ref = 4;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_Out_Objc_Message 5")]
        public const int LLVMDisassembler_ReferenceType_Out_Objc_Message = 5;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_Out_Objc_Message_Ref 6")]
        public const int LLVMDisassembler_ReferenceType_Out_Objc_Message_Ref = 6;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_Out_Objc_Selector_Ref 7")]
        public const int LLVMDisassembler_ReferenceType_Out_Objc_Selector_Ref = 7;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_Out_Objc_Class_Ref 8")]
        public const int LLVMDisassembler_ReferenceType_Out_Objc_Class_Ref = 8;

        [NativeTypeName("#define LLVMDisassembler_ReferenceType_DeMangled_Name 9")]
        public const int LLVMDisassembler_ReferenceType_DeMangled_Name = 9;

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetErrorTypeId", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorTypeId")]
        public static extern void* GetErrorTypeId([NativeTypeName("LLVMErrorRef")] LLVMOpaqueError* Err);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMConsumeError", ExactSpelling = true)]
        public static extern void ConsumeError([NativeTypeName("LLVMErrorRef")] LLVMOpaqueError* Err);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetErrorMessage", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetErrorMessage([NativeTypeName("LLVMErrorRef")] LLVMOpaqueError* Err);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeErrorMessage", ExactSpelling = true)]
        public static extern void DisposeErrorMessage([NativeTypeName("char *")] sbyte* ErrMsg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetStringErrorTypeId", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorTypeId")]
        public static extern void* GetStringErrorTypeId();

        [NativeTypeName("#define LLVMErrorSuccess 0")]
        public const int LLVMErrorSuccess = 0;

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInstallFatalErrorHandler", ExactSpelling = true)]
        public static extern void InstallFatalErrorHandler([NativeTypeName("LLVMFatalErrorHandler")] IntPtr Handler);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMResetFatalErrorHandler", ExactSpelling = true)]
        public static extern void ResetFatalErrorHandler();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMEnablePrettyStackTrace", ExactSpelling = true)]
        public static extern void EnablePrettyStackTrace();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMLinkInMCJIT", ExactSpelling = true)]
        public static extern void LinkInMCJIT();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMLinkInInterpreter", ExactSpelling = true)]
        public static extern void LinkInInterpreter();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateGenericValueOfInt", ExactSpelling = true)]
        [return: NativeTypeName("LLVMGenericValueRef")]
        public static extern LLVMOpaqueGenericValue* CreateGenericValueOfInt([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("unsigned long long")] ulong N, [NativeTypeName("LLVMBool")] int IsSigned);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateGenericValueOfPointer", ExactSpelling = true)]
        [return: NativeTypeName("LLVMGenericValueRef")]
        public static extern LLVMOpaqueGenericValue* CreateGenericValueOfPointer([NativeTypeName("void *")] void* P);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateGenericValueOfFloat", ExactSpelling = true)]
        [return: NativeTypeName("LLVMGenericValueRef")]
        public static extern LLVMOpaqueGenericValue* CreateGenericValueOfFloat([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, double N);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGenericValueIntWidth", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GenericValueIntWidth([NativeTypeName("LLVMGenericValueRef")] LLVMOpaqueGenericValue* GenValRef);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGenericValueToInt", ExactSpelling = true)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong GenericValueToInt([NativeTypeName("LLVMGenericValueRef")] LLVMOpaqueGenericValue* GenVal, [NativeTypeName("LLVMBool")] int IsSigned);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGenericValueToPointer", ExactSpelling = true)]
        [return: NativeTypeName("void *")]
        public static extern void* GenericValueToPointer([NativeTypeName("LLVMGenericValueRef")] LLVMOpaqueGenericValue* GenVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGenericValueToFloat", ExactSpelling = true)]
        public static extern double GenericValueToFloat([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* TyRef, [NativeTypeName("LLVMGenericValueRef")] LLVMOpaqueGenericValue* GenVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeGenericValue", ExactSpelling = true)]
        public static extern void DisposeGenericValue([NativeTypeName("LLVMGenericValueRef")] LLVMOpaqueGenericValue* GenVal);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateExecutionEngineForModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateExecutionEngineForModule([NativeTypeName("LLVMExecutionEngineRef *")] LLVMOpaqueExecutionEngine** OutEE, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("char **")] sbyte** OutError);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateInterpreterForModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateInterpreterForModule([NativeTypeName("LLVMExecutionEngineRef *")] LLVMOpaqueExecutionEngine** OutInterp, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("char **")] sbyte** OutError);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateJITCompilerForModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateJITCompilerForModule([NativeTypeName("LLVMExecutionEngineRef *")] LLVMOpaqueExecutionEngine** OutJIT, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("unsigned int")] uint OptLevel, [NativeTypeName("char **")] sbyte** OutError);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMCJITCompilerOptions", ExactSpelling = true)]
        public static extern void InitializeMCJITCompilerOptions([NativeTypeName("struct LLVMMCJITCompilerOptions *")] LLVMMCJITCompilerOptions* Options, [NativeTypeName("size_t")] UIntPtr SizeOfOptions);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateMCJITCompilerForModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateMCJITCompilerForModule([NativeTypeName("LLVMExecutionEngineRef *")] LLVMOpaqueExecutionEngine** OutJIT, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("struct LLVMMCJITCompilerOptions *")] LLVMMCJITCompilerOptions* Options, [NativeTypeName("size_t")] UIntPtr SizeOfOptions, [NativeTypeName("char **")] sbyte** OutError);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeExecutionEngine", ExactSpelling = true)]
        public static extern void DisposeExecutionEngine([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRunStaticConstructors", ExactSpelling = true)]
        public static extern void RunStaticConstructors([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRunStaticDestructors", ExactSpelling = true)]
        public static extern void RunStaticDestructors([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRunFunctionAsMain", ExactSpelling = true)]
        public static extern int RunFunctionAsMain([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("unsigned int")] uint ArgC, [NativeTypeName("const char *const *")] sbyte** ArgV, [NativeTypeName("const char *const *")] sbyte** EnvP);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRunFunction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMGenericValueRef")]
        public static extern LLVMOpaqueGenericValue* RunFunction([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("LLVMGenericValueRef *")] LLVMOpaqueGenericValue** Args);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMFreeMachineCodeForFunction", ExactSpelling = true)]
        public static extern void FreeMachineCodeForFunction([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddModule", ExactSpelling = true)]
        public static extern void AddModule([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemoveModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int RemoveModule([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutMod, [NativeTypeName("char **")] sbyte** OutError);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMFindFunction", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int FindFunction([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** OutFn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRecompileAndRelinkFunction", ExactSpelling = true)]
        [return: NativeTypeName("void *")]
        public static extern void* RecompileAndRelinkFunction([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetExecutionEngineTargetData", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTargetDataRef")]
        public static extern LLVMOpaqueTargetData* GetExecutionEngineTargetData([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetExecutionEngineTargetMachine", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTargetMachineRef")]
        public static extern LLVMOpaqueTargetMachine* GetExecutionEngineTargetMachine([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddGlobalMapping", ExactSpelling = true)]
        public static extern void AddGlobalMapping([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, [NativeTypeName("void *")] void* Addr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetPointerToGlobal", ExactSpelling = true)]
        [return: NativeTypeName("void *")]
        public static extern void* GetPointerToGlobal([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetGlobalValueAddress", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetGlobalValueAddress([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFunctionAddress", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetFunctionAddress([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMExecutionEngineGetErrMsg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ExecutionEngineGetErrMsg([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("char **")] sbyte** OutError);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateSimpleMCJITMemoryManager", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMCJITMemoryManagerRef")]
        public static extern LLVMOpaqueMCJITMemoryManager* CreateSimpleMCJITMemoryManager([NativeTypeName("void *")] void* Opaque, [NativeTypeName("LLVMMemoryManagerAllocateCodeSectionCallback")] IntPtr AllocateCodeSection, [NativeTypeName("LLVMMemoryManagerAllocateDataSectionCallback")] IntPtr AllocateDataSection, [NativeTypeName("LLVMMemoryManagerFinalizeMemoryCallback")] IntPtr FinalizeMemory, [NativeTypeName("LLVMMemoryManagerDestroyCallback")] IntPtr Destroy);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeMCJITMemoryManager", ExactSpelling = true)]
        public static extern void DisposeMCJITMemoryManager([NativeTypeName("LLVMMCJITMemoryManagerRef")] LLVMOpaqueMCJITMemoryManager* MM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateGDBRegistrationListener", ExactSpelling = true)]
        [return: NativeTypeName("LLVMJITEventListenerRef")]
        public static extern LLVMOpaqueJITEventListener* CreateGDBRegistrationListener();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateIntelJITEventListener", ExactSpelling = true)]
        [return: NativeTypeName("LLVMJITEventListenerRef")]
        public static extern LLVMOpaqueJITEventListener* CreateIntelJITEventListener();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateOProfileJITEventListener", ExactSpelling = true)]
        [return: NativeTypeName("LLVMJITEventListenerRef")]
        public static extern LLVMOpaqueJITEventListener* CreateOProfileJITEventListener();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreatePerfJITEventListener", ExactSpelling = true)]
        [return: NativeTypeName("LLVMJITEventListenerRef")]
        public static extern LLVMOpaqueJITEventListener* CreatePerfJITEventListener();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeTransformUtils", ExactSpelling = true)]
        public static extern void InitializeTransformUtils([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeScalarOpts", ExactSpelling = true)]
        public static extern void InitializeScalarOpts([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeObjCARCOpts", ExactSpelling = true)]
        public static extern void InitializeObjCARCOpts([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeVectorization", ExactSpelling = true)]
        public static extern void InitializeVectorization([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeInstCombine", ExactSpelling = true)]
        public static extern void InitializeInstCombine([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAggressiveInstCombiner", ExactSpelling = true)]
        public static extern void InitializeAggressiveInstCombiner([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeIPO", ExactSpelling = true)]
        public static extern void InitializeIPO([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeInstrumentation", ExactSpelling = true)]
        public static extern void InitializeInstrumentation([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAnalysis", ExactSpelling = true)]
        public static extern void InitializeAnalysis([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeIPA", ExactSpelling = true)]
        public static extern void InitializeIPA([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeCodeGen", ExactSpelling = true)]
        public static extern void InitializeCodeGen([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeTarget", ExactSpelling = true)]
        public static extern void InitializeTarget([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMParseIRInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ParseIRInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* ContextRef, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutM, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMLinkModules2", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int LinkModules2([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Dest, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Src);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("llvm_lto_t")]
        public static extern void* llvm_create_optimizer();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void llvm_destroy_optimizer([NativeTypeName("llvm_lto_t")] void* lto);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("llvm_lto_status_t")]
        public static extern llvm_lto_status llvm_read_object_file([NativeTypeName("llvm_lto_t")] void* lto, [NativeTypeName("const char *")] sbyte* input_filename);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("llvm_lto_status_t")]
        public static extern llvm_lto_status llvm_optimize_modules([NativeTypeName("llvm_lto_t")] void* lto, [NativeTypeName("const char *")] sbyte* output_filename);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lto_get_version();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lto_get_error_message();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_module_is_object_file([NativeTypeName("const char *")] sbyte* path);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_module_is_object_file_for_target([NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const char *")] sbyte* target_triple_prefix);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_module_has_objc_category([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_module_is_object_file_in_memory([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_module_is_object_file_in_memory_for_target([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length, [NativeTypeName("const char *")] sbyte* target_triple_prefix);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create([NativeTypeName("const char *")] sbyte* path);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_from_memory([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_from_memory_with_path([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length, [NativeTypeName("const char *")] sbyte* path);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_in_local_context([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length, [NativeTypeName("const char *")] sbyte* path);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_in_codegen_context([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_from_fd(int fd, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("size_t")] UIntPtr file_size);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_from_fd_at_offset(int fd, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("size_t")] UIntPtr file_size, [NativeTypeName("size_t")] UIntPtr map_size, [NativeTypeName("off_t")] int offset);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_module_dispose([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lto_module_get_target_triple([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_module_set_target_triple([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod, [NativeTypeName("const char *")] sbyte* triple);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint lto_module_get_num_symbols([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lto_module_get_symbol_name([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod, [NativeTypeName("unsigned int")] uint index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern lto_symbol_attributes lto_module_get_symbol_attribute([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod, [NativeTypeName("unsigned int")] uint index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lto_module_get_linkeropts([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_module_get_macho_cputype([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod, [NativeTypeName("unsigned int *")] uint* out_cputype, [NativeTypeName("unsigned int *")] uint* out_cpusubtype);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_codegen_set_diagnostic_handler([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* param0, [NativeTypeName("lto_diagnostic_handler_t")] IntPtr param1, [NativeTypeName("void *")] void* param2);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_code_gen_t")]
        public static extern LLVMOpaqueLTOCodeGenerator* lto_codegen_create();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_code_gen_t")]
        public static extern LLVMOpaqueLTOCodeGenerator* lto_codegen_create_in_local_context();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_codegen_dispose([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* param0);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_codegen_add_module([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_codegen_set_module([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_codegen_set_debug_model([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, lto_debug_model param1);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_codegen_set_pic_model([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, lto_codegen_model param1);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_codegen_set_cpu([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* cpu);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_codegen_set_assembler_path([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* path);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_codegen_set_assembler_args([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char **")] sbyte** args, int nargs);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_codegen_add_must_preserve_symbol([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* symbol);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_codegen_write_merged_modules([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* path);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* lto_codegen_compile([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("size_t *")] UIntPtr* length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_codegen_compile_to_file([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char **")] sbyte** name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_codegen_optimize([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const void *")]
        public static extern void* lto_codegen_compile_optimized([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("size_t *")] UIntPtr* length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint lto_api_version();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_codegen_debug_options([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* param1);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_codegen_debug_options_array([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char *const *")] sbyte** param1, int number);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_initialize_disassembler();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_codegen_set_should_internalize([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("lto_bool_t")] byte ShouldInternalize);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_codegen_set_should_embed_uselists([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("lto_bool_t")] byte ShouldEmbedUselists);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_input_t")]
        public static extern LLVMOpaqueLTOInput* lto_input_create([NativeTypeName("const void *")] void* buffer, [NativeTypeName("size_t")] UIntPtr buffer_size, [NativeTypeName("const char *")] sbyte* path);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void lto_input_dispose([NativeTypeName("lto_input_t")] LLVMOpaqueLTOInput* input);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint lto_input_get_num_dependent_libraries([NativeTypeName("lto_input_t")] LLVMOpaqueLTOInput* input);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lto_input_get_dependent_library([NativeTypeName("lto_input_t")] LLVMOpaqueLTOInput* input, [NativeTypeName("size_t")] UIntPtr index, [NativeTypeName("size_t *")] UIntPtr* size);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *const *")]
        public static extern sbyte** lto_runtime_lib_symbols_list([NativeTypeName("size_t *")] UIntPtr* size);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("thinlto_code_gen_t")]
        public static extern LLVMOpaqueThinLTOCodeGenerator* thinlto_create_codegen();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_dispose([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_add_module([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* identifier, [NativeTypeName("const char *")] sbyte* data, int length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_process([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint thinlto_module_get_num_objects([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern LTOObjectBuffer thinlto_module_get_object([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint thinlto_module_get_num_object_files([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* thinlto_module_get_object_file([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint index);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte thinlto_codegen_set_pic_model([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, lto_codegen_model param1);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_set_savetemps_dir([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* save_temps_dir);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_set_generated_objects_dir([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* save_temps_dir);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_set_cpu([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* cpu);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_disable_codegen([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("lto_bool_t")] byte disable);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_set_codegen_only([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("lto_bool_t")] byte codegen_only);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_debug_options([NativeTypeName("const char *const *")] sbyte** options, int number);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern byte lto_module_is_thinlto([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_add_must_preserve_symbol([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* name, int length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_add_cross_referenced_symbol([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* name, int length);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_set_cache_dir([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* cache_dir);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_set_cache_pruning_interval([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, int interval);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_set_final_cache_size_relative_to_available_space([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint percentage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_set_cache_entry_expiration([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint expiration);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_set_cache_size_bytes([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint max_size_bytes);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_set_cache_size_megabytes([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint max_size_megabytes);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void thinlto_codegen_set_cache_size_files([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint max_size_files);

        [NativeTypeName("#define LTO_API_VERSION 27")]
        public const int LTO_API_VERSION = 27;

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateBinary", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBinaryRef")]
        public static extern LLVMOpaqueBinary* CreateBinary([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* Context, [NativeTypeName("char **")] sbyte** ErrorMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeBinary", ExactSpelling = true)]
        public static extern void DisposeBinary([NativeTypeName("LLVMBinaryRef")] LLVMOpaqueBinary* BR);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBinaryCopyMemoryBuffer", ExactSpelling = true)]
        [return: NativeTypeName("LLVMMemoryBufferRef")]
        public static extern LLVMOpaqueMemoryBuffer* BinaryCopyMemoryBuffer([NativeTypeName("LLVMBinaryRef")] LLVMOpaqueBinary* BR);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMBinaryGetType", ExactSpelling = true)]
        public static extern LLVMBinaryType BinaryGetType([NativeTypeName("LLVMBinaryRef")] LLVMOpaqueBinary* BR);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMachOUniversalBinaryCopyObjectForArch", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBinaryRef")]
        public static extern LLVMOpaqueBinary* MachOUniversalBinaryCopyObjectForArch([NativeTypeName("LLVMBinaryRef")] LLVMOpaqueBinary* BR, [NativeTypeName("const char *")] sbyte* Arch, [NativeTypeName("size_t")] UIntPtr ArchLen, [NativeTypeName("char **")] sbyte** ErrorMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMObjectFileCopySectionIterator", ExactSpelling = true)]
        [return: NativeTypeName("LLVMSectionIteratorRef")]
        public static extern LLVMOpaqueSectionIterator* ObjectFileCopySectionIterator([NativeTypeName("LLVMBinaryRef")] LLVMOpaqueBinary* BR);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMObjectFileIsSectionIteratorAtEnd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ObjectFileIsSectionIteratorAtEnd([NativeTypeName("LLVMBinaryRef")] LLVMOpaqueBinary* BR, [NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMObjectFileCopySymbolIterator", ExactSpelling = true)]
        [return: NativeTypeName("LLVMSymbolIteratorRef")]
        public static extern LLVMOpaqueSymbolIterator* ObjectFileCopySymbolIterator([NativeTypeName("LLVMBinaryRef")] LLVMOpaqueBinary* BR);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMObjectFileIsSymbolIteratorAtEnd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ObjectFileIsSymbolIteratorAtEnd([NativeTypeName("LLVMBinaryRef")] LLVMOpaqueBinary* BR, [NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeSectionIterator", ExactSpelling = true)]
        public static extern void DisposeSectionIterator([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMoveToNextSection", ExactSpelling = true)]
        public static extern void MoveToNextSection([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMoveToContainingSection", ExactSpelling = true)]
        public static extern void MoveToContainingSection([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* Sect, [NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* Sym);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeSymbolIterator", ExactSpelling = true)]
        public static extern void DisposeSymbolIterator([NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMoveToNextSymbol", ExactSpelling = true)]
        public static extern void MoveToNextSymbol([NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSectionName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetSectionName([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSectionSize", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetSectionSize([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSectionContents", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetSectionContents([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSectionAddress", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetSectionAddress([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSectionContainsSymbol", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetSectionContainsSymbol([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI, [NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* Sym);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetRelocations", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRelocationIteratorRef")]
        public static extern LLVMOpaqueRelocationIterator* GetRelocations([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* Section);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeRelocationIterator", ExactSpelling = true)]
        public static extern void DisposeRelocationIterator([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsRelocationIteratorAtEnd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsRelocationIteratorAtEnd([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* Section, [NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMMoveToNextRelocation", ExactSpelling = true)]
        public static extern void MoveToNextRelocation([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSymbolName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetSymbolName([NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSymbolAddress", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetSymbolAddress([NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSymbolSize", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetSymbolSize([NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetRelocationOffset", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetRelocationOffset([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetRelocationSymbol", ExactSpelling = true)]
        [return: NativeTypeName("LLVMSymbolIteratorRef")]
        public static extern LLVMOpaqueSymbolIterator* GetRelocationSymbol([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetRelocationType", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetRelocationType([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetRelocationTypeName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetRelocationTypeName([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetRelocationValueString", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetRelocationValueString([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateObjectFile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMObjectFileRef")]
        public static extern LLVMOpaqueObjectFile* CreateObjectFile([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeObjectFile", ExactSpelling = true)]
        public static extern void DisposeObjectFile([NativeTypeName("LLVMObjectFileRef")] LLVMOpaqueObjectFile* ObjectFile);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSections", ExactSpelling = true)]
        [return: NativeTypeName("LLVMSectionIteratorRef")]
        public static extern LLVMOpaqueSectionIterator* GetSections([NativeTypeName("LLVMObjectFileRef")] LLVMOpaqueObjectFile* ObjectFile);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsSectionIteratorAtEnd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsSectionIteratorAtEnd([NativeTypeName("LLVMObjectFileRef")] LLVMOpaqueObjectFile* ObjectFile, [NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetSymbols", ExactSpelling = true)]
        [return: NativeTypeName("LLVMSymbolIteratorRef")]
        public static extern LLVMOpaqueSymbolIterator* GetSymbols([NativeTypeName("LLVMObjectFileRef")] LLVMOpaqueObjectFile* ObjectFile);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIsSymbolIteratorAtEnd", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsSymbolIteratorAtEnd([NativeTypeName("LLVMObjectFileRef")] LLVMOpaqueObjectFile* ObjectFile, [NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcExecutionSessionIntern", ExactSpelling = true)]
        [return: NativeTypeName("LLVMOrcSymbolStringPoolEntryRef")]
        public static extern LLVMOrcQuaqueSymbolStringPoolEntryPtr* OrcExecutionSessionIntern([NativeTypeName("LLVMOrcExecutionSessionRef")] LLVMOrcOpaqueExecutionSession* ES, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcReleaseSymbolStringPoolEntry", ExactSpelling = true)]
        public static extern void OrcReleaseSymbolStringPoolEntry([NativeTypeName("LLVMOrcSymbolStringPoolEntryRef")] LLVMOrcQuaqueSymbolStringPoolEntryPtr* S);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcDisposeJITDylibDefinitionGenerator", ExactSpelling = true)]
        public static extern void OrcDisposeJITDylibDefinitionGenerator([NativeTypeName("LLVMOrcJITDylibDefinitionGeneratorRef")] LLVMOrcOpaqueJITDylibDefinitionGenerator* DG);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcJITDylibAddGenerator", ExactSpelling = true)]
        public static extern void OrcJITDylibAddGenerator([NativeTypeName("LLVMOrcJITDylibRef")] LLVMOrcOpaqueJITDylib* JD, [NativeTypeName("LLVMOrcJITDylibDefinitionGeneratorRef")] LLVMOrcOpaqueJITDylibDefinitionGenerator* DG);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcCreateDynamicLibrarySearchGeneratorForProcess", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcCreateDynamicLibrarySearchGeneratorForProcess([NativeTypeName("LLVMOrcJITDylibDefinitionGeneratorRef *")] LLVMOrcOpaqueJITDylibDefinitionGenerator** Result, [NativeTypeName("char")] sbyte GlobalPrefx, [NativeTypeName("LLVMOrcSymbolPredicate")] IntPtr Filter, [NativeTypeName("void *")] void* FilterCtx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcCreateNewThreadSafeContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMOrcThreadSafeContextRef")]
        public static extern LLVMOrcOpaqueThreadSafeContext* OrcCreateNewThreadSafeContext();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcThreadSafeContextGetContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMContextRef")]
        public static extern LLVMOpaqueContext* OrcThreadSafeContextGetContext([NativeTypeName("LLVMOrcThreadSafeContextRef")] LLVMOrcOpaqueThreadSafeContext* TSCtx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcDisposeThreadSafeContext", ExactSpelling = true)]
        public static extern void OrcDisposeThreadSafeContext([NativeTypeName("LLVMOrcThreadSafeContextRef")] LLVMOrcOpaqueThreadSafeContext* TSCtx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcCreateNewThreadSafeModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMOrcThreadSafeModuleRef")]
        public static extern LLVMOrcOpaqueThreadSafeModule* OrcCreateNewThreadSafeModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("LLVMOrcThreadSafeContextRef")] LLVMOrcOpaqueThreadSafeContext* TSCtx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcDisposeThreadSafeModule", ExactSpelling = true)]
        public static extern void OrcDisposeThreadSafeModule([NativeTypeName("LLVMOrcThreadSafeModuleRef")] LLVMOrcOpaqueThreadSafeModule* TSM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcJITTargetMachineBuilderDetectHost", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcJITTargetMachineBuilderDetectHost([NativeTypeName("LLVMOrcJITTargetMachineBuilderRef *")] LLVMOrcOpaqueJITTargetMachineBuilder** Result);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcJITTargetMachineBuilderCreateFromTargetMachine", ExactSpelling = true)]
        [return: NativeTypeName("LLVMOrcJITTargetMachineBuilderRef")]
        public static extern LLVMOrcOpaqueJITTargetMachineBuilder* OrcJITTargetMachineBuilderCreateFromTargetMachine([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* TM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcDisposeJITTargetMachineBuilder", ExactSpelling = true)]
        public static extern void OrcDisposeJITTargetMachineBuilder([NativeTypeName("LLVMOrcJITTargetMachineBuilderRef")] LLVMOrcOpaqueJITTargetMachineBuilder* JTMB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcCreateLLJITBuilder", ExactSpelling = true)]
        [return: NativeTypeName("LLVMOrcLLJITBuilderRef")]
        public static extern LLVMOrcOpaqueLLJITBuilder* OrcCreateLLJITBuilder();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcDisposeLLJITBuilder", ExactSpelling = true)]
        public static extern void OrcDisposeLLJITBuilder([NativeTypeName("LLVMOrcLLJITBuilderRef")] LLVMOrcOpaqueLLJITBuilder* Builder);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcLLJITBuilderSetJITTargetMachineBuilder", ExactSpelling = true)]
        public static extern void OrcLLJITBuilderSetJITTargetMachineBuilder([NativeTypeName("LLVMOrcLLJITBuilderRef")] LLVMOrcOpaqueLLJITBuilder* Builder, [NativeTypeName("LLVMOrcJITTargetMachineBuilderRef")] LLVMOrcOpaqueJITTargetMachineBuilder* JTMB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcCreateLLJIT", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcCreateLLJIT([NativeTypeName("LLVMOrcLLJITRef *")] LLVMOrcOpaqueLLJIT** Result, [NativeTypeName("LLVMOrcLLJITBuilderRef")] LLVMOrcOpaqueLLJITBuilder* Builder);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcDisposeLLJIT", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcDisposeLLJIT([NativeTypeName("LLVMOrcLLJITRef")] LLVMOrcOpaqueLLJIT* J);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcLLJITGetExecutionSession", ExactSpelling = true)]
        [return: NativeTypeName("LLVMOrcExecutionSessionRef")]
        public static extern LLVMOrcOpaqueExecutionSession* OrcLLJITGetExecutionSession([NativeTypeName("LLVMOrcLLJITRef")] LLVMOrcOpaqueLLJIT* J);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcLLJITGetMainJITDylib", ExactSpelling = true)]
        [return: NativeTypeName("LLVMOrcJITDylibRef")]
        public static extern LLVMOrcOpaqueJITDylib* OrcLLJITGetMainJITDylib([NativeTypeName("LLVMOrcLLJITRef")] LLVMOrcOpaqueLLJIT* J);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcLLJITGetTripleString", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* OrcLLJITGetTripleString([NativeTypeName("LLVMOrcLLJITRef")] LLVMOrcOpaqueLLJIT* J);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcLLJITGetGlobalPrefix", ExactSpelling = true)]
        [return: NativeTypeName("char")]
        public static extern sbyte OrcLLJITGetGlobalPrefix([NativeTypeName("LLVMOrcLLJITRef")] LLVMOrcOpaqueLLJIT* J);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcLLJITMangleAndIntern", ExactSpelling = true)]
        [return: NativeTypeName("LLVMOrcSymbolStringPoolEntryRef")]
        public static extern LLVMOrcQuaqueSymbolStringPoolEntryPtr* OrcLLJITMangleAndIntern([NativeTypeName("LLVMOrcLLJITRef")] LLVMOrcOpaqueLLJIT* J, [NativeTypeName("const char *")] sbyte* UnmangledName);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcLLJITAddObjectFile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcLLJITAddObjectFile([NativeTypeName("LLVMOrcLLJITRef")] LLVMOrcOpaqueLLJIT* J, [NativeTypeName("LLVMOrcJITDylibRef")] LLVMOrcOpaqueJITDylib* JD, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* ObjBuffer);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcLLJITAddLLVMIRModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcLLJITAddLLVMIRModule([NativeTypeName("LLVMOrcLLJITRef")] LLVMOrcOpaqueLLJIT* J, [NativeTypeName("LLVMOrcJITDylibRef")] LLVMOrcOpaqueJITDylib* JD, [NativeTypeName("LLVMOrcThreadSafeModuleRef")] LLVMOrcOpaqueThreadSafeModule* TSM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcLLJITLookup", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcLLJITLookup([NativeTypeName("LLVMOrcLLJITRef")] LLVMOrcOpaqueLLJIT* J, [NativeTypeName("LLVMOrcJITTargetAddress *")] ulong* Result, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcCreateInstance", ExactSpelling = true)]
        [return: NativeTypeName("LLVMOrcJITStackRef")]
        public static extern LLVMOrcOpaqueJITStack* OrcCreateInstance([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* TM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcGetErrorMsg", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* OrcGetErrorMsg([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcGetMangledSymbol", ExactSpelling = true)]
        public static extern void OrcGetMangledSymbol([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("char **")] sbyte** MangledSymbol, [NativeTypeName("const char *")] sbyte* Symbol);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcDisposeMangledSymbol", ExactSpelling = true)]
        public static extern void OrcDisposeMangledSymbol([NativeTypeName("char *")] sbyte* MangledSymbol);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcCreateLazyCompileCallback", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcCreateLazyCompileCallback([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcTargetAddress *")] ulong* RetAddr, [NativeTypeName("LLVMOrcLazyCompileCallbackFn")] IntPtr Callback, [NativeTypeName("void *")] void* CallbackCtx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcCreateIndirectStub", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcCreateIndirectStub([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("const char *")] sbyte* StubName, [NativeTypeName("LLVMOrcTargetAddress")] ulong InitAddr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcSetIndirectStubPointer", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcSetIndirectStubPointer([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("const char *")] sbyte* StubName, [NativeTypeName("LLVMOrcTargetAddress")] ulong NewAddr);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcAddEagerlyCompiledIR", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcAddEagerlyCompiledIR([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcModuleHandle *")] ulong* RetHandle, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Mod, [NativeTypeName("LLVMOrcSymbolResolverFn")] IntPtr SymbolResolver, [NativeTypeName("void *")] void* SymbolResolverCtx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcAddLazilyCompiledIR", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcAddLazilyCompiledIR([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcModuleHandle *")] ulong* RetHandle, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Mod, [NativeTypeName("LLVMOrcSymbolResolverFn")] IntPtr SymbolResolver, [NativeTypeName("void *")] void* SymbolResolverCtx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcAddObjectFile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcAddObjectFile([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcModuleHandle *")] ulong* RetHandle, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* Obj, [NativeTypeName("LLVMOrcSymbolResolverFn")] IntPtr SymbolResolver, [NativeTypeName("void *")] void* SymbolResolverCtx);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcRemoveModule", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcRemoveModule([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcModuleHandle")] ulong H);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcGetSymbolAddress", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcGetSymbolAddress([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcTargetAddress *")] ulong* RetAddr, [NativeTypeName("const char *")] sbyte* SymbolName);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcGetSymbolAddressIn", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcGetSymbolAddressIn([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcTargetAddress *")] ulong* RetAddr, [NativeTypeName("LLVMOrcModuleHandle")] ulong H, [NativeTypeName("const char *")] sbyte* SymbolName);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcDisposeInstance", ExactSpelling = true)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcDisposeInstance([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcRegisterJITEventListener", ExactSpelling = true)]
        public static extern void OrcRegisterJITEventListener([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMJITEventListenerRef")] LLVMOpaqueJITEventListener* L);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOrcUnregisterJITEventListener", ExactSpelling = true)]
        public static extern void OrcUnregisterJITEventListener([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMJITEventListenerRef")] LLVMOpaqueJITEventListener* L);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkStringGetData", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* RemarkStringGetData([NativeTypeName("LLVMRemarkStringRef")] LLVMRemarkOpaqueString* String);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkStringGetLen", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint RemarkStringGetLen([NativeTypeName("LLVMRemarkStringRef")] LLVMRemarkOpaqueString* String);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkDebugLocGetSourceFilePath", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkStringRef")]
        public static extern LLVMRemarkOpaqueString* RemarkDebugLocGetSourceFilePath([NativeTypeName("LLVMRemarkDebugLocRef")] LLVMRemarkOpaqueDebugLoc* DL);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkDebugLocGetSourceLine", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint RemarkDebugLocGetSourceLine([NativeTypeName("LLVMRemarkDebugLocRef")] LLVMRemarkOpaqueDebugLoc* DL);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkDebugLocGetSourceColumn", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint RemarkDebugLocGetSourceColumn([NativeTypeName("LLVMRemarkDebugLocRef")] LLVMRemarkOpaqueDebugLoc* DL);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkArgGetKey", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkStringRef")]
        public static extern LLVMRemarkOpaqueString* RemarkArgGetKey([NativeTypeName("LLVMRemarkArgRef")] LLVMRemarkOpaqueArg* Arg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkArgGetValue", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkStringRef")]
        public static extern LLVMRemarkOpaqueString* RemarkArgGetValue([NativeTypeName("LLVMRemarkArgRef")] LLVMRemarkOpaqueArg* Arg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkArgGetDebugLoc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkDebugLocRef")]
        public static extern LLVMRemarkOpaqueDebugLoc* RemarkArgGetDebugLoc([NativeTypeName("LLVMRemarkArgRef")] LLVMRemarkOpaqueArg* Arg);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkEntryDispose", ExactSpelling = true)]
        public static extern void RemarkEntryDispose([NativeTypeName("LLVMRemarkEntryRef")] LLVMRemarkOpaqueEntry* Remark);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkEntryGetType", ExactSpelling = true)]
        [return: NativeTypeName("enum LLVMRemarkType")]
        public static extern LLVMRemarkType RemarkEntryGetType([NativeTypeName("LLVMRemarkEntryRef")] LLVMRemarkOpaqueEntry* Remark);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkEntryGetPassName", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkStringRef")]
        public static extern LLVMRemarkOpaqueString* RemarkEntryGetPassName([NativeTypeName("LLVMRemarkEntryRef")] LLVMRemarkOpaqueEntry* Remark);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkEntryGetRemarkName", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkStringRef")]
        public static extern LLVMRemarkOpaqueString* RemarkEntryGetRemarkName([NativeTypeName("LLVMRemarkEntryRef")] LLVMRemarkOpaqueEntry* Remark);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkEntryGetFunctionName", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkStringRef")]
        public static extern LLVMRemarkOpaqueString* RemarkEntryGetFunctionName([NativeTypeName("LLVMRemarkEntryRef")] LLVMRemarkOpaqueEntry* Remark);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkEntryGetDebugLoc", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkDebugLocRef")]
        public static extern LLVMRemarkOpaqueDebugLoc* RemarkEntryGetDebugLoc([NativeTypeName("LLVMRemarkEntryRef")] LLVMRemarkOpaqueEntry* Remark);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkEntryGetHotness", ExactSpelling = true)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong RemarkEntryGetHotness([NativeTypeName("LLVMRemarkEntryRef")] LLVMRemarkOpaqueEntry* Remark);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkEntryGetNumArgs", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint RemarkEntryGetNumArgs([NativeTypeName("LLVMRemarkEntryRef")] LLVMRemarkOpaqueEntry* Remark);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkEntryGetFirstArg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkArgRef")]
        public static extern LLVMRemarkOpaqueArg* RemarkEntryGetFirstArg([NativeTypeName("LLVMRemarkEntryRef")] LLVMRemarkOpaqueEntry* Remark);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkEntryGetNextArg", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkArgRef")]
        public static extern LLVMRemarkOpaqueArg* RemarkEntryGetNextArg([NativeTypeName("LLVMRemarkArgRef")] LLVMRemarkOpaqueArg* It, [NativeTypeName("LLVMRemarkEntryRef")] LLVMRemarkOpaqueEntry* Remark);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkParserCreateYAML", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkParserRef")]
        public static extern LLVMRemarkOpaqueParser* RemarkParserCreateYAML([NativeTypeName("const void *")] void* Buf, [NativeTypeName("uint64_t")] ulong Size);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkParserCreateBitstream", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkParserRef")]
        public static extern LLVMRemarkOpaqueParser* RemarkParserCreateBitstream([NativeTypeName("const void *")] void* Buf, [NativeTypeName("uint64_t")] ulong Size);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkParserGetNext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMRemarkEntryRef")]
        public static extern LLVMRemarkOpaqueEntry* RemarkParserGetNext([NativeTypeName("LLVMRemarkParserRef")] LLVMRemarkOpaqueParser* Parser);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkParserHasError", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int RemarkParserHasError([NativeTypeName("LLVMRemarkParserRef")] LLVMRemarkOpaqueParser* Parser);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkParserGetErrorMessage", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* RemarkParserGetErrorMessage([NativeTypeName("LLVMRemarkParserRef")] LLVMRemarkOpaqueParser* Parser);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkParserDispose", ExactSpelling = true)]
        public static extern void RemarkParserDispose([NativeTypeName("LLVMRemarkParserRef")] LLVMRemarkOpaqueParser* Parser);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMRemarkVersion", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint RemarkVersion();

        [NativeTypeName("#define REMARKS_API_VERSION 1")]
        public const int REMARKS_API_VERSION = 1;

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMLoadLibraryPermanently", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int LoadLibraryPermanently([NativeTypeName("const char *")] sbyte* Filename);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMParseCommandLineOptions", ExactSpelling = true)]
        public static extern void ParseCommandLineOptions(int argc, [NativeTypeName("const char *const *")] sbyte** argv, [NativeTypeName("const char *")] sbyte* Overview);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSearchForAddressOfSymbol", ExactSpelling = true)]
        [return: NativeTypeName("void *")]
        public static extern void* SearchForAddressOfSymbol([NativeTypeName("const char *")] sbyte* symbolName);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddSymbol", ExactSpelling = true)]
        public static extern void AddSymbol([NativeTypeName("const char *")] sbyte* symbolName, [NativeTypeName("void *")] void* symbolValue);

        public static void InitializeAllTargetInfos()
        {
            InitializeAArch64TargetInfo();
            InitializeAMDGPUTargetInfo();
            InitializeARMTargetInfo();
            InitializeAVRTargetInfo();
            InitializeBPFTargetInfo();
            InitializeHexagonTargetInfo();
            InitializeLanaiTargetInfo();
            InitializeMipsTargetInfo();
            InitializeMSP430TargetInfo();
            InitializeNVPTXTargetInfo();
            InitializePowerPCTargetInfo();
            InitializeRISCVTargetInfo();
            InitializeSparcTargetInfo();
            InitializeSystemZTargetInfo();
            InitializeWebAssemblyTargetInfo();
            InitializeX86TargetInfo();
            InitializeXCoreTargetInfo();
        }

        public static void InitializeAllTargets()
        {
            InitializeAArch64Target();
            InitializeAMDGPUTarget();
            InitializeARMTarget();
            InitializeAVRTarget();
            InitializeBPFTarget();
            InitializeHexagonTarget();
            InitializeLanaiTarget();
            InitializeMipsTarget();
            InitializeMSP430Target();
            InitializeNVPTXTarget();
            InitializePowerPCTarget();
            InitializeRISCVTarget();
            InitializeSparcTarget();
            InitializeSystemZTarget();
            InitializeWebAssemblyTarget();
            InitializeX86Target();
            InitializeXCoreTarget();
        }

        public static void InitializeAllTargetMCs()
        {
            InitializeAArch64TargetMC();
            InitializeAMDGPUTargetMC();
            InitializeARMTargetMC();
            InitializeAVRTargetMC();
            InitializeBPFTargetMC();
            InitializeHexagonTargetMC();
            InitializeLanaiTargetMC();
            InitializeMipsTargetMC();
            InitializeMSP430TargetMC();
            InitializeNVPTXTargetMC();
            InitializePowerPCTargetMC();
            InitializeRISCVTargetMC();
            InitializeSparcTargetMC();
            InitializeSystemZTargetMC();
            InitializeWebAssemblyTargetMC();
            InitializeX86TargetMC();
            InitializeXCoreTargetMC();
        }

        public static void InitializeAllAsmPrinters()
        {
            InitializeAArch64AsmPrinter();
            InitializeAMDGPUAsmPrinter();
            InitializeARMAsmPrinter();
            InitializeAVRAsmPrinter();
            InitializeBPFAsmPrinter();
            InitializeHexagonAsmPrinter();
            InitializeLanaiAsmPrinter();
            InitializeMipsAsmPrinter();
            InitializeMSP430AsmPrinter();
            InitializeNVPTXAsmPrinter();
            InitializePowerPCAsmPrinter();
            InitializeRISCVAsmPrinter();
            InitializeSparcAsmPrinter();
            InitializeSystemZAsmPrinter();
            InitializeWebAssemblyAsmPrinter();
            InitializeX86AsmPrinter();
            InitializeXCoreAsmPrinter();
        }

        public static void InitializeAllAsmParsers()
        {
            InitializeAArch64AsmParser();
            InitializeAMDGPUAsmParser();
            InitializeARMAsmParser();
            InitializeAVRAsmParser();
            InitializeBPFAsmParser();
            InitializeHexagonAsmParser();
            InitializeLanaiAsmParser();
            InitializeMipsAsmParser();
            InitializeMSP430AsmParser();
            InitializePowerPCAsmParser();
            InitializeRISCVAsmParser();
            InitializeSparcAsmParser();
            InitializeSystemZAsmParser();
            InitializeWebAssemblyAsmParser();
            InitializeX86AsmParser();
        }

        public static void InitializeAllDisassemblers()
        {
            InitializeAArch64Disassembler();
            InitializeAMDGPUDisassembler();
            InitializeARMDisassembler();
            InitializeAVRDisassembler();
            InitializeBPFDisassembler();
            InitializeHexagonDisassembler();
            InitializeLanaiDisassembler();
            InitializeMipsDisassembler();
            InitializeMSP430Disassembler();
            InitializePowerPCDisassembler();
            InitializeRISCVDisassembler();
            InitializeSparcDisassembler();
            InitializeSystemZDisassembler();
            InitializeWebAssemblyDisassembler();
            InitializeX86Disassembler();
            InitializeXCoreDisassembler();
        }

        [return: NativeTypeName("LLVMBool")]
        public static int InitializeNativeTarget()
        {
            InitializeX86TargetInfo();
            InitializeX86Target();
            InitializeX86TargetMC();
            return 0;
        }

        [return: NativeTypeName("LLVMBool")]
        public static int InitializeNativeAsmParser()
        {
            InitializeX86AsmParser();
            return 0;
        }

        [return: NativeTypeName("LLVMBool")]
        public static int InitializeNativeAsmPrinter()
        {
            InitializeX86AsmPrinter();
            return 0;
        }

        [return: NativeTypeName("LLVMBool")]
        public static int InitializeNativeDisassembler()
        {
            InitializeX86Disassembler();
            return 0;
        }

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetModuleDataLayout", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTargetDataRef")]
        public static extern LLVMOpaqueTargetData* GetModuleDataLayout([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetModuleDataLayout", ExactSpelling = true)]
        public static extern void SetModuleDataLayout([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* DL);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateTargetData", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTargetDataRef")]
        public static extern LLVMOpaqueTargetData* CreateTargetData([NativeTypeName("const char *")] sbyte* StringRep);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeTargetData", ExactSpelling = true)]
        public static extern void DisposeTargetData([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddTargetLibraryInfo", ExactSpelling = true)]
        public static extern void AddTargetLibraryInfo([NativeTypeName("LLVMTargetLibraryInfoRef")] LLVMOpaqueTargetLibraryInfotData* TLI, [NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCopyStringRepOfTargetData", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* CopyStringRepOfTargetData([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMByteOrder", ExactSpelling = true)]
        [return: NativeTypeName("enum LLVMByteOrdering")]
        public static extern LLVMByteOrdering ByteOrder([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPointerSize", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint PointerSize([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPointerSizeForAS", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint PointerSizeForAS([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("unsigned int")] uint AS);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIntPtrType", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntPtrType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIntPtrTypeForAS", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntPtrTypeForAS([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("unsigned int")] uint AS);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIntPtrTypeInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntPtrTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMIntPtrTypeForASInContext", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntPtrTypeForASInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("unsigned int")] uint AS);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSizeOfTypeInBits", ExactSpelling = true)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong SizeOfTypeInBits([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMStoreSizeOfType", ExactSpelling = true)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong StoreSizeOfType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMABISizeOfType", ExactSpelling = true)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong ABISizeOfType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMABIAlignmentOfType", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint ABIAlignmentOfType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCallFrameAlignmentOfType", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CallFrameAlignmentOfType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPreferredAlignmentOfType", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint PreferredAlignmentOfType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPreferredAlignmentOfGlobal", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint PreferredAlignmentOfGlobal([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMElementAtOffset", ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint ElementAtOffset([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("unsigned long long")] ulong Offset);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMOffsetOfElement", ExactSpelling = true)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong OffsetOfElement([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("unsigned int")] uint Element);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetFirstTarget", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTargetRef")]
        public static extern LLVMTarget* GetFirstTarget();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetNextTarget", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTargetRef")]
        public static extern LLVMTarget* GetNextTarget([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTargetFromName", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTargetRef")]
        public static extern LLVMTarget* GetTargetFromName([NativeTypeName("const char *")] sbyte* Name);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTargetFromTriple", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetTargetFromTriple([NativeTypeName("const char *")] sbyte* Triple, [NativeTypeName("LLVMTargetRef *")] LLVMTarget** T, [NativeTypeName("char **")] sbyte** ErrorMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTargetName", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetTargetName([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTargetDescription", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetTargetDescription([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMTargetHasJIT", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TargetHasJIT([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMTargetHasTargetMachine", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TargetHasTargetMachine([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMTargetHasAsmBackend", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TargetHasAsmBackend([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateTargetMachine", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTargetMachineRef")]
        public static extern LLVMOpaqueTargetMachine* CreateTargetMachine([NativeTypeName("LLVMTargetRef")] LLVMTarget* T, [NativeTypeName("const char *")] sbyte* Triple, [NativeTypeName("const char *")] sbyte* CPU, [NativeTypeName("const char *")] sbyte* Features, LLVMCodeGenOptLevel Level, LLVMRelocMode Reloc, LLVMCodeModel CodeModel);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMDisposeTargetMachine", ExactSpelling = true)]
        public static extern void DisposeTargetMachine([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTargetMachineTarget", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTargetRef")]
        public static extern LLVMTarget* GetTargetMachineTarget([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTargetMachineTriple", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetTargetMachineTriple([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTargetMachineCPU", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetTargetMachineCPU([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetTargetMachineFeatureString", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetTargetMachineFeatureString([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMCreateTargetDataLayout", ExactSpelling = true)]
        [return: NativeTypeName("LLVMTargetDataRef")]
        public static extern LLVMOpaqueTargetData* CreateTargetDataLayout([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMSetTargetMachineAsmVerbosity", ExactSpelling = true)]
        public static extern void SetTargetMachineAsmVerbosity([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T, [NativeTypeName("LLVMBool")] int VerboseAsm);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMTargetMachineEmitToFile", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TargetMachineEmitToFile([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("char *")] sbyte* Filename, LLVMCodeGenFileType codegen, [NativeTypeName("char **")] sbyte** ErrorMessage);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMTargetMachineEmitToMemoryBuffer", ExactSpelling = true)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TargetMachineEmitToMemoryBuffer([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, LLVMCodeGenFileType codegen, [NativeTypeName("char **")] sbyte** ErrorMessage, [NativeTypeName("LLVMMemoryBufferRef *")] LLVMOpaqueMemoryBuffer** OutMemBuf);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetDefaultTargetTriple", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetDefaultTargetTriple();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMNormalizeTargetTriple", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* NormalizeTargetTriple([NativeTypeName("const char *")] sbyte* triple);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetHostCPUName", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetHostCPUName();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMGetHostCPUFeatures", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetHostCPUFeatures();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddAnalysisPasses", ExactSpelling = true)]
        public static extern void AddAnalysisPasses([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T, [NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddAggressiveInstCombinerPass", ExactSpelling = true)]
        public static extern void AddAggressiveInstCombinerPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddCoroEarlyPass", ExactSpelling = true)]
        public static extern void AddCoroEarlyPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddCoroSplitPass", ExactSpelling = true)]
        public static extern void AddCoroSplitPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddCoroElidePass", ExactSpelling = true)]
        public static extern void AddCoroElidePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddCoroCleanupPass", ExactSpelling = true)]
        public static extern void AddCoroCleanupPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderAddCoroutinePassesToExtensionPoints", ExactSpelling = true)]
        public static extern void PassManagerBuilderAddCoroutinePassesToExtensionPoints([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddInstructionCombiningPass", ExactSpelling = true)]
        public static extern void AddInstructionCombiningPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddArgumentPromotionPass", ExactSpelling = true)]
        public static extern void AddArgumentPromotionPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddConstantMergePass", ExactSpelling = true)]
        public static extern void AddConstantMergePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddMergeFunctionsPass", ExactSpelling = true)]
        public static extern void AddMergeFunctionsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddCalledValuePropagationPass", ExactSpelling = true)]
        public static extern void AddCalledValuePropagationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddDeadArgEliminationPass", ExactSpelling = true)]
        public static extern void AddDeadArgEliminationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddFunctionAttrsPass", ExactSpelling = true)]
        public static extern void AddFunctionAttrsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddFunctionInliningPass", ExactSpelling = true)]
        public static extern void AddFunctionInliningPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddAlwaysInlinerPass", ExactSpelling = true)]
        public static extern void AddAlwaysInlinerPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddGlobalDCEPass", ExactSpelling = true)]
        public static extern void AddGlobalDCEPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddGlobalOptimizerPass", ExactSpelling = true)]
        public static extern void AddGlobalOptimizerPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddIPConstantPropagationPass", ExactSpelling = true)]
        public static extern void AddIPConstantPropagationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddPruneEHPass", ExactSpelling = true)]
        public static extern void AddPruneEHPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddIPSCCPPass", ExactSpelling = true)]
        public static extern void AddIPSCCPPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddInternalizePass", ExactSpelling = true)]
        public static extern void AddInternalizePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* param0, [NativeTypeName("unsigned int")] uint AllButMain);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddInternalizePassWithMustPreservePredicate", ExactSpelling = true)]
        public static extern void AddInternalizePassWithMustPreservePredicate([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM, [NativeTypeName("void *")] void* Context, [NativeTypeName("LLVMBool (*)(LLVMValueRef, void *)")] IntPtr MustPreserve);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddStripDeadPrototypesPass", ExactSpelling = true)]
        public static extern void AddStripDeadPrototypesPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddStripSymbolsPass", ExactSpelling = true)]
        public static extern void AddStripSymbolsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderCreate", ExactSpelling = true)]
        [return: NativeTypeName("LLVMPassManagerBuilderRef")]
        public static extern LLVMOpaquePassManagerBuilder* PassManagerBuilderCreate();

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderDispose", ExactSpelling = true)]
        public static extern void PassManagerBuilderDispose([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderSetOptLevel", ExactSpelling = true)]
        public static extern void PassManagerBuilderSetOptLevel([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("unsigned int")] uint OptLevel);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderSetSizeLevel", ExactSpelling = true)]
        public static extern void PassManagerBuilderSetSizeLevel([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("unsigned int")] uint SizeLevel);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderSetDisableUnitAtATime", ExactSpelling = true)]
        public static extern void PassManagerBuilderSetDisableUnitAtATime([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMBool")] int Value);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderSetDisableUnrollLoops", ExactSpelling = true)]
        public static extern void PassManagerBuilderSetDisableUnrollLoops([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMBool")] int Value);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderSetDisableSimplifyLibCalls", ExactSpelling = true)]
        public static extern void PassManagerBuilderSetDisableSimplifyLibCalls([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMBool")] int Value);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderUseInlinerWithThreshold", ExactSpelling = true)]
        public static extern void PassManagerBuilderUseInlinerWithThreshold([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("unsigned int")] uint Threshold);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderPopulateFunctionPassManager", ExactSpelling = true)]
        public static extern void PassManagerBuilderPopulateFunctionPassManager([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderPopulateModulePassManager", ExactSpelling = true)]
        public static extern void PassManagerBuilderPopulateModulePassManager([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMPassManagerBuilderPopulateLTOPassManager", ExactSpelling = true)]
        public static extern void PassManagerBuilderPopulateLTOPassManager([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM, [NativeTypeName("LLVMBool")] int Internalize, [NativeTypeName("LLVMBool")] int RunInliner);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddAggressiveDCEPass", ExactSpelling = true)]
        public static extern void AddAggressiveDCEPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddDCEPass", ExactSpelling = true)]
        public static extern void AddDCEPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddBitTrackingDCEPass", ExactSpelling = true)]
        public static extern void AddBitTrackingDCEPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddAlignmentFromAssumptionsPass", ExactSpelling = true)]
        public static extern void AddAlignmentFromAssumptionsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddCFGSimplificationPass", ExactSpelling = true)]
        public static extern void AddCFGSimplificationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddDeadStoreEliminationPass", ExactSpelling = true)]
        public static extern void AddDeadStoreEliminationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddScalarizerPass", ExactSpelling = true)]
        public static extern void AddScalarizerPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddMergedLoadStoreMotionPass", ExactSpelling = true)]
        public static extern void AddMergedLoadStoreMotionPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddGVNPass", ExactSpelling = true)]
        public static extern void AddGVNPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddNewGVNPass", ExactSpelling = true)]
        public static extern void AddNewGVNPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddIndVarSimplifyPass", ExactSpelling = true)]
        public static extern void AddIndVarSimplifyPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddJumpThreadingPass", ExactSpelling = true)]
        public static extern void AddJumpThreadingPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLICMPass", ExactSpelling = true)]
        public static extern void AddLICMPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLoopDeletionPass", ExactSpelling = true)]
        public static extern void AddLoopDeletionPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLoopIdiomPass", ExactSpelling = true)]
        public static extern void AddLoopIdiomPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLoopRotatePass", ExactSpelling = true)]
        public static extern void AddLoopRotatePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLoopRerollPass", ExactSpelling = true)]
        public static extern void AddLoopRerollPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLoopUnrollPass", ExactSpelling = true)]
        public static extern void AddLoopUnrollPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLoopUnrollAndJamPass", ExactSpelling = true)]
        public static extern void AddLoopUnrollAndJamPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLoopUnswitchPass", ExactSpelling = true)]
        public static extern void AddLoopUnswitchPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLowerAtomicPass", ExactSpelling = true)]
        public static extern void AddLowerAtomicPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddMemCpyOptPass", ExactSpelling = true)]
        public static extern void AddMemCpyOptPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddPartiallyInlineLibCallsPass", ExactSpelling = true)]
        public static extern void AddPartiallyInlineLibCallsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddReassociatePass", ExactSpelling = true)]
        public static extern void AddReassociatePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddSCCPPass", ExactSpelling = true)]
        public static extern void AddSCCPPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddScalarReplAggregatesPass", ExactSpelling = true)]
        public static extern void AddScalarReplAggregatesPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddScalarReplAggregatesPassSSA", ExactSpelling = true)]
        public static extern void AddScalarReplAggregatesPassSSA([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddScalarReplAggregatesPassWithThreshold", ExactSpelling = true)]
        public static extern void AddScalarReplAggregatesPassWithThreshold([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM, int Threshold);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddSimplifyLibCallsPass", ExactSpelling = true)]
        public static extern void AddSimplifyLibCallsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddTailCallEliminationPass", ExactSpelling = true)]
        public static extern void AddTailCallEliminationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddConstantPropagationPass", ExactSpelling = true)]
        public static extern void AddConstantPropagationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddDemoteMemoryToRegisterPass", ExactSpelling = true)]
        public static extern void AddDemoteMemoryToRegisterPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddVerifierPass", ExactSpelling = true)]
        public static extern void AddVerifierPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddCorrelatedValuePropagationPass", ExactSpelling = true)]
        public static extern void AddCorrelatedValuePropagationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddEarlyCSEPass", ExactSpelling = true)]
        public static extern void AddEarlyCSEPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddEarlyCSEMemSSAPass", ExactSpelling = true)]
        public static extern void AddEarlyCSEMemSSAPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLowerExpectIntrinsicPass", ExactSpelling = true)]
        public static extern void AddLowerExpectIntrinsicPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLowerConstantIntrinsicsPass", ExactSpelling = true)]
        public static extern void AddLowerConstantIntrinsicsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddTypeBasedAliasAnalysisPass", ExactSpelling = true)]
        public static extern void AddTypeBasedAliasAnalysisPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddScopedNoAliasAAPass", ExactSpelling = true)]
        public static extern void AddScopedNoAliasAAPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddBasicAliasAnalysisPass", ExactSpelling = true)]
        public static extern void AddBasicAliasAnalysisPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddUnifyFunctionExitNodesPass", ExactSpelling = true)]
        public static extern void AddUnifyFunctionExitNodesPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLowerSwitchPass", ExactSpelling = true)]
        public static extern void AddLowerSwitchPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddPromoteMemoryToRegisterPass", ExactSpelling = true)]
        public static extern void AddPromoteMemoryToRegisterPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddAddDiscriminatorsPass", ExactSpelling = true)]
        public static extern void AddAddDiscriminatorsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddLoopVectorizePass", ExactSpelling = true)]
        public static extern void AddLoopVectorizePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMAddSLPVectorizePass", ExactSpelling = true)]
        public static extern void AddSLPVectorizePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);
    }
}
