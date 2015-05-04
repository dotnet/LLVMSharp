namespace LLVMSharp
{
    using System;

    public class Type : IEquatable<Type>
    {
        protected readonly LLVMTypeRef instance;

        private readonly LLVMTypeKind kind;

        public Type(LLVMTypeRef typeRef)
        {
            this.instance = typeRef;
            this.kind = LLVM.GetTypeKind(typeRef);
        }

        internal LLVMTypeRef TypeRef
        {
            get { return this.instance; }
        }

        public void Print()
        {
            LLVM.PrintTypeToString(this.instance);
        }

        public void Dump()
        {
            LLVM.DumpType(this.instance);
        }

        public LLVMContextRef Context
        {
            get { return LLVM.GetTypeContext(this.instance); }
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

        public bool IsIntegerBitwidh(uint Bitwidth)
        {
            return this.kind == LLVMTypeKind.LLVMIntegerTypeKind && LLVM.GetIntTypeWidth(this.instance) == Bitwidth;
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
            get { return LLVM.GetIntTypeWidth(this.instance); }
        }

        public Type GetFunctionParamType(uint i)
        {
            return new Type(LLVM.GetParamTypes(this.instance)[i]);
        }

        public uint FunctionNumParams
        {
            get { return LLVM.CountParamTypes(this.instance); }
        }

        public bool IsFunctionVarArg
        {
            get { return LLVM.IsFunctionVarArg(this.instance); }
        }

        public string StructName
        {
            get { return LLVM.GetStructName(this.instance); }
        }

        public uint StructNumElements
        {
            get { return LLVM.CountStructElementTypes(this.instance); }
        }

        public Type GetStructElementType(uint i)
        {
            return new Type(LLVM.GetStructElementTypes(this.instance)[i]);
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
                return this.instance == other.instance;
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
            return this.instance.GetHashCode();
        }
    }
}