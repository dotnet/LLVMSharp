namespace LLVMSharp.Api
{
    using Utilities;

    public static class Host
    {
        public static string GetDefaultTargetTriple() => LLVM.GetDefaultTargetTriple().IntPtrToString();
    }
}
