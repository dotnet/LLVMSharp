namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;
    using LLVMSharp.API.Values;
    using LLVMSharp.Utilities;

    partial struct LLVMBasicBlockRef : IHandle<BasicBlock>
    {
        IntPtr IHandle<BasicBlock>.GetInternalPointer() => this.Pointer;
        BasicBlock IHandle<BasicBlock>.ToWrapperType() => new BasicBlock(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMBasicBlockRef t && this.Equals(t);
        public bool Equals(LLVMBasicBlockRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMBasicBlockRef op1, LLVMBasicBlockRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMBasicBlockRef op1, LLVMBasicBlockRef op2) => !(op1 == op2);

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

        public LLVMBasicBlockRef InsertBasicBlock(string @Name)
        {
            return LLVM.InsertBasicBlock(this, @Name);
        }

        public void DeleteBasicBlock()
        {
            LLVM.DeleteBasicBlock(this);
        }

        public void RemoveBasicBlockFromParent()
        {
            LLVM.RemoveBasicBlockFromParent(this);
        }

        public void MoveBasicBlockBefore(LLVMBasicBlockRef @MovePos)
        {
            LLVM.MoveBasicBlockBefore(this, @MovePos);
        }

        public void MoveBasicBlockAfter(LLVMBasicBlockRef @MovePos)
        {
            LLVM.MoveBasicBlockAfter(this, @MovePos);
        }

        public LLVMValueRef GetFirstInstruction()
        {
            return LLVM.GetFirstInstruction(this);
        }

        public LLVMValueRef GetLastInstruction()
        {
            return LLVM.GetLastInstruction(this);
        }

        public void Dump()
        {
            LLVM.DumpValue(this);
        }

        public override string ToString()
        {
            IntPtr ptr = LLVM.PrintValueToString(this);
            string retval = Marshal.PtrToStringAnsi(ptr) ?? string.Empty;
            LLVM.DisposeMessage(ptr);
            return retval;
        }
    }
}