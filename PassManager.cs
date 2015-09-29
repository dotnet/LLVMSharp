namespace LLVMSharp
{
    using System;

    public sealed class PassManager : IDisposable, IEquatable<PassManager>
    {
        internal readonly LLVMPassManagerRef Instance;

        private bool disposed;

        public PassManager()
        {
            this.Instance = LLVM.CreatePassManager();
        }

        public PassManager(LLVMModuleRef module)
        {
            this.Instance = LLVM.CreateFunctionPassManagerForModule(module);
        }

        public PassManager(LLVMModuleProviderRef moduleProvider)
        {
            this.Instance = LLVM.CreateFunctionPassManager(moduleProvider);
        }

        internal PassManager(LLVMPassManagerRef passManagerRef)
        {
            this.Instance = passManagerRef;
        }

        ~PassManager()
        {
            this.Dispose(false);
        }

        public bool RunPassManager(LLVMModuleRef m)
        {
            return LLVM.RunPassManager(this.Instance, m);
        }

        public bool InitializeFunctionPassManager()
        {
            return LLVM.InitializeFunctionPassManager(this.Instance);
        }

        public bool RunFunctionPassManager(LLVMValueRef f)
        {
            return LLVM.RunFunctionPassManager(this.Instance, f);
        }

        public bool FinalizeFunctionPassManager()
        {
            return LLVM.FinalizeFunctionPassManager(this.Instance);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            LLVM.DisposePassManager(this.Instance);
            this.disposed = true;
        }

        public void AddArgumentPromotionPass()
        {
            LLVM.AddArgumentPromotionPass(this.Instance);
        }

        public void AddConstantMergePass()
        {
            LLVM.AddConstantMergePass(this.Instance);
        }

        public void AddDeadArgEliminationPass()
        {
            LLVM.AddDeadArgEliminationPass(this.Instance);
        }

        public void AddFunctionAttrsPass()
        {
            LLVM.AddFunctionAttrsPass(this.Instance);
        }

        public void AddFunctionInliningPass()
        {
            LLVM.AddFunctionInliningPass(this.Instance);
        }

        public void AddAlwaysInlinerPass()
        {
            LLVM.AddAlwaysInlinerPass(this.Instance);
        }

        public void AddGlobalDCEPass()
        {
            LLVM.AddGlobalDCEPass(this.Instance);
        }

        public void AddGlobalOptimizerPass()
        {
            LLVM.AddGlobalOptimizerPass(this.Instance);
        }

        public void AddIPConstantPropagationPass()
        {
            LLVM.AddIPConstantPropagationPass(this.Instance);
        }

        public void AddPruneEHPass()
        {
            LLVM.AddPruneEHPass(this.Instance);
        }

        public void AddIPSCCPPass()
        {
            LLVM.AddIPSCCPPass(this.Instance);
        }

        public void AddInternalizePass(uint allButMain)
        {
            LLVM.AddInternalizePass(this.Instance, allButMain);
        }

        public void AddStripDeadPrototypesPass()
        {
            LLVM.AddStripDeadPrototypesPass(this.Instance);
        }

        public void AddStripSymbolsPass()
        {
            LLVM.AddStripSymbolsPass(this.Instance);
        }

        public void AddAggressiveDCEPass()
        {
            LLVM.AddAggressiveDCEPass(this.Instance);
        }

        public void AddAlignmentFromAssumptionsPass()
        {
            LLVM.AddAlignmentFromAssumptionsPass(this.Instance);
        }

        public void AddCFGSimplificationPass()
        {
            LLVM.AddCFGSimplificationPass(this.Instance);
        }

        public void AddDeadStoreEliminationPass()
        {
            LLVM.AddDeadStoreEliminationPass(this.Instance);
        }

        public void AddScalarizerPass()
        {
            LLVM.AddScalarizerPass(this.Instance);
        }

        public void AddMergedLoadStoreMotionPass()
        {
            LLVM.AddMergedLoadStoreMotionPass(this.Instance);
        }

        public void AddGVNPass()
        {
            LLVM.AddGVNPass(this.Instance);
        }

        public void AddIndVarSimplifyPass()
        {
            LLVM.AddIndVarSimplifyPass(this.Instance);
        }

        public void AddInstructionCombiningPass()
        {
            LLVM.AddInstructionCombiningPass(this.Instance);
        }

        public void AddJumpThreadingPass()
        {
            LLVM.AddJumpThreadingPass(this.Instance);
        }

        public void AddLICMPass()
        {
            LLVM.AddLICMPass(this.Instance);
        }

        public void AddLoopDeletionPass()
        {
            LLVM.AddLoopDeletionPass(this.Instance);
        }

        public void AddLoopIdiomPass()
        {
            LLVM.AddLoopIdiomPass(this.Instance);
        }

        public void AddLoopRotatePass()
        {
            LLVM.AddLoopRotatePass(this.Instance);
        }

        public void AddLoopRerollPass()
        {
            LLVM.AddLoopRerollPass(this.Instance);
        }

        public void AddLoopUnrollPass()
        {
            LLVM.AddLoopUnrollPass(this.Instance);
        }

        public void AddLoopUnswitchPass()
        {
            LLVM.AddLoopUnswitchPass(this.Instance);
        }

        public void AddMemCpyOptPass()
        {
            LLVM.AddMemCpyOptPass(this.Instance);
        }

        public void AddPartiallyInlineLibCallsPass()
        {
            LLVM.AddPartiallyInlineLibCallsPass(this.Instance);
        }

        public void AddLowerSwitchPass()
        {
            LLVM.AddLowerSwitchPass(this.Instance);
        }

        public void AddPromoteMemoryToRegisterPass()
        {
            LLVM.AddPromoteMemoryToRegisterPass(this.Instance);
        }

        public void AddReassociatePass()
        {
            LLVM.AddReassociatePass(this.Instance);
        }

        public void AddSCCPPass()
        {
            LLVM.AddSCCPPass(this.Instance);
        }

        public void AddScalarReplAggregatesPass()
        {
            LLVM.AddScalarReplAggregatesPass(this.Instance);
        }

        public void AddScalarReplAggregatesPassSSA()
        {
            LLVM.AddScalarReplAggregatesPassSSA(this.Instance);
        }

        public void AddScalarReplAggregatesPassWithThreshold(int threshold)
        {
            LLVM.AddScalarReplAggregatesPassWithThreshold(this.Instance, threshold);
        }

        public void AddSimplifyLibCallsPass()
        {
            LLVM.AddSimplifyLibCallsPass(this.Instance);
        }

        public void AddTailCallEliminationPass()
        {
            LLVM.AddTailCallEliminationPass(this.Instance);
        }

        public void AddConstantPropagationPass()
        {
            LLVM.AddConstantPropagationPass(this.Instance);
        }

        public void AddDemoteMemoryToRegisterPass()
        {
            LLVM.AddDemoteMemoryToRegisterPass(this.Instance);
        }

        public void AddVerifierPass()
        {
            LLVM.AddVerifierPass(this.Instance);
        }

        public void AddCorrelatedValuePropagationPass()
        {
            LLVM.AddCorrelatedValuePropagationPass(this.Instance);
        }

        public void AddEarlyCSEPass()
        {
            LLVM.AddEarlyCSEPass(this.Instance);
        }

        public void AddLowerExpectIntrinsicPass()
        {
            LLVM.AddLowerExpectIntrinsicPass(this.Instance);
        }

        public void AddTypeBasedAliasAnalysisPass()
        {
            LLVM.AddTypeBasedAliasAnalysisPass(this.Instance);
        }

        public void AddScopedNoAliasAAPass()
        {
            LLVM.AddScopedNoAliasAAPass(this.Instance);
        }

        public void AddBasicAliasAnalysisPass()
        {
            LLVM.AddBasicAliasAnalysisPass(this.Instance);
        }

        public void AddBBVectorizePass()
        {
            LLVM.AddBBVectorizePass(this.Instance);
        }

        public void AddLoopVectorizePass()
        {
            LLVM.AddLoopVectorizePass(this.Instance);
        }

        public void AddSLPVectorizePass()
        {
            LLVM.AddSLPVectorizePass(this.Instance);
        }

        public bool Equals(PassManager other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            else
            {
                return this.Instance == other.Instance;
            }
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
            else
            {
                return op1.Equals(op2);
            }
        }

        public static bool operator !=(PassManager op1, PassManager op2)
        {
            return !(op1 == op2);
        }

        public override int GetHashCode()
        {
            return this.Instance.GetHashCode();
        }
    }
}