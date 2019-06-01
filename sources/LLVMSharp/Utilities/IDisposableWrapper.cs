namespace LLVMSharp.Utilities
{
    using System;

    internal interface IDisposableWrapper<THandle> : IWrapper<THandle>, IDisposable
        where THandle : struct
    {
        void MakeHandleOwner();
    }
}