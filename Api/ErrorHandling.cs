namespace LLVMSharp.Api
{
    using System;

    public static class ErrorHandling
    {
        public static FatalErrorHandler InstallFatalErrorHandler(Action<string> action)
        {
            return new FatalErrorHandler(new LLVMFatalErrorHandler(action));
        }

        public static void ResetFatalErrorHandler()
        {
            LLVM.ResetFatalErrorHandler();
        }

        public static void EnablePrettyStackTrace()
        {
            LLVM.EnablePrettyStackTrace();
        }
    }
}
