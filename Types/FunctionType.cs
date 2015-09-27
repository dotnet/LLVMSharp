namespace LLVMSharp
{
    using System;

    public sealed class FunctionType : Type
    {
        private readonly Type[] _params;

        /// <summary>
        /// get
        /// </summary>
        /// <param name="result">Type *</param>
        /// <param name="isVarArg">bool</param>
        /// <returns>Type *</returns>
        public static FunctionType Get(Type result, bool isVarArg)
        {
            return Get(result, new Type[1], isVarArg);
        }

        /// <summary>
        /// get
        /// </summary>
        /// <param name="result">Type *</param>
        /// <param name="params">ArrayRef[Type *]</param>
        /// <param name="isVarArg">bool</param>
        /// <returns>Type *</returns>
        public static FunctionType Get(Type result, Type[] @params, bool isVarArg)
        {
            uint count = (uint) @params.Length;
            var args = new LLVMTypeRef[Math.Max(count, 1)];
            for (int i = 0; i < count; ++i)
            {
                args[i] = @params[i].TypeRef;
            }

            return
                new FunctionType(LLVM.FunctionType(result.TypeRef, out args[0], (uint) args.Length,
                    isVarArg ? new LLVMBool(1) : new LLVMBool(0)));
        }

        internal FunctionType(LLVMTypeRef typeRef) 
            : base(typeRef)
        {
            this._params = new Type[LLVM.CountParamTypes(this.Instance)];
        }

        public FunctionType(Type returnType, Type[] parameterTypes)
            : this(returnType, parameterTypes, false)
        {            
        }

        public FunctionType(Type returnType, Type[] parameterTypes, bool isVarArgs)
            : base(LLVM.FunctionType(returnType.ToTypeRef(), parameterTypes.ToTypeRefs(), isVarArgs))
        {
        }

        /// <summary>
        /// getNumParams
        /// </summary>
        /// <returns>uint</returns>
        public uint NumParams
        {
            get { return (uint)this._params.Length; }
        }

        /// <summary>
        /// isVarArg
        /// </summary>
        /// <returns>bool</returns>
        public bool IsVarArg { get { return LLVM.IsFunctionVarArg(this.Instance).Value == 1; } }

        /// <summary>
        /// getReturnType
        /// </summary>
        /// <returns>Type *</returns>
        public Type ReturnType { get { return new Type(LLVM.GetReturnType(this.Instance)); } }

        /// <summary>
        /// getParamType
        /// </summary>
        /// <param name="i">unsigned</param>
        /// <returns>Type *</returns>
        public Type GetParamType(uint i)
        {
            return this._params[i];
        }
    }
}