namespace LLVMSharp.Api
{
    public static class Interpreter
    {
        public static void LinkInInterpreter()
        {
            LLVM.LinkInInterpreter();
        }
    }
}
