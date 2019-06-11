namespace LLVMSharp
{
    public unsafe partial struct LLVMOpInfoSymbol1
    {
        [NativeTypeName("uint64_t")]
        public ulong Present;

        [NativeTypeName("const char *")]
        public sbyte* Name;

        [NativeTypeName("uint64_t")]
        public ulong Value;
    }
}
