namespace LLVMSharp.API
{
    public static class Core
    {
        public static void Shutdown() => LLVM.Shutdown();
    }
}
