namespace LLVMSharp.API.Values
{
    using Constants.GlobalValues.GlobalObjects;
    using System.Collections.Generic;
    using Utilities;

    public sealed class BasicBlock : Value, IWrapper<LLVMBasicBlockRef>
    {
        public static BasicBlock Create(Function parent, string name) => LLVM.AppendBasicBlock(parent.Unwrap(), name).Wrap();
        public static BasicBlock Create(Function parent, string name, Context context) => LLVM.AppendBasicBlockInContext(context.Unwrap(), parent.Unwrap(), name).Wrap();

        LLVMBasicBlockRef IWrapper<LLVMBasicBlockRef>.ToHandleType => LLVM.ValueAsBasicBlock(this.Unwrap<LLVMValueRef>());

        internal BasicBlock(LLVMBasicBlockRef blockRef)
            : base(LLVM.BasicBlockAsValue(blockRef))
        {
        }

        public Instruction[] Instructions
        {
            get
            {
                var instructions = new List<Instruction>();
                var i = GetFirstInstruction();
                while(i != null)
                {
                    instructions.Add(i);
                    i = i.NextInstruction;
                }
                return instructions.ToArray();
            }
        }

        public Value Parent => LLVM.GetBasicBlockParent(this.Unwrap<LLVMBasicBlockRef>()).Wrap();
        public void RemoveFromParent() => LLVM.RemoveBasicBlockFromParent(this.Unwrap<LLVMBasicBlockRef>());
        public void Delete() => LLVM.DeleteBasicBlock(this.Unwrap<LLVMBasicBlockRef>());

        public Value Terminator => LLVM.GetBasicBlockTerminator(this.Unwrap<LLVMBasicBlockRef>()).Wrap();

        public BasicBlock PreviousBasicBlock => LLVM.GetPreviousBasicBlock(this.Unwrap<LLVMBasicBlockRef>()).Wrap();
        public BasicBlock NextBasicBlock => LLVM.GetNextBasicBlock(this.Unwrap<LLVMBasicBlockRef>()).Wrap();

        public void MoveBefore(BasicBlock movePos) => LLVM.MoveBasicBlockBefore(this.Unwrap<LLVMBasicBlockRef>(), movePos.Unwrap<LLVMBasicBlockRef>());
        public void MoveAfter(BasicBlock movePos) => LLVM.MoveBasicBlockAfter(this.Unwrap<LLVMBasicBlockRef>(), movePos.Unwrap<LLVMBasicBlockRef>());

        public Instruction GetFirstInstruction() => LLVM.GetFirstInstruction(this.Unwrap<LLVMBasicBlockRef>()).WrapAs<Instruction>();
        public Instruction GetLastInstruction() => LLVM.GetLastInstruction(this.Unwrap<LLVMBasicBlockRef>()).WrapAs<Instruction>();

        public BasicBlock InsertBefore(string name) => LLVM.InsertBasicBlock(this.Unwrap<LLVMBasicBlockRef>(), name).Wrap();
        public BasicBlock InsertBefore(string name, Context context) => LLVM.InsertBasicBlockInContext(context.Unwrap(), this.Unwrap<LLVMBasicBlockRef>(), name).Wrap();
    }
}