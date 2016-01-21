namespace LLVMSharp
{
    public sealed class Use : IWrapper<LLVMUseRef>
    {
        LLVMUseRef IWrapper<LLVMUseRef>.ToHandleType()
        {
            return this._instance;
        }

        void IWrapper<LLVMUseRef>.MakeHandleOwner()
        {
        }

        private readonly LLVMUseRef _instance;

        internal Use(LLVMUseRef instance)
        {
            this._instance = instance;
        }

        public Use NextUse
        {
            get { return LLVM.GetNextUse(this.Unwrap()).Wrap(); }
        }

        public Value User
        {
            get { return LLVM.GetUser(this.Unwrap()).Wrap(); }
        }

        public Value UsedValue
        {
            get { return LLVM.GetUsedValue(this.Unwrap()).Wrap(); }
        }
    }
}
