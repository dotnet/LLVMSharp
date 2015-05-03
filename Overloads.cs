namespace LLVMSharp
{
    using System;

    partial class LLVM
    {
        public static LLVMValueRef[] GetNamedMetadataOperands(LLVMModuleRef M, string name)
        {
            uint count = GetNamedMetadataNumOperands(M, name);
            var buffer = new LLVMValueRef[count];

            if (count > 0)
            {
                GetNamedMetadataOperands(M, name, out buffer[0]);
            }

            return buffer;
        }

        public static LLVMTypeRef FunctionType(LLVMTypeRef ReturnType, LLVMTypeRef[] ParamTypes, bool IsVarArg)
        {
            if (ParamTypes.Length == 0)
            {
                LLVMTypeRef dummy;
                return FunctionType(ReturnType, out dummy, 0, IsVarArg);
            }

            return FunctionType(ReturnType, out ParamTypes[0], (uint)ParamTypes.Length, IsVarArg);
        }

        public static LLVMTypeRef[] GetParamTypes(LLVMTypeRef FunctionTy)
        {
            uint count = CountParamTypes(FunctionTy);
            var buffer = new LLVMTypeRef[count];

            if (count > 0)
            {
                GetParamTypes(FunctionTy, out buffer[0]);
            }

            return buffer;
        }
        
        public static LLVMTypeRef StructTypeInContext(LLVMContextRef C, LLVMTypeRef[] ElementTypes, bool Packed)
        {
            if (ElementTypes.Length == 0)
            {
                LLVMTypeRef dummy;
                return StructTypeInContext(C, out dummy, 0, Packed);
            }

            return StructTypeInContext(C, out ElementTypes[0], (uint)ElementTypes.Length, Packed);
        }

        public static LLVMTypeRef StructType(LLVMTypeRef[] ElementTypes, bool Packed)
        {
            if (ElementTypes.Length == 0)
            {
                LLVMTypeRef dummy;
                return StructType(out dummy, 0, Packed);
            }

            return StructType(out ElementTypes[0], (uint)ElementTypes.Length, Packed);
        }

        public static void StructSetBody(LLVMTypeRef StructTy, LLVMTypeRef[] ElementTypes, bool Packed)
        {
            if (ElementTypes.Length == 0)
            {
                LLVMTypeRef dummy;
                StructSetBody(StructTy, out dummy, 0, Packed);
                return;
            }

            StructSetBody(StructTy, out ElementTypes[0], (uint)ElementTypes.Length, Packed);
        }

        public static LLVMTypeRef[] GetStructElementTypes(LLVMTypeRef StructTy)
        {
            uint count = CountStructElementTypes(StructTy);
            var buffer = new LLVMTypeRef[count];

            if (count > 0)
            {
                GetStructElementTypes(StructTy, out buffer[0]);
            }

            return buffer;
        }

        public static LLVMValueRef ConstStructInContext(LLVMContextRef C, LLVMValueRef[] ConstantVals, bool Packed)
        {
            if (ConstantVals.Length == 0)
            {
                LLVMValueRef dummy;
                return ConstStructInContext(C, out dummy, 0, Packed);
            }

            return ConstStructInContext(C, out ConstantVals[0], (uint)ConstantVals.Length, Packed);
        }

        public static LLVMValueRef ConstStruct(LLVMValueRef[] ConstantVals, bool Packed)
        {
            if (ConstantVals.Length == 0)
            {
                LLVMValueRef dummy;
                return ConstStruct(out dummy, 0, Packed);
            }

            return ConstStruct(out ConstantVals[0], (uint)ConstantVals.Length, Packed);
        }

        public static LLVMValueRef ConstArray(LLVMTypeRef ElementTy, LLVMValueRef[] ConstantVals)
        {
            if (ConstantVals.Length == 0)
            {
                LLVMValueRef dummy;
                return ConstArray(ElementTy, out dummy, 0);
            }

            return ConstArray(ElementTy, out ConstantVals[0], (uint)ConstantVals.Length);
        }

        public static LLVMValueRef ConstNamedStruct(LLVMTypeRef StructTy, LLVMValueRef[] ConstantVals)
        {
            if (ConstantVals.Length == 0)
            {
                LLVMValueRef dummy;
                return ConstNamedStruct(StructTy, out dummy, 0);
            }

            return ConstNamedStruct(StructTy, out ConstantVals[0], (uint)ConstantVals.Length);
        }

        public static LLVMValueRef ConstVector(LLVMValueRef[] ScalarConstantVars)
        {
            if (ScalarConstantVars.Length == 0)
            {
                LLVMValueRef dummy;
                return ConstVector(out dummy, 0);
            }

            return ConstVector(out ScalarConstantVars[0], (uint)ScalarConstantVars.Length);
        }

        public static LLVMValueRef ConstGEP(LLVMValueRef ConstantVal, LLVMValueRef[] ConstantIndices)
        {
            if (ConstantIndices.Length == 0)
            {
                LLVMValueRef dummy;
                return ConstGEP(ConstantVal, out dummy, 0);
            }

            return ConstGEP(ConstantVal, out ConstantIndices[0], (uint)ConstantIndices.Length);
        }

        public static LLVMValueRef ConstInBoundsGEP(LLVMValueRef ConstantVal, LLVMValueRef[] ConstantIndices)
        {
            if (ConstantIndices.Length == 0)
            {
                LLVMValueRef dummy;
                return ConstInBoundsGEP(ConstantVal, out dummy, 0);
            }

            return ConstInBoundsGEP(ConstantVal, out ConstantIndices[0], (uint)ConstantIndices.Length);
        }

        public static LLVMValueRef ConstExtractValue(LLVMValueRef AggConstant, uint[] IdxList)
        {
            if (IdxList.Length == 0)
            {
                uint dummy;
                return ConstExtractValue(AggConstant, out dummy, 0);
            }

            return ConstExtractValue(AggConstant, out IdxList[0], (uint)IdxList.Length);
        }

        public static LLVMValueRef ConstInsertValue(LLVMValueRef AggConstant, LLVMValueRef ElementValueConstant, uint[] IdxList)
        {
            if (IdxList.Length == 0)
            {
                uint dummy;
                return ConstInsertValue(AggConstant, ElementValueConstant, out dummy, 0);
            }

            return ConstInsertValue(AggConstant, ElementValueConstant, out IdxList[0], (uint)IdxList.Length);
        }

        public static LLVMValueRef[] GetParams(LLVMValueRef Fn)
        {
            uint count = CountParams(Fn);
            var buffer = new LLVMValueRef[count];

            if (count > 0)
            {
                GetParams(Fn, out buffer[0]);
            }
            
            return buffer;
        }

        public static LLVMValueRef MDNodeInContext(LLVMContextRef C, LLVMValueRef[] Vals)
        {
            if (Vals.Length == 0)
            {
                LLVMValueRef dummy;
                return MDNodeInContext(C, out dummy, 0);
            }

            return MDNodeInContext(C, out Vals[0], (uint)Vals.Length);
        }

        public static LLVMValueRef MDNode(LLVMValueRef[] Vals)
        {
            if (Vals.Length == 0)
            {
                LLVMValueRef dummy;
                return MDNode(out dummy, 0);
            }

            return MDNode(out Vals[0], (uint)Vals.Length);
        }

        public static LLVMValueRef[] GetMDNodeOperands(LLVMValueRef V)
        {
            uint count = GetMDNodeNumOperands(V);
            var buffer = new LLVMValueRef[count];

            if (count > 0)
            {
                GetMDNodeOperands(V, out buffer[0]);
            }
            
            return buffer;
        }

        public static LLVMBasicBlockRef[] GetBasicBlocks(LLVMValueRef Fn)
        {
            uint count = CountBasicBlocks(Fn);
            var buffer = new LLVMBasicBlockRef[count];

            if (count > 0)
            {
                GetBasicBlocks(Fn, out buffer[0]);
            }
            
            return buffer;
        }

        public static void AddIncoming(LLVMValueRef PhiNode, LLVMValueRef[] IncomingValues, LLVMBasicBlockRef[] IncomingBlocks, uint Count)
        {
            if (Count == 0)
            {
                return;
            }

            AddIncoming(PhiNode, out IncomingValues[0], out IncomingBlocks[0], Count);
        }

        public static LLVMValueRef BuildAggregateRet(LLVMBuilderRef param0, LLVMValueRef[] RetVals)
        {
            return BuildAggregateRet(param0, out RetVals[0], (uint)RetVals.Length);
        }

        public static LLVMValueRef BuildInvoke(LLVMBuilderRef param0, LLVMValueRef Fn, LLVMValueRef[] Args, LLVMBasicBlockRef Then, LLVMBasicBlockRef Catch, string Name)
        {
            if (Args.Length == 0)
            {
                LLVMValueRef dummy;
                return BuildInvoke(param0, Fn, out dummy, 0, Then, Catch, Name);
            }

            return BuildInvoke(param0, Fn, out Args[0], (uint)Args.Length, Then, Catch, Name);
        }

        public static LLVMValueRef BuildGEP(LLVMBuilderRef B, LLVMValueRef Pointer, LLVMValueRef[] Indices, string Name)
        {
            if (Indices.Length == 0)
            {
                LLVMValueRef dummy;
                return BuildGEP(B, Pointer, out dummy, 0, Name);
            }

            return BuildGEP(B, Pointer, out Indices[0], (uint)Indices.Length, Name);
        }

        public static LLVMValueRef BuildInBoundsGEP(LLVMBuilderRef B, LLVMValueRef Pointer, LLVMValueRef[] Indices, string Name)
        {
            if (Indices.Length == 0)
            {
                LLVMValueRef dummy;
                return BuildInBoundsGEP(B, Pointer, out dummy, 0, Name);
            }

            return BuildInBoundsGEP(B, Pointer, out Indices[0], (uint)Indices.Length, Name);
        }

        public static LLVMValueRef BuildCall(LLVMBuilderRef param0, LLVMValueRef Fn, LLVMValueRef[] Args, string Name)
        {
            if (Args.Length == 0)
            {
                LLVMValueRef dummy;
                return BuildCall(param0, Fn, out dummy, 0, Name);
            }

            return BuildCall(param0, Fn, out Args[0], (uint)Args.Length, Name);
        }

        public static void InitializeMCJITCompilerOptions(LLVMMCJITCompilerOptions[] Options)
        {
            if (Options.Length == 0)
            {
                LLVMMCJITCompilerOptions dummy;
                InitializeMCJITCompilerOptions(out dummy, 0);
                return;
            }

            InitializeMCJITCompilerOptions(out Options[0], Options.Length);
        }

        public static bool CreateMCJITCompilerForModule(out LLVMExecutionEngineRef OutJIT, LLVMModuleRef M, LLVMMCJITCompilerOptions[] Options, out IntPtr OutError)
        {
            if (Options.Length == 0)
            {
                LLVMMCJITCompilerOptions dummy;
                return CreateMCJITCompilerForModule(out OutJIT, M, out dummy, 0, out OutError);
            }

            return CreateMCJITCompilerForModule(out OutJIT, M, out Options[0], Options.Length, out OutError);
        }

        public static LLVMGenericValueRef RunFunction(LLVMExecutionEngineRef EE, LLVMValueRef F, LLVMGenericValueRef[] Args)
        {
            if (Args.Length == 0)
            {
                LLVMGenericValueRef dummy;
                return RunFunction(EE, F, 0, out dummy);
            }

            return RunFunction(EE, F, (uint)Args.Length, out Args[0]);
        }
    }
}