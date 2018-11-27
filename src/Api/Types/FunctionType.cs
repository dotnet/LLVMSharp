namespace LLVMSharp.API.Types
{
    using Type = API.Type;

    public sealed class FunctionType : Type
    {
        public static FunctionType Create(Type returnType) => Create(returnType, false);
        public static FunctionType Create(Type returnType, bool isVarArg) => Create(returnType, new Type[0], isVarArg);
        public static FunctionType Create(Type returnType, params Type[] parameterTypes) => Create(returnType, parameterTypes, false);
        public static FunctionType Create(Type returnType, Type[] parameterTypes, bool isVarArg) => LLVM.FunctionType(returnType.Unwrap(), parameterTypes.Unwrap(), isVarArg ? new LLVMBool(1) : new LLVMBool(0)).WrapAs<FunctionType>();

        internal FunctionType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override string Name => $"{ReturnType} ({string.Join<Type>(", ", ParamTypes)})";
        public override bool IsFirstClassType => false;

        public Type ReturnType => Create(LLVM.GetReturnType(this.Unwrap()));
        public uint NumParams => LLVM.CountParamTypes(this.Unwrap());
        public Type GetParamType(uint index) => Create(LLVM.GetParamTypes(this.Unwrap())[index]);
        public Type[] ParamTypes => LLVM.GetParamTypes(this.Unwrap()).Wrap<LLVMTypeRef, Type>();
        public bool IsVarArg => LLVM.IsFunctionVarArg(this.Unwrap());
    }
}