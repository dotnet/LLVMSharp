namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public abstract class Value : IEquatable<Value>
    {
        internal static Value[] FromArray(LLVMValueRef[] source)
        {
            var length = source.Length;
            var target = new Value[length];
            for (var i = 0; i < length; ++i)
                target[i] = source[i];
            return target;
        }

        protected readonly LLVMValueRef value;

        private string name;

        private Type type;

        protected Value(LLVMValueRef value)
        {
            this.value = value;
        }

        public LLVMValueRef InnerValue
        {
            get { return this.value; }
        }

        public Type Type
        {
            get { return this.type ?? (this.type = new Type(LLVM.TypeOf(this.value))); }
            set { this.type = value; }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                LLVM.SetValueName(this.value, this.name);
            }
        }

        public LLVMContextRef Context
        {
            get { return this.Type.Context; }
        }

        public void Dump()
        {
            LLVM.DumpValue(this.value);
        }

        public override string ToString()
        {
            IntPtr ptr = LLVM.PrintValueToString(this.value);
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
                return this.value == other.value;
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
            return this.value.GetHashCode();
        }

    }
}