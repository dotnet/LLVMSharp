namespace LLVMSharp.API.Types
{
    public sealed class LabelType : Type
    {
        public static LabelType Create() => LLVM.LabelType().WrapAs<LabelType>();
        public static LabelType Create(Context context) => LLVM.LabelTypeInContext(context.Unwrap()).WrapAs<LabelType>();

        internal LabelType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override string Name => "label";
    }
}
