namespace LLVMSharp.API.Types
{
    public abstract class FPType : Type
    {
        internal FPType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public abstract int MantissaWidth { get; }
        public override abstract uint PrimitiveSizeInBits { get; }
        public override bool IsSingleValueType => true;
    }
}
