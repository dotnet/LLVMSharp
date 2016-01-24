namespace LLVMSharp
{
    internal interface IHandle<out TWrapper>
        where TWrapper : class
    {
        TWrapper ToWrapperType();
    }
}
