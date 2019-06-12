using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMOptRemarkParserRef
    {
        public LLVMOptRemarkParserRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMOptRemarkParserRef(LLVMOptRemarkOpaqueParser* value)
        {
            return new LLVMOptRemarkParserRef((IntPtr)value);
        }

        public static implicit operator LLVMOptRemarkOpaqueParser*(LLVMOptRemarkParserRef value)
        {
            return (LLVMOptRemarkOpaqueParser*)value.Pointer;
        }
    }
}
