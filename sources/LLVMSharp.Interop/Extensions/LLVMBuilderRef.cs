// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop;

public unsafe partial struct LLVMBuilderRef(IntPtr handle) : IDisposable, IEquatable<LLVMBuilderRef>
{
    public IntPtr Handle = handle;

    public readonly LLVMValueRef CurrentDebugLocation
    {
        get
        {
            return (Handle != IntPtr.Zero) ? LLVM.GetCurrentDebugLocation(this) : default;
        }

        set
        {
            LLVM.SetCurrentDebugLocation(this, value);
        }
    }

    public readonly LLVMBasicBlockRef InsertBlock => (Handle != IntPtr.Zero) ? LLVM.GetInsertBlock(this) : default;

    public static implicit operator LLVMBuilderRef(LLVMOpaqueBuilder* Builder) => new LLVMBuilderRef((IntPtr)Builder);

    public static implicit operator LLVMOpaqueBuilder*(LLVMBuilderRef Builder) => (LLVMOpaqueBuilder*)Builder.Handle;

    public static bool operator ==(LLVMBuilderRef left, LLVMBuilderRef right) => left.Handle == right.Handle;

    public static bool operator !=(LLVMBuilderRef left, LLVMBuilderRef right) => !(left == right);

    public static LLVMBuilderRef Create(LLVMContextRef C) => LLVM.CreateBuilderInContext(C);

    public readonly LLVMValueRef BuildAdd(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildAdd(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildAdd(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildAdd(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildAddrSpaceCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildAddrSpaceCast(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildAddrSpaceCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildAddrSpaceCast(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildAggregateRet(LLVMValueRef[] RetVals) => BuildAggregateRet(RetVals.AsSpan());

    public readonly LLVMValueRef BuildAggregateRet(ReadOnlySpan<LLVMValueRef> RetVals)
    {
        fixed (LLVMValueRef* pRetVals = RetVals)
        {
            return LLVM.BuildAggregateRet(this, (LLVMOpaqueValue**)pRetVals, (uint)RetVals.Length);
        }
    }

    public readonly LLVMValueRef BuildAlloca(LLVMTypeRef Ty, string Name = "") => BuildAlloca(Ty, Name.AsSpan());

    public readonly LLVMValueRef BuildAlloca(LLVMTypeRef Ty, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildAlloca(this, Ty, marshaledName);
    }

    public readonly LLVMValueRef BuildAnd(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildAnd(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildAnd(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildAnd(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildArrayAlloca(LLVMTypeRef Ty, LLVMValueRef Val, string Name = "") => BuildArrayAlloca(Ty, Val, Name.AsSpan());

    public readonly LLVMValueRef BuildArrayAlloca(LLVMTypeRef Ty, LLVMValueRef Val, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildArrayAlloca(this, Ty, Val, marshaledName);
    }

    public readonly LLVMValueRef BuildArrayMalloc(LLVMTypeRef Ty, LLVMValueRef Val, string Name = "") => BuildArrayMalloc(Ty, Val, Name.AsSpan());

    public readonly LLVMValueRef BuildArrayMalloc(LLVMTypeRef Ty, LLVMValueRef Val, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildArrayMalloc(this, Ty, Val, marshaledName);
    }

    public readonly LLVMValueRef BuildAShr(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildAShr(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildAShr(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildAShr(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildAtomicRMW(LLVMAtomicRMWBinOp op, LLVMValueRef PTR, LLVMValueRef Val, LLVMAtomicOrdering ordering, bool singleThread) => LLVM.BuildAtomicRMW(this, op, PTR, Val, ordering, singleThread ? 1 : 0);

    public readonly LLVMValueRef BuildBinOp(LLVMOpcode Op, LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildBinOp(Op, LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildBinOp(LLVMOpcode Op, LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildBinOp(this, Op, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildBitCast(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildBitCast(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildBr(LLVMBasicBlockRef Dest) => LLVM.BuildBr(this, Dest);

    public readonly LLVMValueRef BuildCall2(LLVMTypeRef Ty, LLVMValueRef Fn, LLVMValueRef[] Args, string Name = "") => BuildCall2(Ty, Fn, Args.AsSpan(), Name.AsSpan());

    public readonly LLVMValueRef BuildCall2(LLVMTypeRef Ty, LLVMValueRef Fn, ReadOnlySpan<LLVMValueRef> Args, ReadOnlySpan<char> Name)
    {
        fixed (LLVMValueRef* pArgs = Args)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildCall2(this, Ty, Fn, (LLVMOpaqueValue**)pArgs, (uint)Args.Length, marshaledName);
        }
    }

    public readonly LLVMValueRef BuildCast(LLVMOpcode Op, LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildCast(Op, Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildCast(LLVMOpcode Op, LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildCast(this, Op, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildCondBr(LLVMValueRef If, LLVMBasicBlockRef Then, LLVMBasicBlockRef Else) => LLVM.BuildCondBr(this, If, Then, Else);

    public readonly LLVMValueRef BuildExactSDiv(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildExactSDiv(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildExactSDiv(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildExactSDiv(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildExtractElement(LLVMValueRef VecVal, LLVMValueRef Index, string Name = "") => BuildExtractElement(VecVal, Index, Name.AsSpan());

    public readonly LLVMValueRef BuildExtractElement(LLVMValueRef VecVal, LLVMValueRef Index, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildExtractElement(this, VecVal, Index, marshaledName);
    }

    public readonly LLVMValueRef BuildExtractValue(LLVMValueRef AggVal, uint Index, string Name = "") => BuildExtractValue(AggVal, Index, Name.AsSpan());

    public readonly LLVMValueRef BuildExtractValue(LLVMValueRef AggVal, uint Index, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildExtractValue(this, AggVal, Index, marshaledName);
    }

    public readonly LLVMValueRef BuildFAdd(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFAdd(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildFAdd(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFAdd(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildFCmp(LLVMRealPredicate Op, LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFCmp(Op, LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildFCmp(LLVMRealPredicate Op, LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFCmp(this, Op, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildFDiv(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFDiv(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildFDiv(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFDiv(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildFence(LLVMAtomicOrdering ordering, bool singleThread, string Name = "") => BuildFence(ordering, singleThread, Name.AsSpan());

    public readonly LLVMValueRef BuildFence(LLVMAtomicOrdering ordering, bool singleThread, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFence(this, ordering, singleThread ? 1 : 0, marshaledName);
    }

    public readonly LLVMValueRef BuildFMul(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFMul(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildFMul(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFMul(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildFNeg(LLVMValueRef V, string Name = "") => BuildFNeg(V, Name.AsSpan());

    public readonly LLVMValueRef BuildFNeg(LLVMValueRef V, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFNeg(this, V, marshaledName);
    }

    public readonly LLVMValueRef BuildFPCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildFPCast(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildFPCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFPCast(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildFPExt(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildFPCast(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildFPExt(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFPExt(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildFPToSI(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildFPToSI(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildFPToSI(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFPToSI(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildFPToUI(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildFPToUI(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildFPToUI(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFPToUI(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildFPTrunc(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildFPTrunc(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildFPTrunc(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFPTrunc(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildFree(LLVMValueRef PointerVal) => LLVM.BuildFree(this, PointerVal);

    public readonly LLVMValueRef BuildFreeze(LLVMValueRef Val, string Name = "") => BuildFreeze(Val, Name.AsSpan());

    public readonly LLVMValueRef BuildFreeze(LLVMValueRef Val, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFreeze(this, Val, marshaledName);
    }

    public readonly LLVMValueRef BuildFRem(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFRem(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildFRem(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFRem(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildFSub(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFSub(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildFSub(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildFSub(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildGEP2(LLVMTypeRef Ty, LLVMValueRef Pointer, LLVMValueRef[] Indices, string Name = "") => BuildGEP2(Ty, Pointer, Indices.AsSpan(), Name.AsSpan());

    public readonly LLVMValueRef BuildGEP2(LLVMTypeRef Ty, LLVMValueRef Pointer, ReadOnlySpan<LLVMValueRef> Indices, ReadOnlySpan<char> Name)
    {
        fixed (LLVMValueRef* pIndices = Indices)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildGEP2(this, Ty, Pointer, (LLVMOpaqueValue**)pIndices, (uint)Indices.Length, marshaledName);
        }
    }

    public readonly LLVMValueRef BuildGlobalString(string Str, string Name = "") => BuildGlobalString(Str.AsSpan(), Name.AsSpan());

    public readonly LLVMValueRef BuildGlobalString(ReadOnlySpan<char> Str, ReadOnlySpan<char> Name)
    {
        using var marshaledStr = new MarshaledString(Str);
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildGlobalString(this, marshaledStr, marshaledName);
    }

    public readonly LLVMValueRef BuildGlobalStringPtr(string Str, string Name = "") => BuildGlobalStringPtr(Str.AsSpan(), Name.AsSpan());

    public readonly LLVMValueRef BuildGlobalStringPtr(ReadOnlySpan<char> Str, ReadOnlySpan<char> Name)
    {
        using var marshaledStr = new MarshaledString(Str);
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildGlobalStringPtr(this, marshaledStr, marshaledName);
    }

    public readonly LLVMValueRef BuildICmp(LLVMIntPredicate Op, LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildICmp(Op, LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildICmp(LLVMIntPredicate Op, LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildICmp(this, Op, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildInBoundsGEP2(LLVMTypeRef Ty, LLVMValueRef Pointer, LLVMValueRef[] Indices, string Name = "") => BuildInBoundsGEP2(Ty, Pointer, Indices.AsSpan(), Name.AsSpan());

    public readonly LLVMValueRef BuildInBoundsGEP2(LLVMTypeRef Ty, LLVMValueRef Pointer, ReadOnlySpan<LLVMValueRef> Indices, ReadOnlySpan<char> Name)
    {
        fixed (LLVMValueRef* pIndices = Indices)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildInBoundsGEP2(this, Ty, Pointer, (LLVMOpaqueValue**)pIndices, (uint)Indices.Length, marshaledName);
        }
    }

    public readonly LLVMValueRef BuildIndirectBr(LLVMValueRef Addr, uint NumDests) => LLVM.BuildIndirectBr(this, Addr, NumDests);

    public readonly LLVMValueRef BuildInsertElement(LLVMValueRef VecVal, LLVMValueRef EltVal, LLVMValueRef Index, string Name = "") => BuildInsertElement(VecVal, EltVal, Index, Name.AsSpan());

    public readonly LLVMValueRef BuildInsertElement(LLVMValueRef VecVal, LLVMValueRef EltVal, LLVMValueRef Index, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildInsertElement(this, VecVal, EltVal, Index, marshaledName);
    }

    public readonly LLVMValueRef BuildInsertValue(LLVMValueRef AggVal, LLVMValueRef EltVal, uint Index, string Name = "") => BuildInsertValue(AggVal, EltVal, Index, Name.AsSpan());

    public readonly LLVMValueRef BuildInsertValue(LLVMValueRef AggVal, LLVMValueRef EltVal, uint Index, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildInsertValue(this, AggVal, EltVal, Index, marshaledName);
    }

    public readonly LLVMValueRef BuildIntCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildIntCast(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildIntCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildIntCast(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildIntToPtr(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildIntToPtr(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildIntToPtr(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildIntToPtr(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildInvoke2(LLVMTypeRef Ty, LLVMValueRef Fn, LLVMValueRef[] Args, LLVMBasicBlockRef Then, LLVMBasicBlockRef Catch, string Name = "") => BuildInvoke2(Ty, Fn, Args.AsSpan(), Then, Catch, Name.AsSpan());

    public readonly LLVMValueRef BuildInvoke2(LLVMTypeRef Ty, LLVMValueRef Fn, ReadOnlySpan<LLVMValueRef> Args, LLVMBasicBlockRef Then, LLVMBasicBlockRef Catch, ReadOnlySpan<char> Name)
    {
        fixed (LLVMValueRef* pArgs = Args)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildInvoke2(this, Ty, Fn, (LLVMOpaqueValue**)pArgs, (uint)Args.Length, Then, Catch, marshaledName);
        }
    }

    public readonly LLVMValueRef BuildIsNotNull(LLVMValueRef Val, string Name = "") => BuildIsNotNull(Val, Name.AsSpan());

    public readonly LLVMValueRef BuildIsNotNull(LLVMValueRef Val, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildIsNotNull(this, Val, marshaledName);
    }

    public readonly LLVMValueRef BuildIsNull(LLVMValueRef Val, string Name = "") => BuildIsNull(Val, Name.AsSpan());

    public readonly LLVMValueRef BuildIsNull(LLVMValueRef Val, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildIsNull(this, Val, marshaledName);
    }

    public readonly LLVMValueRef BuildLandingPad(LLVMTypeRef Ty, LLVMValueRef PersFn, uint NumClauses, string Name = "") => BuildLandingPad(Ty, PersFn, NumClauses, Name.AsSpan());

    public readonly LLVMValueRef BuildLandingPad(LLVMTypeRef Ty, LLVMValueRef PersFn, uint NumClauses, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildLandingPad(this, Ty, PersFn, NumClauses, marshaledName);
    }

    public readonly LLVMValueRef BuildLoad2(LLVMTypeRef Ty, LLVMValueRef PointerVal, string Name = "") => BuildLoad2(Ty, PointerVal, Name.AsSpan());

    public readonly LLVMValueRef BuildLoad2(LLVMTypeRef Ty, LLVMValueRef PointerVal, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildLoad2(this, Ty, PointerVal, marshaledName);
    }

    public readonly LLVMValueRef BuildLShr(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildLShr(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildLShr(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildLShr(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildMalloc(LLVMTypeRef Ty, string Name = "") => BuildMalloc(Ty, Name.AsSpan());

    public readonly LLVMValueRef BuildMalloc(LLVMTypeRef Ty, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildMalloc(this, Ty, marshaledName);
    }

    public readonly LLVMValueRef BuildMul(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildMul(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildMul(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildMul(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildNeg(LLVMValueRef V, string Name = "") => BuildNeg(V, Name.AsSpan());

    public readonly LLVMValueRef BuildNeg(LLVMValueRef V, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildNeg(this, V, marshaledName);
    }

    public readonly LLVMValueRef BuildNot(LLVMValueRef V, string Name = "") => BuildNot(V, Name.AsSpan());

    public readonly LLVMValueRef BuildNot(LLVMValueRef V, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildNot(this, V, marshaledName);
    }

    public readonly LLVMValueRef BuildNSWAdd(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNSWAdd(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildNSWAdd(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildNSWAdd(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildNSWMul(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNSWMul(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildNSWMul(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildNSWMul(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildNSWNeg(LLVMValueRef V, string Name = "") => BuildNSWNeg(V, Name.AsSpan());

    public readonly LLVMValueRef BuildNSWNeg(LLVMValueRef V, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildNSWNeg(this, V, marshaledName);
    }

    public readonly LLVMValueRef BuildNSWSub(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNSWSub(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildNSWSub(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildNSWSub(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildNUWAdd(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNUWAdd(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildNUWAdd(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildNUWAdd(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildNUWMul(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNUWMul(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildNUWMul(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildNUWMul(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildNUWNeg(LLVMValueRef V, string Name = "") => BuildNUWNeg(V, Name.AsSpan());

    public readonly LLVMValueRef BuildNUWNeg(LLVMValueRef V, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildNUWNeg(this, V, marshaledName);
    }

    public readonly LLVMValueRef BuildNUWSub(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNUWSub(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildNUWSub(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildNUWSub(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildOr(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildOr(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildOr(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildOr(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildPhi(LLVMTypeRef Ty, string Name = "") => BuildPhi(Ty, Name.AsSpan());

    public readonly LLVMValueRef BuildPhi(LLVMTypeRef Ty, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildPhi(this, Ty, marshaledName);
    }

    public readonly LLVMValueRef BuildPointerCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildPointerCast(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildPointerCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildPointerCast(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildPtrDiff2(LLVMTypeRef ElemTy, LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildPtrDiff2(ElemTy, LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildPtrDiff2(LLVMTypeRef ElemTy, LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildPtrDiff2(this, ElemTy, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildPtrToInt(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildPtrToInt(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildPtrToInt(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildPtrToInt(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildResume(LLVMValueRef Exn) => LLVM.BuildResume(this, Exn);

    public readonly LLVMValueRef BuildRet(LLVMValueRef V) => LLVM.BuildRet(this, V);

    public readonly LLVMValueRef BuildRetVoid() => LLVM.BuildRetVoid(this);

    public readonly LLVMValueRef BuildSDiv(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildSDiv(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildSDiv(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildSDiv(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildSelect(LLVMValueRef If, LLVMValueRef Then, LLVMValueRef Else, string Name = "") => BuildSelect(If, Then, Else, Name.AsSpan());

    public readonly LLVMValueRef BuildSelect(LLVMValueRef If, LLVMValueRef Then, LLVMValueRef Else, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildSelect(this, If, Then, Else, marshaledName);
    }

    public readonly LLVMValueRef BuildSExt(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildSExt(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildSExt(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildSExt(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildSExtOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildSExtOrBitCast(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildSExtOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildSExtOrBitCast(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildShl(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildShl(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildShl(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildShl(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildShuffleVector(LLVMValueRef V1, LLVMValueRef V2, LLVMValueRef Mask, string Name = "") => BuildShuffleVector(V1, V2, Mask, Name.AsSpan());

    public readonly LLVMValueRef BuildShuffleVector(LLVMValueRef V1, LLVMValueRef V2, LLVMValueRef Mask, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildShuffleVector(this, V1, V2, Mask, marshaledName);
    }

    public readonly LLVMValueRef BuildSIToFP(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildSIToFP(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildSIToFP(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildSIToFP(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildSRem(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildSRem(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildSRem(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildSRem(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildStore(LLVMValueRef Val, LLVMValueRef Ptr) => LLVM.BuildStore(this, Val, Ptr);

    public readonly LLVMValueRef BuildStructGEP2(LLVMTypeRef Ty, LLVMValueRef Pointer, uint Idx, string Name = "") => BuildStructGEP2(Ty, Pointer, Idx, Name.AsSpan());

    public readonly LLVMValueRef BuildStructGEP2(LLVMTypeRef Ty, LLVMValueRef Pointer, uint Idx, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildStructGEP2(this, Ty, Pointer, Idx, marshaledName);
    }

    public readonly LLVMValueRef BuildSub(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildSub(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildSub(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildSub(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildSwitch(LLVMValueRef V, LLVMBasicBlockRef Else, uint NumCases) => LLVM.BuildSwitch(this, V, Else, NumCases);

    public readonly LLVMValueRef BuildTrunc(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildTrunc(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildTrunc(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildTrunc(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildTruncOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildTruncOrBitCast(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildTruncOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildTruncOrBitCast(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildUDiv(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildUDiv(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildUDiv(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildUDiv(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildUIToFP(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildUIToFP(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildUIToFP(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildUIToFP(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildUnreachable() => LLVM.BuildUnreachable(this);

    public readonly LLVMValueRef BuildURem(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildURem(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildURem(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildURem(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildVAArg(LLVMValueRef List, LLVMTypeRef Ty, string Name = "") => BuildVAArg(List, Ty, Name.AsSpan());

    public readonly LLVMValueRef BuildVAArg(LLVMValueRef List, LLVMTypeRef Ty, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildVAArg(this, List, Ty, marshaledName);
    }

    public readonly LLVMValueRef BuildXor(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildXor(LHS, RHS, Name.AsSpan());

    public readonly LLVMValueRef BuildXor(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildXor(this, LHS, RHS, marshaledName);
    }

    public readonly LLVMValueRef BuildZExt(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildZExt(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildZExt(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildZExt(this, Val, DestTy, marshaledName);
    }

    public readonly LLVMValueRef BuildZExtOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildZExtOrBitCast(Val, DestTy, Name.AsSpan());

    public readonly LLVMValueRef BuildZExtOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        return LLVM.BuildZExtOrBitCast(this, Val, DestTy, marshaledName);
    }
    public readonly void ClearInsertionPosition() => LLVM.ClearInsertionPosition(this);

    public void Dispose()
    {
        if (Handle != IntPtr.Zero)
        {
            LLVM.DisposeBuilder(this);
            Handle = IntPtr.Zero;
        }
    }

    public override readonly bool Equals(object? obj) => (obj is LLVMBuilderRef other) && Equals(other);

    public readonly bool Equals(LLVMBuilderRef other) => this == other;

    public override readonly int GetHashCode() => Handle.GetHashCode();

    public readonly void Insert(LLVMValueRef Instr) => LLVM.InsertIntoBuilder(this, Instr);

    public readonly void InsertWithName(LLVMValueRef Instr, string Name = "") => InsertWithName(Instr, Name.AsSpan());

    public readonly void InsertWithName(LLVMValueRef Instr, ReadOnlySpan<char> Name)
    {
        using var marshaledName = new MarshaledString(Name);
        LLVM.InsertIntoBuilderWithName(this, Instr, marshaledName);
    }

    public readonly void Position(LLVMBasicBlockRef Block, LLVMValueRef Instr) => LLVM.PositionBuilder(this, Block, Instr);

    public readonly void PositionAtEnd(LLVMBasicBlockRef Block) => LLVM.PositionBuilderAtEnd(this, Block);

    public readonly void PositionBefore(LLVMValueRef Instr) => LLVM.PositionBuilderBefore(this, Instr);

    public readonly void SetInstDebugLocation(LLVMValueRef Inst) => LLVM.SetInstDebugLocation(this, Inst);

    public override readonly string ToString() => $"{nameof(LLVMBuilderRef)}: {Handle:X}";
}
