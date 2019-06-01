namespace LLVMSharp.API
{
    public abstract class MetadataAsValue : Value
    {
        internal MetadataAsValue(LLVMValueRef instance) 
            : base(instance)
        {
        }

        public string MDString => LLVM.GetMDString(this.Unwrap(), out uint len);
    }
}
