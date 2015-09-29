namespace LLVMSharp
{
    using System;
    using Values;

    /// <summary>
    /// Helper class that handles the internal conversions between C API and C++ API types.
    /// </summary>
    internal static class Conversions
    {
        public static Type[] ToTypes(this LLVMTypeRef[] source)
        {
            var target = new Type[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i].ToType();
            }
            return target;
        }

        public static LLVMTypeRef[] ToTypeRefs(this Type[] source)
        {
            var target = new LLVMTypeRef[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i].ToTypeRef();
            }
            return target;
        }

        public static Value[] ToValues(this LLVMValueRef[] source)
        {
            var target = new Value[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i].ToValue();
            }
            return target;
        }

        public static LLVMValueRef[] ToValueRefs(this Value[] source)
        {
            var target = new LLVMValueRef[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i].ToValueRef();
            }
            return target;
        }

        public static BasicBlock[] ToBasicBlocks(this LLVMBasicBlockRef[] source)
        {
            var target = new BasicBlock[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i].ToBasicBlock();
            }
            return target;
        }

        public static LLVMBasicBlockRef[] ToBasicBlockRefs(this BasicBlock[] source)
        {
            var target = new LLVMBasicBlockRef[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i].ToBasicBlockRef();
            }
            return target;
        }

        public static LLVMPassManagerRef ToPassManagerRef(this PassManager p)
        {
            return p.Instance;
        }

        public static PassManager ToPassManager(this LLVMPassManagerRef p)
        {
            return new PassManager(p);
        }

        public static LLVMExecutionEngineRef ToExecutionEngineRef(this ExecutionEngine e)
        {
            return e.instance;
        }

        public static ExecutionEngine ToExecutionEngine(this LLVMExecutionEngineRef e)
        {
            return new ExecutionEngine(e);
        }

        public static Value ToValue(this LLVMValueRef v)
        {
            if (LLVM.ValueIsBasicBlock(v))
            {
                return new BasicBlock(v);
            }

            if (LLVM.IsAFunction(v).ToBool())
            {
                return new Function(v);
            }

            if (LLVM.IsABinaryOperator(v).ToBool())
            {
                return v.ToBinaryOperator();
            }

            if (LLVM.IsAInstruction(v).ToBool())
            {
                return v.ToInstruction();
            }

            if (LLVM.IsConstant(v))
            {
                return v.ToConstant();
            }

            if (LLVM.IsAArgument(v).ToBool())
            {
                return new Argument(v);
            }
            
            throw new NotImplementedException();
        }

        public static LLVMValueRef ToValueRef(this Value v)
        {
            return v.InnerValue;
        }

        public static Type ToType(this LLVMTypeRef t)
        {
            return new Type(t);
        }

        public static LLVMTypeRef ToTypeRef(this Type t)
        {
            return t.TypeRef;
        }

        public static Value ToBinaryOperator(this LLVMValueRef v)
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

        public static Value ToInstruction(this LLVMValueRef v)
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

        public static Value ToConstant(this LLVMValueRef v)
        {
            if (LLVM.IsABlockAddress(v).ToBool())
            {
                return new BlockAddress(v);
            }

            if (LLVM.IsAConstantAggregateZero(v).ToBool())
            {
                return new ConstantAggregateZero(v);
            }

            if (LLVM.IsAConstantArray(v).ToBool())
            {
                return new ConstantArray(v);
            }

            if (LLVM.IsAConstantDataSequential(v).ToBool())
            {
                if (LLVM.IsAConstantDataArray(v).ToBool())
                {
                    return new ConstantDataArray(v);
                }

                if (LLVM.IsAConstantDataVector(v).ToBool())
                {
                    return new ConstantDataVector(v);
                }

                return new ConstantDataSequential(v);
            }

            if (LLVM.IsAConstantExpr(v).ToBool())
            {
                return new ConstantExpr(v);
            }

            if (LLVM.IsAConstantFP(v).ToBool())
            {
                return new ConstantFP(v);
            }

            if (LLVM.IsAConstantInt(v).ToBool())
            {
                return new ConstantInt(v);
            }

            if (LLVM.IsAConstantPointerNull(v).ToBool())
            {
                return new ConstantPointerNull(v);
            }

            if (LLVM.IsAConstantStruct(v).ToBool())
            {
                return new ConstantStruct(v);
            }

            if (LLVM.IsAConstantVector(v).ToBool())
            {
                return new ConstantVector(v);
            }

            if (LLVM.IsAGlobalValue(v).ToBool())
            {
                if (LLVM.IsAGlobalAlias(v).ToBool())
                {
                    return new GlobalAlias(v);
                }

                if (LLVM.IsAGlobalObject(v).ToBool())
                {
                    if (LLVM.IsAFunction(v).ToBool())
                    {
                        return new Function(v);
                    }

                    if (LLVM.IsAGlobalVariable(v).ToBool())
                    {
                        return new GlobalVariable(v);
                    }

                    return new GlobalObject(v);
                }

                return new GlobalValue(v);
            }

            if (LLVM.IsAUndefValue(v).ToBool())
            {
                return new UndefValue(v);
            }

            return new Constant(v);
        }

        public static LLVMModuleRef ToModuleRef(this Module m)
        {
            return m.Instance;
        }

        public static Module ToModule(this LLVMModuleRef m)
        {
            return new Module(m);
        }

        public static LLVMBasicBlockRef ToBasicBlockRef(this LLVMValueRef v)
        {
            return LLVM.ValueAsBasicBlock(v);
        }

        public static LLVMBasicBlockRef ToBasicBlockRef(this BasicBlock b)
        {
            return b.ToValueRef().ToBasicBlockRef();
        }

        public static BasicBlock ToBasicBlock(this LLVMBasicBlockRef b)
        {
            return new BasicBlock(b);
        }

        public static LLVMBuilderRef ToBuilderRef(this IRBuilder b)
        {
            return b.instance;
        }

        public static IRBuilder ToIRBuilder(this LLVMBuilderRef b)
        {
            return new IRBuilder(b);
        }

        public static bool ToBool(this LLVMValueRef v)
        {
            return v.Pointer != IntPtr.Zero;
        }
    }
}