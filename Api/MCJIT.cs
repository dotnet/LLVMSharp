namespace LLVMSharp.Api
{
    public static class MCJIT
    {
        public static void LinkInMCJIT()
        {
            LLVM.LinkInInterpreter();
        }
    }
}
