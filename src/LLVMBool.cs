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
    }
}