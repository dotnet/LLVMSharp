namespace LLVMSharp.API.Values.Constants
{
    using global::System;

    public class ConstantDataSequential : Constant
    {
        internal ConstantDataSequential(LLVMValueRef instance)
            : base(instance)
        {
        }

        public bool IsString => LLVM.IsConstantString(this.Unwrap());

        public string GetAsString() => this.IsString ? LLVM.GetAsString(this.Unwrap(), out size_t @out) : throw new InvalidOperationException();

        public Value GetElementAsConstant(uint idx) => LLVM.GetElementAsConstant(this.Unwrap(), idx).Wrap();
    }
}