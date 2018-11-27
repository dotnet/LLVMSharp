namespace LLVMSharp.API.Types
{
    public sealed class MetadataType : Type
    {
        internal MetadataType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }
    }
}
