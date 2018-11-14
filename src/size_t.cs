namespace LLVMSharp
{
    using System;

    partial struct size_t
    {
        public size_t(int num)
        {
            this.Pointer = new IntPtr(num);
        }
    }
}
