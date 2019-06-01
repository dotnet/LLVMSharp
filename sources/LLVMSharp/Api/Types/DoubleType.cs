namespace LLVMSharp.API.Types
{
    public sealed class DoubleType : FPType
    {
        internal DoubleType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override string Name => "double";
        public override uint PrimitiveSizeInBits => 64;
        public override int MantissaWidth => 53;
    }
}
