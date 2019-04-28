namespace LLVMSharp
{
    using System;

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

    partial struct LLVMValueRef
    {
        public static implicit operator LLVMValueRef(LLVMBasicBlockRef b)
        {
            return LLVM.BasicBlockAsValue(b);
        }

        public static implicit operator LLVMBasicBlockRef(LLVMValueRef v)
        {
            return LLVM.ValueAsBasicBlock(v);
        }
    }
}