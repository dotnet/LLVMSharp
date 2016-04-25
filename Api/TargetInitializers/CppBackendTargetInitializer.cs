namespace LLVMSharp.Api.TargetInitializers
{
    public sealed class CppBackendTargetInitializer : 
        ITarget, ITargetInfo, ITargetMC
    {
        internal CppBackendTargetInitializer()
        {            
        }

        public void Target()
        {
            LLVM.InitializeCppBackendTarget();
        }

        public void TargetInfo()
        {
            LLVM.InitializeCppBackendTargetInfo();
        }

        public void TargetMC()
        {
            LLVM.InitializeCppBackendTargetMC();
        }
    }
}
