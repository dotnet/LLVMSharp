namespace LLVMSharp.Api.Values.Constants
{
    using Utilities;

    public class GlobalValue : Constant
    {
        internal GlobalValue(LLVMValueRef instance)
            : base(instance)
        {
        }

        public LLVMLinkage ExternalLinkage
        {
            get { return LLVM.GetLinkage(this.Unwrap()); }
            set { LLVM.SetLinkage(this.Unwrap(), value); }
        }
    }
}