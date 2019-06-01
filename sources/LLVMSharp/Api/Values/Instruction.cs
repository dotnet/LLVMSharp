namespace LLVMSharp.API.Values
{
    using Instructions;
    using Instructions.Cmp;
    using Instructions.Terminator;
    using Instructions.Unary;
    using Instructions.Unary.Casts;
    using global::System;
    using global::System.Collections.Generic;

    public class Instruction : Value
    {
        internal static Dictionary<Opcode, Func<LLVMValueRef, Instruction>> Map = new Dictionary<Opcode, Func<LLVMValueRef, Instruction>>
            {
                { Opcode.Ret, u => new ReturnInst(u) },
                { Opcode.Br, u => new BranchInst(u) },
                { Opcode.Switch, u => new SwitchInst(u) },
                { Opcode.IndirectBr, u => new IndirectBrInst(u) },
                { Opcode.Invoke, u => new InvokeInst(u) },
                { Opcode.Unreachable, u => new UnreachableInst(u) },
                { Opcode.Alloca, u => new AllocaInst(u) },
                { Opcode.Load, u => new LoadInst(u) },
                { Opcode.Store, u => new StoreInst(u) },
                { Opcode.GetElementPtr, u => new GetElementPtrInst(u) },
                { Opcode.Trunc, u => new TruncInst(u) },
                { Opcode.ZExt, u => new ZExtInst(u) },
                { Opcode.SExt, u => new SExtInst(u) },
                { Opcode.FPToUI, u => new FPToUIInst(u) },
                { Opcode.FPToSI, u => new FPToSIInst(u) },
                { Opcode.UIToFP, u => new UIToFPInst(u) },
                { Opcode.SIToFP, u => new SIToFPInst(u) },
                { Opcode.FPTrunc, u => new FPTruncInst(u) },
                { Opcode.FPExt, u => new FPExtInst(u) },
                { Opcode.PtrToInt, u => new PtrToIntInst(u) },
                { Opcode.IntToPtr, u => new IntToPtrInst(u) },
                { Opcode.BitCast, u => new BitCastInst(u) },
                { Opcode.AddrSpaceCast, u => new AddrSpaceCastInst(u) },
                { Opcode.ICmp, u => new ICmpInst(u) },
                { Opcode.FCmp, u => new FCmpInst(u) },
                { Opcode.PHI, u => new PHINode(u) },
                { Opcode.Call, u => new CallInst(u) },
                { Opcode.Select, u => new SelectInst(u) },
                { Opcode.UserOp1, u => throw new NotSupportedException() },
                { Opcode.UserOp2, u => throw new NotSupportedException() },
                { Opcode.VAArg, u => new VAArgInst(u) },
                { Opcode.ExtractElement, u => new ExtractElementInst(u) },
                { Opcode.InsertElement, u => new InsertElementInst(u) },
                { Opcode.ShuffleVector, u => new ShuffleVectorInst(u) },
                { Opcode.ExtractValue, u => new ExtractValueInst(u) },
                { Opcode.InsertValue, u => new InsertValueInst(u) },
                { Opcode.Fence, u => new FenceInst(u) },
                { Opcode.AtomicCmpXchg, u => new AtomicCmpXchgInst(u) },
                { Opcode.AtomicRMW, u => new AtomicRMWInst(u) },
                { Opcode.Resume, u => new ResumeInst(u) },
                { Opcode.LandingPad, u => new LandingPadInst(u) },
            };

        internal new static Instruction Create(LLVMValueRef v)
        {
            if (v.Pointer == IntPtr.Zero)
            {
                return null;
            }

            var opcode = LLVM.GetInstructionOpcode(v).Wrap();
            if (Map.ContainsKey(opcode))
            {
                return Map[opcode](v);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        internal Instruction(LLVMValueRef instance)
            : base(instance)
        {
        }

        public bool HasMetadata => LLVM.HasMetadata(this.Unwrap()) != 0;
        public Value GetMetadata(uint kindID) => LLVM.GetMetadata(this.Unwrap(), kindID).Wrap();
        public void SetMetadata(uint kindID, Value node) => LLVM.SetMetadata(this.Unwrap(), kindID, node.Unwrap());

        public BasicBlock Parent => LLVM.GetInstructionParent(this.Unwrap()).Wrap();

        public Instruction PreviousInstruction => LLVM.GetPreviousInstruction(this.Unwrap()).WrapAs<Instruction>();
        public Instruction NextInstruction => LLVM.GetNextInstruction(this.Unwrap()).WrapAs<Instruction>();

        public void EraseFromParent() => LLVM.InstructionEraseFromParent(this.Unwrap());

        public Instruction Clone() => LLVM.InstructionClone(this.Unwrap()).WrapAs<Instruction>();

        public void SetParameterAlignment(uint index, uint align) => LLVM.SetInstrParamAlignment(this.Unwrap(), index, align);

        public Opcode Opcode => LLVM.GetInstructionOpcode(this.Unwrap()).Wrap();
    }
}