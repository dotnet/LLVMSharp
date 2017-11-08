namespace LLVMSharp.Api
{
    public static class Threading
    {
        public static bool IsMultithreaded => LLVM.IsMultithreaded();
    }
}
