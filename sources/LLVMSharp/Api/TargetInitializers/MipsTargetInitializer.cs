namespace LLVMSharp.API.TargetInitializers
{
    public sealed class MipsTargetInitializer : TargetInitializer,
        ITarget, ITargetInfo, ITargetMC, IAsmPrinter, IAsmParser, IDisassembler
    {
        internal MipsTargetInitializer()
        {            
        }

        public void Target() => LLVM.InitializeMipsTarget();
        public void TargetInfo() => LLVM.InitializeMipsTargetInfo();
        public void TargetMC() => LLVM.InitializeMipsTargetMC();
        public void AsmPrinter() => LLVM.InitializeMipsAsmPrinter();
        public void AsmParser() => LLVM.InitializeMipsAsmParser();
        public void Disassembler() => LLVM.InitializeMipsDisassembler();
    }
}
