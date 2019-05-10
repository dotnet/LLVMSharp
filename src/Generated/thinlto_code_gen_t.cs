using System;

namespace LLVMSharp
{
    public partial struct thinlto_code_gen_t
    {
        public thinlto_code_gen_t(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;
    }
}
