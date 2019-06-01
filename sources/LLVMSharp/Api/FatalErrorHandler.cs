namespace LLVMSharp.API
{
    using System;

    public sealed class FatalErrorHandler : IDisposable
    {
        public static FatalErrorHandler Install(Action<string> action) => new FatalErrorHandler(new LLVMFatalErrorHandler(action));
        public static void Reset() => LLVM.ResetFatalErrorHandler();
        public static void EnablePrettyStackTrace() => LLVM.EnablePrettyStackTrace();

        private readonly LLVMFatalErrorHandler _functionPtr;

        internal FatalErrorHandler(LLVMFatalErrorHandler functionPtr)
        {
            this._functionPtr = functionPtr;
            LLVM.InstallFatalErrorHandler(functionPtr);
        }

        public void Dispose() => LLVM.ResetFatalErrorHandler();
    }
}
