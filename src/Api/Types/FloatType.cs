namespace LLVMSharp.API.Types
{
    public sealed class FloatType : FPType
    {
        internal FloatType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override string Name => "float";
        public override uint PrimitiveSizeInBits => 32;
        public override int MantissaWidth => 24;
    }
}
