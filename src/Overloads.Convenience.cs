using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    partial class LLVM
    {
        public static LLVMValueRef[] GetNamedMetadataOperands(LLVMModuleRef m, string name)
        {
            uint count = GetNamedMetadataNumOperands(m, name);
            var buffer = new LLVMValueRef[count];

            if (count > 0)
            {
                GetNamedMetadataOperands(m, name, out buffer[0]);
            }

            return buffer;
        }

        public static LLVMTypeRef FunctionType(LLVMTypeRef returnType, LLVMTypeRef[] paramTypes, LLVMBool isVarArg)
        {
            if (paramTypes.Length == 0)
            {
                return FunctionType(returnType, out LLVMTypeRef dummy, 0, isVarArg);
            }

            return FunctionType(returnType, out paramTypes[0], (uint)paramTypes.Length, isVarArg);
        }

        public static LLVMTypeRef[] GetParamTypes(LLVMTypeRef functionTy)
        {
            uint count = CountParamTypes(functionTy);
            var buffer = new LLVMTypeRef[count];

            if (count > 0)
            {
                GetParamTypes(functionTy, out buffer[0]);
            }

            return buffer;
        }

        public static LLVMTypeRef StructTypeInContext(LLVMContextRef c, LLVMTypeRef[] elementTypes, LLVMBool packed)
        {
            if (elementTypes.Length == 0)
            {
                return StructTypeInContext(c, out LLVMTypeRef dummy, 0, packed);
            }

            return StructTypeInContext(c, out elementTypes[0], (uint)elementTypes.Length, packed);
        }

        public static LLVMTypeRef StructType(LLVMTypeRef[] elementTypes, LLVMBool packed)
        {
            if (elementTypes.Length == 0)
            {
                return StructType(out LLVMTypeRef dummy, 0, packed);
            }

            return StructType(out elementTypes[0], (uint)elementTypes.Length, packed);
        }

        public static void StructSetBody(LLVMTypeRef structTy, LLVMTypeRef[] elementTypes, LLVMBool packed)
        {
            if (elementTypes.Length == 0)
            {
                StructSetBody(structTy, out LLVMTypeRef dummy, 0, packed);
                return;
            }

            StructSetBody(structTy, out elementTypes[0], (uint)elementTypes.Length, packed);
        }

        public static LLVMTypeRef[] GetStructElementTypes(LLVMTypeRef structTy)
        {
            uint count = CountStructElementTypes(structTy);
            var buffer = new LLVMTypeRef[count];

            if (count > 0)
            {
                GetStructElementTypes(structTy, out buffer[0]);
            }

            return buffer;
        }

        public static LLVMValueRef ConstStructInContext(LLVMContextRef c, LLVMValueRef[] constantVals, LLVMBool packed)
        {
            if (constantVals.Length == 0)
            {
                return ConstStructInContext(c, out LLVMValueRef dummy, 0, packed);
            }

            return ConstStructInContext(c, out constantVals[0], (uint)constantVals.Length, packed);
        }

        public static LLVMValueRef ConstStruct(LLVMValueRef[] constantVals, LLVMBool packed)
        {
            if (constantVals.Length == 0)
            {
                return ConstStruct(out LLVMValueRef dummy, 0, packed);
            }

            return ConstStruct(out constantVals[0], (uint)constantVals.Length, packed);
        }

        public static LLVMValueRef ConstArray(LLVMTypeRef elementTy, LLVMValueRef[] constantVals)
        {
            if (constantVals.Length == 0)
            {
                return ConstArray(elementTy, out LLVMValueRef dummy, 0);
            }

            return ConstArray(elementTy, out constantVals[0], (uint)constantVals.Length);
        }

        public static LLVMValueRef ConstNamedStruct(LLVMTypeRef structTy, LLVMValueRef[] constantVals)
        {
            if (constantVals.Length == 0)
            {
                return ConstNamedStruct(structTy, out LLVMValueRef dummy, 0);
            }

            return ConstNamedStruct(structTy, out constantVals[0], (uint)constantVals.Length);
        }

        public static LLVMValueRef ConstVector(LLVMValueRef[] scalarConstantVars)
        {
            if (scalarConstantVars.Length == 0)
            {
                return ConstVector(out LLVMValueRef dummy, 0);
            }

            return ConstVector(out scalarConstantVars[0], (uint)scalarConstantVars.Length);
        }

        public static LLVMValueRef ConstGEP(LLVMValueRef constantVal, LLVMValueRef[] constantIndices)
        {
            if (constantIndices.Length == 0)
            {
                return ConstGEP(constantVal, out LLVMValueRef dummy, 0);
            }

            return ConstGEP(constantVal, out constantIndices[0], (uint)constantIndices.Length);
        }

        public static LLVMValueRef ConstInBoundsGEP(LLVMValueRef constantVal, LLVMValueRef[] constantIndices)
        {
            if (constantIndices.Length == 0)
            {
                return ConstInBoundsGEP(constantVal, out LLVMValueRef dummy, 0);
            }

            return ConstInBoundsGEP(constantVal, out constantIndices[0], (uint)constantIndices.Length);
        }

        public static LLVMValueRef ConstExtractValue(LLVMValueRef aggConstant, uint[] idxList)
        {
            if (idxList.Length == 0)
            {
                return ConstExtractValue(aggConstant, out uint dummy, 0);
            }

            return ConstExtractValue(aggConstant, out idxList[0], (uint)idxList.Length);
        }

        public static LLVMValueRef ConstInsertValue(LLVMValueRef aggConstant, LLVMValueRef elementValueConstant, uint[] idxList)
        {
            if (idxList.Length == 0)
            {
                return ConstInsertValue(aggConstant, elementValueConstant, out uint dummy, 0);
            }

            return ConstInsertValue(aggConstant, elementValueConstant, out idxList[0], (uint)idxList.Length);
        }

        public static LLVMValueRef[] GetParams(LLVMValueRef fn)
        {
            uint count = CountParams(fn);
            var buffer = new LLVMValueRef[count];

            if (count > 0)
            {
                GetParams(fn, out buffer[0]);
            }

            return buffer;
        }

        public static LLVMValueRef MDNodeInContext(LLVMContextRef c, LLVMValueRef[] vals)
        {
            if (vals.Length == 0)
            {
                return MDNodeInContext(c, out LLVMValueRef dummy, 0);
            }

            return MDNodeInContext(c, out vals[0], (uint)vals.Length);
        }

        public static LLVMValueRef MDNode(LLVMValueRef[] vals)
        {
            if (vals.Length == 0)
            {
                return MDNode(out LLVMValueRef dummy, 0);
            }

            return MDNode(out vals[0], (uint)vals.Length);
        }

        public static LLVMValueRef[] GetMDNodeOperands(LLVMValueRef v)
        {
            uint count = GetMDNodeNumOperands(v);
            var buffer = new LLVMValueRef[count];

            if (count > 0)
            {
                GetMDNodeOperands(v, out buffer[0]);
            }

            return buffer;
        }

        public static LLVMBasicBlockRef[] GetBasicBlocks(LLVMValueRef fn)
        {
            uint count = CountBasicBlocks(fn);
            var buffer = new LLVMBasicBlockRef[count];

            if (count > 0)
            {
                GetBasicBlocks(fn, out buffer[0]);
            }

            return buffer;
        }

        public static void AddIncoming(LLVMValueRef phiNode, LLVMValueRef[] incomingValues, LLVMBasicBlockRef[] incomingBlocks, uint count)
        {
            if (count == 0)
            {
                return;
            }

            AddIncoming(phiNode, out incomingValues[0], out incomingBlocks[0], count);
        }

        public static void AddIncoming(LLVMValueRef phiNode, LLVMValueRef[] incomingValues, LLVMBasicBlockRef[] incomingBlocks)
        {
            AddIncoming(phiNode, incomingValues, incomingBlocks, (uint)incomingValues.Length);
        }

        public static LLVMValueRef BuildAggregateRet(LLVMBuilderRef param0, LLVMValueRef[] retVals)
        {
            return BuildAggregateRet(param0, out retVals[0], (uint)retVals.Length);
        }

        public static LLVMValueRef BuildInvoke(LLVMBuilderRef param0, LLVMValueRef fn, LLVMValueRef[] args, LLVMBasicBlockRef then, LLVMBasicBlockRef Catch, string name)
        {
            if (args.Length == 0)
            {
                return BuildInvoke(param0, fn, out LLVMValueRef dummy, 0, then, Catch, name);
            }

            return BuildInvoke(param0, fn, out args[0], (uint)args.Length, then, Catch, name);
        }

        public static LLVMValueRef BuildGEP(LLVMBuilderRef b, LLVMValueRef pointer, LLVMValueRef[] indices, string name)
        {
            if (indices.Length == 0)
            {
                return BuildGEP(b, pointer, out LLVMValueRef dummy, 0, name);
            }

            return BuildGEP(b, pointer, out indices[0], (uint)indices.Length, name);
        }

        public static LLVMValueRef BuildInBoundsGEP(LLVMBuilderRef b, LLVMValueRef pointer, LLVMValueRef[] indices, string name)
        {
            if (indices.Length == 0)
            {
                return BuildInBoundsGEP(b, pointer, out LLVMValueRef dummy, 0, name);
            }

            return BuildInBoundsGEP(b, pointer, out indices[0], (uint)indices.Length, name);
        }

        public static LLVMValueRef BuildCall(LLVMBuilderRef param0, LLVMValueRef fn, LLVMValueRef[] args, string name)
        {
            if (args.Length == 0)
            {
                return BuildCall(param0, fn, out LLVMValueRef dummy, 0, name);
            }

            return BuildCall(param0, fn, out args[0], (uint)args.Length, name);
        }

        public static LLVMGenericValueRef RunFunction(LLVMExecutionEngineRef ee, LLVMValueRef f, LLVMGenericValueRef[] args)
        {
            if (args.Length == 0)
            {
                return RunFunction(ee, f, 0, out LLVMGenericValueRef dummy);
            }

            return RunFunction(ee, f, (uint)args.Length, out args[0]);
        }

        public static LLVMTypeRef FunctionType(LLVMTypeRef ReturnType, LLVMTypeRef[] ParamTypes, bool IsVarArg)
        {
            if (ParamTypes.Length == 0)
            {
                return FunctionType(ReturnType, out LLVMTypeRef dummy, 0, IsVarArg);
            }

            return FunctionType(ReturnType, out ParamTypes[0], (uint)ParamTypes.Length, IsVarArg);
        }

        public static LLVMTypeRef StructTypeInContext(LLVMContextRef C, LLVMTypeRef[] ElementTypes, bool Packed)
        {
            if (ElementTypes.Length == 0)
            {
                return StructTypeInContext(C, out LLVMTypeRef dummy, 0, Packed);
            }

            return StructTypeInContext(C, out ElementTypes[0], (uint)ElementTypes.Length, Packed);
        }

        public static LLVMTypeRef StructType(LLVMTypeRef[] ElementTypes, bool Packed)
        {
            if (ElementTypes.Length == 0)
            {
                return StructType(out LLVMTypeRef dummy, 0, Packed);
            }

            return StructType(out ElementTypes[0], (uint)ElementTypes.Length, Packed);
        }

        public static void StructSetBody(LLVMTypeRef StructTy, LLVMTypeRef[] ElementTypes, bool Packed)
        {
            if (ElementTypes.Length == 0)
            {
                StructSetBody(StructTy, out LLVMTypeRef dummy, 0, Packed);
                return;
            }

            StructSetBody(StructTy, out ElementTypes[0], (uint)ElementTypes.Length, Packed);
        }

        public static LLVMValueRef ConstStructInContext(LLVMContextRef C, LLVMValueRef[] ConstantVals, bool Packed)
        {
            if (ConstantVals.Length == 0)
            {
                return ConstStructInContext(C, out LLVMValueRef dummy, 0, Packed);
            }

            return ConstStructInContext(C, out ConstantVals[0], (uint)ConstantVals.Length, Packed);
        }

        public static LLVMValueRef ConstStruct(LLVMValueRef[] ConstantVals, bool Packed)
        {
            if (ConstantVals.Length == 0)
            {
                return ConstStruct(out LLVMValueRef dummy, 0, Packed);
            }

            return ConstStruct(out ConstantVals[0], (uint)ConstantVals.Length, Packed);
        }

        public static LLVMTypeRef[] GetSubtypes(LLVMTypeRef Tp)
        {
            var arr = new LLVMTypeRef[GetNumContainedTypes(Tp)];
            GetSubtypes(Tp, out arr[0]);

            return arr;
        }

        public static LLVMAttributeRef[] GetAttributesAtIndex(LLVMValueRef F, LLVMAttributeIndex Idx)
        {
            var arr = new LLVMAttributeRef[GetAttributeCountAtIndex(F, Idx)];
            GetAttributesAtIndex(F, Idx, out arr[0]);

            return arr;
        }

        public static LLVMAttributeRef[] GetCallSiteAttributes(LLVMValueRef C, LLVMAttributeIndex Idx)
        {
            var arr = new LLVMAttributeRef[GetCallSiteAttributeCount(C, Idx)];
            GetCallSiteAttributes(C, Idx, out arr[0]);

            return arr;
        }

        public static LLVMAttributeRef GetCallSiteStringAttribute(LLVMValueRef C, LLVMAttributeIndex Idx, [MarshalAs(UnmanagedType.LPStr)] string Kind)
        {
            return GetCallSiteStringAttribute(C, Idx, Kind, Kind == null ? 0 : (uint)Kind.Length);
        }

        public static uint GetEnumAttributeKindForName(string Name)
        {
            return GetEnumAttributeKindForName(Name, new size_t(Name == null ? 0 : Name.Length));
        }

        public static LLVMAttributeRef CreateStringAttribute(LLVMContextRef C, string Kind, string Value)
        {
            return CreateStringAttribute(C,
                                         Kind, Kind == null ? 0 : (uint)Kind.Length,
                                         Value, Value == null ? 0 : (uint)Value.Length);
        }

        public static LLVMAttributeRef GetStringAttributeAtIndex(LLVMValueRef F, LLVMAttributeIndex Idx, string Kind)
        {
            return GetStringAttributeAtIndex(F, Idx, Kind, Kind == null ? 0 : (uint)Kind.Length);
        }

        public static string GetStringAttributeKind(LLVMAttributeRef A)
        {
            return GetStringAttributeKind(A, out uint length);
        }

        public static string GetStringAttributeValue(LLVMAttributeRef A)
        {
            return GetStringAttributeValue(A, out uint length);
        }


        public static void RemoveCallSiteStringAttribute(LLVMValueRef C, LLVMAttributeIndex Idx, [MarshalAs(UnmanagedType.LPStr)] string Kind)
        {
            RemoveCallSiteStringAttribute(C, Idx, Kind, Kind == null ? 0 : (uint)Kind.Length);
        }


        public static void RemoveStringAttributeAtIndex(LLVMValueRef F, LLVMAttributeIndex Idx, string Kind)
        {
            RemoveStringAttributeAtIndex(F, Idx, Kind, Kind == null ? 0 : (uint)Kind.Length);
        }

        public static LLVMBool VerifyModule(LLVMModuleRef M, LLVMVerifierFailureAction Action, out string OutMessage)
        {
            var retVal = VerifyModule(M, Action, out IntPtr message);
            OutMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool ParseBitcode(LLVMMemoryBufferRef MemBuf, out LLVMModuleRef OutModule, out string OutMessage)
        {
            var retVal = ParseBitcode(MemBuf, out OutModule, out IntPtr message);
            OutMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool ParseBitcodeInContext(LLVMContextRef ContextRef, LLVMMemoryBufferRef MemBuf, out LLVMModuleRef OutModule, out string OutMessage)
        {
            var retVal = ParseBitcodeInContext(ContextRef, MemBuf, out OutModule, out IntPtr message);
            OutMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool GetBitcodeModuleInContext(LLVMContextRef ContextRef, LLVMMemoryBufferRef MemBuf, out LLVMModuleRef OutM, out string OutMessage)
        {
            var retVal = GetBitcodeModuleInContext(ContextRef, MemBuf, out OutM, out IntPtr message);
            OutMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool GetBitcodeModule(LLVMMemoryBufferRef MemBuf, out LLVMModuleRef OutM, out string OutMessage)
        {
            var retVal = GetBitcodeModule(MemBuf, out OutM, out IntPtr message);
            OutMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool PrintModuleToFile(LLVMModuleRef M, string Filename, out string ErrorMessage)
        {
            var retVal = PrintModuleToFile(M, Filename, out IntPtr message);
            ErrorMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool CreateMemoryBufferWithContentsOfFile(string Path, out LLVMMemoryBufferRef OutMemBuf, out string OutMessage)
        {
            var retVal = CreateMemoryBufferWithContentsOfFile(Path, out OutMemBuf, out IntPtr message);
            OutMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool CreateMemoryBufferWithSTDIN(out LLVMMemoryBufferRef OutMemBuf, out string OutMessage)
        {
            var retVal = CreateMemoryBufferWithSTDIN(out OutMemBuf, out IntPtr message);
            OutMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool GetTargetFromTriple(string Triple, out LLVMTargetRef T, out string ErrorMessage)
        {
            var retVal = GetTargetFromTriple(Triple, out T, out IntPtr message);
            ErrorMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool TargetMachineEmitToFile(LLVMTargetMachineRef T, LLVMModuleRef M, IntPtr Filename, LLVMCodeGenFileType codegen, out string ErrorMessage)
        {
            var retVal = TargetMachineEmitToFile(T, M, Filename, codegen, out IntPtr message);
            ErrorMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool TargetMachineEmitToMemoryBuffer(LLVMTargetMachineRef T, LLVMModuleRef M, LLVMCodeGenFileType codegen, out string ErrorMessage, out LLVMMemoryBufferRef OutMemBuf)
        {
            var retVal = TargetMachineEmitToMemoryBuffer(T, M, codegen, out IntPtr message, out OutMemBuf);
            ErrorMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool CreateExecutionEngineForModule(out LLVMExecutionEngineRef OutEE, LLVMModuleRef M, out string OutError)
        {
            var retVal = CreateExecutionEngineForModule(out OutEE, M, out IntPtr message);
            OutError = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool CreateInterpreterForModule(out LLVMExecutionEngineRef OutInterp, LLVMModuleRef M, out string OutError)
        {
            var retVal = CreateInterpreterForModule(out OutInterp, M, out IntPtr message);
            OutError = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool CreateJITCompilerForModule(out LLVMExecutionEngineRef OutJIT, LLVMModuleRef M, uint OptLevel, out string OutError)
        {
            var retVal = CreateJITCompilerForModule(out OutJIT, M, OptLevel, out IntPtr message);
            OutError = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static void InitializeMCJITCompilerOptions(LLVMMCJITCompilerOptions Options)
        {
            unsafe
            {
                InitializeMCJITCompilerOptions(&Options, new size_t(sizeof(LLVMMCJITCompilerOptions)));
            }
        }

        public static LLVMBool CreateMCJITCompilerForModule(out LLVMExecutionEngineRef OutJIT, LLVMModuleRef M, LLVMMCJITCompilerOptions Options, out string OutError)
        {
            LLVMBool retVal;
            IntPtr message;

            unsafe
            {
                retVal = CreateMCJITCompilerForModule(out OutJIT, M, &Options, new size_t(sizeof(LLVMMCJITCompilerOptions)), out message);
            }

            OutError = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool RemoveModule(LLVMExecutionEngineRef EE, LLVMModuleRef M, out LLVMModuleRef OutMod, out string OutError)
        {
            var retVal = RemoveModule(EE, M, out OutMod, out IntPtr message);
            OutError = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static LLVMBool ParseIRInContext(LLVMContextRef ContextRef, LLVMMemoryBufferRef MemBuf, out LLVMModuleRef OutM, out string OutMessage)
        {
            var retVal = ParseIRInContext(ContextRef, MemBuf, out OutM, out IntPtr message);
            OutMessage = message != IntPtr.Zero && retVal.Value != 0 ? Marshal.PtrToStringAnsi(message) : null;
            DisposeMessage(message);
            return retVal;
        }

        public static void OrcGetMangledSymbol(LLVMOrcJITStackRef JITStack, out string MangledSymbol, string Symbol)
        {
            OrcGetMangledSymbol(JITStack, out IntPtr ptr, Symbol);
            MangledSymbol = ptr != IntPtr.Zero ? Marshal.PtrToStringAnsi(ptr) : null;
            OrcDisposeMangledSymbol(ptr);
        }
    }
}