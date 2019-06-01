namespace LLVMSharp.API
{
    using System;

    public sealed class Message : IDisposable
    {
        public static Message Create(string message) => new Message(LLVM.CreateMessage(message));

        private readonly IntPtr _ptr;

        internal Message(IntPtr ptr)
        {
            this._ptr = ptr;
        }

        public void Dispose() => LLVM.DisposeMessage(this._ptr);
    }
}
