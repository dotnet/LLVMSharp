namespace LLVMSharp
{
    using System;

    public class Type : IEquatable<Type>
    {
        public static readonly Type Int1 = new Type(LLVM.Int1Type());
        public static readonly Type Int8 = new Type(LLVM.Int8Type());
        public static readonly Type Int16 = new Type(LLVM.Int16Type());
        public static readonly Type Int32 = new Type(LLVM.Int32Type());
        public static readonly Type Int64 = new Type(LLVM.Int64Type());

        public static readonly Type Half = new Type(LLVM.HalfType());
        public static readonly Type Float = new Type(LLVM.FloatType());
        public static readonly Type Double = new Type(LLVM.DoubleType());
        public static readonly Type X86FP80 = new Type(LLVM.X86FP80Type());
        public static readonly Type FP128 = new Type(LLVM.FP128Type());
        public static readonly Type PPCFP128 = new Type(LLVM.PPCFP128Type());

        public static Type Int(int bitLength)
        {
            return LLVM.IntType((uint) bitLength);
        }

        protected readonly LLVMTypeRef Instance;
        private readonly LLVMTypeKind kind;

        public Type(LLVMTypeRef typeRef)
        {
            this.Instance = typeRef;
            this.kind = LLVM.GetTypeKind(typeRef);
        }

        internal LLVMTypeRef TypeRef
        {
            get { return this.Instance; }
        }

        public void Print()
        {
            LLVM.PrintTypeToString(this.ToTypeRef());
        }

        public void Dump()
        {
            LLVM.DumpType(this.ToTypeRef());
        }

        public LLVMContextRef Context
        {
            get { return LLVM.GetTypeContext(this.ToTypeRef()); }
        }

        public bool IsVoidTy
        {
            get { return this.kind == LLVMTypeKind.LLVMVoidTypeKind; }
        }

        public bool IsHalfTy
        {
            get { return this.kind == LLVMTypeKind.LLVMHalfTypeKind; }
        }

        public bool IsFloatTy
        {
            get { return this.kind == LLVMTypeKind.LLVMFloatTypeKind; }
        }

        public bool IsDoubleTy
        {
            get { return this.kind == LLVMTypeKind.LLVMDoubleTypeKind; }
        }

        public bool IsX86_FP80Ty
        {
            get { return this.kind == LLVMTypeKind.LLVMX86_FP80TypeKind; }
        }

        public bool IsFP128Ty
        {
            get { return this.kind == LLVMTypeKind.LLVMFP128TypeKind; }
        }

        public bool IsPPC_FP128Ty
        {
            get { return this.kind == LLVMTypeKind.LLVMPPC_FP128TypeKind; }
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
            get { return this.kind == LLVMTypeKind.LLVMX86_MMXTypeKind; }
        }

        public bool IsLabelTy
        {
            get { return this.kind == LLVMTypeKind.LLVMLabelTypeKind; }
        }

        public bool IsMetadataTy
        {
            get { return this.kind == LLVMTypeKind.LLVMMetadataTypeKind; }
        }

        public bool IsIntegerTy
        {
            get { return this.kind == LLVMTypeKind.LLVMIntegerTypeKind; }
        }

        public bool IsIntegerBitwidh(uint bitwidth)
        {
            return this.kind == LLVMTypeKind.LLVMIntegerTypeKind && LLVM.GetIntTypeWidth(this.Instance) == bitwidth;
        }
        
        public bool IsFunctionTy
        {
            get { return this.kind == LLVMTypeKind.LLVMFunctionTypeKind; }
        }

        public bool IsStructTy
        {
            get { return this.kind == LLVMTypeKind.LLVMStructTypeKind; }
        }

        public bool IsArrayTy
        {
            get { return this.kind == LLVMTypeKind.LLVMArrayTypeKind; }
        }

        public bool IsPointerTy
        {
            get { return this.kind == LLVMTypeKind.LLVMPointerTypeKind; }
        }

        public bool IsVectorTy
        {
            get { return this.kind == LLVMTypeKind.LLVMVectorTypeKind; }
        }

        public uint IntegerBitWidth
        {
            get { return LLVM.GetIntTypeWidth(this.ToTypeRef()); }
        }

        public Type GetFunctionParamType(uint i)
        {
            return new Type(LLVM.GetParamTypes(this.ToTypeRef())[i]);
        }

        public uint FunctionNumParams
        {
            get { return LLVM.CountParamTypes(this.ToTypeRef()); }
        }

        public bool IsFunctionVarArg
        {
            get { return LLVM.IsFunctionVarArg(this.ToTypeRef()); }
        }

        public string StructName
        {
            get { return LLVM.GetStructName(this.ToTypeRef()); }
        }

        public uint StructNumElements
        {
            get { return LLVM.CountStructElementTypes(this.ToTypeRef()); }
        }

        public Type GetStructElementType(uint i)
        {
            return new Type(LLVM.GetStructElementTypes(this.ToTypeRef())[i]);
        }
        
        public static implicit operator Type(LLVMTypeRef typeRef)
        {
            return new Type(typeRef);
        }

        public static LLVMTypeRef LabelType()
        {
            return LLVM.LabelType();
        }

        public static Type LabelType(LLVMContext c)
        {
            return new Type(LLVM.LabelTypeInContext(c.InternalValue));
        }

        public bool Equals(Type other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            else
            {
                return this.Instance == other.Instance;
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
            return this.Instance.GetHashCode();
        }

        public Value ConstInt(ulong value, bool signExtend)
        {
            return LLVM.ConstInt(this.ToTypeRef(), value, signExtend).ToValue();
        }

    }
}