namespace LLVMSharp.Api.TargetInitializers
{
    public sealed class XCoreTargetInitializer :
        ITarget, ITargetInfo, ITargetMC, IAsmPrinter, IDisassembler
    {
        public void Target()
        {
            LLVM.InitializeXCoreTarget();
        }

        public void TargetInfo()
        {
            LLVM.InitializeXCoreTargetInfo();
        }

        public void TargetMC()
        {
            LLVM.InitializeXCoreTargetMC();
        }

        public void AsmPrinter()
        {
            LLVM.InitializeXCoreAsmPrinter();
        }
        
        public void Disassembler()
        {
            LLVM.InitializeXCoreDisassembler();
        }
    }
}
