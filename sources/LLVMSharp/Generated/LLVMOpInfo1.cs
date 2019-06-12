namespace LLVMSharp
{
    public partial struct LLVMOpInfo1
    {
        [NativeTypeName("struct LLVMOpInfoSymbol1")]
        public LLVMOpInfoSymbol1 AddSymbol;

        [NativeTypeName("struct LLVMOpInfoSymbol1")]
        public LLVMOpInfoSymbol1 SubtractSymbol;

        [NativeTypeName("uint64_t")]
        public ulong Value;

        [NativeTypeName("uint64_t")]
        public ulong VariantKind;
    }
}
