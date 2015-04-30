namespace LLVMSharp
{
    partial struct LLVMBool
    {
        public static implicit operator bool(LLVMBool b)
        {
            return b.Value != 0;
        }

        public static implicit operator LLVMBool(bool b)
        {
            return new LLVMBool(b ? 1 : 0);
        }
    }
}
