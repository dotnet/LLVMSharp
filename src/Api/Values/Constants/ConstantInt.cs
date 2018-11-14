namespace LLVMSharp.API.Values.Constants
{
    using LLVMSharp.API.Types;

    public sealed class ConstantInt : Constant
    {
        public static ConstantInt Get(IntegerType type, ulong value) => Get(type, value, false);
        public static ConstantInt Get(IntegerType type, ulong value, bool signExtend) => LLVM.ConstInt(type.Unwrap(), value, signExtend).WrapAs<ConstantInt>();
        public static ConstantInt Get(IntegerType type, ulong[] words) => LLVM.ConstIntOfArbitraryPrecision(type.Unwrap(), (uint)words.Length, words).WrapAs<ConstantInt>();
        public static ConstantInt Get(IntegerType type, string str, byte radix) => LLVM.ConstIntOfString(type.Unwrap(), str, radix).WrapAs<ConstantInt>();

        internal ConstantInt(LLVMValueRef instance)
            : base(instance)
        {
        }

        public ulong ZExtValue => LLVM.ConstIntGetZExtValue(this.Unwrap());
        public long SExtValue => LLVM.ConstIntGetSExtValue(this.Unwrap());
    }
}