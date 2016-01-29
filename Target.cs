namespace LLVMSharp
{
    using System;

    public sealed class Target : IWrapper<LLVMTargetRef>
    {
        public static Target First
        {
            get { return LLVM.GetFirstTarget().Wrap(); }
        }

        public static Target FromName(string name)
        {
            return LLVM.GetTargetFromName(name).Wrap();
        }

        public static bool FromTriple(string triple, out Target t, out IntPtr errorMessage)
        {
            LLVMTargetRef tRef;
            var r = LLVM.GetTargetFromTriple(triple, out tRef, out errorMessage);
            t = tRef.Wrap();
            return r;
        }

        LLVMTargetRef IWrapper<LLVMTargetRef>.ToHandleType()
        {
            return this._instance;
        }

        private readonly LLVMTargetRef _instance;

        internal Target(LLVMTargetRef instance)
        {
            this._instance = instance;
        }

        public Target Next
        {
            get { return LLVM.GetNextTarget(this.Unwrap()).Wrap(); }
        }

        public string Name
        {
            get { return LLVM.GetTargetName(this.Unwrap()); }
        }

        public string Description
        {
            get { return LLVM.GetTargetDescription(this.Unwrap()); }
        }

        public bool HasJIT
        {
            get { return LLVM.TargetHasJIT(this.Unwrap()); }
        }

        public bool HasTargetMachine
        {
            get { return LLVM.TargetHasTargetMachine(this.Unwrap()); }
        }

        public bool HasAsmBackend
        {
            get { return LLVM.TargetHasAsmBackend(this.Unwrap()); }
        }

        public TargetMachine CreateTargetMachine(string triple, string cpu, string features, LLVMCodeGenOptLevel level,
                                                 LLVMRelocMode reloc, LLVMCodeModel codeModel)
        {
            return LLVM.CreateTargetMachine(this.Unwrap(), triple, cpu, features, level, reloc, codeModel).Wrap();
        }
    }
}
