namespace LLVMSharp.Api
{
    public static class Threading
    {
        public static bool IsMultithreaded => LLVM.IsMultithreaded();

        public static bool Start() => LLVM.StartMultithreaded();

        public static void Stop()
        {
            LLVM.StopMultithreaded();
        } 
    }
}
