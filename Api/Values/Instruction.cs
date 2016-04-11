namespace LLVMSharp.Api.Values
{
    using Instructions;
    using Instructions.Cmp;
    using Instructions.Terminator;
    using Instructions.Unary;
    using Instructions.Unary.Casts;
    using Utilities;

    public class Instruction : Value
    {
        internal new static Instruction Create(LLVMValueRef v)
        {
            var opcode = LLVM.GetInstructionOpcode(v);
            switch (opcode)
            {
                case LLVMOpcode.LLVMRet:
                    return new ReturnInst(v);
                case LLVMOpcode.LLVMBr:
                    return new BranchInst(v);
                case LLVMOpcode.LLVMSwitch:
                    return new SwitchInst(v);
                case LLVMOpcode.LLVMIndirectBr:
                    return new IndirectBrInst(v);
                case LLVMOpcode.LLVMInvoke:
                    return new InvokeInst(v);
                case LLVMOpcode.LLVMUnreachable:
                    return new UnreachableInst(v);
                case LLVMOpcode.LLVMAlloca:
                    return new AllocaInst(v);
                case LLVMOpcode.LLVMLoad:
                    return new LoadInst(v);
                case LLVMOpcode.LLVMStore:
                    return new StoreInst(v);
                case LLVMOpcode.LLVMGetElementPtr:
                    return new GetElementPtrInst(v);
                case LLVMOpcode.LLVMTrunc:
                    return new TruncInst(v);
                case LLVMOpcode.LLVMZExt:
                    return new ZExtInst(v);
                case LLVMOpcode.LLVMSExt:
                    return new SExtInst(v);
                case LLVMOpcode.LLVMFPToUI:
                    return new FPToUIInst(v);
                case LLVMOpcode.LLVMFPToSI:
                    return new FPToSIInst(v);
                case LLVMOpcode.LLVMUIToFP:
                    return new UIToFPInst(v);
                case LLVMOpcode.LLVMSIToFP:
                    return new SIToFPInst(v);
                case LLVMOpcode.LLVMFPTrunc:
                    return new FPTruncInst(v);
                case LLVMOpcode.LLVMFPExt:
                    return new FPExtInst(v);
                case LLVMOpcode.LLVMPtrToInt:
                    return new PtrToIntInst(v);
                case LLVMOpcode.LLVMIntToPtr:
                    return new IntToPtrInst(v);
                case LLVMOpcode.LLVMBitCast:
                    return new BitCastInst(v);
                case LLVMOpcode.LLVMAddrSpaceCast:
                    return new AddrSpaceCastInst(v);
                case LLVMOpcode.LLVMICmp:
                    return new ICmpInst(v);
                case LLVMOpcode.LLVMFCmp:
                    return new FCmpInst(v);
                case LLVMOpcode.LLVMPHI:
                    return new PHINode(v);
                case LLVMOpcode.LLVMCall:
                    return new CallInst(v);
                case LLVMOpcode.LLVMSelect:
                    return new SelectInst(v);
                /*
                case LLVMOpcode.LLVMUserOp1:
                    goto default;
                case LLVMOpcode.LLVMUserOp2:
                    goto default;
                 */
                case LLVMOpcode.LLVMVAArg:
                    return new VAArgInst(v);
                case LLVMOpcode.LLVMExtractElement:
                    return new ExtractElementInst(v);
                case LLVMOpcode.LLVMInsertElement:
                    return new InsertElementInst(v);
                case LLVMOpcode.LLVMShuffleVector:
                    return new ShuffleVectorInst(v);
                case LLVMOpcode.LLVMExtractValue:
                    return new ExtractValueInst(v);
                case LLVMOpcode.LLVMInsertValue:
                    return new InsertValueInst(v);
                case LLVMOpcode.LLVMFence:
                    return new FenceInst(v);
                case LLVMOpcode.LLVMAtomicCmpXchg:
                    return new AtomicCmpXchgInst(v);
                case LLVMOpcode.LLVMAtomicRMW:
                    return new AtomicRMWInst(v);
                case LLVMOpcode.LLVMResume:
                    return new ResumeInst(v);
                case LLVMOpcode.LLVMLandingPad:
                    return new LandingPadInst(v);
                default:
                    return new Instruction(v);
            }
        }

        internal Instruction(LLVMValueRef instance)
            : base(instance)
        {
        }

        public uint InstructionCallConv
        {
            get { return LLVM.GetInstructionCallConv(this.Unwrap()); }
            set { LLVM.SetInstructionCallConv(this.Unwrap(), value); }
        }
        
        public void AddInstrAttribute(uint index, LLVMAttribute param2)
        {
            LLVM.AddInstrAttribute(this.Unwrap(), index, param2);
        }

        public void RemoveInstrAttribute(uint index, LLVMAttribute param2)
        {
            LLVM.RemoveInstrAttribute(this.Unwrap(), index, param2);
        }

        public Value GetMetadata(uint kindID)
        {
            return LLVM.GetMetadata(this.Unwrap(), kindID).Wrap();
        }

        public bool HasMetadata()
        {
            return LLVM.HasMetadata(this.Unwrap()) != 0;
        }

        public void SetMetadata(uint kindID, Value node)
        {
            LLVM.SetMetadata(this.Unwrap(), kindID, node.Unwrap());
        }

        public BasicBlock GetInstructionParent()
        {
            return LLVM.GetInstructionParent(this.Unwrap()).Wrap();
        }

        public Value GetNextInstruction()
        {
            return LLVM.GetNextInstruction(this.Unwrap()).Wrap();
        }

        public Value GetPreviousInstruction()
        {
            return LLVM.GetPreviousInstruction(this.Unwrap()).Wrap();
        }

        public void InstructionEraseFromParent()
        {
            LLVM.InstructionEraseFromParent(this.Unwrap());
        }

        public Value InstructionClone()
        {
            return LLVM.InstructionClone(this.Unwrap()).Wrap();
        }

        public void SetInstrParamAlignment(uint index, uint align)
        {
            LLVM.SetInstrParamAlignment(this.Unwrap(), index, align);
        }
    }
}