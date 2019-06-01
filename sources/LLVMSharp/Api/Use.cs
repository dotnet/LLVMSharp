namespace LLVMSharp.API
{
    using Utilities;

    public sealed class Use : IWrapper<LLVMUseRef>
    {
        LLVMUseRef IWrapper<LLVMUseRef>.ToHandleType => this._instance;

        private readonly LLVMUseRef _instance;

        internal Use(LLVMUseRef instance)
        {
            this._instance = instance;
        }

        public Use Next => LLVM.GetNextUse(this.Unwrap()).Wrap();
        public Value User => LLVM.GetUser(this.Unwrap()).Wrap();
        public Value UsedValue => LLVM.GetUsedValue(this.Unwrap()).Wrap();

        public override string ToString() => this.User.ToString();
    }
}
