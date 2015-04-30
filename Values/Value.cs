namespace LLVMSharp
{
    using System;
    using System.Runtime.InteropServices;

    public abstract class Value
    {
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
            protected set { this.type = value; }
        }

        public string Name
        {
            get { return this.name ?? (this.name = LLVM.GetValueName(this.value)); }
            protected set { this.name = value; }
        }

        public LLVMContext Context
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

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Value other = obj as Value;
            if (other == null)
            {
                return false;
            }

            return other == this;
        }

        public static bool operator ==(Value l, Value r)
        {
            if (l == null || r == null)
            {
                return false;
            }

            return l.value.Pointer == r.value.Pointer;
        }

        public static bool operator !=(Value l, Value r)
        {
            if (l == null || r == null)
            {
                return false;
            }

            return l.value.Pointer != r.value.Pointer;
        }
    }
}