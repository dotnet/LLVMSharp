namespace LLVMSharp.API.Types
{
    public sealed class PPCFP128Type : FPType
    {
        internal PPCFP128Type(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override string Name => "ppc_fp128";
        public override uint PrimitiveSizeInBits => 80;
        public override int MantissaWidth => -1;
    }
}
