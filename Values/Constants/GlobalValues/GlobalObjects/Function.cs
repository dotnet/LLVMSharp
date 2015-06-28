namespace LLVMSharp
{
    using System.Collections.Generic;

    public sealed class Function : GlobalObject
    {
        internal Function(LLVMValueRef value)
            : base(value)
        {
        }

        public static Function Create(FunctionType type, LLVMLinkage linkage, string name, Module m)
        {
            var value = LLVM.AddFunction(m.instance, name, type.TypeRef);
            var f = new Function(value);
            LLVM.SetLinkage(value, linkage);
            return f;
        }

        public Module Parent { get; private set; }

        /// <summary>
        /// getReturnType
        /// </summary>
        public Type ReturnType
        {
            get
            {
                return new FunctionType(LLVM.GetReturnType(this.Type.TypeRef));
            }
        }

        public LinkedList<BasicBlock> BasicBlocks { get; private set; }

        /// <summary>
        /// getFunctionType
        /// </summary>
        public Type FunctionType { get; private set; }

        /// <summary>
        /// getContext
        /// </summary>
        public LLVMContext Context { get; private set; }

        /// <summary>
        /// isVarArg
        /// </summary>
        public bool IsVarArg { get; private set; }

        /// <summary>
        /// isIntrinsic
        /// </summary>
        public bool IsIntrinsic { get; private set; }

        /// <summary>
        /// getCallingConv
        /// setCallingConv
        /// </summary>
        public LLVMCallConv CallingConvention { get; set; }

        /// <summary>
        /// hasGC
        /// </summary>
        public bool HasGC { get; private set; }

        /// <summary>
        /// getGC
        /// setGC
        /// </summary>
        public string GC
        {
            get { return LLVM.GetGC(this.InnerValue); }
            set { LLVM.SetGC(this.InnerValue, value); }
        }

        /// <summary>
        /// clearGC
        /// </summary>
        public void ClearGC()
        {
            LLVM.SetGC(this.InnerValue, string.Empty);
        }

        public Value GetParameter(int index)
        {
            return LLVM.GetParam(this.ToValueRef(), (uint) index).ToValue();
        }
    }
}