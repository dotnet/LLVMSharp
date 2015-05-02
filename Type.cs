namespace LLVMSharp
{
    public class Type
    {
        protected LLVMTypeRef typeRef;

        private readonly LLVMTypeKind kind;

        public Type(LLVMTypeRef typeRef)
        {
            this.typeRef = typeRef;
            this.kind = LLVM.GetTypeKind(typeRef);
        }

        internal LLVMTypeRef TypeRef { get { return this.typeRef; } }

        public void Dump()
        {
            LLVM.DumpType(this.typeRef);
        }

        public LLVMContext Context { get; private set; }

        /// <summary>
        /// isVoidTy
        /// </summary>
        /// <returns>bool</returns>
        public bool IsVoidTy
        {
            get { return kind == LLVMTypeKind.LLVMVoidTypeKind; }
        }

        /// <summary>
        /// isHalfTy
        /// </summary>
        /// <returns>bool</returns>
        public bool IsHalfTy
        {
            get { return kind == LLVMTypeKind.LLVMHalfTypeKind; }
        }

        /// <summary>
        /// isFloatTy
        /// </summary>
        /// <returns>bool</returns>
        public bool IsFloatTy
        {
            get { return kind == LLVMTypeKind.LLVMFloatTypeKind; }
        }

        /// <summary>
        /// isDoubleTy
        /// </summary>
        /// <returns>bool</returns>
        public bool IsDoubleTy
        {
            get { return kind == LLVMTypeKind.LLVMDoubleTypeKind; }
        }

        /// <summary>
        /// isX86_FP80Ty
        /// </summary>
        /// <returns>bool</returns>
        public bool IsX86_FP80Ty
        {
            get { return kind == LLVMTypeKind.LLVMX86_FP80TypeKind; }
        }

        /// <summary>
        /// isFP128Ty
        /// </summary>
        /// <returns>bool</returns>
        public bool IsFP128Ty
        {
            get { return kind == LLVMTypeKind.LLVMFP128TypeKind; }
        }

        /// <summary>
        /// isPPC_FP128Ty
        /// </summary>
        /// <returns>bool</returns>
        public bool IsPPC_FP128Ty
        {
            get { return kind == LLVMTypeKind.LLVMPPC_FP128TypeKind; }
        }

        /// <summary>
        /// isFloatingPointTy
        /// </summary>
        /// <returns>bool</returns>
        public bool IsFloatingPointTy
        {
            get { return kind == LLVMTypeKind.LLVMFloatTypeKind; }
        }

        /// <summary>
        /// isLabelTy
        /// </summary>
        /// <returns>bool</returns>
        public bool IsLabelTy
        {
            get { return kind == LLVMTypeKind.LLVMLabelTypeKind; }
        }

        /// <summary>
        /// isMetadataTy
        /// </summary>
        /// <returns>bool</returns>
        public bool IsMetadataTy
        {
            get { return kind == LLVMTypeKind.LLVMMetadataTypeKind; }
        }

        /// <summary>
        /// isIntegerTy
        /// </summary>
        /// <returns>bool</returns>
        public bool IsIntegerTy
        {
            get { return kind == LLVMTypeKind.LLVMIntegerTypeKind; }
        }

        public Type GetLabelType()
        {
            return new Type(LLVM.LabelType());
        }

        public static Type GetLabelType(LLVMContext c)
        {
            return new Type(LLVM.LabelTypeInContext(c.InternalValue));
        }

        public static implicit operator Type(LLVMTypeRef typeRef)
        {
            return new Type(typeRef);
        }
    }
}