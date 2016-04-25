namespace LLVMSharp.Api
{
    using System;
    using Utilities;

    public sealed class PassManager : IDisposable, IEquatable<PassManager>, IDisposableWrapper<LLVMPassManagerRef>
    {
        public static PassManager Create()
        {
            return LLVM.CreatePassManager().Wrap().MakeHandleOwner<PassManager, LLVMPassManagerRef>();
        }

        public static PassManager Create(Module module)
        {
            return
                LLVM.CreateFunctionPassManagerForModule(module.Unwrap())
                    .Wrap()
                    .MakeHandleOwner<PassManager, LLVMPassManagerRef>();
        }

        public static PassManager Create(ModuleProvider provider)
        {
            return
                LLVM.CreateFunctionPassManager(provider.Unwrap())
                    .Wrap()
                    .MakeHandleOwner<PassManager, LLVMPassManagerRef>();
        }

        LLVMPassManagerRef IWrapper<LLVMPassManagerRef>.ToHandleType()
        {
            return this._instance;
        }

        void IDisposableWrapper<LLVMPassManagerRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

        private readonly LLVMPassManagerRef _instance;
        private bool _disposed;
        private bool _owner;

        internal PassManager(LLVMPassManagerRef passManagerRef)
        {
            this._instance = passManagerRef;
        }

        ~PassManager()
        {
            this.Dispose(false);
        }

        public bool RunPassManager(Module m)
        {
            return LLVM.RunPassManager(this.Unwrap(), m.Unwrap());
        }

        public bool InitializeFunctionPassManager()
        {
            return LLVM.InitializeFunctionPassManager(this.Unwrap());
        }

        public bool RunFunctionPassManager(Value f)
        {
            return LLVM.RunFunctionPassManager(this.Unwrap(), f.Unwrap());
        }

        public bool FinalizeFunctionPassManager()
        {
            return LLVM.FinalizeFunctionPassManager(this.Unwrap());
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (this._owner)
            {
                LLVM.DisposePassManager(this.Unwrap());
            }

            this._disposed = true;
        }

        public void AddArgumentPromotionPass()
        {
            LLVM.AddArgumentPromotionPass(this.Unwrap());
        }

        public void AddConstantMergePass()
        {
            LLVM.AddConstantMergePass(this.Unwrap());
        }

        public void AddDeadArgEliminationPass()
        {
            LLVM.AddDeadArgEliminationPass(this.Unwrap());
        }

        public void AddFunctionAttrsPass()
        {
            LLVM.AddFunctionAttrsPass(this.Unwrap());
        }

        public void AddFunctionInliningPass()
        {
            LLVM.AddFunctionInliningPass(this.Unwrap());
        }

        public void AddAlwaysInlinerPass()
        {
            LLVM.AddAlwaysInlinerPass(this.Unwrap());
        }

        public void AddGlobalDCEPass()
        {
            LLVM.AddGlobalDCEPass(this.Unwrap());
        }

        public void AddGlobalOptimizerPass()
        {
            LLVM.AddGlobalOptimizerPass(this.Unwrap());
        }

        public void AddIPConstantPropagationPass()
        {
            LLVM.AddIPConstantPropagationPass(this.Unwrap());
        }

        public void AddPruneEHPass()
        {
            LLVM.AddPruneEHPass(this.Unwrap());
        }

        public void AddIPSCCPPass()
        {
            LLVM.AddIPSCCPPass(this.Unwrap());
        }

        public void AddInternalizePass(uint allButMain)
        {
            LLVM.AddInternalizePass(this.Unwrap(), allButMain);
        }

        public void AddStripDeadPrototypesPass()
        {
            LLVM.AddStripDeadPrototypesPass(this.Unwrap());
        }

        public void AddStripSymbolsPass()
        {
            LLVM.AddStripSymbolsPass(this.Unwrap());
        }

        public void AddAggressiveDCEPass()
        {
            LLVM.AddAggressiveDCEPass(this.Unwrap());
        }

        public void AddAlignmentFromAssumptionsPass()
        {
            LLVM.AddAlignmentFromAssumptionsPass(this.Unwrap());
        }

        public void AddCFGSimplificationPass()
        {
            LLVM.AddCFGSimplificationPass(this.Unwrap());
        }

        public void AddDeadStoreEliminationPass()
        {
            LLVM.AddDeadStoreEliminationPass(this.Unwrap());
        }

        public void AddScalarizerPass()
        {
            LLVM.AddScalarizerPass(this.Unwrap());
        }

        public void AddMergedLoadStoreMotionPass()
        {
            LLVM.AddMergedLoadStoreMotionPass(this.Unwrap());
        }

        public void AddGVNPass()
        {
            LLVM.AddGVNPass(this.Unwrap());
        }

        public void AddIndVarSimplifyPass()
        {
            LLVM.AddIndVarSimplifyPass(this.Unwrap());
        }

        public void AddInstructionCombiningPass()
        {
            LLVM.AddInstructionCombiningPass(this.Unwrap());
        }

        public void AddJumpThreadingPass()
        {
            LLVM.AddJumpThreadingPass(this.Unwrap());
        }

        public void AddLICMPass()
        {
            LLVM.AddLICMPass(this.Unwrap());
        }

        public void AddLoopDeletionPass()
        {
            LLVM.AddLoopDeletionPass(this.Unwrap());
        }

        public void AddLoopIdiomPass()
        {
            LLVM.AddLoopIdiomPass(this.Unwrap());
        }

        public void AddLoopRotatePass()
        {
            LLVM.AddLoopRotatePass(this.Unwrap());
        }

        public void AddLoopRerollPass()
        {
            LLVM.AddLoopRerollPass(this.Unwrap());
        }

        public void AddLoopUnrollPass()
        {
            LLVM.AddLoopUnrollPass(this.Unwrap());
        }

        public void AddLoopUnswitchPass()
        {
            LLVM.AddLoopUnswitchPass(this.Unwrap());
        }

        public void AddMemCpyOptPass()
        {
            LLVM.AddMemCpyOptPass(this.Unwrap());
        }

        public void AddPartiallyInlineLibCallsPass()
        {
            LLVM.AddPartiallyInlineLibCallsPass(this.Unwrap());
        }

        public void AddLowerSwitchPass()
        {
            LLVM.AddLowerSwitchPass(this.Unwrap());
        }

        public void AddPromoteMemoryToRegisterPass()
        {
            LLVM.AddPromoteMemoryToRegisterPass(this.Unwrap());
        }

        public void AddReassociatePass()
        {
            LLVM.AddReassociatePass(this.Unwrap());
        }

        public void AddSCCPPass()
        {
            LLVM.AddSCCPPass(this.Unwrap());
        }

        public void AddScalarReplAggregatesPass()
        {
            LLVM.AddScalarReplAggregatesPass(this.Unwrap());
        }

        public void AddScalarReplAggregatesPassSSA()
        {
            LLVM.AddScalarReplAggregatesPassSSA(this.Unwrap());
        }

        public void AddScalarReplAggregatesPassWithThreshold(int threshold)
        {
            LLVM.AddScalarReplAggregatesPassWithThreshold(this.Unwrap(), threshold);
        }

        public void AddSimplifyLibCallsPass()
        {
            LLVM.AddSimplifyLibCallsPass(this.Unwrap());
        }

        public void AddTailCallEliminationPass()
        {
            LLVM.AddTailCallEliminationPass(this.Unwrap());
        }

        public void AddConstantPropagationPass()
        {
            LLVM.AddConstantPropagationPass(this.Unwrap());
        }

        public void AddDemoteMemoryToRegisterPass()
        {
            LLVM.AddDemoteMemoryToRegisterPass(this.Unwrap());
        }

        public void AddVerifierPass()
        {
            LLVM.AddVerifierPass(this.Unwrap());
        }

        public void AddCorrelatedValuePropagationPass()
        {
            LLVM.AddCorrelatedValuePropagationPass(this.Unwrap());
        }

        public void AddEarlyCSEPass()
        {
            LLVM.AddEarlyCSEPass(this.Unwrap());
        }

        public void AddLowerExpectIntrinsicPass()
        {
            LLVM.AddLowerExpectIntrinsicPass(this.Unwrap());
        }

        public void AddTypeBasedAliasAnalysisPass()
        {
            LLVM.AddTypeBasedAliasAnalysisPass(this.Unwrap());
        }

        public void AddScopedNoAliasAAPass()
        {
            LLVM.AddScopedNoAliasAAPass(this.Unwrap());
        }

        public void AddBasicAliasAnalysisPass()
        {
            LLVM.AddBasicAliasAnalysisPass(this.Unwrap());
        }

        public void AddBBVectorizePass()
        {
            LLVM.AddBBVectorizePass(this.Unwrap());
        }

        public void AddLoopVectorizePass()
        {
            LLVM.AddLoopVectorizePass(this.Unwrap());
        }

        public void AddSLPVectorizePass()
        {
            LLVM.AddSLPVectorizePass(this.Unwrap());
        }

        public bool Equals(PassManager other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return this.Unwrap() == other.Unwrap();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as PassManager);
        }

        public static bool operator ==(PassManager op1, PassManager op2)
        {
            if (ReferenceEquals(op1, null))
            {
                return ReferenceEquals(op2, null);
            }
            return op1.Equals(op2);
        }

        public static bool operator !=(PassManager op1, PassManager op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Unwrap().GetHashCode();
        }

    }
}