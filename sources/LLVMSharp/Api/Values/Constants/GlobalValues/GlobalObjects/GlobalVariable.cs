namespace LLVMSharp.API.Values.Constants.GlobalValues.GlobalObjects
{
    public sealed class GlobalVariable : GlobalObject
    {
        internal GlobalVariable(LLVMValueRef instance)
            : base(instance)
        {
        }

        public Value Initializer
        {
            get => LLVM.GetInitializer(this.Unwrap()).Wrap();
            set => LLVM.SetInitializer(this.Unwrap(), value.Unwrap());
        }

        public bool IsExternallyInitialized
        {
            get => LLVM.IsExternallyInitialized(this.Unwrap());
            set => LLVM.SetExternallyInitialized(this.Unwrap(), value);
        }

        public GlobalVariable NextGlobal => LLVM.GetNextGlobal(this.Unwrap()).WrapAs<GlobalVariable>();
        public GlobalVariable PreviousGlobal => LLVM.GetPreviousGlobal(this.Unwrap()).WrapAs<GlobalVariable>();

        public bool IsGlobalConstant
        {
            get => LLVM.IsGlobalConstant(this.Unwrap());
            set => LLVM.SetGlobalConstant(this.Unwrap(), value);
        }

        public bool IsThreadLocal
        {
            get => LLVM.IsThreadLocal(this.Unwrap());
            set => LLVM.SetThreadLocal(this.Unwrap(), value);
        }

        public ThreadLocalMode ThreadLocalMode
        {
            get => LLVM.GetThreadLocalMode(this.Unwrap()).Wrap();
            set => LLVM.SetThreadLocalMode(this.Unwrap(), value.Unwrap());
        }

        public void Delete() => LLVM.DeleteGlobal(this.Unwrap());
    }
}