namespace LLVMSharp.API
{
    using LLVMSharp;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Utilities;
    using Values;
    using Values.Constants.GlobalValues.GlobalObjects;
    using Values.Instructions;

    public abstract class Value : IEquatable<Value>, IWrapper<LLVMValueRef>
    {
        LLVMValueRef IWrapper<LLVMValueRef>.ToHandleType => this._instance;

        internal static Value Create(LLVMValueRef v)
        {
            if (v.Pointer == IntPtr.Zero)
            {
                return null;
            }
            
            if (LLVM.ValueIsBasicBlock(v))
            {
                return new BasicBlock(LLVM.ValueAsBasicBlock(v));
            }

            if (LLVM.IsAFunction(v).ToBool())
            {
                return new Function(v);
            }

            if (LLVM.IsABinaryOperator(v).ToBool())
            {
                return BinaryOperator.Create(v);
            }

            if (LLVM.IsAInstruction(v).ToBool())
            {
                return Instruction.Create(v);
            }

            if (LLVM.IsConstant(v))
            {
                return Constant.Create(v);
            }

            if (LLVM.IsAArgument(v).ToBool())
            {
                return new Argument(v);
            }

            if (LLVM.IsAMDString(v).ToBool())
            {
                return new MDStringAsValue(v);
            }

            throw new NotImplementedException();
        }
        
        private readonly LLVMValueRef _instance;

        internal Value(LLVMValueRef instance)
        {
            this._instance = instance;
            this.Operands = new OperandList(this);
        }

        public Type Type => LLVM.TypeOf(this.Unwrap()).Wrap();

        public string Name
        {
            get => Marshal.PtrToStringAnsi(LLVM.GetValueNameAsPtr(this.Unwrap()));
            set => LLVM.SetValueName(this.Unwrap(), value);
        }

        public Context Context => this.Type.Context;
                
        public void Dump() => LLVM.DumpValue(this.Unwrap());
        
        public IReadOnlyList<Use> Uses
        {
            get
            {
                var list = new List<Use>();
                var use = LLVM.GetFirstUse(this.Unwrap()).Wrap();
                while(use != null)
                {
                    list.Add(use);
                    use = use.Next;
                }
                return list;
            }
        }
        public void ReplaceAllUsesWith(Value v) => LLVM.ReplaceAllUsesWith(this.Unwrap(), v.Unwrap());

        public Use GetOperandUse(uint index) => LLVM.GetOperandUse(this.Unwrap(), index).Wrap();

        public OperandList Operands { get; } 

        public override string ToString() => this.Unwrap().ValueRefToString();

        public override int GetHashCode() => this._instance.GetHashCode();
        public override bool Equals(object obj) => this.Equals(obj as Value);
        public bool Equals(Value other) => ReferenceEquals(other, null) ? false : this._instance == other._instance;
        public static bool operator ==(Value op1, Value op2) => ReferenceEquals(op1, null) ? ReferenceEquals(op2, null) : op1.Equals(op2);
        public static bool operator !=(Value op1, Value op2) => !(op1 == op2);
    }
}