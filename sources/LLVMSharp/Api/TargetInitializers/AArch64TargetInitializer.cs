namespace LLVMSharp.API.TargetInitializers
{
    public sealed class AArch64TargetInitializer : TargetInitializer,
        ITarget, ITargetInfo, ITargetMC, IAsmPrinter, IAsmParser, IDisassembler
    {
        internal AArch64TargetInitializer()
        {            
        }

        public void Target() => LLVM.InitializeAArch64Target();
        public void TargetInfo() => LLVM.InitializeAArch64TargetInfo();
        public void TargetMC() => LLVM.InitializeAArch64TargetMC();
        public void AsmPrinter() => LLVM.InitializeAArch64AsmPrinter();
        public void AsmParser() => LLVM.InitializeAArch64AsmParser();
        public void Disassembler() => LLVM.InitializeAArch64Disassembler();
    }
}
