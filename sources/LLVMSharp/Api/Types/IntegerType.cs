namespace LLVMSharp.API.Types
{
    public sealed class IntegerType : Type
    {
        public static IntegerType Create(uint bitWidth) => LLVM.IntType(bitWidth).WrapAs<IntegerType>();
        public static IntegerType Create(Context context, uint bitWidth) => LLVM.IntTypeInContext(context.Unwrap(), bitWidth).WrapAs<IntegerType>();

        internal IntegerType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public uint BitWidth => LLVM.GetIntTypeWidth(this.Unwrap());
        public override bool IsSingleValueType => true;

        public override string Name => $"i{this.BitWidth}";
        public override uint PrimitiveSizeInBits => this.BitWidth;
    }
}
