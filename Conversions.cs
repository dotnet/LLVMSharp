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

    partial struct LLVMValueRef
    {
        public static implicit operator Value(LLVMValueRef v)
        {
            if (LLVM.ValueIsBasicBlock(v))
            {
                return new BasicBlock(v);
            }

            if (LLVM.IsConstant(v))
            {
                return new ConstantFP(v);
            }

            LLVMOpcode opcode = LLVM.GetInstructionOpcode(v);

            return null;
        }

        public static implicit operator LLVMValueRef(Value v)
        {
            return v.InnerValue;
        }
    }
}