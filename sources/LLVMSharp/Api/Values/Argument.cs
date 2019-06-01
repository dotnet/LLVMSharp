namespace LLVMSharp.API.Values
{
    using LLVMSharp.API.Values.Constants.GlobalValues.GlobalObjects;

    public sealed class Argument : Value
    {
        public Argument(LLVMValueRef pointer)
            : base(pointer)
        {
        }

        public void SetAlignment(uint align) => LLVM.SetParamAlignment(this.Unwrap(), align);       

        public Function Parent => LLVM.GetParamParent(this.Unwrap()).WrapAs<Function>();
        public Argument NextParameter => LLVM.GetNextParam(this.Unwrap()).WrapAs<Argument>();
        public Argument PreviousParameter => LLVM.GetPreviousParam(this.Unwrap()).WrapAs<Argument>();
    }
}
