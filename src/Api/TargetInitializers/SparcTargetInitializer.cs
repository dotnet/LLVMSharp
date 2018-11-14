namespace LLVMSharp.API.TargetInitializers
{
    public sealed class SparcTargetInitializer : TargetInitializer,
        ITarget, ITargetInfo, ITargetMC, IAsmPrinter, IAsmParser, IDisassembler
    {
        internal SparcTargetInitializer()
        {            
        }

        public void Target() => LLVM.InitializeSparcTarget();
        public void TargetInfo() => LLVM.InitializeSparcTargetInfo();
        public void TargetMC() => LLVM.InitializeSparcTargetMC();
        public void AsmPrinter() => LLVM.InitializeSparcAsmPrinter();
        public void AsmParser() => LLVM.InitializeSparcAsmParser();
        public void Disassembler() => LLVM.InitializeSparcDisassembler();
    }
}
