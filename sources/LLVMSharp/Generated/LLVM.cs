using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    public static unsafe partial class LLVM
    {
        private const string libraryPath = "libLLVM";

        [DllImport(libraryPath, EntryPoint = "LLVMVerifyModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int VerifyModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, LLVMVerifierFailureAction Action, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMVerifyFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int VerifyFunction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, LLVMVerifierFailureAction Action);

        [DllImport(libraryPath, EntryPoint = "LLVMViewFunctionCFG", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ViewFunctionCFG([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMViewFunctionCFGOnly", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ViewFunctionCFGOnly([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMParseBitcode", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ParseBitcode([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutModule, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMParseBitcode2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ParseBitcode2([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutModule);

        [DllImport(libraryPath, EntryPoint = "LLVMParseBitcodeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ParseBitcodeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* ContextRef, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutModule, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMParseBitcodeInContext2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ParseBitcodeInContext2([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* ContextRef, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutModule);

        [DllImport(libraryPath, EntryPoint = "LLVMGetBitcodeModuleInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetBitcodeModuleInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* ContextRef, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutM, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMGetBitcodeModuleInContext2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetBitcodeModuleInContext2([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* ContextRef, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutM);

        [DllImport(libraryPath, EntryPoint = "LLVMGetBitcodeModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetBitcodeModule([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutM, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMGetBitcodeModule2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetBitcodeModule2([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutM);

        [DllImport(libraryPath, EntryPoint = "LLVMWriteBitcodeToFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteBitcodeToFile([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Path);

        [DllImport(libraryPath, EntryPoint = "LLVMWriteBitcodeToFD", CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteBitcodeToFD([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, int FD, int ShouldClose, int Unbuffered);

        [DllImport(libraryPath, EntryPoint = "LLVMWriteBitcodeToFileHandle", CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteBitcodeToFileHandle([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, int Handle);

        [DllImport(libraryPath, EntryPoint = "LLVMWriteBitcodeToMemoryBuffer", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMemoryBufferRef")]
        public static extern LLVMOpaqueMemoryBuffer* WriteBitcodeToMemoryBuffer([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetOrInsertComdat", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMComdatRef")]
        public static extern LLVMComdat* GetOrInsertComdat([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMGetComdat", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMComdatRef")]
        public static extern LLVMComdat* GetComdat([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V);

        [DllImport(libraryPath, EntryPoint = "LLVMSetComdat", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetComdat([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("LLVMComdatRef")] LLVMComdat* C);

        [DllImport(libraryPath, EntryPoint = "LLVMGetComdatSelectionKind", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMComdatSelectionKind GetComdatSelectionKind([NativeTypeName("LLVMComdatRef")] LLVMComdat* C);

        [DllImport(libraryPath, EntryPoint = "LLVMSetComdatSelectionKind", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetComdatSelectionKind([NativeTypeName("LLVMComdatRef")] LLVMComdat* C, LLVMComdatSelectionKind Kind);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeCore", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeCore([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMShutdown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Shutdown();

        [DllImport(libraryPath, EntryPoint = "LLVMCreateMessage", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* CreateMessage([NativeTypeName("const char *")] sbyte* Message);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeMessage([NativeTypeName("char *")] sbyte* Message);

        [DllImport(libraryPath, EntryPoint = "LLVMContextCreate", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMContextRef")]
        public static extern LLVMOpaqueContext* ContextCreate();

        [DllImport(libraryPath, EntryPoint = "LLVMGetGlobalContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMContextRef")]
        public static extern LLVMOpaqueContext* GetGlobalContext();

        [DllImport(libraryPath, EntryPoint = "LLVMContextSetDiagnosticHandler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ContextSetDiagnosticHandler([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMDiagnosticHandler")] IntPtr Handler, [NativeTypeName("void *")] void* DiagnosticContext);

        [DllImport(libraryPath, EntryPoint = "LLVMContextGetDiagnosticHandler", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMDiagnosticHandler")]
        public static extern IntPtr ContextGetDiagnosticHandler([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMContextGetDiagnosticContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("void *")]
        public static extern void* ContextGetDiagnosticContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMContextSetYieldCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ContextSetYieldCallback([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMYieldCallback")] IntPtr Callback, [NativeTypeName("void *")] void* OpaqueHandle);

        [DllImport(libraryPath, EntryPoint = "LLVMContextShouldDiscardValueNames", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ContextShouldDiscardValueNames([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMContextSetDiscardValueNames", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ContextSetDiscardValueNames([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMBool")] int Discard);

        [DllImport(libraryPath, EntryPoint = "LLVMContextDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ContextDispose([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDiagInfoDescription", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetDiagInfoDescription([NativeTypeName("LLVMDiagnosticInfoRef")] LLVMOpaqueDiagnosticInfo* DI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDiagInfoSeverity", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMDiagnosticSeverity GetDiagInfoSeverity([NativeTypeName("LLVMDiagnosticInfoRef")] LLVMOpaqueDiagnosticInfo* DI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetMDKindIDInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetMDKindIDInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("unsigned int")] uint SLen);

        [DllImport(libraryPath, EntryPoint = "LLVMGetMDKindID", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetMDKindID([NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("unsigned int")] uint SLen);

        [DllImport(libraryPath, EntryPoint = "LLVMGetEnumAttributeKindForName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetEnumAttributeKindForName([NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr SLen);

        [DllImport(libraryPath, EntryPoint = "LLVMGetLastEnumAttributeKind", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetLastEnumAttributeKind();

        [DllImport(libraryPath, EntryPoint = "LLVMCreateEnumAttribute", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* CreateEnumAttribute([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("unsigned int")] uint KindID, [NativeTypeName("uint64_t")] ulong Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetEnumAttributeKind", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetEnumAttributeKind([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport(libraryPath, EntryPoint = "LLVMGetEnumAttributeValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetEnumAttributeValue([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateStringAttribute", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* CreateStringAttribute([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* K, [NativeTypeName("unsigned int")] uint KLength, [NativeTypeName("const char *")] sbyte* V, [NativeTypeName("unsigned int")] uint VLength);

        [DllImport(libraryPath, EntryPoint = "LLVMGetStringAttributeKind", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetStringAttributeKind([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A, [NativeTypeName("unsigned int *")] uint* Length);

        [DllImport(libraryPath, EntryPoint = "LLVMGetStringAttributeValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetStringAttributeValue([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A, [NativeTypeName("unsigned int *")] uint* Length);

        [DllImport(libraryPath, EntryPoint = "LLVMIsEnumAttribute", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsEnumAttribute([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport(libraryPath, EntryPoint = "LLVMIsStringAttribute", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsStringAttribute([NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport(libraryPath, EntryPoint = "LLVMModuleCreateWithName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMModuleRef")]
        public static extern LLVMOpaqueModule* ModuleCreateWithName([NativeTypeName("const char *")] sbyte* ModuleID);

        [DllImport(libraryPath, EntryPoint = "LLVMModuleCreateWithNameInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMModuleRef")]
        public static extern LLVMOpaqueModule* ModuleCreateWithNameInContext([NativeTypeName("const char *")] sbyte* ModuleID, [NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMCloneModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMModuleRef")]
        public static extern LLVMOpaqueModule* CloneModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetModuleIdentifier", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetModuleIdentifier([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("size_t *")] UIntPtr* Len);

        [DllImport(libraryPath, EntryPoint = "LLVMSetModuleIdentifier", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetModuleIdentifier([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Ident, [NativeTypeName("size_t")] UIntPtr Len);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSourceFileName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetSourceFileName([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("size_t *")] UIntPtr* Len);

        [DllImport(libraryPath, EntryPoint = "LLVMSetSourceFileName", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSourceFileName([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr Len);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDataLayoutStr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetDataLayoutStr([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDataLayout", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetDataLayout([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMSetDataLayout", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDataLayout([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* DataLayoutStr);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTarget", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetTarget([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMSetTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTarget([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Triple);

        [DllImport(libraryPath, EntryPoint = "LLVMCopyModuleFlagsMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMModuleFlagEntry *")]
        public static extern LLVMOpaqueModuleFlagEntry* CopyModuleFlagsMetadata([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("size_t *")] UIntPtr* Len);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeModuleFlagsMetadata", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeModuleFlagsMetadata([NativeTypeName("LLVMModuleFlagEntry *")] LLVMOpaqueModuleFlagEntry* Entries);

        [DllImport(libraryPath, EntryPoint = "LLVMModuleFlagEntriesGetFlagBehavior", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMModuleFlagBehavior ModuleFlagEntriesGetFlagBehavior([NativeTypeName("LLVMModuleFlagEntry *")] LLVMOpaqueModuleFlagEntry* Entries, [NativeTypeName("unsigned int")] uint Index);

        [DllImport(libraryPath, EntryPoint = "LLVMModuleFlagEntriesGetKey", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* ModuleFlagEntriesGetKey([NativeTypeName("LLVMModuleFlagEntry *")] LLVMOpaqueModuleFlagEntry* Entries, [NativeTypeName("unsigned int")] uint Index, [NativeTypeName("size_t *")] UIntPtr* Len);

        [DllImport(libraryPath, EntryPoint = "LLVMModuleFlagEntriesGetMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* ModuleFlagEntriesGetMetadata([NativeTypeName("LLVMModuleFlagEntry *")] LLVMOpaqueModuleFlagEntry* Entries, [NativeTypeName("unsigned int")] uint Index);

        [DllImport(libraryPath, EntryPoint = "LLVMGetModuleFlag", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* GetModuleFlag([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Key, [NativeTypeName("size_t")] UIntPtr KeyLen);

        [DllImport(libraryPath, EntryPoint = "LLVMAddModuleFlag", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddModuleFlag([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, LLVMModuleFlagBehavior Behavior, [NativeTypeName("const char *")] sbyte* Key, [NativeTypeName("size_t")] UIntPtr KeyLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMDumpModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DumpModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMPrintModuleToFile", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int PrintModuleToFile([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Filename, [NativeTypeName("char **")] sbyte** ErrorMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMPrintModuleToString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* PrintModuleToString([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetModuleInlineAsm", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetModuleInlineAsm([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("size_t *")] UIntPtr* Len);

        [DllImport(libraryPath, EntryPoint = "LLVMSetModuleInlineAsm2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetModuleInlineAsm2([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Asm, [NativeTypeName("size_t")] UIntPtr Len);

        [DllImport(libraryPath, EntryPoint = "LLVMAppendModuleInlineAsm", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AppendModuleInlineAsm([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Asm, [NativeTypeName("size_t")] UIntPtr Len);

        [DllImport(libraryPath, EntryPoint = "LLVMGetInlineAsm", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetInlineAsm([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("char *")] sbyte* AsmString, [NativeTypeName("size_t")] UIntPtr AsmStringSize, [NativeTypeName("char *")] sbyte* Constraints, [NativeTypeName("size_t")] UIntPtr ConstraintsSize, [NativeTypeName("LLVMBool")] int HasSideEffects, [NativeTypeName("LLVMBool")] int IsAlignStack, LLVMInlineAsmDialect Dialect);

        [DllImport(libraryPath, EntryPoint = "LLVMGetModuleContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMContextRef")]
        public static extern LLVMOpaqueContext* GetModuleContext([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTypeByName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GetTypeByName([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFirstNamedMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetFirstNamedMetadata([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetLastNamedMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetLastNamedMetadata([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNextNamedMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetNextNamedMetadata([NativeTypeName("LLVMNamedMDNodeRef")] LLVMOpaqueNamedMDNode* NamedMDNode);

        [DllImport(libraryPath, EntryPoint = "LLVMGetPreviousNamedMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetPreviousNamedMetadata([NativeTypeName("LLVMNamedMDNodeRef")] LLVMOpaqueNamedMDNode* NamedMDNode);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNamedMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetNamedMetadata([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport(libraryPath, EntryPoint = "LLVMGetOrInsertNamedMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMNamedMDNodeRef")]
        public static extern LLVMOpaqueNamedMDNode* GetOrInsertNamedMetadata([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNamedMetadataName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetNamedMetadataName([NativeTypeName("LLVMNamedMDNodeRef")] LLVMOpaqueNamedMDNode* NamedMD, [NativeTypeName("size_t *")] UIntPtr* NameLen);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNamedMetadataNumOperands", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNamedMetadataNumOperands([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNamedMetadataOperands", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetNamedMetadataOperands([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Dest);

        [DllImport(libraryPath, EntryPoint = "LLVMAddNamedMetadataOperand", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddNamedMetadataOperand([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDebugLocDirectory", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetDebugLocDirectory([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int *")] uint* Length);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDebugLocFilename", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetDebugLocFilename([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int *")] uint* Length);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDebugLocLine", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetDebugLocLine([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDebugLocColumn", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetDebugLocColumn([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMAddFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AddFunction([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* FunctionTy);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNamedFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNamedFunction([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFirstFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetFirstFunction([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetLastFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetLastFunction([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNextFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNextFunction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMGetPreviousFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPreviousFunction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMSetModuleInlineAsm", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetModuleInlineAsm([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Asm);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTypeKind", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMTypeKind GetTypeKind([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMTypeIsSized", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TypeIsSized([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTypeContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMContextRef")]
        public static extern LLVMOpaqueContext* GetTypeContext([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMDumpType", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DumpType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMPrintTypeToString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* PrintTypeToString([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMInt1TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int1TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMInt8TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int8TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMInt16TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int16TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMInt32TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int32TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMInt64TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int64TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMInt128TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int128TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMIntTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("unsigned int")] uint NumBits);

        [DllImport(libraryPath, EntryPoint = "LLVMInt1Type", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int1Type();

        [DllImport(libraryPath, EntryPoint = "LLVMInt8Type", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int8Type();

        [DllImport(libraryPath, EntryPoint = "LLVMInt16Type", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int16Type();

        [DllImport(libraryPath, EntryPoint = "LLVMInt32Type", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int32Type();

        [DllImport(libraryPath, EntryPoint = "LLVMInt64Type", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int64Type();

        [DllImport(libraryPath, EntryPoint = "LLVMInt128Type", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* Int128Type();

        [DllImport(libraryPath, EntryPoint = "LLVMIntType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntType([NativeTypeName("unsigned int")] uint NumBits);

        [DllImport(libraryPath, EntryPoint = "LLVMGetIntTypeWidth", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetIntTypeWidth([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* IntegerTy);

        [DllImport(libraryPath, EntryPoint = "LLVMHalfTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* HalfTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMFloatTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* FloatTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMDoubleTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* DoubleTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMX86FP80TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* X86FP80TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMFP128TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* FP128TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMPPCFP128TypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* PPCFP128TypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMHalfType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* HalfType();

        [DllImport(libraryPath, EntryPoint = "LLVMFloatType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* FloatType();

        [DllImport(libraryPath, EntryPoint = "LLVMDoubleType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* DoubleType();

        [DllImport(libraryPath, EntryPoint = "LLVMX86FP80Type", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* X86FP80Type();

        [DllImport(libraryPath, EntryPoint = "LLVMFP128Type", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* FP128Type();

        [DllImport(libraryPath, EntryPoint = "LLVMPPCFP128Type", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* PPCFP128Type();

        [DllImport(libraryPath, EntryPoint = "LLVMFunctionType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* FunctionType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ReturnType, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ParamTypes, [NativeTypeName("unsigned int")] uint ParamCount, [NativeTypeName("LLVMBool")] int IsVarArg);

        [DllImport(libraryPath, EntryPoint = "LLVMIsFunctionVarArg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsFunctionVarArg([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* FunctionTy);

        [DllImport(libraryPath, EntryPoint = "LLVMGetReturnType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GetReturnType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* FunctionTy);

        [DllImport(libraryPath, EntryPoint = "LLVMCountParamTypes", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CountParamTypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* FunctionTy);

        [DllImport(libraryPath, EntryPoint = "LLVMGetParamTypes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetParamTypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* FunctionTy, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** Dest);

        [DllImport(libraryPath, EntryPoint = "LLVMStructTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* StructTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ElementTypes, [NativeTypeName("unsigned int")] uint ElementCount, [NativeTypeName("LLVMBool")] int Packed);

        [DllImport(libraryPath, EntryPoint = "LLVMStructType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* StructType([NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ElementTypes, [NativeTypeName("unsigned int")] uint ElementCount, [NativeTypeName("LLVMBool")] int Packed);

        [DllImport(libraryPath, EntryPoint = "LLVMStructCreateNamed", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* StructCreateNamed([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMGetStructName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetStructName([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMStructSetBody", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StructSetBody([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ElementTypes, [NativeTypeName("unsigned int")] uint ElementCount, [NativeTypeName("LLVMBool")] int Packed);

        [DllImport(libraryPath, EntryPoint = "LLVMCountStructElementTypes", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CountStructElementTypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy);

        [DllImport(libraryPath, EntryPoint = "LLVMGetStructElementTypes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetStructElementTypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** Dest);

        [DllImport(libraryPath, EntryPoint = "LLVMStructGetTypeAtIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* StructGetTypeAtIndex([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("unsigned int")] uint i);

        [DllImport(libraryPath, EntryPoint = "LLVMIsPackedStruct", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsPackedStruct([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy);

        [DllImport(libraryPath, EntryPoint = "LLVMIsOpaqueStruct", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsOpaqueStruct([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy);

        [DllImport(libraryPath, EntryPoint = "LLVMIsLiteralStruct", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsLiteralStruct([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy);

        [DllImport(libraryPath, EntryPoint = "LLVMGetElementType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GetElementType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSubtypes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetSubtypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Tp, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** Arr);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNumContainedTypes", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumContainedTypes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Tp);

        [DllImport(libraryPath, EntryPoint = "LLVMArrayType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* ArrayType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ElementType, [NativeTypeName("unsigned int")] uint ElementCount);

        [DllImport(libraryPath, EntryPoint = "LLVMGetArrayLength", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetArrayLength([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ArrayTy);

        [DllImport(libraryPath, EntryPoint = "LLVMPointerType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* PointerType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ElementType, [NativeTypeName("unsigned int")] uint AddressSpace);

        [DllImport(libraryPath, EntryPoint = "LLVMGetPointerAddressSpace", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetPointerAddressSpace([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* PointerTy);

        [DllImport(libraryPath, EntryPoint = "LLVMVectorType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* VectorType([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ElementType, [NativeTypeName("unsigned int")] uint ElementCount);

        [DllImport(libraryPath, EntryPoint = "LLVMGetVectorSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetVectorSize([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* VectorTy);

        [DllImport(libraryPath, EntryPoint = "LLVMVoidTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* VoidTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMLabelTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* LabelTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMX86MMXTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* X86MMXTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMTokenTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* TokenTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMMetadataTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* MetadataTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMVoidType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* VoidType();

        [DllImport(libraryPath, EntryPoint = "LLVMLabelType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* LabelType();

        [DllImport(libraryPath, EntryPoint = "LLVMX86MMXType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* X86MMXType();

        [DllImport(libraryPath, EntryPoint = "LLVMTypeOf", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* TypeOf([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetValueKind", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMValueKind GetValueKind([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetValueName2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetValueName2([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("size_t *")] UIntPtr* Length);

        [DllImport(libraryPath, EntryPoint = "LLVMSetValueName2", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetValueName2([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport(libraryPath, EntryPoint = "LLVMDumpValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DumpValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMPrintValueToString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* PrintValueToString([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMReplaceAllUsesWith", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ReplaceAllUsesWith([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* OldVal, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* NewVal);

        [DllImport(libraryPath, EntryPoint = "LLVMIsConstant", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsConstant([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsUndef", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsUndef([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAArgument", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAArgument([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsABasicBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsABasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAInlineAsm", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAInlineAsm([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAUser", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAUser([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstant", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstant([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsABlockAddress", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsABlockAddress([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantAggregateZero", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantAggregateZero([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantArray", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantArray([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantDataSequential", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantDataSequential([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantDataArray", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantDataArray([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantDataVector", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantDataVector([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantExpr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantExpr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantFP", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantFP([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantInt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantInt([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantPointerNull", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantPointerNull([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantStruct", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantStruct([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantTokenNone", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantTokenNone([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAConstantVector", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAConstantVector([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAGlobalValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGlobalValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAGlobalAlias", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGlobalAlias([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAGlobalIFunc", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGlobalIFunc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAGlobalObject", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGlobalObject([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFunction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAGlobalVariable", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGlobalVariable([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAUndefValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAUndefValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAInstruction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAInstruction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsABinaryOperator", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsABinaryOperator([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsACallInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACallInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAIntrinsicInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAIntrinsicInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsADbgInfoIntrinsic", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsADbgInfoIntrinsic([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsADbgVariableIntrinsic", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsADbgVariableIntrinsic([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsADbgDeclareInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsADbgDeclareInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsADbgLabelInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsADbgLabelInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAMemIntrinsic", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMemIntrinsic([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAMemCpyInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMemCpyInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAMemMoveInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMemMoveInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAMemSetInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMemSetInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsACmpInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACmpInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAFCmpInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFCmpInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAICmpInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAICmpInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAExtractElementInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAExtractElementInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAGetElementPtrInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAGetElementPtrInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAInsertElementInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAInsertElementInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAInsertValueInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAInsertValueInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsALandingPadInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsALandingPadInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAPHINode", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAPHINode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsASelectInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsASelectInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAShuffleVectorInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAShuffleVectorInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAStoreInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAStoreInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsABranchInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsABranchInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAIndirectBrInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAIndirectBrInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAInvokeInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAInvokeInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAReturnInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAReturnInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsASwitchInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsASwitchInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAUnreachableInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAUnreachableInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAResumeInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAResumeInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsACleanupReturnInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACleanupReturnInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsACatchReturnInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACatchReturnInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAFuncletPadInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFuncletPadInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsACatchPadInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACatchPadInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsACleanupPadInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACleanupPadInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAUnaryInstruction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAUnaryInstruction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAAllocaInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAAllocaInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsACastInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsACastInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAAddrSpaceCastInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAAddrSpaceCastInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsABitCastInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsABitCastInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAFPExtInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFPExtInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAFPToSIInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFPToSIInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAFPToUIInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFPToUIInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAFPTruncInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAFPTruncInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAIntToPtrInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAIntToPtrInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAPtrToIntInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAPtrToIntInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsASExtInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsASExtInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsASIToFPInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsASIToFPInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsATruncInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsATruncInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAUIToFPInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAUIToFPInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAZExtInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAZExtInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAExtractValueInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAExtractValueInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsALoadInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsALoadInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAVAArgInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAVAArgInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAMDNode", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMDNode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAMDString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsAMDString([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetValueName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetValueName([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMSetValueName", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetValueName([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFirstUse", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMUseRef")]
        public static extern LLVMOpaqueUse* GetFirstUse([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNextUse", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMUseRef")]
        public static extern LLVMOpaqueUse* GetNextUse([NativeTypeName("LLVMUseRef")] LLVMOpaqueUse* U);

        [DllImport(libraryPath, EntryPoint = "LLVMGetUser", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetUser([NativeTypeName("LLVMUseRef")] LLVMOpaqueUse* U);

        [DllImport(libraryPath, EntryPoint = "LLVMGetUsedValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetUsedValue([NativeTypeName("LLVMUseRef")] LLVMOpaqueUse* U);

        [DllImport(libraryPath, EntryPoint = "LLVMGetOperand", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetOperand([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int")] uint Index);

        [DllImport(libraryPath, EntryPoint = "LLVMGetOperandUse", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMUseRef")]
        public static extern LLVMOpaqueUse* GetOperandUse([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int")] uint Index);

        [DllImport(libraryPath, EntryPoint = "LLVMSetOperand", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetOperand([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* User, [NativeTypeName("unsigned int")] uint Index, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNumOperands", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetNumOperands([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNull", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNull([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMConstAllOnes", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstAllOnes([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMGetUndef", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetUndef([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMIsNull", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsNull([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMConstPointerNull", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstPointerNull([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMConstInt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInt([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* IntTy, [NativeTypeName("unsigned long long")] ulong N, [NativeTypeName("LLVMBool")] int SignExtend);

        [DllImport(libraryPath, EntryPoint = "LLVMConstIntOfArbitraryPrecision", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstIntOfArbitraryPrecision([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* IntTy, [NativeTypeName("unsigned int")] uint NumWords, [NativeTypeName("const uint64_t []")] ulong* Words);

        [DllImport(libraryPath, EntryPoint = "LLVMConstIntOfString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstIntOfString([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* IntTy, [NativeTypeName("const char *")] sbyte* Text, [NativeTypeName("uint8_t")] byte Radix);

        [DllImport(libraryPath, EntryPoint = "LLVMConstIntOfStringAndSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstIntOfStringAndSize([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* IntTy, [NativeTypeName("const char *")] sbyte* Text, [NativeTypeName("unsigned int")] uint SLen, [NativeTypeName("uint8_t")] byte Radix);

        [DllImport(libraryPath, EntryPoint = "LLVMConstReal", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstReal([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* RealTy, double N);

        [DllImport(libraryPath, EntryPoint = "LLVMConstRealOfString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstRealOfString([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* RealTy, [NativeTypeName("const char *")] sbyte* Text);

        [DllImport(libraryPath, EntryPoint = "LLVMConstRealOfStringAndSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstRealOfStringAndSize([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* RealTy, [NativeTypeName("const char *")] sbyte* Text, [NativeTypeName("unsigned int")] uint SLen);

        [DllImport(libraryPath, EntryPoint = "LLVMConstIntGetZExtValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong ConstIntGetZExtValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport(libraryPath, EntryPoint = "LLVMConstIntGetSExtValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("long long")]
        public static extern long ConstIntGetSExtValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport(libraryPath, EntryPoint = "LLVMConstRealGetDouble", CallingConvention = CallingConvention.Cdecl)]
        public static extern double ConstRealGetDouble([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMBool *")] int* losesInfo);

        [DllImport(libraryPath, EntryPoint = "LLVMConstStringInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstStringInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("unsigned int")] uint Length, [NativeTypeName("LLVMBool")] int DontNullTerminate);

        [DllImport(libraryPath, EntryPoint = "LLVMConstString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstString([NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("unsigned int")] uint Length, [NativeTypeName("LLVMBool")] int DontNullTerminate);

        [DllImport(libraryPath, EntryPoint = "LLVMIsConstantString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsConstantString([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* c);

        [DllImport(libraryPath, EntryPoint = "LLVMGetAsString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetAsString([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* c, [NativeTypeName("size_t *")] UIntPtr* Length);

        [DllImport(libraryPath, EntryPoint = "LLVMConstStructInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstStructInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantVals, [NativeTypeName("unsigned int")] uint Count, [NativeTypeName("LLVMBool")] int Packed);

        [DllImport(libraryPath, EntryPoint = "LLVMConstStruct", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstStruct([NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantVals, [NativeTypeName("unsigned int")] uint Count, [NativeTypeName("LLVMBool")] int Packed);

        [DllImport(libraryPath, EntryPoint = "LLVMConstArray", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstArray([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ElementTy, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantVals, [NativeTypeName("unsigned int")] uint Length);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNamedStruct", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNamedStruct([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantVals, [NativeTypeName("unsigned int")] uint Count);

        [DllImport(libraryPath, EntryPoint = "LLVMGetElementAsConstant", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetElementAsConstant([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("unsigned int")] uint idx);

        [DllImport(libraryPath, EntryPoint = "LLVMConstVector", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstVector([NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ScalarConstantVals, [NativeTypeName("unsigned int")] uint Size);

        [DllImport(libraryPath, EntryPoint = "LLVMGetConstOpcode", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMOpcode GetConstOpcode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport(libraryPath, EntryPoint = "LLVMAlignOf", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AlignOf([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMSizeOf", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* SizeOf([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNeg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNeg([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNSWNeg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNSWNeg([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNUWNeg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNUWNeg([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFNeg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFNeg([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNot", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNot([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport(libraryPath, EntryPoint = "LLVMConstAdd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstAdd([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNSWAdd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNSWAdd([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNUWAdd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNUWAdd([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFAdd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFAdd([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstSub", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSub([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNSWSub", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNSWSub([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNUWSub", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNUWSub([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFSub", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFSub([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstMul", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstMul([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNSWMul", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNSWMul([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstNUWMul", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstNUWMul([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFMul", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFMul([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstUDiv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstUDiv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstExactUDiv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstExactUDiv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstSDiv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSDiv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstExactSDiv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstExactSDiv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFDiv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFDiv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstURem", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstURem([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstSRem", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSRem([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFRem", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFRem([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstAnd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstAnd([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstOr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstOr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstXor", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstXor([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstICmp", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstICmp(LLVMIntPredicate Predicate, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFCmp", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFCmp(LLVMRealPredicate Predicate, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstShl", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstShl([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstLShr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstLShr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstAShr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstAShr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHSConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHSConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstGEP", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstGEP([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantIndices, [NativeTypeName("unsigned int")] uint NumIndices);

        [DllImport(libraryPath, EntryPoint = "LLVMConstGEP2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstGEP2([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantIndices, [NativeTypeName("unsigned int")] uint NumIndices);

        [DllImport(libraryPath, EntryPoint = "LLVMConstInBoundsGEP", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInBoundsGEP([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantIndices, [NativeTypeName("unsigned int")] uint NumIndices);

        [DllImport(libraryPath, EntryPoint = "LLVMConstInBoundsGEP2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInBoundsGEP2([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** ConstantIndices, [NativeTypeName("unsigned int")] uint NumIndices);

        [DllImport(libraryPath, EntryPoint = "LLVMConstTrunc", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstTrunc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstSExt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSExt([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstZExt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstZExt([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFPTrunc", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFPTrunc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFPExt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFPExt([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstUIToFP", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstUIToFP([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstSIToFP", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSIToFP([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFPToUI", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFPToUI([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFPToSI", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFPToSI([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstPtrToInt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstPtrToInt([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstIntToPtr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstIntToPtr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstBitCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstBitCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstAddrSpaceCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstAddrSpaceCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstZExtOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstZExtOrBitCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstSExtOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSExtOrBitCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstTruncOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstTruncOrBitCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstPointerCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstPointerCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstIntCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstIntCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType, [NativeTypeName("LLVMBool")] int isSigned);

        [DllImport(libraryPath, EntryPoint = "LLVMConstFPCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstFPCast([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* ToType);

        [DllImport(libraryPath, EntryPoint = "LLVMConstSelect", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstSelect([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantCondition, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantIfTrue, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantIfFalse);

        [DllImport(libraryPath, EntryPoint = "LLVMConstExtractElement", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstExtractElement([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VectorConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IndexConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstInsertElement", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInsertElement([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VectorConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ElementValueConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IndexConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstShuffleVector", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstShuffleVector([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VectorAConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VectorBConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* MaskConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMConstExtractValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstExtractValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AggConstant, [NativeTypeName("unsigned int *")] uint* IdxList, [NativeTypeName("unsigned int")] uint NumIdx);

        [DllImport(libraryPath, EntryPoint = "LLVMConstInsertValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInsertValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AggConstant, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ElementValueConstant, [NativeTypeName("unsigned int *")] uint* IdxList, [NativeTypeName("unsigned int")] uint NumIdx);

        [DllImport(libraryPath, EntryPoint = "LLVMBlockAddress", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BlockAddress([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMConstInlineAsm", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* ConstInlineAsm([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* AsmString, [NativeTypeName("const char *")] sbyte* Constraints, [NativeTypeName("LLVMBool")] int HasSideEffects, [NativeTypeName("LLVMBool")] int IsAlignStack);

        [DllImport(libraryPath, EntryPoint = "LLVMGetGlobalParent", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMModuleRef")]
        public static extern LLVMOpaqueModule* GetGlobalParent([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport(libraryPath, EntryPoint = "LLVMIsDeclaration", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsDeclaration([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport(libraryPath, EntryPoint = "LLVMGetLinkage", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMLinkage GetLinkage([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport(libraryPath, EntryPoint = "LLVMSetLinkage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetLinkage([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, LLVMLinkage Linkage);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSection", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetSection([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport(libraryPath, EntryPoint = "LLVMSetSection", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSection([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, [NativeTypeName("const char *")] sbyte* Section);

        [DllImport(libraryPath, EntryPoint = "LLVMGetVisibility", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMVisibility GetVisibility([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport(libraryPath, EntryPoint = "LLVMSetVisibility", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVisibility([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, LLVMVisibility Viz);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDLLStorageClass", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMDLLStorageClass GetDLLStorageClass([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport(libraryPath, EntryPoint = "LLVMSetDLLStorageClass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetDLLStorageClass([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, LLVMDLLStorageClass Class);

        [DllImport(libraryPath, EntryPoint = "LLVMGetUnnamedAddress", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMUnnamedAddr GetUnnamedAddress([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport(libraryPath, EntryPoint = "LLVMSetUnnamedAddress", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetUnnamedAddress([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, LLVMUnnamedAddr UnnamedAddr);

        [DllImport(libraryPath, EntryPoint = "LLVMGlobalGetValueType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GlobalGetValueType([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport(libraryPath, EntryPoint = "LLVMHasUnnamedAddr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int HasUnnamedAddr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport(libraryPath, EntryPoint = "LLVMSetUnnamedAddr", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetUnnamedAddr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, [NativeTypeName("LLVMBool")] int HasUnnamedAddr);

        [DllImport(libraryPath, EntryPoint = "LLVMGetAlignment", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetAlignment([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V);

        [DllImport(libraryPath, EntryPoint = "LLVMSetAlignment", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAlignment([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("unsigned int")] uint Bytes);

        [DllImport(libraryPath, EntryPoint = "LLVMGlobalSetMetadata", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GlobalSetMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, [NativeTypeName("unsigned int")] uint Kind, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* MD);

        [DllImport(libraryPath, EntryPoint = "LLVMGlobalEraseMetadata", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GlobalEraseMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, [NativeTypeName("unsigned int")] uint Kind);

        [DllImport(libraryPath, EntryPoint = "LLVMGlobalClearMetadata", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GlobalClearMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport(libraryPath, EntryPoint = "LLVMGlobalCopyAllMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueMetadataEntry *")]
        public static extern LLVMOpaqueValueMetadataEntry* GlobalCopyAllMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Value, [NativeTypeName("size_t *")] UIntPtr* NumEntries);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeValueMetadataEntries", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeValueMetadataEntries([NativeTypeName("LLVMValueMetadataEntry *")] LLVMOpaqueValueMetadataEntry* Entries);

        [DllImport(libraryPath, EntryPoint = "LLVMValueMetadataEntriesGetKind", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint ValueMetadataEntriesGetKind([NativeTypeName("LLVMValueMetadataEntry *")] LLVMOpaqueValueMetadataEntry* Entries, [NativeTypeName("unsigned int")] uint Index);

        [DllImport(libraryPath, EntryPoint = "LLVMValueMetadataEntriesGetMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* ValueMetadataEntriesGetMetadata([NativeTypeName("LLVMValueMetadataEntry *")] LLVMOpaqueValueMetadataEntry* Entries, [NativeTypeName("unsigned int")] uint Index);

        [DllImport(libraryPath, EntryPoint = "LLVMAddGlobal", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AddGlobal([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMAddGlobalInAddressSpace", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AddGlobalInAddressSpace([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("unsigned int")] uint AddressSpace);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNamedGlobal", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNamedGlobal([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFirstGlobal", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetFirstGlobal([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetLastGlobal", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetLastGlobal([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNextGlobal", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNextGlobal([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport(libraryPath, EntryPoint = "LLVMGetPreviousGlobal", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPreviousGlobal([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport(libraryPath, EntryPoint = "LLVMDeleteGlobal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteGlobal([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport(libraryPath, EntryPoint = "LLVMGetInitializer", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetInitializer([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport(libraryPath, EntryPoint = "LLVMSetInitializer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetInitializer([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal);

        [DllImport(libraryPath, EntryPoint = "LLVMIsThreadLocal", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsThreadLocal([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport(libraryPath, EntryPoint = "LLVMSetThreadLocal", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetThreadLocal([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar, [NativeTypeName("LLVMBool")] int IsThreadLocal);

        [DllImport(libraryPath, EntryPoint = "LLVMIsGlobalConstant", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsGlobalConstant([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport(libraryPath, EntryPoint = "LLVMSetGlobalConstant", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGlobalConstant([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar, [NativeTypeName("LLVMBool")] int IsConstant);

        [DllImport(libraryPath, EntryPoint = "LLVMGetThreadLocalMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMThreadLocalMode GetThreadLocalMode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport(libraryPath, EntryPoint = "LLVMSetThreadLocalMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetThreadLocalMode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar, LLVMThreadLocalMode Mode);

        [DllImport(libraryPath, EntryPoint = "LLVMIsExternallyInitialized", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsExternallyInitialized([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport(libraryPath, EntryPoint = "LLVMSetExternallyInitialized", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetExternallyInitialized([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar, [NativeTypeName("LLVMBool")] int IsExtInit);

        [DllImport(libraryPath, EntryPoint = "LLVMAddAlias", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AddAlias([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Aliasee, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNamedGlobalAlias", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNamedGlobalAlias([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFirstGlobalAlias", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetFirstGlobalAlias([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetLastGlobalAlias", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetLastGlobalAlias([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNextGlobalAlias", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNextGlobalAlias([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GA);

        [DllImport(libraryPath, EntryPoint = "LLVMGetPreviousGlobalAlias", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPreviousGlobalAlias([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GA);

        [DllImport(libraryPath, EntryPoint = "LLVMAliasGetAliasee", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* AliasGetAliasee([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Alias);

        [DllImport(libraryPath, EntryPoint = "LLVMAliasSetAliasee", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AliasSetAliasee([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Alias, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Aliasee);

        [DllImport(libraryPath, EntryPoint = "LLVMDeleteFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteFunction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMHasPersonalityFn", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int HasPersonalityFn([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMGetPersonalityFn", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPersonalityFn([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMSetPersonalityFn", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPersonalityFn([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PersonalityFn);

        [DllImport(libraryPath, EntryPoint = "LLVMGetIntrinsicID", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetIntrinsicID([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMGetIntrinsicDeclaration", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetIntrinsicDeclaration([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Mod, [NativeTypeName("unsigned int")] uint ID, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ParamTypes, [NativeTypeName("size_t")] UIntPtr ParamCount);

        [DllImport(libraryPath, EntryPoint = "LLVMIntrinsicGetType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntrinsicGetType([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* Ctx, [NativeTypeName("unsigned int")] uint ID, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ParamTypes, [NativeTypeName("size_t")] UIntPtr ParamCount);

        [DllImport(libraryPath, EntryPoint = "LLVMIntrinsicGetName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* IntrinsicGetName([NativeTypeName("unsigned int")] uint ID, [NativeTypeName("size_t *")] UIntPtr* NameLength);

        [DllImport(libraryPath, EntryPoint = "LLVMIntrinsicCopyOverloadedName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* IntrinsicCopyOverloadedName([NativeTypeName("unsigned int")] uint ID, [NativeTypeName("LLVMTypeRef *")] LLVMOpaqueType** ParamTypes, [NativeTypeName("size_t")] UIntPtr ParamCount, [NativeTypeName("size_t *")] UIntPtr* NameLength);

        [DllImport(libraryPath, EntryPoint = "LLVMIntrinsicIsOverloaded", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IntrinsicIsOverloaded([NativeTypeName("unsigned int")] uint ID);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFunctionCallConv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetFunctionCallConv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMSetFunctionCallConv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetFunctionCallConv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("unsigned int")] uint CC);

        [DllImport(libraryPath, EntryPoint = "LLVMGetGC", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetGC([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMSetGC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetGC([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMAddAttributeAtIndex", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAttributeAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport(libraryPath, EntryPoint = "LLVMGetAttributeCountAtIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetAttributeCountAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx);

        [DllImport(libraryPath, EntryPoint = "LLVMGetAttributesAtIndex", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetAttributesAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("LLVMAttributeRef *")] LLVMOpaqueAttributeRef** Attrs);

        [DllImport(libraryPath, EntryPoint = "LLVMGetEnumAttributeAtIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* GetEnumAttributeAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("unsigned int")] uint KindID);

        [DllImport(libraryPath, EntryPoint = "LLVMGetStringAttributeAtIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* GetStringAttributeAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("const char *")] sbyte* K, [NativeTypeName("unsigned int")] uint KLen);

        [DllImport(libraryPath, EntryPoint = "LLVMRemoveEnumAttributeAtIndex", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveEnumAttributeAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("unsigned int")] uint KindID);

        [DllImport(libraryPath, EntryPoint = "LLVMRemoveStringAttributeAtIndex", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveStringAttributeAtIndex([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("const char *")] sbyte* K, [NativeTypeName("unsigned int")] uint KLen);

        [DllImport(libraryPath, EntryPoint = "LLVMAddTargetDependentFunctionAttr", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddTargetDependentFunctionAttr([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("const char *")] sbyte* A, [NativeTypeName("const char *")] sbyte* V);

        [DllImport(libraryPath, EntryPoint = "LLVMCountParams", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CountParams([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMGetParams", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetParams([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Params);

        [DllImport(libraryPath, EntryPoint = "LLVMGetParam", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetParam([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("unsigned int")] uint Index);

        [DllImport(libraryPath, EntryPoint = "LLVMGetParamParent", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetParamParent([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFirstParam", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetFirstParam([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMGetLastParam", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetLastParam([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNextParam", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNextParam([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Arg);

        [DllImport(libraryPath, EntryPoint = "LLVMGetPreviousParam", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPreviousParam([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Arg);

        [DllImport(libraryPath, EntryPoint = "LLVMSetParamAlignment", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetParamAlignment([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Arg, [NativeTypeName("unsigned int")] uint Align);

        [DllImport(libraryPath, EntryPoint = "LLVMMDStringInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* MDStringInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("unsigned int")] uint SLen);

        [DllImport(libraryPath, EntryPoint = "LLVMMDString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* MDString([NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("unsigned int")] uint SLen);

        [DllImport(libraryPath, EntryPoint = "LLVMMDNodeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* MDNodeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Vals, [NativeTypeName("unsigned int")] uint Count);

        [DllImport(libraryPath, EntryPoint = "LLVMMDNode", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* MDNode([NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Vals, [NativeTypeName("unsigned int")] uint Count);

        [DllImport(libraryPath, EntryPoint = "LLVMMetadataAsValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* MetadataAsValue([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* MD);

        [DllImport(libraryPath, EntryPoint = "LLVMValueAsMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* ValueAsMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetMDString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetMDString([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("unsigned int *")] uint* Length);

        [DllImport(libraryPath, EntryPoint = "LLVMGetMDNodeNumOperands", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetMDNodeNumOperands([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V);

        [DllImport(libraryPath, EntryPoint = "LLVMGetMDNodeOperands", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetMDNodeOperands([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Dest);

        [DllImport(libraryPath, EntryPoint = "LLVMBasicBlockAsValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BasicBlockAsValue([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMValueIsBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ValueIsBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMValueAsBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* ValueAsBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetBasicBlockName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetBasicBlockName([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMGetBasicBlockParent", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetBasicBlockParent([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMGetBasicBlockTerminator", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetBasicBlockTerminator([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMCountBasicBlocks", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CountBasicBlocks([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMGetBasicBlocks", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetBasicBlocks([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMBasicBlockRef *")] LLVMOpaqueBasicBlock** BasicBlocks);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFirstBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetFirstBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMGetLastBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetLastBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNextBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetNextBasicBlock([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMGetPreviousBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetPreviousBasicBlock([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMGetEntryBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetEntryBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateBasicBlockInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* CreateBasicBlockInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMAppendBasicBlockInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* AppendBasicBlockInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMAppendBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* AppendBasicBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMInsertBasicBlockInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* InsertBasicBlockInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMInsertBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* InsertBasicBlock([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* InsertBeforeBB, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMDeleteBasicBlock", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteBasicBlock([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMRemoveBasicBlockFromParent", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveBasicBlockFromParent([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMMoveBasicBlockBefore", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveBasicBlockBefore([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* MovePos);

        [DllImport(libraryPath, EntryPoint = "LLVMMoveBasicBlockAfter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveBasicBlockAfter([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* MovePos);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFirstInstruction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetFirstInstruction([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMGetLastInstruction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetLastInstruction([NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMHasMetadata", CallingConvention = CallingConvention.Cdecl)]
        public static extern int HasMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val);

        [DllImport(libraryPath, EntryPoint = "LLVMGetMetadata", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int")] uint KindID);

        [DllImport(libraryPath, EntryPoint = "LLVMSetMetadata", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetMetadata([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("unsigned int")] uint KindID, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Node);

        [DllImport(libraryPath, EntryPoint = "LLVMInstructionGetAllMetadataOtherThanDebugLoc", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueMetadataEntry *")]
        public static extern LLVMOpaqueValueMetadataEntry* InstructionGetAllMetadataOtherThanDebugLoc([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr, [NativeTypeName("size_t *")] UIntPtr* NumEntries);

        [DllImport(libraryPath, EntryPoint = "LLVMGetInstructionParent", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetInstructionParent([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNextInstruction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetNextInstruction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMGetPreviousInstruction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetPreviousInstruction([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMInstructionRemoveFromParent", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InstructionRemoveFromParent([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMInstructionEraseFromParent", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InstructionEraseFromParent([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMGetInstructionOpcode", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMOpcode GetInstructionOpcode([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMGetICmpPredicate", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMIntPredicate GetICmpPredicate([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFCmpPredicate", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMRealPredicate GetFCmpPredicate([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMInstructionClone", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* InstructionClone([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMIsATerminatorInst", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* IsATerminatorInst([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNumArgOperands", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumArgOperands([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport(libraryPath, EntryPoint = "LLVMSetInstructionCallConv", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetInstructionCallConv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr, [NativeTypeName("unsigned int")] uint CC);

        [DllImport(libraryPath, EntryPoint = "LLVMGetInstructionCallConv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetInstructionCallConv([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport(libraryPath, EntryPoint = "LLVMSetInstrParamAlignment", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetInstrParamAlignment([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr, [NativeTypeName("unsigned int")] uint index, [NativeTypeName("unsigned int")] uint Align);

        [DllImport(libraryPath, EntryPoint = "LLVMAddCallSiteAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCallSiteAttribute([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("LLVMAttributeRef")] LLVMOpaqueAttributeRef* A);

        [DllImport(libraryPath, EntryPoint = "LLVMGetCallSiteAttributeCount", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetCallSiteAttributeCount([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx);

        [DllImport(libraryPath, EntryPoint = "LLVMGetCallSiteAttributes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetCallSiteAttributes([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("LLVMAttributeRef *")] LLVMOpaqueAttributeRef** Attrs);

        [DllImport(libraryPath, EntryPoint = "LLVMGetCallSiteEnumAttribute", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* GetCallSiteEnumAttribute([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("unsigned int")] uint KindID);

        [DllImport(libraryPath, EntryPoint = "LLVMGetCallSiteStringAttribute", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMAttributeRef")]
        public static extern LLVMOpaqueAttributeRef* GetCallSiteStringAttribute([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("const char *")] sbyte* K, [NativeTypeName("unsigned int")] uint KLen);

        [DllImport(libraryPath, EntryPoint = "LLVMRemoveCallSiteEnumAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveCallSiteEnumAttribute([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("unsigned int")] uint KindID);

        [DllImport(libraryPath, EntryPoint = "LLVMRemoveCallSiteStringAttribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RemoveCallSiteStringAttribute([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C, [NativeTypeName("LLVMAttributeIndex")] uint Idx, [NativeTypeName("const char *")] sbyte* K, [NativeTypeName("unsigned int")] uint KLen);

        [DllImport(libraryPath, EntryPoint = "LLVMGetCalledFunctionType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GetCalledFunctionType([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* C);

        [DllImport(libraryPath, EntryPoint = "LLVMGetCalledValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetCalledValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport(libraryPath, EntryPoint = "LLVMIsTailCall", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsTailCall([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CallInst);

        [DllImport(libraryPath, EntryPoint = "LLVMSetTailCall", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTailCall([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CallInst, [NativeTypeName("LLVMBool")] int IsTailCall);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNormalDest", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetNormalDest([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InvokeInst);

        [DllImport(libraryPath, EntryPoint = "LLVMGetUnwindDest", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetUnwindDest([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InvokeInst);

        [DllImport(libraryPath, EntryPoint = "LLVMSetNormalDest", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetNormalDest([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InvokeInst, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* B);

        [DllImport(libraryPath, EntryPoint = "LLVMSetUnwindDest", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetUnwindDest([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* InvokeInst, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* B);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNumSuccessors", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumSuccessors([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Term);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSuccessor", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetSuccessor([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Term, [NativeTypeName("unsigned int")] uint i);

        [DllImport(libraryPath, EntryPoint = "LLVMSetSuccessor", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSuccessor([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Term, [NativeTypeName("unsigned int")] uint i, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* block);

        [DllImport(libraryPath, EntryPoint = "LLVMIsConditional", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsConditional([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Branch);

        [DllImport(libraryPath, EntryPoint = "LLVMGetCondition", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetCondition([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Branch);

        [DllImport(libraryPath, EntryPoint = "LLVMSetCondition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCondition([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Branch, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Cond);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSwitchDefaultDest", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetSwitchDefaultDest([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* SwitchInstr);

        [DllImport(libraryPath, EntryPoint = "LLVMGetAllocatedType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* GetAllocatedType([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Alloca);

        [DllImport(libraryPath, EntryPoint = "LLVMIsInBounds", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsInBounds([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GEP);

        [DllImport(libraryPath, EntryPoint = "LLVMSetIsInBounds", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetIsInBounds([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GEP, [NativeTypeName("LLVMBool")] int InBounds);

        [DllImport(libraryPath, EntryPoint = "LLVMAddIncoming", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddIncoming([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PhiNode, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** IncomingValues, [NativeTypeName("LLVMBasicBlockRef *")] LLVMOpaqueBasicBlock** IncomingBlocks, [NativeTypeName("unsigned int")] uint Count);

        [DllImport(libraryPath, EntryPoint = "LLVMCountIncoming", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CountIncoming([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PhiNode);

        [DllImport(libraryPath, EntryPoint = "LLVMGetIncomingValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetIncomingValue([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PhiNode, [NativeTypeName("unsigned int")] uint Index);

        [DllImport(libraryPath, EntryPoint = "LLVMGetIncomingBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetIncomingBlock([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PhiNode, [NativeTypeName("unsigned int")] uint Index);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNumIndices", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumIndices([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMGetIndices", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const unsigned int *")]
        public static extern uint* GetIndices([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateBuilderInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBuilderRef")]
        public static extern LLVMOpaqueBuilder* CreateBuilderInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateBuilder", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBuilderRef")]
        public static extern LLVMOpaqueBuilder* CreateBuilder();

        [DllImport(libraryPath, EntryPoint = "LLVMPositionBuilder", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PositionBuilder([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Block, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport(libraryPath, EntryPoint = "LLVMPositionBuilderBefore", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PositionBuilderBefore([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport(libraryPath, EntryPoint = "LLVMPositionBuilderAtEnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PositionBuilderAtEnd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Block);

        [DllImport(libraryPath, EntryPoint = "LLVMGetInsertBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBasicBlockRef")]
        public static extern LLVMOpaqueBasicBlock* GetInsertBlock([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder);

        [DllImport(libraryPath, EntryPoint = "LLVMClearInsertionPosition", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearInsertionPosition([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder);

        [DllImport(libraryPath, EntryPoint = "LLVMInsertIntoBuilder", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InsertIntoBuilder([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport(libraryPath, EntryPoint = "LLVMInsertIntoBuilderWithName", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InsertIntoBuilderWithName([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeBuilder", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeBuilder([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder);

        [DllImport(libraryPath, EntryPoint = "LLVMSetCurrentDebugLocation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCurrentDebugLocation([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* L);

        [DllImport(libraryPath, EntryPoint = "LLVMGetCurrentDebugLocation", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetCurrentDebugLocation([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder);

        [DllImport(libraryPath, EntryPoint = "LLVMSetInstDebugLocation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetInstDebugLocation([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Inst);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildRetVoid", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildRetVoid([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildRet", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildRet([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildAggregateRet", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAggregateRet([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** RetVals, [NativeTypeName("unsigned int")] uint N);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildBr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildBr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Dest);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildCondBr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCondBr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* If, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Then, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Else);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildSwitch", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSwitch([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Else, [NativeTypeName("unsigned int")] uint NumCases);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildIndirectBr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIndirectBr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Addr, [NativeTypeName("unsigned int")] uint NumDests);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildInvoke", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInvoke([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Then, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Catch, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildInvoke2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInvoke2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Then, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Catch, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildUnreachable", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildUnreachable([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildResume", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildResume([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Exn);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildLandingPad", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildLandingPad([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PersFn, [NativeTypeName("unsigned int")] uint NumClauses, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildCleanupRet", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCleanupRet([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchPad, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildCatchRet", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCatchRet([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchPad, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* BB);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildCatchPad", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCatchPad([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ParentPad, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildCleanupPad", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCleanupPad([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ParentPad, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildCatchSwitch", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCatchSwitch([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ParentPad, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* UnwindBB, [NativeTypeName("unsigned int")] uint NumHandlers, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMAddCase", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCase([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Switch, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* OnVal, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Dest);

        [DllImport(libraryPath, EntryPoint = "LLVMAddDestination", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddDestination([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* IndirectBr, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Dest);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNumClauses", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumClauses([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LandingPad);

        [DllImport(libraryPath, EntryPoint = "LLVMGetClause", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetClause([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LandingPad, [NativeTypeName("unsigned int")] uint Idx);

        [DllImport(libraryPath, EntryPoint = "LLVMAddClause", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddClause([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LandingPad, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ClauseVal);

        [DllImport(libraryPath, EntryPoint = "LLVMIsCleanup", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsCleanup([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LandingPad);

        [DllImport(libraryPath, EntryPoint = "LLVMSetCleanup", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCleanup([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LandingPad, [NativeTypeName("LLVMBool")] int Val);

        [DllImport(libraryPath, EntryPoint = "LLVMAddHandler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddHandler([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchSwitch, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Dest);

        [DllImport(libraryPath, EntryPoint = "LLVMGetNumHandlers", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetNumHandlers([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchSwitch);

        [DllImport(libraryPath, EntryPoint = "LLVMGetHandlers", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetHandlers([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchSwitch, [NativeTypeName("LLVMBasicBlockRef *")] LLVMOpaqueBasicBlock** Handlers);

        [DllImport(libraryPath, EntryPoint = "LLVMGetArgOperand", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetArgOperand([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Funclet, [NativeTypeName("unsigned int")] uint i);

        [DllImport(libraryPath, EntryPoint = "LLVMSetArgOperand", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetArgOperand([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Funclet, [NativeTypeName("unsigned int")] uint i, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* value);

        [DllImport(libraryPath, EntryPoint = "LLVMGetParentCatchSwitch", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* GetParentCatchSwitch([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchPad);

        [DllImport(libraryPath, EntryPoint = "LLVMSetParentCatchSwitch", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetParentCatchSwitch([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchPad, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CatchSwitch);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildAdd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAdd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildNSWAdd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNSWAdd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildNUWAdd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNUWAdd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFAdd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFAdd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildSub", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSub([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildNSWSub", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNSWSub([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildNUWSub", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNUWSub([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFSub", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFSub([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildMul", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildMul([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildNSWMul", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNSWMul([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildNUWMul", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNUWMul([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFMul", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFMul([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildUDiv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildUDiv([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildExactUDiv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildExactUDiv([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildSDiv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSDiv([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildExactSDiv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildExactSDiv([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFDiv", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFDiv([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildURem", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildURem([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildSRem", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSRem([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFRem", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFRem([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildShl", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildShl([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildLShr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildLShr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildAShr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAShr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildAnd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAnd([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildOr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildOr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildXor", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildXor([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildBinOp", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildBinOp([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, LLVMOpcode Op, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildNeg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNeg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildNSWNeg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNSWNeg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildNUWNeg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNUWNeg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFNeg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFNeg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildNot", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildNot([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildMalloc", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildMalloc([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildArrayMalloc", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildArrayMalloc([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildMemSet", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildMemSet([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Ptr, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Len, [NativeTypeName("unsigned int")] uint Align);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildMemCpy", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildMemCpy([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Dst, [NativeTypeName("unsigned int")] uint DstAlign, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Src, [NativeTypeName("unsigned int")] uint SrcAlign, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Size);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildMemMove", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildMemMove([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Dst, [NativeTypeName("unsigned int")] uint DstAlign, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Src, [NativeTypeName("unsigned int")] uint SrcAlign, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Size);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildAlloca", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAlloca([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildArrayAlloca", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildArrayAlloca([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFree", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFree([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PointerVal);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildLoad", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildLoad([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PointerVal, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildLoad2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildLoad2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PointerVal, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildStore", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildStore([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Ptr);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildGEP", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildGEP([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Indices, [NativeTypeName("unsigned int")] uint NumIndices, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildInBoundsGEP", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInBoundsGEP([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Indices, [NativeTypeName("unsigned int")] uint NumIndices, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildStructGEP", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildStructGEP([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("unsigned int")] uint Idx, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildGEP2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildGEP2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Indices, [NativeTypeName("unsigned int")] uint NumIndices, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildInBoundsGEP2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInBoundsGEP2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Indices, [NativeTypeName("unsigned int")] uint NumIndices, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildStructGEP2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildStructGEP2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Pointer, [NativeTypeName("unsigned int")] uint Idx, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildGlobalString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildGlobalString([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildGlobalStringPtr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildGlobalStringPtr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("const char *")] sbyte* Str, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMGetVolatile", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetVolatile([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* MemoryAccessInst);

        [DllImport(libraryPath, EntryPoint = "LLVMSetVolatile", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetVolatile([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* MemoryAccessInst, [NativeTypeName("LLVMBool")] int IsVolatile);

        [DllImport(libraryPath, EntryPoint = "LLVMGetOrdering", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMAtomicOrdering GetOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* MemoryAccessInst);

        [DllImport(libraryPath, EntryPoint = "LLVMSetOrdering", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* MemoryAccessInst, LLVMAtomicOrdering Ordering);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildTrunc", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildTrunc([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildZExt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildZExt([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildSExt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSExt([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFPToUI", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFPToUI([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFPToSI", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFPToSI([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildUIToFP", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildUIToFP([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildSIToFP", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSIToFP([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFPTrunc", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFPTrunc([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFPExt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFPExt([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildPtrToInt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildPtrToInt([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildIntToPtr", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIntToPtr([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildBitCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildBitCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildAddrSpaceCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAddrSpaceCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildZExtOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildZExtOrBitCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildSExtOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSExtOrBitCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildTruncOrBitCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildTruncOrBitCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, LLVMOpcode Op, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildPointerCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildPointerCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildIntCast2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIntCast2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("LLVMBool")] int IsSigned, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFPCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFPCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildIntCast", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIntCast([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* DestTy, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildICmp", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildICmp([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, LLVMIntPredicate Op, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFCmp", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFCmp([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, LLVMRealPredicate Op, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildPhi", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildPhi([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildCall", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCall([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildCall2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildCall2([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* param1, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** Args, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildSelect", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildSelect([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* If, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Then, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Else, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildVAArg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildVAArg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* List, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildExtractElement", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildExtractElement([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VecVal, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Index, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildInsertElement", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInsertElement([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* VecVal, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* EltVal, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Index, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildShuffleVector", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildShuffleVector([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V1, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* V2, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Mask, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildExtractValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildExtractValue([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AggVal, [NativeTypeName("unsigned int")] uint Index, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildInsertValue", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildInsertValue([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AggVal, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* EltVal, [NativeTypeName("unsigned int")] uint Index, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildIsNull", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIsNull([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildIsNotNull", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildIsNotNull([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildPtrDiff", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildPtrDiff([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* param0, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* LHS, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* RHS, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildFence", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildFence([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, LLVMAtomicOrdering ordering, [NativeTypeName("LLVMBool")] int singleThread, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildAtomicRMW", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAtomicRMW([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, LLVMAtomicRMWBinOp op, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* PTR, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, LLVMAtomicOrdering ordering, [NativeTypeName("LLVMBool")] int singleThread);

        [DllImport(libraryPath, EntryPoint = "LLVMBuildAtomicCmpXchg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* BuildAtomicCmpXchg([NativeTypeName("LLVMBuilderRef")] LLVMOpaqueBuilder* B, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Ptr, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Cmp, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* New, LLVMAtomicOrdering SuccessOrdering, LLVMAtomicOrdering FailureOrdering, [NativeTypeName("LLVMBool")] int SingleThread);

        [DllImport(libraryPath, EntryPoint = "LLVMIsAtomicSingleThread", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsAtomicSingleThread([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AtomicInst);

        [DllImport(libraryPath, EntryPoint = "LLVMSetAtomicSingleThread", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAtomicSingleThread([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* AtomicInst, [NativeTypeName("LLVMBool")] int SingleThread);

        [DllImport(libraryPath, EntryPoint = "LLVMGetCmpXchgSuccessOrdering", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMAtomicOrdering GetCmpXchgSuccessOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CmpXchgInst);

        [DllImport(libraryPath, EntryPoint = "LLVMSetCmpXchgSuccessOrdering", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCmpXchgSuccessOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CmpXchgInst, LLVMAtomicOrdering Ordering);

        [DllImport(libraryPath, EntryPoint = "LLVMGetCmpXchgFailureOrdering", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMAtomicOrdering GetCmpXchgFailureOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CmpXchgInst);

        [DllImport(libraryPath, EntryPoint = "LLVMSetCmpXchgFailureOrdering", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetCmpXchgFailureOrdering([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* CmpXchgInst, LLVMAtomicOrdering Ordering);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateModuleProviderForExistingModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMModuleProviderRef")]
        public static extern LLVMOpaqueModuleProvider* CreateModuleProviderForExistingModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeModuleProvider", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeModuleProvider([NativeTypeName("LLVMModuleProviderRef")] LLVMOpaqueModuleProvider* M);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateMemoryBufferWithContentsOfFile", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateMemoryBufferWithContentsOfFile([NativeTypeName("const char *")] sbyte* Path, [NativeTypeName("LLVMMemoryBufferRef *")] LLVMOpaqueMemoryBuffer** OutMemBuf, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateMemoryBufferWithSTDIN", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateMemoryBufferWithSTDIN([NativeTypeName("LLVMMemoryBufferRef *")] LLVMOpaqueMemoryBuffer** OutMemBuf, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateMemoryBufferWithMemoryRange", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMemoryBufferRef")]
        public static extern LLVMOpaqueMemoryBuffer* CreateMemoryBufferWithMemoryRange([NativeTypeName("const char *")] sbyte* InputData, [NativeTypeName("size_t")] UIntPtr InputDataLength, [NativeTypeName("const char *")] sbyte* BufferName, [NativeTypeName("LLVMBool")] int RequiresNullTerminator);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateMemoryBufferWithMemoryRangeCopy", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMemoryBufferRef")]
        public static extern LLVMOpaqueMemoryBuffer* CreateMemoryBufferWithMemoryRangeCopy([NativeTypeName("const char *")] sbyte* InputData, [NativeTypeName("size_t")] UIntPtr InputDataLength, [NativeTypeName("const char *")] sbyte* BufferName);

        [DllImport(libraryPath, EntryPoint = "LLVMGetBufferStart", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetBufferStart([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf);

        [DllImport(libraryPath, EntryPoint = "LLVMGetBufferSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("size_t")]
        public static extern UIntPtr GetBufferSize([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeMemoryBuffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeMemoryBuffer([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf);

        [DllImport(libraryPath, EntryPoint = "LLVMGetGlobalPassRegistry", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMPassRegistryRef")]
        public static extern LLVMOpaquePassRegistry* GetGlobalPassRegistry();

        [DllImport(libraryPath, EntryPoint = "LLVMCreatePassManager", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMPassManagerRef")]
        public static extern LLVMOpaquePassManager* CreatePassManager();

        [DllImport(libraryPath, EntryPoint = "LLVMCreateFunctionPassManagerForModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMPassManagerRef")]
        public static extern LLVMOpaquePassManager* CreateFunctionPassManagerForModule([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateFunctionPassManager", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMPassManagerRef")]
        public static extern LLVMOpaquePassManager* CreateFunctionPassManager([NativeTypeName("LLVMModuleProviderRef")] LLVMOpaqueModuleProvider* MP);

        [DllImport(libraryPath, EntryPoint = "LLVMRunPassManager", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int RunPassManager([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeFunctionPassManager", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int InitializeFunctionPassManager([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* FPM);

        [DllImport(libraryPath, EntryPoint = "LLVMRunFunctionPassManager", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int RunFunctionPassManager([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* FPM, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F);

        [DllImport(libraryPath, EntryPoint = "LLVMFinalizeFunctionPassManager", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int FinalizeFunctionPassManager([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* FPM);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposePassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposePassManager([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMStartMultithreaded", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int StartMultithreaded();

        [DllImport(libraryPath, EntryPoint = "LLVMStopMultithreaded", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopMultithreaded();

        [DllImport(libraryPath, EntryPoint = "LLVMIsMultithreaded", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsMultithreaded();

        [DllImport(libraryPath, EntryPoint = "LLVMDebugMetadataVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint DebugMetadataVersion();

        [DllImport(libraryPath, EntryPoint = "LLVMGetModuleDebugMetadataVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GetModuleDebugMetadataVersion([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Module);

        [DllImport(libraryPath, EntryPoint = "LLVMStripModuleDebugInfo", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int StripModuleDebugInfo([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Module);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateDIBuilderDisallowUnresolved", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMDIBuilderRef")]
        public static extern LLVMOpaqueDIBuilder* CreateDIBuilderDisallowUnresolved([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateDIBuilder", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMDIBuilderRef")]
        public static extern LLVMOpaqueDIBuilder* CreateDIBuilder([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeDIBuilder", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeDIBuilder([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderFinalize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DIBuilderFinalize([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateCompileUnit", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateCompileUnit([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, LLVMDWARFSourceLanguage Lang, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* FileRef, [NativeTypeName("const char *")] sbyte* Producer, [NativeTypeName("size_t")] UIntPtr ProducerLen, [NativeTypeName("LLVMBool")] int isOptimized, [NativeTypeName("const char *")] sbyte* Flags, [NativeTypeName("size_t")] UIntPtr FlagsLen, [NativeTypeName("unsigned int")] uint RuntimeVer, [NativeTypeName("const char *")] sbyte* SplitName, [NativeTypeName("size_t")] UIntPtr SplitNameLen, LLVMDWARFEmissionKind Kind, [NativeTypeName("unsigned int")] uint DWOId, [NativeTypeName("LLVMBool")] int SplitDebugInlining, [NativeTypeName("LLVMBool")] int DebugInfoForProfiling);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateFile", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateFile([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("const char *")] sbyte* Filename, [NativeTypeName("size_t")] UIntPtr FilenameLen, [NativeTypeName("const char *")] sbyte* Directory, [NativeTypeName("size_t")] UIntPtr DirectoryLen);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateModule([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ParentScope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("const char *")] sbyte* ConfigMacros, [NativeTypeName("size_t")] UIntPtr ConfigMacrosLen, [NativeTypeName("const char *")] sbyte* IncludePath, [NativeTypeName("size_t")] UIntPtr IncludePathLen, [NativeTypeName("const char *")] sbyte* ISysRoot, [NativeTypeName("size_t")] UIntPtr ISysRootLen);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateNameSpace", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateNameSpace([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ParentScope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMBool")] int ExportSymbols);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateFunction([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("const char *")] sbyte* LinkageName, [NativeTypeName("size_t")] UIntPtr LinkageNameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMBool")] int IsLocalToUnit, [NativeTypeName("LLVMBool")] int IsDefinition, [NativeTypeName("unsigned int")] uint ScopeLine, LLVMDIFlags Flags, [NativeTypeName("LLVMBool")] int IsOptimized);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateLexicalBlock", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateLexicalBlock([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line, [NativeTypeName("unsigned int")] uint Column);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateLexicalBlockFile", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateLexicalBlockFile([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Discriminator);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateImportedModuleFromNamespace", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateImportedModuleFromNamespace([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* NS, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateImportedModuleFromAlias", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateImportedModuleFromAlias([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ImportedEntity, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateImportedModuleFromModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateImportedModuleFromModule([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* M, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateImportedDeclaration", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateImportedDeclaration([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Decl, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateDebugLocation", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateDebugLocation([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* Ctx, [NativeTypeName("unsigned int")] uint Line, [NativeTypeName("unsigned int")] uint Column, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* InlinedAt);

        [DllImport(libraryPath, EntryPoint = "LLVMDILocationGetLine", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint DILocationGetLine([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Location);

        [DllImport(libraryPath, EntryPoint = "LLVMDILocationGetColumn", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint DILocationGetColumn([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Location);

        [DllImport(libraryPath, EntryPoint = "LLVMDILocationGetScope", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DILocationGetScope([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Location);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderGetOrCreateTypeArray", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderGetOrCreateTypeArray([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Data, [NativeTypeName("size_t")] UIntPtr NumElements);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateSubroutineType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateSubroutineType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** ParameterTypes, [NativeTypeName("unsigned int")] uint NumParameterTypes, LLVMDIFlags Flags);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateEnumerationType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateEnumerationType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Elements, [NativeTypeName("unsigned int")] uint NumElements, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ClassTy);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateUnionType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateUnionType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Elements, [NativeTypeName("unsigned int")] uint NumElements, [NativeTypeName("unsigned int")] uint RunTimeLang, [NativeTypeName("const char *")] sbyte* UniqueId, [NativeTypeName("size_t")] UIntPtr UniqueIdLen);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateArrayType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateArrayType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("uint64_t")] ulong Size, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Subscripts, [NativeTypeName("unsigned int")] uint NumSubscripts);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateVectorType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateVectorType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("uint64_t")] ulong Size, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Subscripts, [NativeTypeName("unsigned int")] uint NumSubscripts);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateUnspecifiedType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateUnspecifiedType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateBasicType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateBasicType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("LLVMDWARFTypeEncoding")] uint Encoding, LLVMDIFlags Flags);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreatePointerType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreatePointerType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* PointeeTy, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("unsigned int")] uint AddressSpace, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateStructType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateStructType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DerivedFrom, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Elements, [NativeTypeName("unsigned int")] uint NumElements, [NativeTypeName("unsigned int")] uint RunTimeLang, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VTableHolder, [NativeTypeName("const char *")] sbyte* UniqueId, [NativeTypeName("size_t")] UIntPtr UniqueIdLen);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateMemberType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateMemberType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("uint64_t")] ulong OffsetInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateStaticMemberType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateStaticMemberType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type, LLVMDIFlags Flags, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* ConstantVal, [NativeTypeName("uint32_t")] uint AlignInBits);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateMemberPointerType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateMemberPointerType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* PointeeType, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* ClassType, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, LLVMDIFlags Flags);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateObjCIVar", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateObjCIVar([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("uint64_t")] ulong OffsetInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* PropertyNode);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateObjCProperty", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateObjCProperty([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("const char *")] sbyte* GetterName, [NativeTypeName("size_t")] UIntPtr GetterNameLen, [NativeTypeName("const char *")] sbyte* SetterName, [NativeTypeName("size_t")] UIntPtr SetterNameLen, [NativeTypeName("unsigned int")] uint PropertyAttributes, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateObjectPointerType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateObjectPointerType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateQualifiedType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateQualifiedType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("unsigned int")] uint Tag, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateReferenceType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateReferenceType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("unsigned int")] uint Tag, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateNullPtrType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateNullPtrType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateTypedef", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateTypedef([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateInheritance", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateInheritance([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* BaseTy, [NativeTypeName("uint64_t")] ulong BaseOffset, [NativeTypeName("uint32_t")] uint VBPtrOffset, LLVMDIFlags Flags);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateForwardDecl", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateForwardDecl([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("unsigned int")] uint Tag, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line, [NativeTypeName("unsigned int")] uint RuntimeLang, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("const char *")] sbyte* UniqueIdentifier, [NativeTypeName("size_t")] UIntPtr UniqueIdentifierLen);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateReplaceableCompositeType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateReplaceableCompositeType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("unsigned int")] uint Tag, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint Line, [NativeTypeName("unsigned int")] uint RuntimeLang, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, LLVMDIFlags Flags, [NativeTypeName("const char *")] sbyte* UniqueIdentifier, [NativeTypeName("size_t")] UIntPtr UniqueIdentifierLen);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateBitFieldMemberType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateBitFieldMemberType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint64_t")] ulong OffsetInBits, [NativeTypeName("uint64_t")] ulong StorageOffsetInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateClassType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateClassType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNumber, [NativeTypeName("uint64_t")] ulong SizeInBits, [NativeTypeName("uint32_t")] uint AlignInBits, [NativeTypeName("uint64_t")] ulong OffsetInBits, LLVMDIFlags Flags, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DerivedFrom, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Elements, [NativeTypeName("unsigned int")] uint NumElements, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VTableHolder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* TemplateParamsNode, [NativeTypeName("const char *")] sbyte* UniqueIdentifier, [NativeTypeName("size_t")] UIntPtr UniqueIdentifierLen);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateArtificialType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateArtificialType([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Type);

        [DllImport(libraryPath, EntryPoint = "LLVMDITypeGetName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* DITypeGetName([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType, [NativeTypeName("size_t *")] UIntPtr* Length);

        [DllImport(libraryPath, EntryPoint = "LLVMDITypeGetSizeInBits", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong DITypeGetSizeInBits([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType);

        [DllImport(libraryPath, EntryPoint = "LLVMDITypeGetOffsetInBits", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong DITypeGetOffsetInBits([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType);

        [DllImport(libraryPath, EntryPoint = "LLVMDITypeGetAlignInBits", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint DITypeGetAlignInBits([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType);

        [DllImport(libraryPath, EntryPoint = "LLVMDITypeGetLine", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint DITypeGetLine([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType);

        [DllImport(libraryPath, EntryPoint = "LLVMDITypeGetFlags", CallingConvention = CallingConvention.Cdecl)]
        public static extern LLVMDIFlags DITypeGetFlags([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DType);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderGetOrCreateSubrange", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderGetOrCreateSubrange([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("int64_t")] long LowerBound, [NativeTypeName("int64_t")] long Count);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderGetOrCreateArray", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderGetOrCreateArray([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Data, [NativeTypeName("size_t")] UIntPtr NumElements);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateExpression", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateExpression([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("int64_t *")] long* Addr, [NativeTypeName("size_t")] UIntPtr Length);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateConstantValueExpression", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateConstantValueExpression([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("int64_t")] long Value);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateGlobalVariableExpression", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateGlobalVariableExpression([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("const char *")] sbyte* Linkage, [NativeTypeName("size_t")] UIntPtr LinkLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMBool")] int LocalToUnit, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Expr, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Decl, [NativeTypeName("uint32_t")] uint AlignInBits);

        [DllImport(libraryPath, EntryPoint = "LLVMTemporaryMDNode", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* TemporaryMDNode([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* Ctx, [NativeTypeName("LLVMMetadataRef *")] LLVMOpaqueMetadata** Data, [NativeTypeName("size_t")] UIntPtr NumElements);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeTemporaryMDNode", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeTemporaryMDNode([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* TempNode);

        [DllImport(libraryPath, EntryPoint = "LLVMMetadataReplaceAllUsesWith", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MetadataReplaceAllUsesWith([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* TempTargetMetadata, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Replacement);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateTempGlobalVariableFwdDecl", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateTempGlobalVariableFwdDecl([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("const char *")] sbyte* Linkage, [NativeTypeName("size_t")] UIntPtr LnkLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMBool")] int LocalToUnit, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Decl, [NativeTypeName("uint32_t")] uint AlignInBits);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderInsertDeclareBefore", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* DIBuilderInsertDeclareBefore([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Storage, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VarInfo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Expr, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DebugLoc, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderInsertDeclareAtEnd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* DIBuilderInsertDeclareAtEnd([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Storage, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VarInfo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Expr, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DebugLoc, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Block);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderInsertDbgValueBefore", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* DIBuilderInsertDbgValueBefore([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VarInfo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Expr, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DebugLoc, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Instr);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderInsertDbgValueAtEnd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMValueRef")]
        public static extern LLVMOpaqueValue* DIBuilderInsertDbgValueAtEnd([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Val, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* VarInfo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Expr, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* DebugLoc, [NativeTypeName("LLVMBasicBlockRef")] LLVMOpaqueBasicBlock* Block);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateAutoVariable", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateAutoVariable([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMBool")] int AlwaysPreserve, LLVMDIFlags Flags, [NativeTypeName("uint32_t")] uint AlignInBits);

        [DllImport(libraryPath, EntryPoint = "LLVMDIBuilderCreateParameterVariable", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* DIBuilderCreateParameterVariable([NativeTypeName("LLVMDIBuilderRef")] LLVMOpaqueDIBuilder* Builder, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Scope, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("size_t")] UIntPtr NameLen, [NativeTypeName("unsigned int")] uint ArgNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* File, [NativeTypeName("unsigned int")] uint LineNo, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Ty, [NativeTypeName("LLVMBool")] int AlwaysPreserve, LLVMDIFlags Flags);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSubprogram", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataRef")]
        public static extern LLVMOpaqueMetadata* GetSubprogram([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Func);

        [DllImport(libraryPath, EntryPoint = "LLVMSetSubprogram", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetSubprogram([NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Func, [NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* SP);

        [DllImport(libraryPath, EntryPoint = "LLVMGetMetadataKind", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMetadataKind")]
        public static extern uint GetMetadataKind([NativeTypeName("LLVMMetadataRef")] LLVMOpaqueMetadata* Metadata);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateDisasm", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMDisasmContextRef")]
        public static extern void* CreateDisasm([NativeTypeName("const char *")] sbyte* TripleName, [NativeTypeName("void *")] void* DisInfo, int TagType, [NativeTypeName("LLVMOpInfoCallback")] IntPtr GetOpInfo, [NativeTypeName("LLVMSymbolLookupCallback")] IntPtr SymbolLookUp);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateDisasmCPU", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMDisasmContextRef")]
        public static extern void* CreateDisasmCPU([NativeTypeName("const char *")] sbyte* Triple, [NativeTypeName("const char *")] sbyte* CPU, [NativeTypeName("void *")] void* DisInfo, int TagType, [NativeTypeName("LLVMOpInfoCallback")] IntPtr GetOpInfo, [NativeTypeName("LLVMSymbolLookupCallback")] IntPtr SymbolLookUp);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateDisasmCPUFeatures", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMDisasmContextRef")]
        public static extern void* CreateDisasmCPUFeatures([NativeTypeName("const char *")] sbyte* Triple, [NativeTypeName("const char *")] sbyte* CPU, [NativeTypeName("const char *")] sbyte* Features, [NativeTypeName("void *")] void* DisInfo, int TagType, [NativeTypeName("LLVMOpInfoCallback")] IntPtr GetOpInfo, [NativeTypeName("LLVMSymbolLookupCallback")] IntPtr SymbolLookUp);

        [DllImport(libraryPath, EntryPoint = "LLVMSetDisasmOptions", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetDisasmOptions([NativeTypeName("LLVMDisasmContextRef")] void* DC, [NativeTypeName("uint64_t")] ulong Options);

        [DllImport(libraryPath, EntryPoint = "LLVMDisasmDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisasmDispose([NativeTypeName("LLVMDisasmContextRef")] void* DC);

        [DllImport(libraryPath, EntryPoint = "LLVMDisasmInstruction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("size_t")]
        public static extern UIntPtr DisasmInstruction([NativeTypeName("LLVMDisasmContextRef")] void* DC, [NativeTypeName("uint8_t *")] byte* Bytes, [NativeTypeName("uint64_t")] ulong BytesSize, [NativeTypeName("uint64_t")] ulong PC, [NativeTypeName("char *")] sbyte* OutString, [NativeTypeName("size_t")] UIntPtr OutStringSize);

        [DllImport(libraryPath, EntryPoint = "LLVMGetErrorTypeId", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorTypeId")]
        public static extern void* GetErrorTypeId([NativeTypeName("LLVMErrorRef")] LLVMOpaqueError* Err);

        [DllImport(libraryPath, EntryPoint = "LLVMConsumeError", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ConsumeError([NativeTypeName("LLVMErrorRef")] LLVMOpaqueError* Err);

        [DllImport(libraryPath, EntryPoint = "LLVMGetErrorMessage", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetErrorMessage([NativeTypeName("LLVMErrorRef")] LLVMOpaqueError* Err);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeErrorMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeErrorMessage([NativeTypeName("char *")] sbyte* ErrMsg);

        [DllImport(libraryPath, EntryPoint = "LLVMGetStringErrorTypeId", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorTypeId")]
        public static extern void* GetStringErrorTypeId();

        [DllImport(libraryPath, EntryPoint = "LLVMInstallFatalErrorHandler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InstallFatalErrorHandler([NativeTypeName("LLVMFatalErrorHandler")] IntPtr Handler);

        [DllImport(libraryPath, EntryPoint = "LLVMResetFatalErrorHandler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResetFatalErrorHandler();

        [DllImport(libraryPath, EntryPoint = "LLVMEnablePrettyStackTrace", CallingConvention = CallingConvention.Cdecl)]
        public static extern void EnablePrettyStackTrace();

        [DllImport(libraryPath, EntryPoint = "LLVMLinkInMCJIT", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LinkInMCJIT();

        [DllImport(libraryPath, EntryPoint = "LLVMLinkInInterpreter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void LinkInInterpreter();

        [DllImport(libraryPath, EntryPoint = "LLVMCreateGenericValueOfInt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMGenericValueRef")]
        public static extern LLVMOpaqueGenericValue* CreateGenericValueOfInt([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, [NativeTypeName("unsigned long long")] ulong N, [NativeTypeName("LLVMBool")] int IsSigned);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateGenericValueOfPointer", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMGenericValueRef")]
        public static extern LLVMOpaqueGenericValue* CreateGenericValueOfPointer([NativeTypeName("void *")] void* P);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateGenericValueOfFloat", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMGenericValueRef")]
        public static extern LLVMOpaqueGenericValue* CreateGenericValueOfFloat([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty, double N);

        [DllImport(libraryPath, EntryPoint = "LLVMGenericValueIntWidth", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint GenericValueIntWidth([NativeTypeName("LLVMGenericValueRef")] LLVMOpaqueGenericValue* GenValRef);

        [DllImport(libraryPath, EntryPoint = "LLVMGenericValueToInt", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong GenericValueToInt([NativeTypeName("LLVMGenericValueRef")] LLVMOpaqueGenericValue* GenVal, [NativeTypeName("LLVMBool")] int IsSigned);

        [DllImport(libraryPath, EntryPoint = "LLVMGenericValueToPointer", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("void *")]
        public static extern void* GenericValueToPointer([NativeTypeName("LLVMGenericValueRef")] LLVMOpaqueGenericValue* GenVal);

        [DllImport(libraryPath, EntryPoint = "LLVMGenericValueToFloat", CallingConvention = CallingConvention.Cdecl)]
        public static extern double GenericValueToFloat([NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* TyRef, [NativeTypeName("LLVMGenericValueRef")] LLVMOpaqueGenericValue* GenVal);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeGenericValue", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeGenericValue([NativeTypeName("LLVMGenericValueRef")] LLVMOpaqueGenericValue* GenVal);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateExecutionEngineForModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateExecutionEngineForModule([NativeTypeName("LLVMExecutionEngineRef *")] LLVMOpaqueExecutionEngine** OutEE, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("char **")] sbyte** OutError);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateInterpreterForModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateInterpreterForModule([NativeTypeName("LLVMExecutionEngineRef *")] LLVMOpaqueExecutionEngine** OutInterp, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("char **")] sbyte** OutError);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateJITCompilerForModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateJITCompilerForModule([NativeTypeName("LLVMExecutionEngineRef *")] LLVMOpaqueExecutionEngine** OutJIT, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("unsigned int")] uint OptLevel, [NativeTypeName("char **")] sbyte** OutError);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMCJITCompilerOptions", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMCJITCompilerOptions([NativeTypeName("struct LLVMMCJITCompilerOptions *")] LLVMMCJITCompilerOptions* Options, [NativeTypeName("size_t")] UIntPtr SizeOfOptions);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateMCJITCompilerForModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int CreateMCJITCompilerForModule([NativeTypeName("LLVMExecutionEngineRef *")] LLVMOpaqueExecutionEngine** OutJIT, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("struct LLVMMCJITCompilerOptions *")] LLVMMCJITCompilerOptions* Options, [NativeTypeName("size_t")] UIntPtr SizeOfOptions, [NativeTypeName("char **")] sbyte** OutError);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeExecutionEngine", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeExecutionEngine([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE);

        [DllImport(libraryPath, EntryPoint = "LLVMRunStaticConstructors", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunStaticConstructors([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE);

        [DllImport(libraryPath, EntryPoint = "LLVMRunStaticDestructors", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunStaticDestructors([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE);

        [DllImport(libraryPath, EntryPoint = "LLVMRunFunctionAsMain", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RunFunctionAsMain([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("unsigned int")] uint ArgC, [NativeTypeName("const char *const *")] sbyte** ArgV, [NativeTypeName("const char *const *")] sbyte** EnvP);

        [DllImport(libraryPath, EntryPoint = "LLVMRunFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMGenericValueRef")]
        public static extern LLVMOpaqueGenericValue* RunFunction([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F, [NativeTypeName("unsigned int")] uint NumArgs, [NativeTypeName("LLVMGenericValueRef *")] LLVMOpaqueGenericValue** Args);

        [DllImport(libraryPath, EntryPoint = "LLVMFreeMachineCodeForFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern void FreeMachineCodeForFunction([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* F);

        [DllImport(libraryPath, EntryPoint = "LLVMAddModule", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddModule([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMRemoveModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int RemoveModule([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutMod, [NativeTypeName("char **")] sbyte** OutError);

        [DllImport(libraryPath, EntryPoint = "LLVMFindFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int FindFunction([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("const char *")] sbyte* Name, [NativeTypeName("LLVMValueRef *")] LLVMOpaqueValue** OutFn);

        [DllImport(libraryPath, EntryPoint = "LLVMRecompileAndRelinkFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("void *")]
        public static extern void* RecompileAndRelinkFunction([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Fn);

        [DllImport(libraryPath, EntryPoint = "LLVMGetExecutionEngineTargetData", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTargetDataRef")]
        public static extern LLVMOpaqueTargetData* GetExecutionEngineTargetData([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE);

        [DllImport(libraryPath, EntryPoint = "LLVMGetExecutionEngineTargetMachine", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTargetMachineRef")]
        public static extern LLVMOpaqueTargetMachine* GetExecutionEngineTargetMachine([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE);

        [DllImport(libraryPath, EntryPoint = "LLVMAddGlobalMapping", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddGlobalMapping([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global, [NativeTypeName("void *")] void* Addr);

        [DllImport(libraryPath, EntryPoint = "LLVMGetPointerToGlobal", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("void *")]
        public static extern void* GetPointerToGlobal([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* Global);

        [DllImport(libraryPath, EntryPoint = "LLVMGetGlobalValueAddress", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetGlobalValueAddress([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFunctionAddress", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetFunctionAddress([NativeTypeName("LLVMExecutionEngineRef")] LLVMOpaqueExecutionEngine* EE, [NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateSimpleMCJITMemoryManager", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMMCJITMemoryManagerRef")]
        public static extern LLVMOpaqueMCJITMemoryManager* CreateSimpleMCJITMemoryManager([NativeTypeName("void *")] void* Opaque, [NativeTypeName("LLVMMemoryManagerAllocateCodeSectionCallback")] IntPtr AllocateCodeSection, [NativeTypeName("LLVMMemoryManagerAllocateDataSectionCallback")] IntPtr AllocateDataSection, [NativeTypeName("LLVMMemoryManagerFinalizeMemoryCallback")] IntPtr FinalizeMemory, [NativeTypeName("LLVMMemoryManagerDestroyCallback")] IntPtr Destroy);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeMCJITMemoryManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeMCJITMemoryManager([NativeTypeName("LLVMMCJITMemoryManagerRef")] LLVMOpaqueMCJITMemoryManager* MM);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateGDBRegistrationListener", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMJITEventListenerRef")]
        public static extern LLVMOpaqueJITEventListener* CreateGDBRegistrationListener();

        [DllImport(libraryPath, EntryPoint = "LLVMCreateIntelJITEventListener", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMJITEventListenerRef")]
        public static extern LLVMOpaqueJITEventListener* CreateIntelJITEventListener();

        [DllImport(libraryPath, EntryPoint = "LLVMCreateOProfileJITEventListener", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMJITEventListenerRef")]
        public static extern LLVMOpaqueJITEventListener* CreateOProfileJITEventListener();

        [DllImport(libraryPath, EntryPoint = "LLVMCreatePerfJITEventListener", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMJITEventListenerRef")]
        public static extern LLVMOpaqueJITEventListener* CreatePerfJITEventListener();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeTransformUtils", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeTransformUtils([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeScalarOpts", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeScalarOpts([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeObjCARCOpts", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeObjCARCOpts([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeVectorization", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeVectorization([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeInstCombine", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeInstCombine([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAggressiveInstCombiner", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAggressiveInstCombiner([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeIPO", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeIPO([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeInstrumentation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeInstrumentation([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAnalysis", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAnalysis([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeIPA", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeIPA([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeCodeGen", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeCodeGen([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeTarget([NativeTypeName("LLVMPassRegistryRef")] LLVMOpaquePassRegistry* R);

        [DllImport(libraryPath, EntryPoint = "LLVMParseIRInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int ParseIRInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* ContextRef, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf, [NativeTypeName("LLVMModuleRef *")] LLVMOpaqueModule** OutM, [NativeTypeName("char **")] sbyte** OutMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMLinkModules2", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int LinkModules2([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Dest, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Src);

        [DllImport(libraryPath, EntryPoint = "llvm_create_optimizer", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("llvm_lto_t")]
        public static extern void* llvm_create_optimizer();

        [DllImport(libraryPath, EntryPoint = "llvm_destroy_optimizer", CallingConvention = CallingConvention.Cdecl)]
        public static extern void llvm_destroy_optimizer([NativeTypeName("llvm_lto_t")] void* lto);

        [DllImport(libraryPath, EntryPoint = "llvm_read_object_file", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("llvm_lto_status_t")]
        public static extern llvm_lto_status llvm_read_object_file([NativeTypeName("llvm_lto_t")] void* lto, [NativeTypeName("const char *")] sbyte* input_filename);

        [DllImport(libraryPath, EntryPoint = "llvm_optimize_modules", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("llvm_lto_status_t")]
        public static extern llvm_lto_status llvm_optimize_modules([NativeTypeName("llvm_lto_t")] void* lto, [NativeTypeName("const char *")] sbyte* output_filename);

        [DllImport(libraryPath, EntryPoint = "lto_get_version", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lto_get_version();

        [DllImport(libraryPath, EntryPoint = "lto_get_error_message", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lto_get_error_message();

        [DllImport(libraryPath, EntryPoint = "lto_module_is_object_file", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_module_is_object_file([NativeTypeName("const char *")] sbyte* path);

        [DllImport(libraryPath, EntryPoint = "lto_module_is_object_file_for_target", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_module_is_object_file_for_target([NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const char *")] sbyte* target_triple_prefix);

        [DllImport(libraryPath, EntryPoint = "lto_module_has_objc_category", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_module_has_objc_category([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length);

        [DllImport(libraryPath, EntryPoint = "lto_module_is_object_file_in_memory", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_module_is_object_file_in_memory([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length);

        [DllImport(libraryPath, EntryPoint = "lto_module_is_object_file_in_memory_for_target", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_module_is_object_file_in_memory_for_target([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length, [NativeTypeName("const char *")] sbyte* target_triple_prefix);

        [DllImport(libraryPath, EntryPoint = "lto_module_create", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create([NativeTypeName("const char *")] sbyte* path);

        [DllImport(libraryPath, EntryPoint = "lto_module_create_from_memory", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_from_memory([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length);

        [DllImport(libraryPath, EntryPoint = "lto_module_create_from_memory_with_path", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_from_memory_with_path([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length, [NativeTypeName("const char *")] sbyte* path);

        [DllImport(libraryPath, EntryPoint = "lto_module_create_in_local_context", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_in_local_context([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length, [NativeTypeName("const char *")] sbyte* path);

        [DllImport(libraryPath, EntryPoint = "lto_module_create_in_codegen_context", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_in_codegen_context([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] UIntPtr length, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg);

        [DllImport(libraryPath, EntryPoint = "lto_module_create_from_fd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_from_fd(int fd, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("size_t")] UIntPtr file_size);

        [DllImport(libraryPath, EntryPoint = "lto_module_create_from_fd_at_offset", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_module_t")]
        public static extern LLVMOpaqueLTOModule* lto_module_create_from_fd_at_offset(int fd, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("size_t")] UIntPtr file_size, [NativeTypeName("size_t")] UIntPtr map_size, [NativeTypeName("off_t")] int offset);

        [DllImport(libraryPath, EntryPoint = "lto_module_dispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_module_dispose([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport(libraryPath, EntryPoint = "lto_module_get_target_triple", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lto_module_get_target_triple([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport(libraryPath, EntryPoint = "lto_module_set_target_triple", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_module_set_target_triple([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod, [NativeTypeName("const char *")] sbyte* triple);

        [DllImport(libraryPath, EntryPoint = "lto_module_get_num_symbols", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint lto_module_get_num_symbols([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport(libraryPath, EntryPoint = "lto_module_get_symbol_name", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lto_module_get_symbol_name([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod, [NativeTypeName("unsigned int")] uint index);

        [DllImport(libraryPath, EntryPoint = "lto_module_get_symbol_attribute", CallingConvention = CallingConvention.Cdecl)]
        public static extern lto_symbol_attributes lto_module_get_symbol_attribute([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod, [NativeTypeName("unsigned int")] uint index);

        [DllImport(libraryPath, EntryPoint = "lto_module_get_linkeropts", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* lto_module_get_linkeropts([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_set_diagnostic_handler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_set_diagnostic_handler([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* param0, [NativeTypeName("lto_diagnostic_handler_t")] IntPtr param1, [NativeTypeName("void *")] void* param2);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_create", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_code_gen_t")]
        public static extern LLVMOpaqueLTOCodeGenerator* lto_codegen_create();

        [DllImport(libraryPath, EntryPoint = "lto_codegen_create_in_local_context", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_code_gen_t")]
        public static extern LLVMOpaqueLTOCodeGenerator* lto_codegen_create_in_local_context();

        [DllImport(libraryPath, EntryPoint = "lto_codegen_dispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_dispose([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* param0);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_add_module", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_codegen_add_module([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_set_module", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_set_module([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_set_debug_model", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_codegen_set_debug_model([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, lto_debug_model param1);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_set_pic_model", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_codegen_set_pic_model([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, lto_codegen_model param1);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_set_cpu", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_set_cpu([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* cpu);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_set_assembler_path", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_set_assembler_path([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* path);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_set_assembler_args", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_set_assembler_args([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char **")] sbyte** args, int nargs);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_add_must_preserve_symbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_add_must_preserve_symbol([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* symbol);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_write_merged_modules", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_codegen_write_merged_modules([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* path);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_compile", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const void *")]
        public static extern void* lto_codegen_compile([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("size_t *")] UIntPtr* length);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_compile_to_file", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_codegen_compile_to_file([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char **")] sbyte** name);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_optimize", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_codegen_optimize([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_compile_optimized", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const void *")]
        public static extern void* lto_codegen_compile_optimized([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("size_t *")] UIntPtr* length);

        [DllImport(libraryPath, EntryPoint = "lto_api_version", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint lto_api_version();

        [DllImport(libraryPath, EntryPoint = "lto_codegen_debug_options", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_debug_options([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* param1);

        [DllImport(libraryPath, EntryPoint = "lto_initialize_disassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_initialize_disassembler();

        [DllImport(libraryPath, EntryPoint = "lto_codegen_set_should_internalize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_set_should_internalize([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("lto_bool_t")] bool ShouldInternalize);

        [DllImport(libraryPath, EntryPoint = "lto_codegen_set_should_embed_uselists", CallingConvention = CallingConvention.Cdecl)]
        public static extern void lto_codegen_set_should_embed_uselists([NativeTypeName("lto_code_gen_t")] LLVMOpaqueLTOCodeGenerator* cg, [NativeTypeName("lto_bool_t")] bool ShouldEmbedUselists);

        [DllImport(libraryPath, EntryPoint = "thinlto_create_codegen", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("thinlto_code_gen_t")]
        public static extern LLVMOpaqueThinLTOCodeGenerator* thinlto_create_codegen();

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_dispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_dispose([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_add_module", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_add_module([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* identifier, [NativeTypeName("const char *")] sbyte* data, int length);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_process", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_process([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg);

        [DllImport(libraryPath, EntryPoint = "thinlto_module_get_num_objects", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint thinlto_module_get_num_objects([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg);

        [DllImport(libraryPath, EntryPoint = "thinlto_module_get_object", CallingConvention = CallingConvention.Cdecl)]
        public static extern LTOObjectBuffer thinlto_module_get_object([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint index);

        [DllImport(libraryPath, EntryPoint = "thinlto_module_get_num_object_files", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint thinlto_module_get_num_object_files([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg);

        [DllImport(libraryPath, EntryPoint = "thinlto_module_get_object_file", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* thinlto_module_get_object_file([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint index);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_set_pic_model", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool thinlto_codegen_set_pic_model([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, lto_codegen_model param1);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_set_savetemps_dir", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_set_savetemps_dir([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* save_temps_dir);

        [DllImport(libraryPath, EntryPoint = "thinlto_set_generated_objects_dir", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_set_generated_objects_dir([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* save_temps_dir);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_set_cpu", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_set_cpu([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* cpu);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_disable_codegen", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_disable_codegen([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("lto_bool_t")] bool disable);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_set_codegen_only", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_set_codegen_only([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("lto_bool_t")] bool codegen_only);

        [DllImport(libraryPath, EntryPoint = "thinlto_debug_options", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_debug_options([NativeTypeName("const char *const *")] sbyte** options, int number);

        [DllImport(libraryPath, EntryPoint = "lto_module_is_thinlto", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("lto_bool_t")]
        public static extern bool lto_module_is_thinlto([NativeTypeName("lto_module_t")] LLVMOpaqueLTOModule* mod);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_add_must_preserve_symbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_add_must_preserve_symbol([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* name, int length);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_add_cross_referenced_symbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_add_cross_referenced_symbol([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* name, int length);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_set_cache_dir", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_set_cache_dir([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("const char *")] sbyte* cache_dir);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_set_cache_pruning_interval", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_set_cache_pruning_interval([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, int interval);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_set_final_cache_size_relative_to_available_space", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_set_final_cache_size_relative_to_available_space([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint percentage);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_set_cache_entry_expiration", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_set_cache_entry_expiration([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint expiration);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_set_cache_size_bytes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_set_cache_size_bytes([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint max_size_bytes);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_set_cache_size_megabytes", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_set_cache_size_megabytes([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint max_size_megabytes);

        [DllImport(libraryPath, EntryPoint = "thinlto_codegen_set_cache_size_files", CallingConvention = CallingConvention.Cdecl)]
        public static extern void thinlto_codegen_set_cache_size_files([NativeTypeName("thinlto_code_gen_t")] LLVMOpaqueThinLTOCodeGenerator* cg, [NativeTypeName("unsigned int")] uint max_size_files);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateObjectFile", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMObjectFileRef")]
        public static extern LLVMOpaqueObjectFile* CreateObjectFile([NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* MemBuf);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeObjectFile", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeObjectFile([NativeTypeName("LLVMObjectFileRef")] LLVMOpaqueObjectFile* ObjectFile);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSections", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMSectionIteratorRef")]
        public static extern LLVMOpaqueSectionIterator* GetSections([NativeTypeName("LLVMObjectFileRef")] LLVMOpaqueObjectFile* ObjectFile);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeSectionIterator", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeSectionIterator([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMIsSectionIteratorAtEnd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsSectionIteratorAtEnd([NativeTypeName("LLVMObjectFileRef")] LLVMOpaqueObjectFile* ObjectFile, [NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMMoveToNextSection", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveToNextSection([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMMoveToContainingSection", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveToContainingSection([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* Sect, [NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* Sym);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSymbols", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMSymbolIteratorRef")]
        public static extern LLVMOpaqueSymbolIterator* GetSymbols([NativeTypeName("LLVMObjectFileRef")] LLVMOpaqueObjectFile* ObjectFile);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeSymbolIterator", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeSymbolIterator([NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMIsSymbolIteratorAtEnd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsSymbolIteratorAtEnd([NativeTypeName("LLVMObjectFileRef")] LLVMOpaqueObjectFile* ObjectFile, [NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMMoveToNextSymbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveToNextSymbol([NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSectionName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetSectionName([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSectionSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetSectionSize([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSectionContents", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetSectionContents([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSectionAddress", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetSectionAddress([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSectionContainsSymbol", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetSectionContainsSymbol([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* SI, [NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* Sym);

        [DllImport(libraryPath, EntryPoint = "LLVMGetRelocations", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMRelocationIteratorRef")]
        public static extern LLVMOpaqueRelocationIterator* GetRelocations([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* Section);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeRelocationIterator", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeRelocationIterator([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport(libraryPath, EntryPoint = "LLVMIsRelocationIteratorAtEnd", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int IsRelocationIteratorAtEnd([NativeTypeName("LLVMSectionIteratorRef")] LLVMOpaqueSectionIterator* Section, [NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport(libraryPath, EntryPoint = "LLVMMoveToNextRelocation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MoveToNextRelocation([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSymbolName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetSymbolName([NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSymbolAddress", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetSymbolAddress([NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetSymbolSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetSymbolSize([NativeTypeName("LLVMSymbolIteratorRef")] LLVMOpaqueSymbolIterator* SI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetRelocationOffset", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetRelocationOffset([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetRelocationSymbol", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMSymbolIteratorRef")]
        public static extern LLVMOpaqueSymbolIterator* GetRelocationSymbol([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetRelocationType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint64_t")]
        public static extern ulong GetRelocationType([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetRelocationTypeName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetRelocationTypeName([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport(libraryPath, EntryPoint = "LLVMGetRelocationValueString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetRelocationValueString([NativeTypeName("LLVMRelocationIteratorRef")] LLVMOpaqueRelocationIterator* RI);

        [DllImport(libraryPath, EntryPoint = "LLVMOptRemarkParserCreate", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMOptRemarkParserRef")]
        public static extern LLVMOptRemarkOpaqueParser* OptRemarkParserCreate([NativeTypeName("const void *")] void* Buf, [NativeTypeName("uint64_t")] ulong Size);

        [DllImport(libraryPath, EntryPoint = "LLVMOptRemarkParserGetNext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMOptRemarkEntry *")]
        public static extern LLVMOptRemarkEntry* OptRemarkParserGetNext([NativeTypeName("LLVMOptRemarkParserRef")] LLVMOptRemarkOpaqueParser* Parser);

        [DllImport(libraryPath, EntryPoint = "LLVMOptRemarkParserHasError", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int OptRemarkParserHasError([NativeTypeName("LLVMOptRemarkParserRef")] LLVMOptRemarkOpaqueParser* Parser);

        [DllImport(libraryPath, EntryPoint = "LLVMOptRemarkParserGetErrorMessage", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* OptRemarkParserGetErrorMessage([NativeTypeName("LLVMOptRemarkParserRef")] LLVMOptRemarkOpaqueParser* Parser);

        [DllImport(libraryPath, EntryPoint = "LLVMOptRemarkParserDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void OptRemarkParserDispose([NativeTypeName("LLVMOptRemarkParserRef")] LLVMOptRemarkOpaqueParser* Parser);

        [DllImport(libraryPath, EntryPoint = "LLVMOptRemarkVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint OptRemarkVersion();

        [DllImport(libraryPath, EntryPoint = "LLVMOrcCreateInstance", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMOrcJITStackRef")]
        public static extern LLVMOrcOpaqueJITStack* OrcCreateInstance([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* TM);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcGetErrorMsg", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* OrcGetErrorMsg([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcGetMangledSymbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void OrcGetMangledSymbol([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("char **")] sbyte** MangledSymbol, [NativeTypeName("const char *")] sbyte* Symbol);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcDisposeMangledSymbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void OrcDisposeMangledSymbol([NativeTypeName("char *")] sbyte* MangledSymbol);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcCreateLazyCompileCallback", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcCreateLazyCompileCallback([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcTargetAddress *")] ulong* RetAddr, [NativeTypeName("LLVMOrcLazyCompileCallbackFn")] IntPtr Callback, [NativeTypeName("void *")] void* CallbackCtx);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcCreateIndirectStub", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcCreateIndirectStub([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("const char *")] sbyte* StubName, [NativeTypeName("LLVMOrcTargetAddress")] ulong InitAddr);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcSetIndirectStubPointer", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcSetIndirectStubPointer([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("const char *")] sbyte* StubName, [NativeTypeName("LLVMOrcTargetAddress")] ulong NewAddr);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcAddEagerlyCompiledIR", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcAddEagerlyCompiledIR([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcModuleHandle *")] ulong* RetHandle, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Mod, [NativeTypeName("LLVMOrcSymbolResolverFn")] IntPtr SymbolResolver, [NativeTypeName("void *")] void* SymbolResolverCtx);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcAddLazilyCompiledIR", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcAddLazilyCompiledIR([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcModuleHandle *")] ulong* RetHandle, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* Mod, [NativeTypeName("LLVMOrcSymbolResolverFn")] IntPtr SymbolResolver, [NativeTypeName("void *")] void* SymbolResolverCtx);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcAddObjectFile", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcAddObjectFile([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcModuleHandle *")] ulong* RetHandle, [NativeTypeName("LLVMMemoryBufferRef")] LLVMOpaqueMemoryBuffer* Obj, [NativeTypeName("LLVMOrcSymbolResolverFn")] IntPtr SymbolResolver, [NativeTypeName("void *")] void* SymbolResolverCtx);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcRemoveModule", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcRemoveModule([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcModuleHandle")] ulong H);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcGetSymbolAddress", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcGetSymbolAddress([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcTargetAddress *")] ulong* RetAddr, [NativeTypeName("const char *")] sbyte* SymbolName);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcGetSymbolAddressIn", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcGetSymbolAddressIn([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMOrcTargetAddress *")] ulong* RetAddr, [NativeTypeName("LLVMOrcModuleHandle")] ulong H, [NativeTypeName("const char *")] sbyte* SymbolName);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcDisposeInstance", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMErrorRef")]
        public static extern LLVMOpaqueError* OrcDisposeInstance([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcRegisterJITEventListener", CallingConvention = CallingConvention.Cdecl)]
        public static extern void OrcRegisterJITEventListener([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMJITEventListenerRef")] LLVMOpaqueJITEventListener* L);

        [DllImport(libraryPath, EntryPoint = "LLVMOrcUnregisterJITEventListener", CallingConvention = CallingConvention.Cdecl)]
        public static extern void OrcUnregisterJITEventListener([NativeTypeName("LLVMOrcJITStackRef")] LLVMOrcOpaqueJITStack* JITStack, [NativeTypeName("LLVMJITEventListenerRef")] LLVMOpaqueJITEventListener* L);

        [DllImport(libraryPath, EntryPoint = "LLVMLoadLibraryPermanently", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int LoadLibraryPermanently([NativeTypeName("const char *")] sbyte* Filename);

        [DllImport(libraryPath, EntryPoint = "LLVMParseCommandLineOptions", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ParseCommandLineOptions(int argc, [NativeTypeName("const char *const *")] sbyte** argv, [NativeTypeName("const char *")] sbyte* Overview);

        [DllImport(libraryPath, EntryPoint = "LLVMSearchForAddressOfSymbol", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("void *")]
        public static extern void* SearchForAddressOfSymbol([NativeTypeName("const char *")] sbyte* symbolName);

        [DllImport(libraryPath, EntryPoint = "LLVMAddSymbol", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddSymbol([NativeTypeName("const char *")] sbyte* symbolName, [NativeTypeName("void *")] void* symbolValue);

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAArch64TargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64TargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAMDGPUTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAMDGPUTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeARMTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeBPFTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeBPFTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeHexagonTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeHexagonTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeLanaiTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeLanaiTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMipsTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMSP430TargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMSP430TargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeNVPTXTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeNVPTXTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializePowerPCTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSparcTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSystemZTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeWebAssemblyTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeWebAssemblyTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeX86TargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86TargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeXCoreTargetInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeXCoreTargetInfo();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAArch64Target", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64Target();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAMDGPUTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAMDGPUTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeARMTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeBPFTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeBPFTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeHexagonTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeHexagonTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeLanaiTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeLanaiTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMipsTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMSP430Target", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMSP430Target();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeNVPTXTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeNVPTXTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializePowerPCTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSparcTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSystemZTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeWebAssemblyTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeWebAssemblyTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeX86Target", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86Target();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeXCoreTarget", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeXCoreTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAArch64TargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64TargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAMDGPUTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAMDGPUTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeARMTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeBPFTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeBPFTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeHexagonTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeHexagonTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeLanaiTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeLanaiTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMipsTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMSP430TargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMSP430TargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeNVPTXTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeNVPTXTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializePowerPCTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSparcTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSystemZTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeWebAssemblyTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeWebAssemblyTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeX86TargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86TargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeXCoreTargetMC", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeXCoreTargetMC();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAArch64AsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64AsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAMDGPUAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAMDGPUAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeARMAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeBPFAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeBPFAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeHexagonAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeHexagonAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeLanaiAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeLanaiAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMipsAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMSP430AsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMSP430AsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeNVPTXAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeNVPTXAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializePowerPCAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSparcAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSystemZAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeWebAssemblyAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeWebAssemblyAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeX86AsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86AsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeXCoreAsmPrinter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeXCoreAsmPrinter();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAArch64AsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64AsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAMDGPUAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAMDGPUAsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeARMAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMAsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeBPFAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeBPFAsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeHexagonAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeHexagonAsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeLanaiAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeLanaiAsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMipsAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsAsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMSP430AsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMSP430AsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializePowerPCAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCAsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSparcAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcAsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSystemZAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZAsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeWebAssemblyAsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeWebAssemblyAsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeX86AsmParser", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86AsmParser();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAArch64Disassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAArch64Disassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeAMDGPUDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeAMDGPUDisassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeARMDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeARMDisassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeBPFDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeBPFDisassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeHexagonDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeHexagonDisassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeLanaiDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeLanaiDisassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMipsDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMipsDisassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeMSP430Disassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeMSP430Disassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializePowerPCDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializePowerPCDisassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSparcDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSparcDisassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeSystemZDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSystemZDisassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeWebAssemblyDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeWebAssemblyDisassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeX86Disassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeX86Disassembler();

        [DllImport(libraryPath, EntryPoint = "LLVMInitializeXCoreDisassembler", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeXCoreDisassembler();

        public static void InitializeAllTargetInfos()
        {
            InitializeAArch64TargetInfo();
            InitializeAMDGPUTargetInfo();
            InitializeARMTargetInfo();
            InitializeBPFTargetInfo();
            InitializeHexagonTargetInfo();
            InitializeLanaiTargetInfo();
            InitializeMipsTargetInfo();
            InitializeMSP430TargetInfo();
            InitializeNVPTXTargetInfo();
            InitializePowerPCTargetInfo();
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
            InitializeBPFTarget();
            InitializeHexagonTarget();
            InitializeLanaiTarget();
            InitializeMipsTarget();
            InitializeMSP430Target();
            InitializeNVPTXTarget();
            InitializePowerPCTarget();
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
            InitializeBPFTargetMC();
            InitializeHexagonTargetMC();
            InitializeLanaiTargetMC();
            InitializeMipsTargetMC();
            InitializeMSP430TargetMC();
            InitializeNVPTXTargetMC();
            InitializePowerPCTargetMC();
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
            InitializeBPFAsmPrinter();
            InitializeHexagonAsmPrinter();
            InitializeLanaiAsmPrinter();
            InitializeMipsAsmPrinter();
            InitializeMSP430AsmPrinter();
            InitializeNVPTXAsmPrinter();
            InitializePowerPCAsmPrinter();
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
            InitializeBPFAsmParser();
            InitializeHexagonAsmParser();
            InitializeLanaiAsmParser();
            InitializeMipsAsmParser();
            InitializeMSP430AsmParser();
            InitializePowerPCAsmParser();
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
            InitializeBPFDisassembler();
            InitializeHexagonDisassembler();
            InitializeLanaiDisassembler();
            InitializeMipsDisassembler();
            InitializeMSP430Disassembler();
            InitializePowerPCDisassembler();
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

        [DllImport(libraryPath, EntryPoint = "LLVMGetModuleDataLayout", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTargetDataRef")]
        public static extern LLVMOpaqueTargetData* GetModuleDataLayout([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M);

        [DllImport(libraryPath, EntryPoint = "LLVMSetModuleDataLayout", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetModuleDataLayout([NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* DL);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateTargetData", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTargetDataRef")]
        public static extern LLVMOpaqueTargetData* CreateTargetData([NativeTypeName("const char *")] sbyte* StringRep);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeTargetData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeTargetData([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport(libraryPath, EntryPoint = "LLVMAddTargetLibraryInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddTargetLibraryInfo([NativeTypeName("LLVMTargetLibraryInfoRef")] LLVMOpaqueTargetLibraryInfotData* TLI, [NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMCopyStringRepOfTargetData", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* CopyStringRepOfTargetData([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport(libraryPath, EntryPoint = "LLVMByteOrder", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("enum LLVMByteOrdering")]
        public static extern LLVMByteOrdering ByteOrder([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport(libraryPath, EntryPoint = "LLVMPointerSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint PointerSize([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport(libraryPath, EntryPoint = "LLVMPointerSizeForAS", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint PointerSizeForAS([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("unsigned int")] uint AS);

        [DllImport(libraryPath, EntryPoint = "LLVMIntPtrType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntPtrType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport(libraryPath, EntryPoint = "LLVMIntPtrTypeForAS", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntPtrTypeForAS([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("unsigned int")] uint AS);

        [DllImport(libraryPath, EntryPoint = "LLVMIntPtrTypeInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntPtrTypeInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD);

        [DllImport(libraryPath, EntryPoint = "LLVMIntPtrTypeForASInContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTypeRef")]
        public static extern LLVMOpaqueType* IntPtrTypeForASInContext([NativeTypeName("LLVMContextRef")] LLVMOpaqueContext* C, [NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("unsigned int")] uint AS);

        [DllImport(libraryPath, EntryPoint = "LLVMSizeOfTypeInBits", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong SizeOfTypeInBits([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMStoreSizeOfType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong StoreSizeOfType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMABISizeOfType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong ABISizeOfType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMABIAlignmentOfType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint ABIAlignmentOfType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMCallFrameAlignmentOfType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint CallFrameAlignmentOfType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMPreferredAlignmentOfType", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint PreferredAlignmentOfType([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* Ty);

        [DllImport(libraryPath, EntryPoint = "LLVMPreferredAlignmentOfGlobal", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint PreferredAlignmentOfGlobal([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMValueRef")] LLVMOpaqueValue* GlobalVar);

        [DllImport(libraryPath, EntryPoint = "LLVMElementAtOffset", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint ElementAtOffset([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("unsigned long long")] ulong Offset);

        [DllImport(libraryPath, EntryPoint = "LLVMOffsetOfElement", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong OffsetOfElement([NativeTypeName("LLVMTargetDataRef")] LLVMOpaqueTargetData* TD, [NativeTypeName("LLVMTypeRef")] LLVMOpaqueType* StructTy, [NativeTypeName("unsigned int")] uint Element);

        [DllImport(libraryPath, EntryPoint = "LLVMGetFirstTarget", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTargetRef")]
        public static extern LLVMTarget* GetFirstTarget();

        [DllImport(libraryPath, EntryPoint = "LLVMGetNextTarget", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTargetRef")]
        public static extern LLVMTarget* GetNextTarget([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetFromName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTargetRef")]
        public static extern LLVMTarget* GetTargetFromName([NativeTypeName("const char *")] sbyte* Name);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetFromTriple", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int GetTargetFromTriple([NativeTypeName("const char *")] sbyte* Triple, [NativeTypeName("LLVMTargetRef *")] LLVMTarget** T, [NativeTypeName("char **")] sbyte** ErrorMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetTargetName([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetDescription", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* GetTargetDescription([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport(libraryPath, EntryPoint = "LLVMTargetHasJIT", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TargetHasJIT([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport(libraryPath, EntryPoint = "LLVMTargetHasTargetMachine", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TargetHasTargetMachine([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport(libraryPath, EntryPoint = "LLVMTargetHasAsmBackend", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TargetHasAsmBackend([NativeTypeName("LLVMTargetRef")] LLVMTarget* T);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateTargetMachine", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTargetMachineRef")]
        public static extern LLVMOpaqueTargetMachine* CreateTargetMachine([NativeTypeName("LLVMTargetRef")] LLVMTarget* T, [NativeTypeName("const char *")] sbyte* Triple, [NativeTypeName("const char *")] sbyte* CPU, [NativeTypeName("const char *")] sbyte* Features, LLVMCodeGenOptLevel Level, LLVMRelocMode Reloc, LLVMCodeModel CodeModel);

        [DllImport(libraryPath, EntryPoint = "LLVMDisposeTargetMachine", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisposeTargetMachine([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetMachineTarget", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTargetRef")]
        public static extern LLVMTarget* GetTargetMachineTarget([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetMachineTriple", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetTargetMachineTriple([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetMachineCPU", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetTargetMachineCPU([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport(libraryPath, EntryPoint = "LLVMGetTargetMachineFeatureString", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetTargetMachineFeatureString([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport(libraryPath, EntryPoint = "LLVMCreateTargetDataLayout", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMTargetDataRef")]
        public static extern LLVMOpaqueTargetData* CreateTargetDataLayout([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T);

        [DllImport(libraryPath, EntryPoint = "LLVMSetTargetMachineAsmVerbosity", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetTargetMachineAsmVerbosity([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T, [NativeTypeName("LLVMBool")] int VerboseAsm);

        [DllImport(libraryPath, EntryPoint = "LLVMTargetMachineEmitToFile", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TargetMachineEmitToFile([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, [NativeTypeName("char *")] sbyte* Filename, LLVMCodeGenFileType codegen, [NativeTypeName("char **")] sbyte** ErrorMessage);

        [DllImport(libraryPath, EntryPoint = "LLVMTargetMachineEmitToMemoryBuffer", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMBool")]
        public static extern int TargetMachineEmitToMemoryBuffer([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T, [NativeTypeName("LLVMModuleRef")] LLVMOpaqueModule* M, LLVMCodeGenFileType codegen, [NativeTypeName("char **")] sbyte** ErrorMessage, [NativeTypeName("LLVMMemoryBufferRef *")] LLVMOpaqueMemoryBuffer** OutMemBuf);

        [DllImport(libraryPath, EntryPoint = "LLVMGetDefaultTargetTriple", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetDefaultTargetTriple();

        [DllImport(libraryPath, EntryPoint = "LLVMNormalizeTargetTriple", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* NormalizeTargetTriple([NativeTypeName("const char *")] sbyte* triple);

        [DllImport(libraryPath, EntryPoint = "LLVMGetHostCPUName", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetHostCPUName();

        [DllImport(libraryPath, EntryPoint = "LLVMGetHostCPUFeatures", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("char *")]
        public static extern sbyte* GetHostCPUFeatures();

        [DllImport(libraryPath, EntryPoint = "LLVMAddAnalysisPasses", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAnalysisPasses([NativeTypeName("LLVMTargetMachineRef")] LLVMOpaqueTargetMachine* T, [NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddAggressiveInstCombinerPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAggressiveInstCombinerPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddCoroEarlyPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCoroEarlyPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddCoroSplitPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCoroSplitPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddCoroElidePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCoroElidePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddCoroCleanupPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCoroCleanupPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddInstructionCombiningPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddInstructionCombiningPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddArgumentPromotionPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddArgumentPromotionPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddConstantMergePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddConstantMergePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddCalledValuePropagationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCalledValuePropagationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddDeadArgEliminationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddDeadArgEliminationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddFunctionAttrsPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddFunctionAttrsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddFunctionInliningPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddFunctionInliningPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddAlwaysInlinerPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAlwaysInlinerPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddGlobalDCEPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddGlobalDCEPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddGlobalOptimizerPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddGlobalOptimizerPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddIPConstantPropagationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddIPConstantPropagationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddPruneEHPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddPruneEHPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddIPSCCPPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddIPSCCPPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddInternalizePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddInternalizePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* param0, [NativeTypeName("unsigned int")] uint AllButMain);

        [DllImport(libraryPath, EntryPoint = "LLVMAddStripDeadPrototypesPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddStripDeadPrototypesPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddStripSymbolsPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddStripSymbolsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMPassManagerBuilderCreate", CallingConvention = CallingConvention.Cdecl)]
        [return: NativeTypeName("LLVMPassManagerBuilderRef")]
        public static extern LLVMOpaquePassManagerBuilder* PassManagerBuilderCreate();

        [DllImport(libraryPath, EntryPoint = "LLVMPassManagerBuilderDispose", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderDispose([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB);

        [DllImport(libraryPath, EntryPoint = "LLVMPassManagerBuilderSetOptLevel", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderSetOptLevel([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("unsigned int")] uint OptLevel);

        [DllImport(libraryPath, EntryPoint = "LLVMPassManagerBuilderSetSizeLevel", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderSetSizeLevel([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("unsigned int")] uint SizeLevel);

        [DllImport(libraryPath, EntryPoint = "LLVMPassManagerBuilderSetDisableUnitAtATime", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderSetDisableUnitAtATime([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMBool")] int Value);

        [DllImport(libraryPath, EntryPoint = "LLVMPassManagerBuilderSetDisableUnrollLoops", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderSetDisableUnrollLoops([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMBool")] int Value);

        [DllImport(libraryPath, EntryPoint = "LLVMPassManagerBuilderSetDisableSimplifyLibCalls", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderSetDisableSimplifyLibCalls([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMBool")] int Value);

        [DllImport(libraryPath, EntryPoint = "LLVMPassManagerBuilderUseInlinerWithThreshold", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderUseInlinerWithThreshold([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("unsigned int")] uint Threshold);

        [DllImport(libraryPath, EntryPoint = "LLVMPassManagerBuilderPopulateFunctionPassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderPopulateFunctionPassManager([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMPassManagerBuilderPopulateModulePassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderPopulateModulePassManager([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMPassManagerBuilderPopulateLTOPassManager", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PassManagerBuilderPopulateLTOPassManager([NativeTypeName("LLVMPassManagerBuilderRef")] LLVMOpaquePassManagerBuilder* PMB, [NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM, [NativeTypeName("LLVMBool")] int Internalize, [NativeTypeName("LLVMBool")] int RunInliner);

        [DllImport(libraryPath, EntryPoint = "LLVMAddAggressiveDCEPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAggressiveDCEPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddBitTrackingDCEPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddBitTrackingDCEPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddAlignmentFromAssumptionsPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddAlignmentFromAssumptionsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddCFGSimplificationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCFGSimplificationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddDeadStoreEliminationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddDeadStoreEliminationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddScalarizerPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddScalarizerPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddMergedLoadStoreMotionPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddMergedLoadStoreMotionPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddGVNPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddGVNPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddNewGVNPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddNewGVNPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddIndVarSimplifyPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddIndVarSimplifyPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddJumpThreadingPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddJumpThreadingPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLICMPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLICMPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLoopDeletionPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopDeletionPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLoopIdiomPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopIdiomPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLoopRotatePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopRotatePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLoopRerollPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopRerollPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLoopUnrollPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopUnrollPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLoopUnrollAndJamPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopUnrollAndJamPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLoopUnswitchPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopUnswitchPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLowerAtomicPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLowerAtomicPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddMemCpyOptPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddMemCpyOptPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddPartiallyInlineLibCallsPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddPartiallyInlineLibCallsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddReassociatePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddReassociatePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddSCCPPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddSCCPPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddScalarReplAggregatesPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddScalarReplAggregatesPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddScalarReplAggregatesPassSSA", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddScalarReplAggregatesPassSSA([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddScalarReplAggregatesPassWithThreshold", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddScalarReplAggregatesPassWithThreshold([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM, int Threshold);

        [DllImport(libraryPath, EntryPoint = "LLVMAddSimplifyLibCallsPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddSimplifyLibCallsPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddTailCallEliminationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddTailCallEliminationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddConstantPropagationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddConstantPropagationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddDemoteMemoryToRegisterPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddDemoteMemoryToRegisterPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddVerifierPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddVerifierPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddCorrelatedValuePropagationPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCorrelatedValuePropagationPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddEarlyCSEPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddEarlyCSEPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddEarlyCSEMemSSAPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddEarlyCSEMemSSAPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLowerExpectIntrinsicPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLowerExpectIntrinsicPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddTypeBasedAliasAnalysisPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddTypeBasedAliasAnalysisPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddScopedNoAliasAAPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddScopedNoAliasAAPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddBasicAliasAnalysisPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddBasicAliasAnalysisPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddUnifyFunctionExitNodesPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddUnifyFunctionExitNodesPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLowerSwitchPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLowerSwitchPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddPromoteMemoryToRegisterPass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddPromoteMemoryToRegisterPass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddLoopVectorizePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddLoopVectorizePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);

        [DllImport(libraryPath, EntryPoint = "LLVMAddSLPVectorizePass", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddSLPVectorizePass([NativeTypeName("LLVMPassManagerRef")] LLVMOpaquePassManager* PM);
    }
}
