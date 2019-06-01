namespace LLVMSharp.API
{
    using Utilities;

    public sealed class PassRegistry : IWrapper<LLVMPassRegistryRef>
    {
        LLVMPassRegistryRef IWrapper<LLVMPassRegistryRef>.ToHandleType => this._instance;

        public static PassRegistry Global => LLVM.GetGlobalPassRegistry().Wrap();

        private readonly LLVMPassRegistryRef _instance;

        internal PassRegistry(LLVMPassRegistryRef instance)
        {
            this._instance = instance;
        }

        public void InitializeCore() => LLVM.InitializeCore(this.Unwrap());
        public void InitializeTransformUtils() => LLVM.InitializeTransformUtils(this.Unwrap());
        public void InitializeScalarOpts() => LLVM.InitializeScalarOpts(this.Unwrap());
        public void InitializeObjCARCOpts() => LLVM.InitializeObjCARCOpts(this.Unwrap());
        public void InitializeVectorization() => LLVM.InitializeVectorization(this.Unwrap());
        public void InitializeInstCombine() => LLVM.InitializeInstCombine(this.Unwrap());
        public void InitializeIPO() => LLVM.InitializeIPO(this.Unwrap());
        public void InitializeInstrumentation() => LLVM.InitializeInstrumentation(this.Unwrap());
        public void InitializeAnalysis() => LLVM.InitializeAnalysis(this.Unwrap());
        public void InitializeIPA() => LLVM.InitializeIPA(this.Unwrap());
        public void InitializeCodeGen() => LLVM.InitializeCodeGen(this.Unwrap());
        public void InitializeTarget() => LLVM.InitializeTarget(this.Unwrap());
    }
}
