namespace LLVMSharp
{
    partial class LLVM
    {
        public static LLVMValueRef BuildCall(LLVMBuilderRef param0, LLVMValueRef Fn, LLVMValueRef[] Args, string Name)
        {
            if (Args.Length == 0)
            {
                LLVMValueRef dummy;
                return BuildCall(param0, Fn, out dummy, 0, Name);
            }

            return BuildCall(param0, Fn, out Args[0], (uint)Args.Length, Name);
        }

        public static LLVMTypeRef FunctionType(LLVMTypeRef ReturnType, LLVMTypeRef[] ParamTypes, LLVMBool IsVarArg)
        {
            if (ParamTypes.Length == 0)
            {
                LLVMTypeRef dummy;
                return FunctionType(ReturnType, out dummy, 0, IsVarArg);
            }

            return FunctionType(ReturnType, out ParamTypes[0], (uint)ParamTypes.Length, IsVarArg);
        }

        public static void StructSetBody(LLVMTypeRef StructTy, LLVMTypeRef[] ElementTypes, LLVMBool Packed)
        {
            if (ElementTypes.Length == 0)
            {
                LLVMTypeRef dummy;
                StructSetBody(StructTy, out dummy, 0, Packed);
                return;
            }

            StructSetBody(StructTy, out ElementTypes[0], (uint)ElementTypes.Length, Packed);
        }

        public static LLVMTypeRef StructTypeInContext(LLVMContextRef C, LLVMTypeRef[] ElementTypes, LLVMBool Packed)
        {
            if (ElementTypes.Length == 0)
            {
                LLVMTypeRef dummy;
                return StructTypeInContext(C, out dummy, 0, Packed);
            }

            return StructTypeInContext(C, out ElementTypes[0], (uint)ElementTypes.Length, Packed);
        }

        public static LLVMTypeRef StructType(LLVMTypeRef[] ElementTypes, LLVMBool Packed)
        {
            if (ElementTypes.Length == 0)
            {
                LLVMTypeRef dummy;
                return StructType(out dummy, 0, Packed);
            }

            return StructType(out ElementTypes[0], (uint)ElementTypes.Length, Packed);
        }

        public static LLVMValueRef ConstStructInContext(LLVMContextRef C, LLVMValueRef[] ConstantVals, LLVMBool Packed)
        {
            if (ConstantVals.Length == 0)
            {
                LLVMValueRef dummy;
                return ConstStructInContext(C, out dummy, 0, Packed);
            }

            return ConstStructInContext(C, out ConstantVals[0], (uint)ConstantVals.Length, Packed);
        }

        public static LLVMValueRef ConstStruct(LLVMValueRef[] ConstantVals, LLVMBool Packed)
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

        public static LLVMValueRef ConstInsertValue(LLVMValueRef AggConstant, LLVMValueRef ElementValueConstant,
            uint[] IdxList)
        {
            if (IdxList.Length == 0)
            {
                uint dummy;
                return ConstInsertValue(AggConstant, ElementValueConstant, out dummy, 0);
            }

            return ConstInsertValue(AggConstant, ElementValueConstant, out IdxList[0], (uint)IdxList.Length);
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

        public static LLVMValueRef BuildInvoke(LLVMBuilderRef param0, LLVMValueRef Fn, LLVMValueRef[] Args,
            LLVMBasicBlockRef Then, LLVMBasicBlockRef Catch, string Name)
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

        public static LLVMValueRef BuildInBoundsGEP(LLVMBuilderRef B, LLVMValueRef Pointer, LLVMValueRef[] Indices,
            string Name)
        {
            if (Indices.Length == 0)
            {
                LLVMValueRef dummy;
                return BuildInBoundsGEP(B, Pointer, out dummy, 0, Name);
            }

            return BuildInBoundsGEP(B, Pointer, out Indices[0], (uint)Indices.Length, Name);
        }
    }
}
