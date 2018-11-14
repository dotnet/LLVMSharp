namespace LLVMSharp.API.Types
{
    public sealed class VoidType : Type
    {
        internal VoidType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override string Name => "void";
        public override bool IsFirstClassType => false;
    }
}
