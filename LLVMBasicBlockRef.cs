namespace LLVMSharp
{
    using System;

    partial struct LLVMBasicBlockRef : IEquatable<LLVMBasicBlockRef>, 
        IHandle<BasicBlock>
    {
        BasicBlock IHandle<BasicBlock>.ToWrapperType()
        {
            return (BasicBlock) Value.Create(new LLVMValueRef {Pointer = this.Pointer});
        }
    
        public LLVMValueRef BasicBlockAsValue()
        {
            return LLVM.BasicBlockAsValue(this);
        }

        public LLVMValueRef GetBasicBlockParent()
        {
            return LLVM.GetBasicBlockParent(this);
        }

        public LLVMValueRef GetBasicBlockTerminator()
        {
            return LLVM.GetBasicBlockTerminator(this);
        }

        public LLVMBasicBlockRef GetNextBasicBlock()
        {
            return LLVM.GetNextBasicBlock(this);
        }

        public LLVMBasicBlockRef GetPreviousBasicBlock()
        {
            return LLVM.GetPreviousBasicBlock(this);
        }

        public LLVMBasicBlockRef InsertBasicBlock(string name)
        {
            return LLVM.InsertBasicBlock(this, name);
        }

        public void DeleteBasicBlock()
        {
            LLVM.DeleteBasicBlock(this);
        }

        public void RemoveBasicBlockFromParent()
        {
            LLVM.RemoveBasicBlockFromParent(this);
        }

        public void MoveBasicBlockBefore(LLVMBasicBlockRef movePos)
        {
            LLVM.MoveBasicBlockBefore(this, movePos);
        }

        public void MoveBasicBlockAfter(LLVMBasicBlockRef movePos)
        {
            LLVM.MoveBasicBlockAfter(this, movePos);
        }

        public LLVMValueRef GetFirstInstruction()
        {
            return LLVM.GetFirstInstruction(this);
        }

        public LLVMValueRef GetLastInstruction()
        {
            return LLVM.GetLastInstruction(this);
        }

        public bool Equals(LLVMBasicBlockRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMBasicBlockRef)
            {
                return this.Equals((LLVMBasicBlockRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMBasicBlockRef op1, LLVMBasicBlockRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMBasicBlockRef op1, LLVMBasicBlockRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}