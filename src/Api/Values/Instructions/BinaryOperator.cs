namespace LLVMSharp.API.Values.Instructions
{
    using Binary;

    public class BinaryOperator : Instruction
    {
        internal new static BinaryOperator Create(LLVMValueRef v)
        {
            var opcode = LLVM.GetInstructionOpcode(v);
            switch (opcode)
            {
                case LLVMOpcode.LLVMAdd:
                    return new Add(v);
                case LLVMOpcode.LLVMFAdd:
                    return new FAdd(v);
                case LLVMOpcode.LLVMSub:
                    return new Sub(v);
                case LLVMOpcode.LLVMFSub:
                    return new FSub(v);
                case LLVMOpcode.LLVMMul:
                    return new Mul(v);
                case LLVMOpcode.LLVMFMul:
                    return new FMul(v);
                case LLVMOpcode.LLVMUDiv:
                    return new UDiv(v);
                case LLVMOpcode.LLVMSDiv:
                    return new SDiv(v);
                case LLVMOpcode.LLVMFDiv:
                    return new FDiv(v);
                case LLVMOpcode.LLVMURem:
                    return new URem(v);
                case LLVMOpcode.LLVMSRem:
                    return new SRem(v);
                case LLVMOpcode.LLVMFRem:
                    return new FRem(v);
                case LLVMOpcode.LLVMShl:
                    return new Shl(v);
                case LLVMOpcode.LLVMLShr:
                    return new LShr(v);
                case LLVMOpcode.LLVMAShr:
                    return new AShr(v);
                case LLVMOpcode.LLVMAnd:
                    return new And(v);
                case LLVMOpcode.LLVMOr:
                    return new Or(v);
                case LLVMOpcode.LLVMXor:
                    return new Xor(v);
                default:
                    return new BinaryOperator(v);
            }
        }

        internal BinaryOperator(LLVMValueRef instance)
            : base(instance)
        {
        }
    }
}