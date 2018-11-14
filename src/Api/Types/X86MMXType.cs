namespace LLVMSharp.API.Types
{
    using Type = LLVMSharp.API.Type;

    public sealed class X86MMXType : Type
    {
        internal X86MMXType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override string Name => "x86_mmx";
        public override uint PrimitiveSizeInBits => 64;
        public override bool IsSingleValueType => true;

        public override bool CanHaveConstants => false;
        public override bool CanHaveArrays => false;
        public override bool CanHaveVectors => false;

        protected internal override string GetLimitedTypeMessage()
            => "This type represents a value held in an MMX register of an x86 machine. Thus, there can be no arrays, vectors or constants of this type.";
    }
}
