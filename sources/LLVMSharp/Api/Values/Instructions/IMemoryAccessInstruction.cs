namespace LLVMSharp.API.Values.Instructions
{
    public interface IMemoryAccessInstruction
    {
        bool IsVolatile { get; set; }
    }
}
