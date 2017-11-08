namespace LLVMSharp.Api.Types
{
    public sealed class MetadataType : Type
    {
        internal MetadataType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }
    }
}
