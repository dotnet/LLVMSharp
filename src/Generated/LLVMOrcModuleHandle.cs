namespace LLVMSharp
{
    public partial struct LLVMOrcModuleHandle
    {
        public LLVMOrcModuleHandle(ulong value)
        {
            Value = value;
        }

        public ulong Value;
    }
}
