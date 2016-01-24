namespace LLVMSharp
{
    using System;

    public partial struct LLVMExecutionEngineRef : IEquatable<LLVMExecutionEngineRef>, IHandle<ExecutionEngine>
    {
        ExecutionEngine IHandle<ExecutionEngine>.ToWrapperType()
        {
            return new ExecutionEngine(this);
        }
        
        public bool Equals(LLVMExecutionEngineRef other)
        {
            return this.Pointer == other.Pointer;
        }

        public override bool Equals(object obj)
        {
            if (obj is LLVMExecutionEngineRef)
            {
                return this.Equals((LLVMExecutionEngineRef)obj);
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(LLVMExecutionEngineRef op1, LLVMExecutionEngineRef op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(LLVMExecutionEngineRef op1, LLVMExecutionEngineRef op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Pointer.GetHashCode();
        }
    }
}
