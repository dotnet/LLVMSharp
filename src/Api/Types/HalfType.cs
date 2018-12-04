namespace LLVMSharp.API.Types
{
    public sealed class HalfType : FPType
    {
        internal HalfType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override string Name => "half";
        public override uint PrimitiveSizeInBits => 16;
        public override int MantissaWidth => 11;
    }
}
