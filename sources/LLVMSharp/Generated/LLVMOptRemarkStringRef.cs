namespace LLVMSharp
{
    public unsafe partial struct LLVMOptRemarkStringRef
    {
        [NativeTypeName("const char *")]
        public sbyte* Str;

        [NativeTypeName("uint32_t")]
        public uint Len;
    }
}
