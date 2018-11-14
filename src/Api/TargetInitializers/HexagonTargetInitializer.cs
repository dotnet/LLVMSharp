namespace LLVMSharp.API.TargetInitializers
{
    public sealed class HexagonTargetInitializer : TargetInitializer,
        ITarget, ITargetInfo, ITargetMC, IAsmPrinter
    {
        internal HexagonTargetInitializer()
        {            
        }

        public void Target() => LLVM.InitializeHexagonTarget();
        public void TargetInfo() => LLVM.InitializeHexagonTargetInfo();
        public void TargetMC() => LLVM.InitializeHexagonTargetMC();
        public void AsmPrinter() => LLVM.InitializeHexagonAsmPrinter();
    }
}
