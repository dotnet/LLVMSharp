namespace LLVMSharp
{
    using System;

    partial struct LLVMTypeRef : IEquatable<LLVMTypeRef>, IHandle<Type>
    {
        public IntPtr GetInternalPointer() => Pointer;

        Type IHandle<Type>.ToWrapperType()
        {
            return Type.Create(this);
        }

        public static LLVMTypeRef FunctionType(LLVMTypeRef returnType, LLVMTypeRef[] paramTypes, LLVMBool isVarArg)
        {
            return LLVM.FunctionType(returnType, paramTypes, isVarArg);
        }

        public static LLVMTypeRef StructType(LLVMTypeRef[] elementTypes, LLVMBool packed)
        {
            return LLVM.StructType(elementTypes, packed);
        }

        public static LLVMTypeRef Int1TypeInContext(LLVMContextRef c)
        {
            return LLVM.Int1TypeInContext(c);
        }

        public static LLVMTypeRef Int8TypeInContext(LLVMContextRef c)
        {
            return LLVM.Int8TypeInContext(c);
        }

        public static LLVMTypeRef Int16TypeInContext(LLVMContextRef c)
        {
            return LLVM.Int16TypeInContext(c);
        }

        public static LLVMTypeRef Int32TypeInContext(LLVMContextRef c)
        {
            return LLVM.Int32TypeInContext(c);
        }

        public static LLVMTypeRef Int64TypeInContext(LLVMContextRef c)
        {
            return LLVM.Int64TypeInContext(c);
        }

        public static LLVMTypeRef IntTypeInContext(LLVMContextRef c, uint numBits)
        {
            return LLVM.IntTypeInContext(c, numBits);
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

        public static LLVMTypeRef IntType(uint numBits)
        {
            return LLVM.IntType(numBits);
        }

        public static LLVMTypeRef HalfTypeInContext(LLVMContextRef c)
        {
            return LLVM.HalfTypeInContext(c);
        }

        public static LLVMTypeRef FloatTypeInContext(LLVMContextRef c)
        {
            return LLVM.FloatTypeInContext(c);
        }

        public static LLVMTypeRef DoubleTypeInContext(LLVMContextRef c)
        {
            return LLVM.DoubleTypeInContext(c);
        }

        public static LLVMTypeRef X86FP80TypeInContext(LLVMContextRef c)
        {
            return LLVM.X86FP80TypeInContext(c);
        }

        public static LLVMTypeRef FP128TypeInContext(LLVMContextRef c)
        {
            return LLVM.FP128TypeInContext(c);
        }

        public static LLVMTypeRef PPCFP128TypeInContext(LLVMContextRef c)
        {
            return LLVM.PPCFP128TypeInContext(c);
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

        public static LLVMTypeRef StructCreateNamed(LLVMContextRef c, string name)
        {
            return LLVM.StructCreateNamed(c, name);
        }

        public static LLVMTypeRef VoidTypeInContext(LLVMContextRef c)
        {
            return LLVM.VoidTypeInContext(c);
        }

        public static LLVMTypeRef LabelTypeInContext(LLVMContextRef c)
        {
            return LLVM.LabelTypeInContext(c);
        }

        public static LLVMTypeRef X86MMXTypeInContext(LLVMContextRef c)
        {
            return LLVM.X86MMXTypeInContext(c);
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

        public static LLVMTypeRef IntPtrType(LLVMTargetDataRef td)
        {
            return LLVM.IntPtrType(td);
        }

        public static LLVMTypeRef IntPtrTypeForAS(LLVMTargetDataRef td, uint @AS)
        {
            return LLVM.IntPtrTypeForAS(td, @AS);
        }

        public static LLVMTypeRef IntPtrTypeInContext(LLVMContextRef c, LLVMTargetDataRef td)
        {
            return LLVM.IntPtrTypeInContext(c, td);
        }

        public static LLVMTypeRef IntPtrTypeForASInContext(LLVMContextRef c, LLVMTargetDataRef td, uint @AS)
        {
            return LLVM.IntPtrTypeForASInContext(c, td, @AS);
        }

        public static LLVMValueRef ConstInlineAsm(LLVMTypeRef ty, string asmString, string constraints, LLVMBool hasSideEffects, LLVMBool isAlignStack)
        {
            return LLVM.ConstInlineAsm(ty, asmString, constraints, hasSideEffects, isAlignStack);
        }

        public static LLVMGenericValueRef CreateGenericValueOfInt(LLVMTypeRef ty, ulong n, LLVMBool isSigned)
        {
            return LLVM.CreateGenericValueOfInt(ty, n, isSigned);
        }

        public static LLVMGenericValueRef CreateGenericValueOfFloat(LLVMTypeRef ty, double n)
        {
            return LLVM.CreateGenericValueOfFloat(ty, n);
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

        public void StructSetBody(LLVMTypeRef[] elementTypes, LLVMBool packed)
        {
            LLVM.StructSetBody(this, elementTypes, packed);
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

        public LLVMTypeRef ArrayType(uint elementCount)
        {
            return LLVM.ArrayType(this, elementCount);
        }

        public uint GetArrayLength()
        {
            return LLVM.GetArrayLength(this);
        }

        public LLVMTypeRef PointerType(uint addressSpace)
        {
            return LLVM.PointerType(this, addressSpace);
        }

        public uint GetPointerAddressSpace()
        {
            return LLVM.GetPointerAddressSpace(this);
        }

        public LLVMTypeRef VectorType(uint elementCount)
        {
            return LLVM.VectorType(this, elementCount);
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

        public LLVMValueRef ConstInt(ulong n, LLVMBool signExtend)
        {
            return LLVM.ConstInt(this, n, signExtend);
        }

        public LLVMValueRef ConstIntOfArbitraryPrecision(uint numWords, int[] words)
        {
            return LLVM.ConstIntOfArbitraryPrecision(this, numWords, words);
        }

        public LLVMValueRef ConstIntOfString(string text, char radix)
        {
            return LLVM.ConstIntOfString(this, text, radix);
        }

        public LLVMValueRef ConstIntOfStringAndSize(string text, uint sLen, char radix)
        {
            return LLVM.ConstIntOfStringAndSize(this, text, sLen, radix);
        }

        public LLVMValueRef ConstReal(double n)
        {
            return LLVM.ConstReal(this, n);
        }

        public LLVMValueRef ConstRealOfString(string text)
        {
            return LLVM.ConstRealOfString(this, text);
        }

        public LLVMValueRef ConstRealOfStringAndSize(string text, uint sLen)
        {
            return LLVM.ConstRealOfStringAndSize(this, text, sLen);
        }

        public LLVMValueRef ConstArray(LLVMValueRef[] constantVals)
        {
            return LLVM.ConstArray(this, constantVals);
        }

        public LLVMValueRef ConstNamedStruct(LLVMValueRef[] constantVals)
        {
            return LLVM.ConstNamedStruct(this, constantVals);
        }

        public LLVMValueRef AlignOf()
        {
            return LLVM.AlignOf(this);
        }

        public LLVMValueRef SizeOf()
        {
            return LLVM.SizeOf(this);
        }

        public double GenericValueToFloat(LLVMGenericValueRef genVal)
        {
            return LLVM.GenericValueToFloat(this, genVal);
        }

        public bool Equals(LLVMTypeRef other)
        {
            return this.Pointer == other.Pointer;
        }
        
        public override bool Equals(object obj)
        {
            if (obj is LLVMTypeRef)
            {
                return this.Equals((LLVMTypeRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMTypeRef op1, LLVMTypeRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMTypeRef op1, LLVMTypeRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}