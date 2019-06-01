namespace LLVMSharp.API.TargetInitializers
{
    public sealed class MSP430TargetInitializer : TargetInitializer,
        ITarget, ITargetInfo, ITargetMC, IAsmPrinter
    {
        internal MSP430TargetInitializer()
        {            
        }

        public void Target() => LLVM.InitializeMSP430Target();
        public void TargetInfo() => LLVM.InitializeMSP430TargetInfo();
        public void TargetMC() => LLVM.InitializeMSP430TargetMC();
        public void AsmPrinter() => LLVM.InitializeMSP430AsmPrinter();
    }
}
