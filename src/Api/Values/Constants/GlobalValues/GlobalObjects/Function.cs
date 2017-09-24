namespace LLVMSharp.Api.Values.Constants.GlobalValues.GlobalObjects
{
    using Types;
    using Utilities;

    public sealed class Function : GlobalObject
    {
        internal Function(LLVMValueRef instance)
            : base(instance)
        {
        }

        public static Function Create(FunctionType type, LLVMLinkage linkage, string name, Module m)
        {
            var value = LLVM.AddFunction(m.Unwrap(), name, type.Unwrap());
            var f = new Function(value);
            LLVM.SetLinkage(value, linkage);
            return f;
        }

        public Type ReturnType
        {
            get { return LLVM.GetReturnType(this.Type.Unwrap()).Wrap(); }
        }

        public BasicBlock[] BasicBlocks
        {
            get
            {
                var e = new LLVMBasicBlockRef[LLVM.CountBasicBlocks(this.Unwrap())];
                LLVM.GetBasicBlocks(this.Unwrap(), out e[0]);
                return e.Wrap<LLVMBasicBlockRef, BasicBlock>();
            }
        }

        public Type FunctionType
        {
            get { return LLVM.TypeOf(this.Unwrap()).Wrap(); }
        }

        public bool IsVarArg
        {
            get { return LLVM.IsFunctionVarArg(this.FunctionType.Unwrap()); }
        }

        public Value GetParameter(int index)
        {
            return LLVM.GetParam(this.Unwrap(), (uint) index).Wrap();
        }

        public BasicBlock AppendBasicBlock(string name)
        {
            return LLVM.AppendBasicBlock(this.Unwrap(), name).Wrap();
        }

        public uint CountBasicBlocks()
        {
            return LLVM.CountBasicBlocks(this.Unwrap());
        }
        
        public BasicBlock GetFirstBasicBlock()
        {
            return LLVM.GetFirstBasicBlock(this.Unwrap()).Wrap();
        }

        public BasicBlock GetLastBasicBlock()
        {
            return LLVM.GetLastBasicBlock(this.Unwrap()).Wrap();
        }

        public BasicBlock GetEntryBasicBlock()
        {
            return LLVM.GetEntryBasicBlock(this.Unwrap()).Wrap();
        }

        public Function NextFunction
        {
            get { return LLVM.GetNextFunction(this.Unwrap()).WrapAs<Function>(); }
        }

        public Function PreviousFunction
        {
            get { return LLVM.GetPreviousFunction(this.Unwrap()).WrapAs<Function>(); }
        }

        public void ViewFunctionCFG()
        {
            LLVM.ViewFunctionCFG(this.Unwrap());
        }

        public void ViewFunctionCFGOnly()
        {
            LLVM.ViewFunctionCFGOnly(this.Unwrap());
        }
    }
}