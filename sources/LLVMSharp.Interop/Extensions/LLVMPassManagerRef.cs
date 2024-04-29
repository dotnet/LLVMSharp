// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMPassManagerRef(IntPtr handle) : IDisposable, IEquatable<LLVMPassManagerRef>
{
    public IntPtr Handle = handle;

    public static implicit operator LLVMPassManagerRef(LLVMOpaquePassManager* value) => new LLVMPassManagerRef((IntPtr)value);

    public static implicit operator LLVMOpaquePassManager*(LLVMPassManagerRef value) => (LLVMOpaquePassManager*)value.Handle;

    public static bool operator ==(LLVMPassManagerRef left, LLVMPassManagerRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMPassManagerRef left, LLVMPassManagerRef right) => !(left == right);

    public static LLVMPassManagerRef Create() => LLVM.CreatePassManager();

    public readonly void AddAggressiveDCEPass() => LLVM.AddAggressiveDCEPass(this);

    public readonly void AddAlignmentFromAssumptionsPass() => LLVM.AddAlignmentFromAssumptionsPass(this);

    public readonly void AddAlwaysInlinerPass() => LLVM.AddAlwaysInlinerPass(this);

    public readonly void AddBasicAliasAnalysisPass() => LLVM.AddBasicAliasAnalysisPass(this);

    public readonly void AddBitTrackingDCEPass() => LLVM.AddBitTrackingDCEPass(this);

    public readonly void AddCalledValuePropagationPass() => LLVM.AddCalledValuePropagationPass(this);

    public readonly void AddCFGSimplificationPass() => LLVM.AddCFGSimplificationPass(this);

    public readonly void AddConstantMergePass() => LLVM.AddConstantMergePass(this);

    public readonly void AddCorrelatedValuePropagationPass() => LLVM.AddCorrelatedValuePropagationPass(this);

    public readonly void AddDCEPass() => LLVM.AddDCEPass(this);

    public readonly void AddDeadArgEliminationPass() => LLVM.AddDeadArgEliminationPass(this);

    public readonly void AddDeadStoreEliminationPass() => LLVM.AddDeadStoreEliminationPass(this);

    public readonly void AddDemoteMemoryToRegisterPass() => LLVM.AddDemoteMemoryToRegisterPass(this);

    public readonly void AddEarlyCSEMemSSAPass() => LLVM.AddEarlyCSEMemSSAPass(this);

    public readonly void AddEarlyCSEPass() => LLVM.AddEarlyCSEPass(this);

    public readonly void AddFunctionAttrsPass() => LLVM.AddFunctionAttrsPass(this);

    public readonly void AddFunctionInliningPass() => LLVM.AddFunctionInliningPass(this);

    public readonly void AddGlobalDCEPass() => LLVM.AddGlobalDCEPass(this);

    public readonly void AddGlobalOptimizerPass() => LLVM.AddGlobalOptimizerPass(this);

    public readonly void AddGVNPass() => LLVM.AddGVNPass(this);

    public readonly void AddIndVarSimplifyPass() => LLVM.AddIndVarSimplifyPass(this);

    public readonly void AddInstructionCombiningPass() => LLVM.AddInstructionCombiningPass(this);

    public readonly void AddInternalizePass(uint AllButMain) => LLVM.AddInternalizePass(this, AllButMain);

    public readonly void AddIPSCCPPass() => LLVM.AddIPSCCPPass(this);

    public readonly void AddJumpThreadingPass() => LLVM.AddJumpThreadingPass(this);

    public readonly void AddLICMPass() => LLVM.AddLICMPass(this);

    public readonly void AddLoopDeletionPass() => LLVM.AddLoopDeletionPass(this);

    public readonly void AddLoopIdiomPass() => LLVM.AddLoopIdiomPass(this);

    public readonly void AddLoopRerollPass() => LLVM.AddLoopRerollPass(this);

    public readonly void AddLoopRotatePass() => LLVM.AddLoopRotatePass(this);

    public readonly void AddLoopUnrollPass() => LLVM.AddLoopUnrollPass(this);

    public readonly void AddLoopVectorizePass() => LLVM.AddLoopVectorizePass(this);

    public readonly void AddLowerConstantIntrinsicsPass() => LLVM.AddLowerConstantIntrinsicsPass(this);

    public readonly void AddLowerExpectIntrinsicPass() => LLVM.AddLowerExpectIntrinsicPass(this);

    public readonly void AddLowerSwitchPass() => LLVM.AddLowerSwitchPass(this);

    public readonly void AddMemCpyOptPass() => LLVM.AddMemCpyOptPass(this);

    public readonly void AddMergedLoadStoreMotionPass() => LLVM.AddMergedLoadStoreMotionPass(this);

    public readonly void AddMergeFunctionsPass() => LLVM.AddMergeFunctionsPass(this);

    public readonly void AddNewGVNPass() => LLVM.AddNewGVNPass(this);

    public readonly void AddPartiallyInlineLibCallsPass() => LLVM.AddPartiallyInlineLibCallsPass(this);

    public readonly void AddPromoteMemoryToRegisterPass() => LLVM.AddPromoteMemoryToRegisterPass(this);

    public readonly void AddReassociatePass() => LLVM.AddReassociatePass(this);

    public readonly void AddScalarizerPass() => LLVM.AddScalarizerPass(this);

    public readonly void AddScalarReplAggregatesPass() => LLVM.AddScalarReplAggregatesPass(this);

    public readonly void AddScalarReplAggregatesPassSSA() => LLVM.AddScalarReplAggregatesPassSSA(this);

    public readonly void AddScalarReplAggregatesPassWithThreshold(int Threshold) => LLVM.AddScalarReplAggregatesPassWithThreshold(this, Threshold);

    public readonly void AddSCCPPass() => LLVM.AddSCCPPass(this);

    public readonly void AddScopedNoAliasAAPass() => LLVM.AddScopedNoAliasAAPass(this);

    public readonly void AddSimplifyLibCallsPass() => LLVM.AddSimplifyLibCallsPass(this);

    public readonly void AddSLPVectorizePass() => LLVM.AddSLPVectorizePass(this);

    public readonly void AddStripDeadPrototypesPass() => LLVM.AddStripDeadPrototypesPass(this);

    public readonly void AddStripSymbolsPass() => LLVM.AddStripSymbolsPass(this);

    public readonly void AddTailCallEliminationPass() => LLVM.AddTailCallEliminationPass(this);

    public readonly void AddTypeBasedAliasAnalysisPass() => LLVM.AddTypeBasedAliasAnalysisPass(this);

    public readonly void AddVerifierPass() => LLVM.AddVerifierPass(this);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposePassManager(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMPassManagerRef other) && Equals(other);

    public readonly bool Equals(LLVMPassManagerRef other) => this == other;

    public readonly bool FinalizeFunctionPassManager() => LLVM.FinalizeFunctionPassManager(this) != 0;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly bool InitializeFunctionPassManager() => LLVM.InitializeFunctionPassManager(this) != 0;

    public readonly bool Run(LLVMModuleRef M) => LLVM.RunPassManager(this, M) != 0;

    public readonly bool RunFunctionPassManager(LLVMValueRef F) => LLVM.RunFunctionPassManager(this, F) != 0;

    public override readonly string ToString() => $"{nameof(LLVMPassManagerRef)}: {Handle:X}";
}
