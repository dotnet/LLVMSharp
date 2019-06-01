namespace LLVMSharp.API.TargetInitializers
{
    public sealed class X86TargetInitializer : TargetInitializer,
        ITarget, ITargetInfo, ITargetMC, IAsmPrinter, IAsmParser, IDisassembler
    {
        internal X86TargetInitializer()
        {            
        }

        public void Target() => LLVM.InitializeX86Target();
        public void TargetInfo() => LLVM.InitializeX86TargetInfo();
        public void TargetMC() => LLVM.InitializeX86TargetMC();
        public void AsmPrinter() => LLVM.InitializeX86AsmPrinter();
        public void AsmParser() => LLVM.InitializeX86AsmParser();
        public void Disassembler() => LLVM.InitializeX86Disassembler();
    }
}
