namespace LLVMSharp
{
    partial struct LLVMBool
    {
        private static readonly LLVMBool False = new LLVMBool(0);
        private static readonly LLVMBool True = new LLVMBool(1);

        public LLVMBool(bool value)
        {
            this.Value = value ? 1 : 0;
        }

        public static implicit operator bool(LLVMBool b)
        {
            return b.Value != 0;
        }

        public static implicit operator LLVMBool(bool b)
        {
            return b ? True : False;
        }
    }
}