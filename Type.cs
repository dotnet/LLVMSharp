using System.Diagnostics;

namespace LLVMSharp
{
    using System;

    public class Type : IEquatable<Type>, IWrapper<LLVMTypeRef>
    {
        internal static Type Create(LLVMTypeRef t)
        {
            if (t.Pointer == IntPtr.Zero)
            {
                return null;
            }

            return new Type(t);
        }

        public static Type Int1
        {
            get { return Context.Global.Int1Type; }
        }

        public static Type Int8
        {
            get { return Context.Global.Int8Type; }
        }

        public static Type Int16
        {
            get { return Context.Global.Int16Type; }
        }

        public static Type Int32
        {
            get { return Context.Global.Int32Type; }
        }

        public static Type Int64
        {
            get { return Context.Global.Int64Type; }
        }

        public static Type Int(int bitLength)
        {
            return LLVM.IntType((uint) bitLength).Wrap();
        }

        public static Type Half
        {
            get { return Context.Global.HalfType; }
        }

        public static Type Float
        {
            get { return Context.Global.FloatType; }
        }

        public static Type Double
        {
            get { return Context.Global.DoubleType; }
        }

        public static Type X86FP80
        {
            get { return Context.Global.X86FP80Type; }
        }

        public static Type FP128
        {
            get { return Context.Global.FP128Type; }
        }

        public static Type PPCFP128
        {
            get { return Context.Global.FP128Type; }
        }

        LLVMTypeRef IWrapper<LLVMTypeRef>.ToHandleType()
        {
            return this._instance;
        }
        
        private readonly LLVMTypeRef _instance;

        internal Type(LLVMTypeRef typeRef)
        {
            this._instance = typeRef;
        }

        public uint AddressSpace
        {
            get { return LLVM.GetPointerAddressSpace(this.Unwrap()); }
        }

        public Context Context
        {
            get { return LLVM.GetTypeContext(this.Unwrap()).Wrap(); }
        }

        public Type GetPointerType(uint addressSpace)
        {
            return LLVM.PointerType(this.Unwrap(), addressSpace).Wrap();
        }

        public string Print()
        {
            return LLVM.PrintTypeToString(this.Unwrap()).IntPtrToString();
        }

        public void Dump()
        {
            LLVM.DumpType(this.Unwrap());
        }

        public Context TypeContext
        {
            get { return LLVM.GetTypeContext(this.Unwrap()).Wrap(); }
        }

        public bool IsVoidTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMVoidTypeKind; }
        }

        public bool IsHalfTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMHalfTypeKind; }
        }

        public bool IsFloatTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMFloatTypeKind; }
        }

        public bool IsDoubleTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMDoubleTypeKind; }
        }

        public bool IsX86_FP80Ty
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMX86_FP80TypeKind; }
        }

        public bool IsFP128Ty
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMFP128TypeKind; }
        }

        public bool IsPPC_FP128Ty
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMPPC_FP128TypeKind; }
        }

        public bool IsFloatingPointTy
        {
            get
            {
                return this.IsHalfTy || this.IsFloatTy || this.IsDoubleTy || this.IsX86_FP80Ty ||
                       this.IsFP128Ty || this.IsPPC_FP128Ty;
            }
        }

        public bool IsX86_MMXTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMX86_MMXTypeKind; }
        }

        public bool IsLabelTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMLabelTypeKind; }
        }

        public bool IsMetadataTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMMetadataTypeKind; }
        }

        public bool IsIntegerTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMIntegerTypeKind; }
        }

        public bool IsIntegerBitwidh(uint bitwidth)
        {
            return this.TypeKind == LLVMTypeKind.LLVMIntegerTypeKind && LLVM.GetIntTypeWidth(this._instance) == bitwidth;
        }
        
        public bool IsFunctionTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMFunctionTypeKind; }
        }

        public bool IsStructTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMStructTypeKind; }
        }

        public bool IsArrayTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMArrayTypeKind; }
        }

        public bool IsPointerTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMPointerTypeKind; }
        }

        public bool IsVectorTy
        {
            get { return this.TypeKind == LLVMTypeKind.LLVMVectorTypeKind; }
        }

        public uint IntBitWidth
        {
            get { return LLVM.GetIntTypeWidth(this.Unwrap()); }
        }

        public Type GetFunctionParamType(uint i)
        {
            return Type.Create(LLVM.GetParamTypes(this.Unwrap())[i]);
        }

        public uint FunctionNumParams
        {
            get { return LLVM.CountParamTypes(this.Unwrap()); }
        }

        public bool IsFunctionVarArg
        {
            get { return LLVM.IsFunctionVarArg(this.Unwrap()); }
        }

        public string StructName
        {
            get
            {
                if (!this.IsStructTy)
                {
                    throw new InvalidOperationException();
                }
                return LLVM.GetStructName(this.Unwrap());
            }
        }

        public uint StructNumElements
        {
            get { return LLVM.CountStructElementTypes(this.Unwrap()); }
        }

        public Type GetStructElementType(uint i)
        {
            return Type.Create(LLVM.GetStructElementTypes(this.Unwrap())[i]);
        }
        
        public static LLVMTypeRef LabelType()
        {
            return LLVM.LabelType();
        }

        public static Type LabelType(Context c)
        {
            return Type.Create(LLVM.LabelTypeInContext(c.Unwrap()));
        }

        public bool Equals(Type other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            else
            {
                return this._instance == other._instance;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Type);
        }

        public static bool operator ==(Type op1, Type op2)
        {
            if (ReferenceEquals(op1, null))
            {
                return ReferenceEquals(op2, null);
            }
            else
            {
                return op1.Equals(op2);
            }
        }

        public static bool operator !=(Type op1, Type op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this._instance.GetHashCode();
        }

        public LLVMTypeKind TypeKind
        {
            get { return LLVM.GetTypeKind(this.Unwrap()); }
        }

        public bool IsSized
        {
            get { return LLVM.TypeIsSized(this.Unwrap()); }
        }

        public void StructSetBody(Type structTy, Type[] elementTypes, bool packed)
        {
            LLVM.StructSetBody(structTy.Unwrap(), elementTypes.Unwrap(), packed);
        }

        public Type[] StructElementTypes
        {
            get { return LLVM.GetStructElementTypes(this.Unwrap()).Wrap<LLVMTypeRef, Type>(); }
        }

        public bool IsPackedStruct
        {
            get { return LLVM.IsPackedStruct(this.Unwrap()); }
        }

        public bool IsOpaqueStruct
        {
            get { return LLVM.IsOpaqueStruct(this.Unwrap()); }
        }

        public Type ElementType
        {
            get { return LLVM.GetElementType(this.Unwrap()).Wrap(); }
        }

        public Type ArrayType(uint elementCount)
        {
            return LLVM.ArrayType(this.Unwrap(), elementCount).Wrap();
        }

        public uint ArrayLength
        {
            get { return LLVM.GetArrayLength(this.Unwrap()); }
        }

        public Type PointerType(uint addressSpace)
        {
            return LLVM.PointerType(this.Unwrap(), addressSpace).Wrap();
        }

        public uint PointerAddressSpace
        {
            get { return LLVM.GetPointerAddressSpace(this.Unwrap()); }
        }

        public Type VectorType(uint elementCount)
        {
            return LLVM.VectorType(this.Unwrap(), elementCount).Wrap();
        }

        public uint VectorSize
        {
            get { return LLVM.GetVectorSize(this.Unwrap()); }
        }

        public Value ConstNull
        {
            get { return LLVM.ConstNull(this.Unwrap()).Wrap(); }
        }

        public Value ConstAllOnes
        {
            get { return LLVM.ConstAllOnes(this.Unwrap()).Wrap(); }
        }

        public Value GetUndef
        {
            get { return LLVM.GetUndef(this.Unwrap()).Wrap(); }
        }

        public Value ConstPointerNull
        {
            get { return LLVM.ConstPointerNull(this.Unwrap()).Wrap(); }
        }

        public Value ConstInt(ulong n, bool signExtend)
        {
            return LLVM.ConstInt(this.Unwrap(), n, signExtend).Wrap();
        }

        public Value ConstIntOfArbitraryPrecision(uint numWords, int[] words)
        {
            return LLVM.ConstIntOfArbitraryPrecision(this.Unwrap(), numWords, words).Wrap();
        }

        public Value ConstIntOfString(string text, char radix)
        {
            return LLVM.ConstIntOfString(this.Unwrap(), text, radix).Wrap();
        }

        public Value ConstIntOfStringAndSize(string text, uint sLen, char radix)
        {
            return LLVM.ConstIntOfStringAndSize(this.Unwrap(), text, sLen, radix).Wrap();
        }

        public Value ConstReal(double n)
        {
            return LLVM.ConstReal(this.Unwrap(), n).Wrap();
        }

        public Value ConstRealOfString(string text)
        {
            return LLVM.ConstRealOfString(this.Unwrap(), text).Wrap();
        }

        public Value ConstRealOfStringAndSize(string text, uint sLen)
        {
            return LLVM.ConstRealOfStringAndSize(this.Unwrap(), text, sLen).Wrap();
        }

        public Value ConstArray(Value[] constantVals)
        {
            return LLVM.ConstArray(this.Unwrap(), constantVals.Unwrap()).Wrap();
        }

        public Value ConstNamedStruct(Value[] constantVals)
        {
            return LLVM.ConstNamedStruct(this.Unwrap(), constantVals.Unwrap()).Wrap();
        }

        public Value Align
        {
            get { return LLVM.AlignOf(this.Unwrap()).Wrap(); }
        }

        public Value Size
        {
            get { return LLVM.SizeOf(this.Unwrap()).Wrap(); }
        }

        public string Name
        {
            get
            {
                if (this.IsVoidTy)
                {
                    return "void";
                }
                if (this.IsHalfTy)
                {
                    return "half";
                }
                if (this.IsFloatTy)
                {
                    return "float";
                }
                if (this.IsDoubleTy)
                {
                    return "double";
                }
                if (this.IsFP128Ty)
                {
                    return "fp128";
                }
                if (this.IsX86_FP80Ty)
                {
                    return "x86_fp80";
                }
                if (this.IsPPC_FP128Ty)
                {
                    return "ppc_fp128";
                }
                if (this.IsX86_MMXTy)
                {
                    return "x86_mmx";
                }
                if (this.IsIntegerTy)
                {
                    return "i" + this.IntBitWidth;
                }
                if (this.IsStructTy)
                {
                    return this.StructName;
                }
                if (this.IsPointerTy)
                {
                    return this.ElementType.Name + "*";
                }
                return string.Empty;
            }
        }

        public override string ToString()
        {
            var name = this.Name;
            if (name != string.Empty)
            {
                return name;
            }
            return base.ToString();
        }
    }
}