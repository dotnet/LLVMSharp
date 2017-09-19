namespace LLVMSharp.Api.TargetInitializers
{
    public sealed class R600TargetInitializer :
        ITarget, ITargetInfo, ITargetMC, IAsmPrinter, IAsmParser
    {
        internal R600TargetInitializer()
        {
        }
        
        public void Target()
        {
            LLVM.InitializeR600Target();
        }

        public void TargetInfo()
        {
            LLVM.InitializeR600TargetInfo();
        }

        public void TargetMC()
        {
            LLVM.InitializeR600TargetMC();
        }

        public void AsmPrinter()
        {
            LLVM.InitializeR600AsmPrinter();
        }

        public void AsmParser()
        {
            LLVM.InitializeR600AsmParser();
        }
    }
}
