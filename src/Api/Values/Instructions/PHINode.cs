namespace LLVMSharp.API.Values.Instructions
{
    using System.Collections.Generic;

    public sealed class PHINode : Instruction
    {
        internal PHINode(LLVMValueRef instance)
            : base(instance)
        {
        }

        public BasicBlock[] IncomingBlocks
        {
            get
            {
                var blocks = new List<BasicBlock>();
                for(var i = 0u; i < CountIncoming; i++)
                {
                    blocks.Add(GetIncomingBlock(i));
                }
                return blocks.ToArray();
            }
        }

        public Value[] IncomingValues
        {
            get
            {
                var values = new List<Value>();
                for(var i = 0u; i < CountIncoming; i++)
                {
                    values.Add(GetIncomingValue(i));
                }
                return values.ToArray();
            }
        }

        public void AddIncoming(Value[] incomingValues, BasicBlock[] incomingBlocks)
        {
            LLVM.AddIncoming(this.Unwrap(), incomingValues.Unwrap(), incomingBlocks.Unwrap<LLVMBasicBlockRef>());
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