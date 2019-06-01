namespace LLVMSharp.API
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("Count = {Count}")]
    public sealed class OperandList : IEnumerable<Value>
    {
        internal Value Value { get; }

        internal OperandList(Value value)
        {
            this.Value = value;
        }

        public int Count => LLVM.GetNumOperands(this.Value.Unwrap());

        public Value this[uint index]
        {
            get => LLVM.GetOperand(this.Value.Unwrap(), index).Wrap();
            set => LLVM.SetOperand(this.Value.Unwrap(), index, value.Unwrap());
        }

        public IEnumerator<Value> GetEnumerator()
        {
            for(var i = 0u; i < this.Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
