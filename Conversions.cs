namespace LLVMSharp
{
    using System;

    partial struct LLVMBool
    {
        private static readonly LLVMBool False = new LLVMBool(0);

        private static readonly LLVMBool True = new LLVMBool(0);

        public static implicit operator bool(LLVMBool b)
        {
            return b.Value != 0;
        }

        public static implicit operator LLVMBool(bool b)
        {
            return b ? True : False;
        }
    }

    partial struct LLVMValueRef
    {
        public static implicit operator bool(LLVMValueRef v)
        {
            return v.Pointer == IntPtr.Zero;
        }

        public static implicit operator Value(LLVMValueRef v)
        {
            if (LLVM.ValueIsBasicBlock(v))
            {
                return new BasicBlock(v);
            }

            if (LLVM.IsABinaryOperator(v))
            {
                return BinaryOperator(v);
            }

            if (LLVM.IsAInstruction(v))
            {
                return Instruction(v);
            }

            if (LLVM.IsConstant(v))
            {
                return Constant(v);
            }

            return null;
        }

        public static implicit operator LLVMValueRef(Value v)
        {
            return v.InnerValue;
        }

        private static Value BinaryOperator(LLVMValueRef v)
        {
            LLVMOpcode opcode = LLVM.GetInstructionOpcode(v);
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

        private static Value Instruction(LLVMValueRef v)
        {
            LLVMOpcode opcode = LLVM.GetInstructionOpcode(v);
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

        private static Value Constant(LLVMValueRef v)
        {
            if (LLVM.IsABlockAddress(v))
            {
                return new BlockAddress(v);
            }

            if (LLVM.IsAConstantAggregateZero(v))
            {
                return new ConstantAggregateZero(v);
            }

            if (LLVM.IsAConstantArray(v))
            {
                return new ConstantArray(v);
            }

            if (LLVM.IsAConstantDataSequential(v))
            {
                if (LLVM.IsAConstantDataArray(v))
                {
                    return new ConstantDataArray(v);
                }

                if (LLVM.IsAConstantDataVector(v))
                {
                    return new ConstantDataVector(v);
                }

                return new ConstantDataSequential(v);
            }

            if (LLVM.IsAConstantExpr(v))
            {
                return new ConstantExpr(v);
            }

            if (LLVM.IsAConstantFP(v))
            {
                return new ConstantFP(v);
            }

            if (LLVM.IsAConstantInt(v))
            {
                return new ConstantInt(v);
            }

            if (LLVM.IsAConstantPointerNull(v))
            {
                return new ConstantPointerNull(v);
            }

            if (LLVM.IsAConstantStruct(v))
            {
                return new ConstantStruct(v);
            }

            if (LLVM.IsAConstantVector(v))
            {
                return new ConstantVector(v);
            }

            if (LLVM.IsAGlobalValue(v))
            {
                if (LLVM.IsAGlobalAlias(v))
                {
                    return new GlobalAlias(v);
                }

                if (LLVM.IsAGlobalObject(v))
                {
                    if (LLVM.IsAFunction(v))
                    {
                        return new Function(v);
                    }

                    if (LLVM.IsAGlobalVariable(v))
                    {
                        return new GlobalVariable(v);
                    }

                    return new GlobalObject(v);
                }

                return new GlobalValue(v);
            }

            if (LLVM.IsAUndefValue(v))
            {
                return new UndefValue(v);
            }

            return new Constant(v);
        }
    }
}