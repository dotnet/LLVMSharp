namespace LLVMSharp.API
{
    using Utilities;

    public sealed class TargetLibraryInfo : IWrapper<LLVMTargetLibraryInfoRef>
    {
        LLVMTargetLibraryInfoRef IWrapper<LLVMTargetLibraryInfoRef>.ToHandleType => this._instance;

        private readonly LLVMTargetLibraryInfoRef _instance;

        internal TargetLibraryInfo(LLVMTargetLibraryInfoRef instance)
        {
            this._instance = instance;
        }

        public void AddTargetLibraryInfo(PassManager pm) => LLVM.AddTargetLibraryInfo(this.Unwrap(), pm.Unwrap());
    }
}
