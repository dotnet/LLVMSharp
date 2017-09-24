namespace LLVMSharp.Api.Values.Instructions
{
    using Utilities;

    public sealed class PHINode : Instruction
    {
        internal PHINode(LLVMValueRef instance)
            : base(instance)
        {
        }

        public void AddIncoming(Value[] incomingValues, BasicBlock[] incomingBlocks)
        {
            LLVM.AddIncoming(this.Unwrap(), out incomingValues.Unwrap()[0], out incomingBlocks.Unwrap<LLVMBasicBlockRef>()[0], (uint)incomingValues.Length);
        }

        public uint CountIncoming
        {
            get { return LLVM.CountIncoming(this.Unwrap()); }
        }

        public BasicBlock GetIncomingBlock(uint index)
        {
            return LLVM.GetIncomingBlock(this.Unwrap(), index).Wrap();
        }

        public Value GetIncomingValue(uint index)
        {
            return LLVM.GetIncomingValue(this.Unwrap(), index).Wrap();
        }
    }
}