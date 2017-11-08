namespace LLVMSharp.Api
{
    public static class Core
    {
        public static void Shutdown() => LLVM.Shutdown();
    }
}
