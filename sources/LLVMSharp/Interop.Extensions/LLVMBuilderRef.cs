// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMBuilderRef : IDisposable, IEquatable<LLVMBuilderRef>
    {
        public IntPtr Handle;

        public LLVMBuilderRef(IntPtr handle)
        {
            Handle = handle;
        }

        public LLVMValueRef CurrentDebugLocation
        {
            get => (Handle != IntPtr.Zero) ? LLVM.GetCurrentDebugLocation(this) : default;
            set => LLVM.SetCurrentDebugLocation(this, value);
        }

        public LLVMBasicBlockRef InsertBlock => (Handle != IntPtr.Zero) ? LLVM.GetInsertBlock(this) : default;

        public static implicit operator LLVMBuilderRef(LLVMOpaqueBuilder* Builder) => new LLVMBuilderRef((IntPtr)Builder);

        public static implicit operator LLVMOpaqueBuilder*(LLVMBuilderRef Builder) => (LLVMOpaqueBuilder*)Builder.Handle;

        public static bool operator ==(LLVMBuilderRef left, LLVMBuilderRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMBuilderRef left, LLVMBuilderRef right) => !(left == right);

        public static LLVMBuilderRef Create(LLVMContextRef C) => LLVM.CreateBuilderInContext(C);

        public LLVMValueRef BuildAdd(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildAdd(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildAdd(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildAdd(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildAddrSpaceCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildAddrSpaceCast(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildAddrSpaceCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildAddrSpaceCast(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildAggregateRet(LLVMValueRef[] RetVals) => BuildAggregateRet(RetVals.AsSpan());

        public LLVMValueRef BuildAggregateRet(ReadOnlySpan<LLVMValueRef> RetVals)
        {
            fixed (LLVMValueRef* pRetVals = RetVals)
            {
                return LLVM.BuildAggregateRet(this, (LLVMOpaqueValue**)pRetVals, (uint)RetVals.Length);
            }
        }

        public LLVMValueRef BuildAlloca(LLVMTypeRef Ty, string Name = "") => BuildAlloca(Ty, Name.AsSpan());

        public LLVMValueRef BuildAlloca(LLVMTypeRef Ty, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildAlloca(this, Ty, marshaledName);
        }

        public LLVMValueRef BuildAnd(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildAnd(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildAnd(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildAnd(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildArrayAlloca(LLVMTypeRef Ty, LLVMValueRef Val, string Name = "") => BuildArrayAlloca(Ty, Val, Name.AsSpan());

        public LLVMValueRef BuildArrayAlloca(LLVMTypeRef Ty, LLVMValueRef Val, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildArrayAlloca(this, Ty, Val, marshaledName);
        }

        public LLVMValueRef BuildArrayMalloc(LLVMTypeRef Ty, LLVMValueRef Val, string Name = "") => BuildArrayMalloc(Ty, Val, Name.AsSpan());

        public LLVMValueRef BuildArrayMalloc(LLVMTypeRef Ty, LLVMValueRef Val, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildArrayMalloc(this, Ty, Val, marshaledName);
        }

        public LLVMValueRef BuildAShr(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildAShr(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildAShr(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildAShr(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildAtomicRMW(LLVMAtomicRMWBinOp op, LLVMValueRef PTR, LLVMValueRef Val, LLVMAtomicOrdering ordering, bool singleThread) => LLVM.BuildAtomicRMW(this, op, PTR, Val, ordering, singleThread ? 1 : 0);

        public LLVMValueRef BuildBinOp(LLVMOpcode Op, LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildBinOp(Op, LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildBinOp(LLVMOpcode Op, LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildBinOp(this, Op, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildBitCast(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildBitCast(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildBr(LLVMBasicBlockRef Dest) => LLVM.BuildBr(this, Dest);

        public LLVMValueRef BuildCall(LLVMValueRef Fn, LLVMValueRef[] Args, string Name = "") => BuildCall(Fn, Args.AsSpan(), Name.AsSpan());

        public LLVMValueRef BuildCall(LLVMValueRef Fn, ReadOnlySpan<LLVMValueRef> Args, ReadOnlySpan<char> Name)
        {
            fixed (LLVMValueRef* pArgs = Args)
            {
                using var marshaledName = new MarshaledString(Name);
                return LLVM.BuildCall(this, Fn, (LLVMOpaqueValue**)pArgs, (uint)Args.Length, marshaledName);
            }
        }

        public LLVMValueRef BuildCast(LLVMOpcode Op, LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildCast(Op, Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildCast(LLVMOpcode Op, LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildCast(this, Op, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildCondBr(LLVMValueRef If, LLVMBasicBlockRef Then, LLVMBasicBlockRef Else) => LLVM.BuildCondBr(this, If, Then, Else);

        public LLVMValueRef BuildExactSDiv(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildExactSDiv(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildExactSDiv(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildExactSDiv(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildExtractElement(LLVMValueRef VecVal, LLVMValueRef Index, string Name = "") => BuildExtractElement(VecVal, Index, Name.AsSpan());

        public LLVMValueRef BuildExtractElement(LLVMValueRef VecVal, LLVMValueRef Index, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildExtractElement(this, VecVal, Index, marshaledName);
        }

        public LLVMValueRef BuildExtractValue(LLVMValueRef AggVal, uint Index, string Name = "") => BuildExtractValue(AggVal, Index, Name.AsSpan());

        public LLVMValueRef BuildExtractValue(LLVMValueRef AggVal, uint Index, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildExtractValue(this, AggVal, Index, marshaledName);
        }

        public LLVMValueRef BuildFAdd(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFAdd(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildFAdd(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFAdd(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildFCmp(LLVMRealPredicate Op, LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFCmp(Op, LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildFCmp(LLVMRealPredicate Op, LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFCmp(this, Op, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildFDiv(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFDiv(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildFDiv(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFDiv(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildFence(LLVMAtomicOrdering ordering, bool singleThread, string Name = "") => BuildFence(ordering, singleThread, Name.AsSpan());

        public LLVMValueRef BuildFence(LLVMAtomicOrdering ordering, bool singleThread, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFence(this, ordering, singleThread ? 1 : 0, marshaledName);
        }

        public LLVMValueRef BuildFMul(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFMul(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildFMul(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFMul(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildFNeg(LLVMValueRef V, string Name = "") => BuildFNeg(V, Name.AsSpan());

        public LLVMValueRef BuildFNeg(LLVMValueRef V, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFNeg(this, V, marshaledName);
        }

        public LLVMValueRef BuildFPCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildFPCast(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildFPCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFPCast(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildFPExt(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildFPCast(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildFPExt(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFPExt(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildFPToSI(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildFPToSI(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildFPToSI(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFPToSI(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildFPToUI(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildFPToUI(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildFPToUI(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFPToUI(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildFPTrunc(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildFPTrunc(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildFPTrunc(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFPTrunc(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildFree(LLVMValueRef PointerVal) => LLVM.BuildFree(this, PointerVal);

        public LLVMValueRef BuildFreeze(LLVMValueRef Val, string Name = "") => BuildFreeze(Val, Name.AsSpan());

        public LLVMValueRef BuildFreeze(LLVMValueRef Val, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFreeze(this, Val, marshaledName);
        }

        public LLVMValueRef BuildFRem(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFRem(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildFRem(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFRem(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildFSub(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildFSub(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildFSub(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildFSub(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildGEP(LLVMValueRef Pointer, LLVMValueRef[] Indices, string Name = "") => BuildGEP(Pointer, Indices.AsSpan(), Name.AsSpan());

        public LLVMValueRef BuildGEP(LLVMValueRef Pointer, ReadOnlySpan<LLVMValueRef> Indices, ReadOnlySpan<char> Name)
        {
            fixed (LLVMValueRef* pIndices = Indices)
            {
                using var marshaledName = new MarshaledString(Name);
                return LLVM.BuildGEP(this, Pointer, (LLVMOpaqueValue**)pIndices, (uint)Indices.Length, marshaledName);
            }
        }

        public LLVMValueRef BuildGlobalString(string Str, string Name = "") => BuildGlobalString(Str.AsSpan(), Name.AsSpan());

        public LLVMValueRef BuildGlobalString(ReadOnlySpan<char> Str, ReadOnlySpan<char> Name)
        {
            using var marshaledStr = new MarshaledString(Str);
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildGlobalString(this, marshaledStr, marshaledName);
        }

        public LLVMValueRef BuildGlobalStringPtr(string Str, string Name = "") => BuildGlobalStringPtr(Str.AsSpan(), Name.AsSpan());

        public LLVMValueRef BuildGlobalStringPtr(ReadOnlySpan<char> Str, ReadOnlySpan<char> Name)
        {
            using var marshaledStr = new MarshaledString(Str);
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildGlobalStringPtr(this, marshaledStr, marshaledName);
        }

        public LLVMValueRef BuildICmp(LLVMIntPredicate Op, LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildICmp(Op, LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildICmp(LLVMIntPredicate Op, LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildICmp(this, Op, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildInBoundsGEP(LLVMValueRef Pointer, LLVMValueRef[] Indices, string Name = "") => BuildInBoundsGEP(Pointer, Indices.AsSpan(), Name.AsSpan());

        public LLVMValueRef BuildInBoundsGEP(LLVMValueRef Pointer, ReadOnlySpan<LLVMValueRef> Indices, ReadOnlySpan<char> Name)
        {
            fixed (LLVMValueRef* pIndices = Indices)
            {
                using var marshaledName = new MarshaledString(Name);
                return LLVM.BuildInBoundsGEP(this, Pointer, (LLVMOpaqueValue**)pIndices, (uint)Indices.Length, marshaledName);
            }
        }

        public LLVMValueRef BuildIndirectBr(LLVMValueRef Addr, uint NumDests) => LLVM.BuildIndirectBr(this, Addr, NumDests);

        public LLVMValueRef BuildInsertElement(LLVMValueRef VecVal, LLVMValueRef EltVal, LLVMValueRef Index, string Name = "") => BuildInsertElement(VecVal, EltVal, Index, Name.AsSpan());

        public LLVMValueRef BuildInsertElement(LLVMValueRef VecVal, LLVMValueRef EltVal, LLVMValueRef Index, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildInsertElement(this, VecVal, EltVal, Index, marshaledName);
        }

        public LLVMValueRef BuildInsertValue(LLVMValueRef AggVal, LLVMValueRef EltVal, uint Index, string Name = "") => BuildInsertValue(AggVal, EltVal, Index, Name.AsSpan());

        public LLVMValueRef BuildInsertValue(LLVMValueRef AggVal, LLVMValueRef EltVal, uint Index, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildInsertValue(this, AggVal, EltVal, Index, marshaledName);
        }

        public LLVMValueRef BuildIntCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildIntCast(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildIntCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildIntCast(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildIntToPtr(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildIntToPtr(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildIntToPtr(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildIntToPtr(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildInvoke(LLVMValueRef Fn, LLVMValueRef[] Args, LLVMBasicBlockRef Then, LLVMBasicBlockRef Catch, string Name = "") => BuildInvoke(Fn, Args.AsSpan(), Then, Catch, Name.AsSpan());

        public LLVMValueRef BuildInvoke(LLVMValueRef Fn, ReadOnlySpan<LLVMValueRef> Args, LLVMBasicBlockRef Then, LLVMBasicBlockRef Catch, ReadOnlySpan<char> Name)
        {
            fixed (LLVMValueRef* pArgs = Args)
            {
                using var marshaledName = new MarshaledString(Name);
                return LLVM.BuildInvoke(this, Fn, (LLVMOpaqueValue**)pArgs, (uint)Args.Length, Then, Catch, marshaledName);
            }
        }

        public LLVMValueRef BuildIsNotNull(LLVMValueRef Val, string Name = "") => BuildIsNotNull(Val, Name.AsSpan());

        public LLVMValueRef BuildIsNotNull(LLVMValueRef Val, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildIsNotNull(this, Val, marshaledName);
        }

        public LLVMValueRef BuildIsNull(LLVMValueRef Val, string Name = "") => BuildIsNull(Val, Name.AsSpan());

        public LLVMValueRef BuildIsNull(LLVMValueRef Val, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildIsNull(this, Val, marshaledName);
        }

        public LLVMValueRef BuildLandingPad(LLVMTypeRef Ty, LLVMValueRef PersFn, uint NumClauses, string Name = "") => BuildLandingPad(Ty, PersFn, NumClauses, Name.AsSpan());

        public LLVMValueRef BuildLandingPad(LLVMTypeRef Ty, LLVMValueRef PersFn, uint NumClauses, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildLandingPad(this, Ty, PersFn, NumClauses, marshaledName);
        }

        public LLVMValueRef BuildLoad(LLVMValueRef PointerVal, string Name = "") => BuildLoad(PointerVal, Name.AsSpan());

        public LLVMValueRef BuildLoad(LLVMValueRef PointerVal, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildLoad(this, PointerVal, marshaledName);
        }

        public LLVMValueRef BuildLShr(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildLShr(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildLShr(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildLShr(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildMalloc(LLVMTypeRef Ty, string Name = "") => BuildMalloc(Ty, Name.AsSpan());

        public LLVMValueRef BuildMalloc(LLVMTypeRef Ty, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildMalloc(this, Ty, marshaledName);
        }

        public LLVMValueRef BuildMul(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildMul(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildMul(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildMul(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildNeg(LLVMValueRef V, string Name = "") => BuildNeg(V, Name.AsSpan());

        public LLVMValueRef BuildNeg(LLVMValueRef V, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildNeg(this, V, marshaledName);
        }

        public LLVMValueRef BuildNot(LLVMValueRef V, string Name = "") => BuildNot(V, Name.AsSpan());

        public LLVMValueRef BuildNot(LLVMValueRef V, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildNot(this, V, marshaledName);
        }

        public LLVMValueRef BuildNSWAdd(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNSWAdd(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildNSWAdd(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildNSWAdd(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildNSWMul(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNSWMul(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildNSWMul(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildNSWMul(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildNSWNeg(LLVMValueRef V, string Name = "") => BuildNSWNeg(V, Name.AsSpan());

        public LLVMValueRef BuildNSWNeg(LLVMValueRef V, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildNSWNeg(this, V, marshaledName);
        }

        public LLVMValueRef BuildNSWSub(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNSWSub(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildNSWSub(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildNSWSub(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildNUWAdd(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNUWAdd(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildNUWAdd(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildNUWAdd(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildNUWMul(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNUWMul(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildNUWMul(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildNUWMul(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildNUWNeg(LLVMValueRef V, string Name = "") => BuildNUWNeg(V, Name.AsSpan());

        public LLVMValueRef BuildNUWNeg(LLVMValueRef V, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildNUWNeg(this, V, marshaledName);
        }

        public LLVMValueRef BuildNUWSub(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildNUWSub(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildNUWSub(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildNUWSub(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildOr(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildOr(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildOr(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildOr(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildPhi(LLVMTypeRef Ty, string Name = "") => BuildPhi(Ty, Name.AsSpan());

        public LLVMValueRef BuildPhi(LLVMTypeRef Ty, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildPhi(this, Ty, marshaledName);
        }

        public LLVMValueRef BuildPointerCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildPointerCast(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildPointerCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildPointerCast(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildPtrDiff(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildPtrDiff(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildPtrDiff(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildPtrDiff(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildPtrToInt(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildPtrToInt(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildPtrToInt(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildPtrToInt(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildResume(LLVMValueRef Exn) => LLVM.BuildResume(this, Exn);

        public LLVMValueRef BuildRet(LLVMValueRef V) => LLVM.BuildRet(this, V);

        public LLVMValueRef BuildRetVoid() => LLVM.BuildRetVoid(this);

        public LLVMValueRef BuildSDiv(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildSDiv(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildSDiv(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildSDiv(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildSelect(LLVMValueRef If, LLVMValueRef Then, LLVMValueRef Else, string Name = "") => BuildSelect(If, Then, Else, Name.AsSpan());

        public LLVMValueRef BuildSelect(LLVMValueRef If, LLVMValueRef Then, LLVMValueRef Else, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildSelect(this, If, Then, Else, marshaledName);
        }

        public LLVMValueRef BuildSExt(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildSExt(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildSExt(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildSExt(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildSExtOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildSExtOrBitCast(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildSExtOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildSExtOrBitCast(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildShl(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildShl(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildShl(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildShl(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildShuffleVector(LLVMValueRef V1, LLVMValueRef V2, LLVMValueRef Mask, string Name = "") => BuildShuffleVector(V1, V2, Mask, Name.AsSpan());

        public LLVMValueRef BuildShuffleVector(LLVMValueRef V1, LLVMValueRef V2, LLVMValueRef Mask, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildShuffleVector(this, V1, V2, Mask, marshaledName);
        }

        public LLVMValueRef BuildSIToFP(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildSIToFP(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildSIToFP(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildSIToFP(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildSRem(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildSRem(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildSRem(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildSRem(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildStore(LLVMValueRef Val, LLVMValueRef Ptr) => LLVM.BuildStore(this, Val, Ptr);

        public LLVMValueRef BuildStructGEP(LLVMValueRef Pointer, uint Idx, string Name = "") => BuildStructGEP(Pointer, Idx, Name.AsSpan());

        public LLVMValueRef BuildStructGEP(LLVMValueRef Pointer, uint Idx, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildStructGEP(this, Pointer, Idx, marshaledName);
        }

        public LLVMValueRef BuildSub(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildSub(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildSub(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildSub(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildSwitch(LLVMValueRef V, LLVMBasicBlockRef Else, uint NumCases) => LLVM.BuildSwitch(this, V, Else, NumCases);

        public LLVMValueRef BuildTrunc(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildTrunc(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildTrunc(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildTrunc(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildTruncOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildTruncOrBitCast(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildTruncOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildTruncOrBitCast(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildUDiv(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildUDiv(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildUDiv(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildUDiv(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildUIToFP(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildUIToFP(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildUIToFP(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildUIToFP(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildUnreachable() => LLVM.BuildUnreachable(this);

        public LLVMValueRef BuildURem(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildURem(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildURem(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildURem(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildVAArg(LLVMValueRef List, LLVMTypeRef Ty, string Name = "") => BuildVAArg(List, Ty, Name.AsSpan());

        public LLVMValueRef BuildVAArg(LLVMValueRef List, LLVMTypeRef Ty, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildVAArg(this, List, Ty, marshaledName);
        }

        public LLVMValueRef BuildXor(LLVMValueRef LHS, LLVMValueRef RHS, string Name = "") => BuildXor(LHS, RHS, Name.AsSpan());

        public LLVMValueRef BuildXor(LLVMValueRef LHS, LLVMValueRef RHS, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildXor(this, LHS, RHS, marshaledName);
        }

        public LLVMValueRef BuildZExt(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildZExt(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildZExt(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildZExt(this, Val, DestTy, marshaledName);
        }

        public LLVMValueRef BuildZExtOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, string Name = "") => BuildZExtOrBitCast(Val, DestTy, Name.AsSpan());

        public LLVMValueRef BuildZExtOrBitCast(LLVMValueRef Val, LLVMTypeRef DestTy, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            return LLVM.BuildZExtOrBitCast(this, Val, DestTy, marshaledName);
        }
        public void ClearInsertionPosition() => LLVM.ClearInsertionPosition(this);

        public void Dispose()
        {
            if (Handle != IntPtr.Zero)
            {
                LLVM.DisposeBuilder(this);
                Handle = IntPtr.Zero;
            }
        }

        public override bool Equals(object obj) => (obj is LLVMBuilderRef other) && Equals(other);

        public bool Equals(LLVMBuilderRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public void Insert(LLVMValueRef Instr) => LLVM.InsertIntoBuilder(this, Instr);

        public void InsertWithName(LLVMValueRef Instr, string Name = "") => InsertWithName(Instr, Name.AsSpan());

        public void InsertWithName(LLVMValueRef Instr, ReadOnlySpan<char> Name)
        {
            using var marshaledName = new MarshaledString(Name);
            LLVM.InsertIntoBuilderWithName(this, Instr, marshaledName);
        }

        public void Position(LLVMBasicBlockRef Block, LLVMValueRef Instr) => LLVM.PositionBuilder(this, Block, Instr);

        public void PositionAtEnd(LLVMBasicBlockRef Block) => LLVM.PositionBuilderAtEnd(this, Block);

        public void PositionBefore(LLVMValueRef Instr) => LLVM.PositionBuilderBefore(this, Instr);

        public void SetInstDebugLocation(LLVMValueRef Inst) => LLVM.SetInstDebugLocation(this, Inst);

        public override string ToString() => $"{nameof(LLVMBuilderRef)}: {Handle:X}";
    }
}
