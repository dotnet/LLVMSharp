namespace LLVMSharp.API
{
    public sealed class MDStringAsValue : MetadataAsValue
    {
        internal MDStringAsValue(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}
