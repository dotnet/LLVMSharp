namespace LLVMSharp
{
    using System.Collections.Generic;

    public sealed class BasicBlock : Value
    {
        public BasicBlock(Type type, string name, Function parent)
            : base(LLVM.BasicBlockAsValue(LLVM.AppendBasicBlock(parent.ToValueRef(), name)))
        {
            this.Type = type;
            this.Name = name;
            this.Parent = parent;
        }

        internal BasicBlock(LLVMBasicBlockRef blockRef)
            : base(LLVM.BasicBlockAsValue(blockRef))
        {
            this.Parent = new Function(LLVM.GetBasicBlockParent(blockRef));
        }

        internal BasicBlock(LLVMValueRef value)
            : this(LLVM.ValueAsBasicBlock(value))
        {
        }

        public LinkedList<Instruction> Instructions { get; private set; }

        public Function Parent { get; private set; }

        public Value BasicBlockTerminator
        {
            get { return LLVM.GetBasicBlockTerminator(this.ToBasicBlockRef()).ToValue(); }
        }

        public BasicBlock GetNextBasicBlock()
        {
            return LLVM.GetNextBasicBlock(this.ToBasicBlockRef()).ToBasicBlock();
        }

        public BasicBlock GetPreviousBasicBlock()
        {
            return LLVM.GetPreviousBasicBlock(this.ToBasicBlockRef()).ToBasicBlock();
        }

        public BasicBlock InsertBasicBlock(string name)
        {
            return LLVM.InsertBasicBlock(this.ToBasicBlockRef(), name).ToBasicBlock();
        }

        public void DeleteBasicBlock()
        {
            LLVM.DeleteBasicBlock(this.ToBasicBlockRef());
        }

        public void RemoveBasicBlockFromParent()
        {
            LLVM.RemoveBasicBlockFromParent(this.ToBasicBlockRef());
        }

        public void MoveBasicBlockBefore(BasicBlock movePos)
        {
            LLVM.MoveBasicBlockBefore(this.ToBasicBlockRef(), movePos.ToBasicBlockRef());
        }

        public void MoveBasicBlockAfter(BasicBlock movePos)
        {
            LLVM.MoveBasicBlockAfter(this.ToBasicBlockRef(), movePos.ToBasicBlockRef());
        }

        public Value GetFirstInstruction()
        {
            return LLVM.GetFirstInstruction(this.ToBasicBlockRef()).ToValue();
        }

        public Value GetLastInstruction()
        {
            return LLVM.GetLastInstruction(this.ToBasicBlockRef()).ToValue();
        }
        
        public Module Module
        {
            get { return this.Parent.Parent; }
        }
        
        public static BasicBlock Create(LLVMContext context, string name, Function parent, BasicBlock insertBefore = null)
        {
            var bb = new BasicBlock(Type.LabelType(context), name, parent);

            if (parent != null)
            {
                if (insertBefore != null)
                {
                    LinkedListNode<BasicBlock> insertBeforeNode = parent.BasicBlocks.Find(insertBefore);
                    if (insertBeforeNode != null)
                    {
                        parent.BasicBlocks.AddBefore(insertBeforeNode, bb);
                    }
                }
                else
                {
                    parent.BasicBlocks.AddLast(bb);
                }
            }

            return bb;
        }
    }
}