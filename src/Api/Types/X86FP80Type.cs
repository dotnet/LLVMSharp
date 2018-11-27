namespace LLVMSharp.API.Types
{
    public sealed class X86FP80Type : FPType
    {
        internal X86FP80Type(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override string Name => "x86_fp80";
        public override uint PrimitiveSizeInBits => 80;
        public override int MantissaWidth => 64;
    }
}
