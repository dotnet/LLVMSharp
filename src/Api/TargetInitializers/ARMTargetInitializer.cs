﻿namespace LLVMSharp.Api.TargetInitializers
{
    public sealed class ARMTargetInitializer : 
        ITarget, ITargetInfo, ITargetMC, IAsmPrinter, IAsmParser, IDisassembler
    {
        internal ARMTargetInitializer()
        {
        }

        public void Target() => LLVM.InitializeARMTarget();
        public void TargetInfo() => LLVM.InitializeARMTargetInfo();
        public void TargetMC() => LLVM.InitializeARMTargetMC();
        public void AsmPrinter() => LLVM.InitializeARMAsmPrinter();
        public void AsmParser() => LLVM.InitializeARMAsmParser();
        public void Disassembler() => LLVM.InitializeARMDisassembler();
    }
}
