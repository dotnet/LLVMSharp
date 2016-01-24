namespace LLVMSharp
{
    using System;

    public sealed class FunctionType : Type
    {
        private readonly Type[] _params;

        public static FunctionType Get(Type result, bool isVarArg)
        {
            return Get(result, new Type[1], isVarArg);
        }

        public static FunctionType Get(Type result, Type[] @params, bool isVarArg)
        {
            var count = (uint) @params.Length;
            var args = new LLVMTypeRef[Math.Max(count, 1)];
            for (var i = 0; i < count; ++i)
            {
                args[i] = @params[i].Unwrap();
            }

            return
                new FunctionType(LLVM.FunctionType(result.Unwrap(), out args[0], (uint) args.Length,
                    isVarArg ? new LLVMBool(1) : new LLVMBool(0)));
        }

        internal FunctionType(LLVMTypeRef typeRef) 
            : base(typeRef)
        {
            this._params = new Type[LLVM.CountParamTypes(this.Unwrap())];
        }

        public FunctionType(Type returnType, Type[] parameterTypes)
            : this(returnType, parameterTypes, false)
        {            
        }

        public FunctionType(Type returnType, Type[] parameterTypes, bool isVarArgs)
            : base(LLVM.FunctionType(returnType.Unwrap(), parameterTypes.Unwrap(), isVarArgs))
        {
        }
        
        public uint NumParams
        {
            get { return (uint) this._params.Length; }
        }

        public bool IsVarArg
        {
            get { return LLVM.IsFunctionVarArg(this.Unwrap()).Value == 1; }
        }

        public Type ReturnType
        {
            get { return Type.Create(LLVM.GetReturnType(this.Unwrap())); }
        }

        public Type GetParamType(uint i)
        {
            return this._params[i];
        }

        public Type[] GetParamTypes()
        {
            return LLVM.GetParamTypes(this.Unwrap()).Wrap<LLVMTypeRef, Type>();
        }
    }
}