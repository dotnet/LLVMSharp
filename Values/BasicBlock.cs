namespace LLVMSharp
{
    using System.Collections.Generic;

    public sealed class BasicBlock : Value
    {
        internal BasicBlock(Type type, string name, Function parent)
            : base(LLVM.BasicBlockAsValue(LLVM.AppendBasicBlock(parent.InnerValue, name)))
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

        public Module Module
        {
            get { return this.Parent.Parent; }
        }

        public static BasicBlock Create(LLVMContext context, string name, Function parent, BasicBlock insertBefore = null)
        {
            var bb = new BasicBlock(Type.GetLabelType(context), name, parent);

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

        public static implicit operator LLVMBasicBlockRef(BasicBlock basicBlock)
        {
            return LLVM.ValueAsBasicBlock(basicBlock.value);
        }
    }
}