namespace LLVMSharp.Utilities
{
    using System;

    internal interface IHandle<out TWrapper>
        where TWrapper : class
    {
        IntPtr GetInternalPointer();
        TWrapper ToWrapperType();
    }
}
