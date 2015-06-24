namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public abstract class Value : IEquatable<Value>
    {
        private readonly LLVMValueRef _value;
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

        public void Dump()
        {
            LLVM.DumpValue(this._value);
        }

        public override string ToString()
        {
            IntPtr ptr = LLVM.PrintValueToString(this._value);
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