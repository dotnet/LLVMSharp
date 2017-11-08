namespace LLVMSharp
{
    using System;
    using Api;
    using Utilities;

    public partial struct LLVMExecutionEngineRef : IEquatable<LLVMExecutionEngineRef>, IHandle<ExecutionEngine>
    {
        IntPtr IHandle<ExecutionEngine>.GetInternalPointer() => this.Pointer;
        ExecutionEngine IHandle<ExecutionEngine>.ToWrapperType() => new ExecutionEngine(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMExecutionEngineRef t && this.Equals(t);
        public bool Equals(LLVMExecutionEngineRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMExecutionEngineRef op1, LLVMExecutionEngineRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMExecutionEngineRef op1, LLVMExecutionEngineRef op2) => !(op1 == op2);
    }
}
