namespace LLVMSharp.API.Values.Constants
{
    public sealed class ConstantStruct : Constant
    {
        public static ConstantStruct GetAnon(params Value[] values) => GetAnon(values, false);
        public static ConstantStruct GetAnon(Value[] values, bool packed) => LLVM.ConstStruct(values.Unwrap(), packed).WrapAs<ConstantStruct>();
        public static ConstantStruct GetAnon(Context context, params Value[] values) => GetAnon(context, values, false);
        public static ConstantStruct GetAnon(Context context, Value[] values, bool packed) => LLVM.ConstStructInContext(context.Unwrap(), values.Unwrap(), packed).WrapAs<ConstantStruct>();
        public static ConstantStruct Get(Type structType, Constant[] values) => LLVM.ConstNamedStruct(structType.Unwrap(), values.Unwrap()).WrapAs<ConstantStruct>();

        internal ConstantStruct(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}