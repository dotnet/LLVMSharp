namespace LLVMSharp
{
    using System;
    using Utilities;

    partial struct LLVMExecutionEngineRef : IEquatable<LLVMExecutionEngineRef>, IHandle<API.ExecutionEngine>
    {
        IntPtr IHandle<API.ExecutionEngine>.GetInternalPointer() => this.Pointer;
        API.ExecutionEngine IHandle<API.ExecutionEngine>.ToWrapperType() => new API.ExecutionEngine(this);

        public override int GetHashCode() => this.Pointer.GetHashCode();
        public override bool Equals(object obj) => obj is LLVMExecutionEngineRef t && this.Equals(t);
        public bool Equals(LLVMExecutionEngineRef other) => this.Pointer == other.Pointer;
        public static bool operator ==(LLVMExecutionEngineRef op1, LLVMExecutionEngineRef op2) => op1.Pointer == op2.Pointer;
        public static bool operator !=(LLVMExecutionEngineRef op1, LLVMExecutionEngineRef op2) => !(op1 == op2);
    }
}
