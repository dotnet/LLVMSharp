namespace LLVMSharp.API.TargetInitializers
{
    public sealed class SystemZTargetInitializer : TargetInitializer,
        ITarget, ITargetInfo, ITargetMC, IAsmPrinter, IAsmParser, IDisassembler
    {
        internal SystemZTargetInitializer()
        {            
        }

        public void Target() => LLVM.InitializeSystemZTarget();
        public void TargetInfo() => LLVM.InitializeSystemZTargetInfo();
        public void TargetMC() => LLVM.InitializeSystemZTargetMC();
        public void AsmPrinter() => LLVM.InitializeSystemZAsmPrinter();
        public void AsmParser() => LLVM.InitializeSystemZAsmParser();
        public void Disassembler() => LLVM.InitializeSystemZDisassembler();
    }
}
