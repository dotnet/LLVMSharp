namespace LLVMSharp.API.TargetInitializers
{
    public sealed class NativeTargetInitializer : TargetInitializer,
        ITarget, IAsmPrinter, IAsmParser, IDisassembler
    {
        internal NativeTargetInitializer()
        {            
        }

        public void Target() => LLVM.InitializeNativeTarget();
        public void AsmPrinter() => LLVM.InitializeNativeAsmPrinter();
        public void AsmParser() => LLVM.InitializeNativeAsmParser();
        public void Disassembler() => LLVM.InitializeNativeDisassembler();
    }
}
