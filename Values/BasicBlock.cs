namespace LLVMSharp
{
    using System.Collections.Generic;

    public sealed class BasicBlock : Value, IWrapper<LLVMBasicBlockRef>
    {
        public static BasicBlock Create(Context context, Function parent, string name)
        {
            return LLVM.AppendBasicBlockInContext(context.Unwrap(), parent.Unwrap(), name).Wrap();
        }
        
        public static BasicBlock Create(Function parent, string name)
        {
            return LLVM.AppendBasicBlock(parent.Unwrap(), name).Wrap();
        }

        LLVMBasicBlockRef IWrapper<LLVMBasicBlockRef>.ToHandleType()
        {
            return LLVM.ValueAsBasicBlock(this.Unwrap<LLVMValueRef>());
        }

        internal BasicBlock(LLVMBasicBlockRef blockRef)
            : base(LLVM.BasicBlockAsValue(blockRef))
        {
        }

        public Value Parent
        {
            get { return LLVM.GetBasicBlockParent(this.Unwrap<LLVMBasicBlockRef>()).Wrap(); }
        }

        public Value BasicBlockTerminator
        {
            get { return LLVM.GetBasicBlockTerminator(this.Unwrap<LLVMBasicBlockRef>()).Wrap<Value>(); }
        }

        public BasicBlock NextBasicBlock
        {
            get { return LLVM.GetNextBasicBlock(this.Unwrap<LLVMBasicBlockRef>()).Wrap(); }
        }

        public BasicBlock PreviousBasicBlock
        {
            get { return LLVM.GetPreviousBasicBlock(this.Unwrap<LLVMBasicBlockRef>()).Wrap(); }
        }

        public void DeleteBasicBlock()
        {
            LLVM.DeleteBasicBlock(this.Unwrap<LLVMBasicBlockRef>());
        }

        public void RemoveBasicBlockFromParent()
        {
            LLVM.RemoveBasicBlockFromParent(this.Unwrap<LLVMBasicBlockRef>());
        }

        public void MoveBasicBlockBefore(BasicBlock movePos)
        {
            LLVM.MoveBasicBlockBefore(this.Unwrap<LLVMBasicBlockRef>(), movePos.Unwrap<LLVMBasicBlockRef>());
        }

        public void MoveBasicBlockAfter(BasicBlock movePos)
        {
            LLVM.MoveBasicBlockAfter(this.Unwrap<LLVMBasicBlockRef>(), movePos.Unwrap<LLVMBasicBlockRef>());
        }

        public Value FirstInstruction
        {
            get { return LLVM.GetFirstInstruction(this.Unwrap<LLVMBasicBlockRef>()).Wrap(); }
        }

        public Value LastInstruction
        {
            get { return LLVM.GetLastInstruction(this.Unwrap<LLVMBasicBlockRef>()).Wrap(); }
        }

        public Value BasicBlockParent
        {
            get { return LLVM.GetBasicBlockParent(this.Unwrap<LLVMBasicBlockRef>()).Wrap(); }
        }

        public BasicBlock InsertBasicBlock(string name)
        {
            return LLVM.InsertBasicBlock(this.Unwrap<LLVMBasicBlockRef>(), name).Wrap();
        }
    }
}