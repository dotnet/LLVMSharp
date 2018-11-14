namespace LLVMSharp.API.Values.Constants.ConstantDataSequentials
{
    using LLVMSharp.API.Types;
    using global::System;
    using Type = LLVMSharp.API.Type;

    public sealed class ConstantDataArray : ConstantDataSequential
    {
        private static Constant GetGeneric<TType, TData>(TType type, Func<TType, ulong, Constant> selector, params TData[] data)
            where TType : Type
        {
            var constants = new Constant[data.Length];
            for(var i = 0; i < data.Length; i++)
            {
                var extended = Convert.ToUInt64(data[i]);
                constants[i] = selector(type, extended);
            }
            return LLVM.ConstArray(type.Unwrap(), constants.Unwrap()).WrapAs<Constant>();
        }

        private static Constant Get<TData>(IntegerType type, params TData[] data) => GetGeneric(type, (x, y) => ConstantInt.Get(x, y), data);
        private static Constant GetFP<TData>(FPType type, params TData[] data) => GetGeneric(type, (x, y) => ConstantFP.Get(x, y), data);

        public static Constant Get(Context context, params byte[] data) => Get(context.Int8Type, data);
        public static Constant Get(Context context, params ushort[] data) => Get(context.Int16Type, data);
        public static Constant Get(Context context, params uint[] data) => Get(context.Int32Type, data);
        public static Constant Get(Context context, params ulong[] data) => Get(context.Int64Type, data);

        public static Constant GetFP(Context context, params float[] data) => GetFP(context.FloatType, data);
        public static Constant GetFP(Context context, params double[] data) => GetFP(context.DoubleType, data);

        public static Constant GetString(Context context, string text, bool nullTerminate) => LLVM.ConstStringInContext(context.Unwrap(), text, (uint)text.Length, nullTerminate).WrapAs<Constant>();
        public static Constant GetString(Context context, string text) => GetString(context, text, true);

        public static Constant GetString(string str, bool nullTerminate) => LLVM.ConstString(str, (uint)str.Length, !nullTerminate).WrapAs<Constant>();
        public static Constant GetString(string str) => GetString(str, true);
                   
        internal ConstantDataArray(LLVMValueRef v)
            : base(v)
        {
        }
    }
}