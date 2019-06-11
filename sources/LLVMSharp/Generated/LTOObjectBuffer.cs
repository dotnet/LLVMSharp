using System;

namespace LLVMSharp
{
    public unsafe partial struct LTOObjectBuffer
    {
        [NativeTypeName("const char *")]
        public sbyte* Buffer;

        [NativeTypeName("size_t")]
        public UIntPtr Size;
    }
}
