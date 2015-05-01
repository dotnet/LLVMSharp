namespace LLVMSharp
{
    using System;

    partial struct LLVMTypeRef
    {
        public static LLVMTypeRef FunctionType(LLVMTypeRef returnType, LLVMTypeRef[] @ParamTypes, LLVMBool @IsVarArg)
        {
            return LLVM.FunctionType(returnType, @ParamTypes, @IsVarArg);
        }

        public static LLVMTypeRef StructType(LLVMTypeRef[] @ElementTypes, LLVMBool @Packed)
        {
            return LLVM.StructType(@ElementTypes, @Packed);
        }

        public static LLVMTypeRef Int1TypeInContext(LLVMContextRef @C)
        {
            return LLVM.Int1TypeInContext(@C);
        }

        public static LLVMTypeRef Int8TypeInContext(LLVMContextRef @C)
        {
            return LLVM.Int8TypeInContext(@C);
        }

        public static LLVMTypeRef Int16TypeInContext(LLVMContextRef @C)
        {
            return LLVM.Int16TypeInContext(@C);
        }

        public static LLVMTypeRef Int32TypeInContext(LLVMContextRef @C)
        {
            return LLVM.Int32TypeInContext(@C);
        }

        public static LLVMTypeRef Int64TypeInContext(LLVMContextRef @C)
        {
            return LLVM.Int64TypeInContext(@C);
        }

        public static LLVMTypeRef IntTypeInContext(LLVMContextRef @C, uint @NumBits)
        {
            return LLVM.IntTypeInContext(@C, @NumBits);
        }

        public static LLVMTypeRef Int1Type()
        {
            return LLVM.Int1Type();
        }

        public static LLVMTypeRef Int8Type()
        {
            return LLVM.Int8Type();
        }

        public static LLVMTypeRef Int16Type()
        {
            return LLVM.Int16Type();
        }

        public static LLVMTypeRef Int32Type()
        {
            return LLVM.Int32Type();
        }

        public static LLVMTypeRef Int64Type()
        {
            return LLVM.Int64Type();
        }

        public static LLVMTypeRef IntType(uint @NumBits)
        {
            return LLVM.IntType(@NumBits);
        }

        public static LLVMTypeRef HalfTypeInContext(LLVMContextRef @C)
        {
            return LLVM.HalfTypeInContext(@C);
        }

        public static LLVMTypeRef FloatTypeInContext(LLVMContextRef @C)
        {
            return LLVM.FloatTypeInContext(@C);
        }

        public static LLVMTypeRef DoubleTypeInContext(LLVMContextRef @C)
        {
            return LLVM.DoubleTypeInContext(@C);
        }

        public static LLVMTypeRef X86FP80TypeInContext(LLVMContextRef @C)
        {
            return LLVM.X86FP80TypeInContext(@C);
        }

        public static LLVMTypeRef FP128TypeInContext(LLVMContextRef @C)
        {
            return LLVM.FP128TypeInContext(@C);
        }

        public static LLVMTypeRef PPCFP128TypeInContext(LLVMContextRef @C)
        {
            return LLVM.PPCFP128TypeInContext(@C);
        }

        public static LLVMTypeRef HalfType()
        {
            return LLVM.HalfType();
        }

        public static LLVMTypeRef FloatType()
        {
            return LLVM.FloatType();
        }

        public static LLVMTypeRef DoubleType()
        {
            return LLVM.DoubleType();
        }

        public static LLVMTypeRef X86FP80Type()
        {
            return LLVM.X86FP80Type();
        }

        public static LLVMTypeRef FP128Type()
        {
            return LLVM.FP128Type();
        }

        public static LLVMTypeRef PPCFP128Type()
        {
            return LLVM.PPCFP128Type();
        }

        public static LLVMTypeRef StructCreateNamed(LLVMContextRef @C, string @Name)
        {
            return LLVM.StructCreateNamed(@C, @Name);
        }

        public static LLVMTypeRef VoidTypeInContext(LLVMContextRef @C)
        {
            return LLVM.VoidTypeInContext(@C);
        }

        public static LLVMTypeRef LabelTypeInContext(LLVMContextRef @C)
        {
            return LLVM.LabelTypeInContext(@C);
        }

        public static LLVMTypeRef X86MMXTypeInContext(LLVMContextRef @C)
        {
            return LLVM.X86MMXTypeInContext(@C);
        }

        public static LLVMTypeRef VoidType()
        {
            return LLVM.VoidType();
        }

        public static LLVMTypeRef LabelType()
        {
            return LLVM.LabelType();
        }

        public static LLVMTypeRef X86MMXType()
        {
            return LLVM.X86MMXType();
        }

        public static LLVMTypeRef IntPtrType(LLVMTargetDataRef @TD)
        {
            return LLVM.IntPtrType(@TD);
        }

        public static LLVMTypeRef IntPtrTypeForAS(LLVMTargetDataRef @TD, uint @AS)
        {
            return LLVM.IntPtrTypeForAS(@TD, @AS);
        }

        public static LLVMTypeRef IntPtrTypeInContext(LLVMContextRef @C, LLVMTargetDataRef @TD)
        {
            return LLVM.IntPtrTypeInContext(@C, @TD);
        }

        public static LLVMTypeRef IntPtrTypeForASInContext(LLVMContextRef @C, LLVMTargetDataRef @TD, uint @AS)
        {
            return LLVM.IntPtrTypeForASInContext(@C, @TD, @AS);
        }

        public static LLVMValueRef ConstInlineAsm(LLVMTypeRef @Ty, string @AsmString, string @Constraints, LLVMBool @HasSideEffects, LLVMBool @IsAlignStack)
        {
            return LLVM.ConstInlineAsm(@Ty, @AsmString, @Constraints, @HasSideEffects, @IsAlignStack);
        }

        public static LLVMGenericValueRef CreateGenericValueOfInt(LLVMTypeRef @Ty, ulong @N, LLVMBool @IsSigned)
        {
            return LLVM.CreateGenericValueOfInt(@Ty, @N, @IsSigned);
        }

        public static LLVMGenericValueRef CreateGenericValueOfFloat(LLVMTypeRef @Ty, double @N)
        {
            return LLVM.CreateGenericValueOfFloat(@Ty, @N);
        }

        public LLVMTypeKind GetTypeKind()
        {
            return LLVM.GetTypeKind(this);
        }

        public LLVMBool TypeIsSized()
        {
            return LLVM.TypeIsSized(this);
        }

        public LLVMContextRef GetTypeContext()
        {
            return LLVM.GetTypeContext(this);
        }

        public void DumpType()
        {
            LLVM.DumpType(this);
        }

        public IntPtr PrintTypeToString()
        {
            return LLVM.PrintTypeToString(this);
        }

        public uint GetIntTypeWidth()
        {
            return LLVM.GetIntTypeWidth(this);
        }

        public LLVMBool IsFunctionVarArg()
        {
            return LLVM.IsFunctionVarArg(this);
        }

        public LLVMTypeRef GetReturnType()
        {
            return LLVM.GetReturnType(this);
        }

        public uint CountParamTypes()
        {
            return LLVM.CountParamTypes(this);
        }

        public LLVMTypeRef[] GetParamTypes()
        {
            return LLVM.GetParamTypes(this);
        }

        public string GetStructName()
        {
            return LLVM.GetStructName(this);
        }

        public void StructSetBody(LLVMTypeRef[] @ElementTypes, LLVMBool @Packed)
        {
            LLVM.StructSetBody(this, @ElementTypes, @Packed);
        }

        public uint CountStructElementTypes()
        {
            return LLVM.CountStructElementTypes(this);
        }

        public LLVMTypeRef[] GetStructElementTypes()
        {
            return LLVM.GetStructElementTypes(this);
        }

        public LLVMBool IsPackedStruct()
        {
            return LLVM.IsPackedStruct(this);
        }

        public LLVMBool IsOpaqueStruct()
        {
            return LLVM.IsOpaqueStruct(this);
        }

        public LLVMTypeRef GetElementType()
        {
            return LLVM.GetElementType(this);
        }

        public LLVMTypeRef ArrayType(uint @ElementCount)
        {
            return LLVM.ArrayType(this, @ElementCount);
        }

        public uint GetArrayLength()
        {
            return LLVM.GetArrayLength(this);
        }

        public LLVMTypeRef PointerType(uint @AddressSpace)
        {
            return LLVM.PointerType(this, @AddressSpace);
        }

        public uint GetPointerAddressSpace()
        {
            return LLVM.GetPointerAddressSpace(this);
        }

        public LLVMTypeRef VectorType(uint @ElementCount)
        {
            return LLVM.VectorType(this, @ElementCount);
        }

        public uint GetVectorSize()
        {
            return LLVM.GetVectorSize(this);
        }

        public LLVMValueRef ConstNull()
        {
            return LLVM.ConstNull(this);
        }

        public LLVMValueRef ConstAllOnes()
        {
            return LLVM.ConstAllOnes(this);
        }

        public LLVMValueRef GetUndef()
        {
            return LLVM.GetUndef(this);
        }

        public LLVMValueRef ConstPointerNull()
        {
            return LLVM.ConstPointerNull(this);
        }

        public LLVMValueRef ConstInt(ulong @N, LLVMBool @SignExtend)
        {
            return LLVM.ConstInt(this, @N, @SignExtend);
        }

        public LLVMValueRef ConstIntOfArbitraryPrecision(uint @NumWords, int[] @Words)
        {
            return LLVM.ConstIntOfArbitraryPrecision(this, @NumWords, @Words);
        }

        public LLVMValueRef ConstIntOfString(string @Text, char @Radix)
        {
            return LLVM.ConstIntOfString(this, @Text, @Radix);
        }

        public LLVMValueRef ConstIntOfStringAndSize(string @Text, uint @SLen, char @Radix)
        {
            return LLVM.ConstIntOfStringAndSize(this, @Text, @SLen, @Radix);
        }

        public LLVMValueRef ConstReal(double @N)
        {
            return LLVM.ConstReal(this, @N);
        }

        public LLVMValueRef ConstRealOfString(string @Text)
        {
            return LLVM.ConstRealOfString(this, @Text);
        }

        public LLVMValueRef ConstRealOfStringAndSize(string @Text, uint @SLen)
        {
            return LLVM.ConstRealOfStringAndSize(this, @Text, @SLen);
        }

        public LLVMValueRef ConstArray(LLVMValueRef[] @ConstantVals)
        {
            return LLVM.ConstArray(this, @ConstantVals);
        }

        public LLVMValueRef ConstNamedStruct(LLVMValueRef[] @ConstantVals)
        {
            return LLVM.ConstNamedStruct(this, @ConstantVals);
        }

        public LLVMValueRef AlignOf()
        {
            return LLVM.AlignOf(this);
        }

        public LLVMValueRef SizeOf()
        {
            return LLVM.SizeOf(this);
        }

        public double GenericValueToFloat(LLVMGenericValueRef @GenVal)
        {
            return LLVM.GenericValueToFloat(this, @GenVal);
        }
    }
}