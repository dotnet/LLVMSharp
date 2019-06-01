namespace LLVMSharp.API.Values.Constants.GlobalValues.GlobalObjects
{
    using LLVMSharp.API.Types.Composite.SequentialTypes;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Types;

    public sealed class Function : GlobalObject
    {
        public static Function Create(FunctionType type, Linkage linkage, string name, Module m)
        {
            var value = LLVM.AddFunction(m.Unwrap(), name, type.Unwrap());
            var f = new Function(value);
            LLVM.SetLinkage(value, linkage.Unwrap());
            return f;
        }

        internal Function(LLVMValueRef instance)
            : base(instance)
        {
        }
        
        public CallingConvention CallingConvention
        {
            get => (CallingConvention)LLVM.GetFunctionCallConv(this.Unwrap());
            set => LLVM.SetFunctionCallConv(this.Unwrap(), (uint)value);
        }

        public Value BlockAddress(BasicBlock bb) => LLVM.BlockAddress(this.Unwrap(), bb.Unwrap<LLVMBasicBlockRef>()).Wrap();

        public uint IntrinsicID => LLVM.GetIntrinsicID(this.Unwrap());

        public string GC
        {
            get => LLVM.GetGC(this.Unwrap());
            set => LLVM.SetGC(this.Unwrap(), value);
        }

        public void AddTargetDependentFunctionAttr(string a, string v) => LLVM.AddTargetDependentFunctionAttr(this.Unwrap(), a, v);

        public IReadOnlyList<Argument> Parameters => LLVM.GetParams(this.Unwrap()).WrapAs<Argument>();
        public IReadOnlyList<BasicBlock> BasicBlocks => LLVM.GetBasicBlocks(this.Unwrap()).Wrap<LLVMBasicBlockRef, BasicBlock>();

        public FunctionType FunctionType => LLVM.GetReturnType(this.Type.Unwrap()).WrapAs<FunctionType>();

        public bool IsVarArg => LLVM.IsFunctionVarArg(this.Type.Unwrap());

        public BasicBlock EntryBasicBlock => LLVM.GetEntryBasicBlock(this.Unwrap()).Wrap();
        public BasicBlock AppendBasicBlock(string name) => LLVM.AppendBasicBlock(this.Unwrap(), name).Wrap();
        public BasicBlock AppendBasicBlock(string name, Context context) => LLVM.AppendBasicBlockInContext(context.Unwrap(), this.Unwrap(), name).WrapAs<BasicBlock>();

        public Function NextFunction => LLVM.GetNextFunction(this.Unwrap()).WrapAs<Function>();
        public Function PreviousFunction => LLVM.GetPreviousFunction(this.Unwrap()).WrapAs<Function>();

        public void Verify()
        {
            if (!this.TryVerify())
            {
                throw new InvalidOperationException($"Function \"{this.Name}\" has errors. Verify the containing module for detailed information.");
            }
        }
        public bool TryVerify() => !LLVM.VerifyFunction(this.Unwrap(), LLVMVerifierFailureAction.LLVMReturnStatusAction);

        public void ViewFunctionCFG() => LLVM.ViewFunctionCFG(this.Unwrap());
        public void ViewFunctionCFGOnly() => LLVM.ViewFunctionCFGOnly(this.Unwrap());

        public void Delete() => LLVM.DeleteFunction(this.Unwrap());
    }
}