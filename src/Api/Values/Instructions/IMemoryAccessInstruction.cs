namespace LLVMSharp.Api.Values.Instructions
{
    public interface IMemoryAccessInstruction
    {
        bool IsVolatile { get; set; }
    }
}
