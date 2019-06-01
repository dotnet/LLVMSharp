namespace LLVMSharp.API.Types
{
    internal interface IAggregateType
    {
        Type this[uint index] { get; }
        uint Length { get; }
    }
}
