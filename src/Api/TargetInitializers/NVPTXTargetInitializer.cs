namespace LLVMSharp.Api.TargetInitializers
{
    public sealed class NVPTXTargetInitializer :
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
