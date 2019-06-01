namespace LLVMSharp.API
{
    public static class Threading
    {
        public static bool IsMultithreaded => LLVM.IsMultithreaded();
    }
}
