namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public abstract class Value : IEquatable<Value>
    {
        internal readonly LLVMValueRef _value;
        private string _name;
        private Type _type;

        protected Value(LLVMValueRef value)
        {
            this._value = value;
        }

        public LLVMValueRef InnerValue
        {
            get { return this._value; }
        }

        public Type Type
        {
            get { return this._type ?? (this._type = new Type(LLVM.TypeOf(this._value))); }
            set { this._type = value; }
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                this._name = value;
                LLVM.SetValueName(this._value, this._name);
            }
        }

        public LLVMContextRef ContextRef
        {
            get { return this.Type.Context; }
        }

        public BasicBlock AppendBasicBlock(string name)
        {
            return LLVM.AppendBasicBlock(this.ToValueRef(), name).ToBasicBlock();
        }

        public bool HasMetadata()
        {
            return LLVM.HasMetadata(this.ToValueRef()) != 0;
        }

        public Value GetMetadata(uint kindID)
        {
            return LLVM.GetMetadata(this.ToValueRef(), kindID).ToValue();
        }

        public void SetMetadata(uint kindID, Value node)
        {
            LLVM.SetMetadata(this.ToValueRef(), kindID, node.ToValueRef());
        }

        public BasicBlock GetInstructionParent()
        {
            return LLVM.GetInstructionParent(this.ToValueRef()).ToBasicBlock();
        }

        public Value GetNextInstruction()
        {
            return LLVM.GetNextInstruction(this.ToValueRef()).ToValue();
        }

        public Value GetPreviousInstruction()
        {
            return LLVM.GetPreviousInstruction(this.ToValueRef()).ToValue();
        }

        public void InstructionEraseFromParent()
        {
            LLVM.InstructionEraseFromParent(this.ToValueRef());
        }

        public LLVMOpcode GetInstructionOpcode()
        {
            return LLVM.GetInstructionOpcode(this.ToValueRef());
        }

        public LLVMIntPredicate GetICmpPredicate()
        {
            return LLVM.GetICmpPredicate(this.ToValueRef());
        }

        public LLVMRealPredicate GetFCmpPredicate()
        {
            return LLVM.GetFCmpPredicate(this.ToValueRef());
        }

        public Value InstructionClone()
        {
            return LLVM.InstructionClone(this.ToValueRef()).ToValue();
        }

        public uint InstructionCallConv
        {
            get { return LLVM.GetInstructionCallConv(this.ToValueRef()); }
            set { LLVM.SetInstructionCallConv(this.ToValueRef(), value); }
        }

        public void AddInstrAttribute(uint index, LLVMAttribute param2)
        {
            LLVM.AddInstrAttribute(this.ToValueRef(), index, param2);
        }

        public void RemoveInstrAttribute(uint index, LLVMAttribute param2)
        {
            LLVM.RemoveInstrAttribute(this.ToValueRef(), index, param2);
        }

        public void SetInstrParamAlignment(uint index, uint align)
        {
            LLVM.SetInstrParamAlignment(this.ToValueRef(), index, align);
        }

        public bool TailCall
        {
            set { LLVM.SetTailCall(this.ToValueRef(), new LLVMBool(value)); }
            get { return LLVM.IsTailCall(this.ToValueRef()); }
        }

        public uint GetNumSuccessors()
        {
            return LLVM.GetNumSuccessors(this.ToValueRef());
        }
        
        public Value Condition
        {
            get { return LLVM.GetCondition(this.ToValueRef()).ToValue(); }
            set { LLVM.SetCondition(this.ToValueRef(), value.ToValueRef()); }
        }

        public BasicBlock GetSwitchDefaultDest(Value switchInstr)
        {
            return LLVM.GetSwitchDefaultDest(this.ToValueRef()).ToBasicBlock();
        }

        public void AddIncoming(Value[] incomingValues, BasicBlock[] incomingBlocks)
        {
            LLVM.AddIncoming(this.ToValueRef(), incomingValues.ToValueRefs(), incomingBlocks.ToBasicBlockRefs());
        }

        public uint CountIncoming()
        {
            return LLVM.CountIncoming(this.ToValueRef());
        }

        public Value GetIncomingValue(uint index)
        {
            return LLVM.GetIncomingValue(this.ToValueRef(), index).ToValue();
        }

        public BasicBlock GetIncomingBlock(uint index)
        {
            return LLVM.GetIncomingBlock(this.ToValueRef(), index).ToBasicBlock();
        }

        public void Dump()
        {
            LLVM.DumpValue(this.ToValueRef());
        }

        public string GetMDString(out uint len)
        {
            return LLVM.GetMDString(this.ToValueRef(), out len);
        }

        public uint GetMDNodeNumOperands()
        {
            return LLVM.GetMDNodeNumOperands(this.ToValueRef());
        }

        public void GetMDNodeOperands(out Value dest)
        {
            LLVMValueRef destValueRef;
            LLVM.GetMDNodeOperands(this.ToValueRef(), out destValueRef);
            dest = destValueRef.ToValue();
        }

        public uint CountBasicBlocks()
        {
            return LLVM.CountBasicBlocks(this.ToValueRef());
        }

        public BasicBlock[] GetBasicBlocks()
        {
            return LLVM.GetBasicBlocks(this.ToValueRef()).ToBasicBlocks();
        }

        public BasicBlock GetFirstBasicBlock()
        {
            return LLVM.GetFirstBasicBlock(this.ToValueRef()).ToBasicBlock();
        }

        public BasicBlock GetLastBasicBlock()
        {
            return LLVM.GetLastBasicBlock(this.ToValueRef()).ToBasicBlock();
        }

        public BasicBlock GetEntryBasicBlock()
        {
            return LLVM.GetEntryBasicBlock(this.ToValueRef()).ToBasicBlock();
        }

        public bool Volatile
        {
            get { return LLVM.GetVolatile(this.ToValueRef()); }
            set { LLVM.SetVolatile(this.ToValueRef(), value); }
        }

        public override string ToString()
        {
            IntPtr ptr = LLVM.PrintValueToString(this.ToValueRef());
            string retVal = Marshal.PtrToStringAnsi(ptr);
            LLVM.DisposeMessage(ptr);
            return retVal ?? string.Empty;
        }
        
        public bool Equals(Value other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            else
            {
                return this._value == other._value;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Value);
        }

        public static bool operator ==(Value op1, Value op2)
        {
            if (ReferenceEquals(op1, null))
            {
                return ReferenceEquals(op2, null);
            }
            else
            {
                return op1.Equals(op2);
            }
        }

        public static bool operator !=(Value op1, Value op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }
    }
}