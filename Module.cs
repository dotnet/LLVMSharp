namespace LLVMSharp
{
    public sealed class Module
    {
        private LLVMContext context;

        internal LLVMModuleRef module;

        public Module(string moduleId, LLVMContext c)
        {
            this.Name = moduleId;
            this.context = c;
        }

        public string Name { get; private set; }

        public void Dump()
        {
            LLVM.DumpModule(this.module);
        }
    }
}