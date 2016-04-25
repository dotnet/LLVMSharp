namespace LLVMSharp.Api
{
    using System;

    public sealed class FatalErrorHandler : IDisposable
    {
        private readonly LLVMFatalErrorHandler _functionPtr;

        internal FatalErrorHandler(LLVMFatalErrorHandler functionPtr)
        {
            this._functionPtr = functionPtr;
            LLVM.InstallFatalErrorHandler(functionPtr);
        }

        public void Dispose()
        {
            LLVM.ResetFatalErrorHandler();
        }
    }
}
