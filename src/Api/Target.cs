namespace LLVMSharp.Api
{
    using System;
    using System.Collections.Generic;
    using Utilities;

    public sealed class Target : IWrapper<LLVMTargetRef>
    {
        LLVMTargetRef IWrapper<LLVMTargetRef>.ToHandleType => this._instance;

        public static string DefaultTriple => LLVM.GetDefaultTargetTriple().MessageToString();

        public static IReadOnlyList<Target> Targets
        {
            get
            {
                var targets = new List<Target>();
                var t = LLVM.GetFirstTarget().Wrap();
                while (t != null)
                {
                    targets.Add(t);
                    t = LLVM.GetNextTarget(t.Unwrap()).Wrap();
                }
                return targets;
            }
        }

        public static Target FromName(string name) => LLVM.GetTargetFromName(name).Wrap();
        public static Target FromTriple(string triple) => LLVM.GetTargetFromTriple(triple, out LLVMTargetRef tRef, out IntPtr errorMessage) ? tRef.Wrap() : throw new Exception(errorMessage.MessageToString());

        private readonly LLVMTargetRef _instance;

        internal Target(LLVMTargetRef instance)
        {
            this._instance = instance;
        }
        
        public string Name => LLVM.GetTargetName(this.Unwrap());

        public string Description => LLVM.GetTargetDescription(this.Unwrap());

        public bool HasJIT => LLVM.TargetHasJIT(this.Unwrap());
        public bool HasTargetMachine => LLVM.TargetHasTargetMachine(this.Unwrap());
        public bool HasAsmBackend => LLVM.TargetHasAsmBackend(this.Unwrap());

        public TargetMachine CreateTargetMachine(string triple, string cpu, string features, LLVMCodeGenOptLevel level, LLVMRelocMode reloc, LLVMCodeModel codeModel) => LLVM.CreateTargetMachine(this.Unwrap(), triple, cpu, features, level, reloc, codeModel).Wrap();

        public override string ToString() => this.Name;
    }
}
