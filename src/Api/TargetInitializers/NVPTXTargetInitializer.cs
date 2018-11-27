namespace LLVMSharp.API.TargetInitializers
{
    public sealed class NVPTXTargetInitializer : TargetInitializer,
        ITarget, ITargetInfo, ITargetMC, IAsmPrinter
    {
        internal NVPTXTargetInitializer()
        {            
        }

        public void Target() => LLVM.InitializeNVPTXTarget();
        public void TargetInfo() => LLVM.InitializeNVPTXTargetInfo();
        public void TargetMC() => LLVM.InitializeNVPTXTargetMC();
        public void AsmPrinter() => LLVM.InitializeNVPTXAsmPrinter();
    }
}
