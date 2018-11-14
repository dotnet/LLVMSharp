namespace LLVMSharp.API.Types
{
    public sealed class FP128Type : FPType
    {
        internal FP128Type(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override string Name => "fp128";
        public override uint PrimitiveSizeInBits => 128;
        public override int MantissaWidth => 113;
    }
}
