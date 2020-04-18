// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class IRBuilder : IRBuilderBase
    {
        public IRBuilder(LLVMContext C) : base(C)
        {
        }

        public Value CreateAdd(Value LHS, Value RHS, string Name ="") => CreateAdd(LHS, RHS, Name.AsSpan());

        public Value CreateAdd(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildAdd(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateAddrSpaceCast(Value V, Type DestTy, string Name = "") => CreateAddrSpaceCast(V, DestTy, Name.AsSpan());

        public Value CreateAddrSpaceCast(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildAddrSpaceCast(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public ReturnInst CreateAggregateRet(Value[] retVals) => CreateAggregateRet(retVals.AsSpan());

        public ReturnInst CreateAggregateRet(ReadOnlySpan<Value> retVals)
        {
            using var retValHandles = new MarshaledArray<Value, LLVMValueRef>(retVals, (value) => value.Handle);
            var handle = Handle.BuildAggregateRet(retValHandles);
            return Context.GetOrCreate<ReturnInst>(handle);
        }

        public AllocaInst CreateAlloca(Type Ty, Value ArraySize = null, string Name = "") => CreateAlloca(Ty, ArraySize, Name.AsSpan());

        public AllocaInst CreateAlloca(Type Ty, Value ArraySize, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildArrayAlloca(Ty.Handle, ArraySize?.Handle ?? default, Name);
            return Context.GetOrCreate<AllocaInst>(handle);
        }

        public Value CreateAnd(Value LHS, Value RHS, string Name = "") => CreateAnd(LHS, RHS, Name.AsSpan());

        public Value CreateAnd(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildAnd(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateAShr(Value LHS, Value RHS, string Name = "") => CreateAShr(LHS, RHS, Name.AsSpan());

        public Value CreateAShr(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildAShr(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public AtomicRMWInst CreateAtomicRMW(AtomicRMWInst.BinOp Op, Value Ptr, Value Val, AtomicOrdering Ordering, SyncScopeID SSID = SyncScopeID.System)
        {
            var handle = Handle.BuildAtomicRMW((LLVMAtomicRMWBinOp)Op, Ptr.Handle, Val.Handle, (LLVMAtomicOrdering)Ordering, SSID == SyncScopeID.SingleThread);
            return Context.GetOrCreate<AtomicRMWInst>(handle);
        }

        public Value CreateBinOp(Instruction.BinaryOps Opc, Value LHS, Value RHS, string Name = "") => CreateBinOp(Opc, LHS, RHS, Name.AsSpan());

        public Value CreateBinOp(Instruction.BinaryOps Opc, Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildBinOp((LLVMOpcode)Opc, LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateBitCast(Value V, Type DestTy, string Name = "") => CreateBitCast(V, DestTy, Name.AsSpan());

        public Value CreateBitCast(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildBitCast(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public BranchInst CreateBr(BasicBlock Dest)
        {
            var handle = Handle.BuildBr(Dest.Handle);
            return Context.GetOrCreate<BranchInst>(handle);
        }

        public CallInst CreateCall(Value Callee, Value[] Args = null, string Name = "") => CreateCall(Callee, Args.AsSpan(), Name.AsSpan());

        public CallInst CreateCall(Value Callee, ReadOnlySpan<Value> Args, ReadOnlySpan<char> Name)
        {
            using var argHandles = new MarshaledArray<Value, LLVMValueRef>(Args, (value) => value.Handle);
            var handle = Handle.BuildCall(Callee.Handle, argHandles, Name);
            return Context.GetOrCreate<CallInst>(handle);
        }

        public Value CreateCast(Instruction.CastOps Op, Value V, Type DestTy, string Name = "") => CreateCast(Op, V, DestTy, Name.AsSpan());

        public Value CreateCast(Instruction.CastOps Op, Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildCast((LLVMOpcode)Op, V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public BranchInst CreateCondBr(Value Cond, BasicBlock True, BasicBlock False)
        {
            var handle = Handle.BuildCondBr(Cond.Handle, True.Handle, False.Handle);
            return Context.GetOrCreate<BranchInst>(handle);
        }

        public Value CreateExactSDiv(Value LHS, Value RHS, string Name = "") => CreateExactSDiv(LHS, RHS, Name.AsSpan());

        public Value CreateExactSDiv(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildExactSDiv(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateExtractElement(Value Vec, Value Idx, string Name = "") => CreateExtractElement(Vec, Idx, Name.AsSpan());

        public Value CreateExtractElement(Value Vec, Value Idx, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildExtractElement(Vec.Handle, Idx.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateExtractValue(Value Agg, uint Idx, string Name = "") => CreateExtractValue(Agg, Idx, Name.AsSpan());

        public Value CreateExtractValue(Value Agg, uint Idx, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildExtractValue(Agg.Handle, Idx, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFAdd(Value L, Value R, string Name = "") => CreateFAdd(L, R, Name.AsSpan());

        public Value CreateFAdd(Value L, Value R, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFAdd(L.Handle, R.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFCmp(CmpInst.Predicate P, Value LHS, Value RHS, string Name = "") => CreateFCmp(P, LHS, RHS, Name.AsSpan());

        public Value CreateFCmp(CmpInst.Predicate P, Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFCmp((LLVMRealPredicate)P, LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFDiv(Value L, Value R, string Name = "") => CreateFDiv(L, R, Name.AsSpan());

        public Value CreateFDiv(Value L, Value R, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFDiv(L.Handle, R.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public FenceInst CreateFence(AtomicOrdering Ordering, SyncScopeID SSID = SyncScopeID.System, string Name = "") => CreateFence(Ordering, SSID, Name.AsSpan());

        public FenceInst CreateFence(AtomicOrdering Ordering, SyncScopeID SSID, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFence((LLVMAtomicOrdering)Ordering, SSID == SyncScopeID.SingleThread, Name);
            return Context.GetOrCreate<FenceInst>(handle);
        }

        public Value CreateFMul(Value L, Value R, string Name = "") => CreateFMul(L, R, Name.AsSpan());

        public Value CreateFMul(Value L, Value R, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFMul(L.Handle, R.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFNeg(Value V, string Name = "") => CreateFNeg(V, Name.AsSpan());

        public Value CreateFNeg(Value V, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFNeg(V.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFPCast(Value V, Type DestTy, string Name = "") => CreateFPCast(V, DestTy, Name.AsSpan());

        public Value CreateFPCast(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFPCast(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFPExt(Value V, Type DestTy, string Name = "") => CreateFPExt(V, DestTy, Name.AsSpan());

        public Value CreateFPExt(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFPExt(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFPToSI(Value V, Type DestTy, string Name = "") => CreateFPToSI(V, DestTy, Name.AsSpan());

        public Value CreateFPToSI(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFPToSI(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFPToUI(Value V, Type DestTy, string Name = "") => CreateFPToUI(V, DestTy, Name.AsSpan());

        public Value CreateFPToUI(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFPToUI(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFPTrunc(Value V, Type DestTy, string Name = "") => CreateFPTrunc(V, DestTy, Name.AsSpan());

        public Value CreateFPTrunc(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFPTrunc(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFreeze(Value V, string Name = "") => CreateFreeze(V, Name.AsSpan());

        public Value CreateFreeze(Value V, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFreeze(V.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFRem(Value L, Value R, string Name = "") => CreateFRem(L, R, Name.AsSpan());

        public Value CreateFRem(Value L, Value R, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFRem(L.Handle, R.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateFSub(Value L, Value R, string Name = "") => CreateFSub(L, R, Name.AsSpan());

        public Value CreateFSub(Value L, Value R, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildFSub(L.Handle, R.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateGEP(Value Ptr, Value[] IdxList, string Name = "") => CreateGEP(Ptr, IdxList.AsSpan(), Name.AsSpan());

        public Value CreateGEP(Value Ptr, ReadOnlySpan<Value> IdxList, ReadOnlySpan<char> Name)
        {
            using var idxListHandles = new MarshaledArray<Value, LLVMValueRef>(IdxList, (value) => value.Handle);
            var handle = Handle.BuildGEP(Ptr.Handle, idxListHandles, Name);
            return Context.GetOrCreate(handle);
        }

        public Constant CreateGlobalStringPtr(string Str, string Name = "") => CreateGlobalStringPtr(Str.AsSpan(), Name.AsSpan());

        public Constant CreateGlobalStringPtr(ReadOnlySpan<char> Str, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildGlobalStringPtr(Str, Name);
            return Context.GetOrCreate<Constant>(handle);
        }

        public Value CreateICmp(CmpInst.Predicate P, Value LHS, Value RHS, string Name = "") => CreateICmp(P, LHS, RHS, Name.AsSpan());

        public Value CreateICmp(CmpInst.Predicate P, Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildICmp((LLVMIntPredicate)P, LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateInBoundsGEP(Value Ptr, Value[] IdxList, string Name = "") => CreateInBoundsGEP(Ptr, IdxList.AsSpan(), Name.AsSpan());

        public Value CreateInBoundsGEP(Value Ptr, ReadOnlySpan<Value> IdxList, ReadOnlySpan<char> Name)
        {
            using var idxListHandles = new MarshaledArray<Value, LLVMValueRef>(IdxList, (value) => value.Handle);
            var handle = Handle.BuildInBoundsGEP(Ptr.Handle, idxListHandles, Name);
            return Context.GetOrCreate(handle);
        }

        public IndirectBrInst CreateIndirectBr(Value Addr, uint NumDests = 10)
        {
            var handle = Handle.BuildIndirectBr(Addr.Handle, NumDests);
            return Context.GetOrCreate<IndirectBrInst>(handle);
        }

        public Value CreateInsertElement(Value Vec, Value NewElt, Value Idx, string Name = "") => CreateInsertElement(Vec, NewElt, Idx, Name.AsSpan());

        public Value CreateInsertElement(Value Vec, Value NewElt, Value Idx, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildInsertElement(Vec.Handle, NewElt.Handle, Idx.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateInsertValue(Value Agg, Value Val, uint Idx, string Name = "") => CreateInsertValue(Agg, Val, Idx, Name.AsSpan());

        public Value CreateInsertValue(Value Agg, Value Val, uint Idx, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildInsertValue(Agg.Handle, Val.Handle, Idx, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateIntCast(Value V, Type DestTy, string Name = "") => CreateIntCast(V, DestTy, Name.AsSpan());

        public Value CreateIntCast(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildIntCast(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateIntToPtr(Value V, Type DestTy, string Name = "") => CreateIntToPtr(V, DestTy, Name.AsSpan());

        public Value CreateIntToPtr(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildIntToPtr(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public InvokeInst CreateInvoke(Value Callee, BasicBlock NormalDest, BasicBlock UnwindDest, Value[] Args, string Name = "") => CreateInvoke(Callee, NormalDest, UnwindDest, Args.AsSpan(), Name.AsSpan());

        public InvokeInst CreateInvoke(Value Callee, BasicBlock NormalDest, BasicBlock UnwindDest, ReadOnlySpan<Value> Args, ReadOnlySpan<char> Name)
        {
            using var argHandles = new MarshaledArray<Value, LLVMValueRef>(Args, (value) => value.Handle);
            var handle = Handle.BuildInvoke(Callee.Handle, argHandles, NormalDest.Handle, UnwindDest.Handle, Name);
            return Context.GetOrCreate<InvokeInst>(handle);
        }

        public Value CreateIsNotNull(Value Arg, string Name = "") => CreateIsNotNull(Arg, Name.AsSpan());

        public Value CreateIsNotNull(Value Arg, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildIsNotNull(Arg.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateIsNull(Value Arg, string Name = "") => CreateIsNull(Arg, Name.AsSpan());

        public Value CreateIsNull(Value Arg, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildIsNull(Arg.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public LandingPadInst CreateLandingPad(Type Ty, uint NumClauses, string Name = "") => CreateLandingPad(Ty, NumClauses, Name.AsSpan());

        public LandingPadInst CreateLandingPad(Type Ty, uint NumClauses, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildLandingPad(Ty.Handle, default, NumClauses, Name);
            return Context.GetOrCreate<LandingPadInst>(handle);
        }

        public LoadInst CreateLoad(Value Ptr, string Name = "") => CreateLoad(Ptr, Name.AsSpan());

        public LoadInst CreateLoad(Value Ptr, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildLoad(Ptr.Handle, Name);
            return Context.GetOrCreate<LoadInst>(handle);
        }

        public Value CreateLShr(Value LHS, Value RHS, string Name = "") => CreateLShr(LHS, RHS, Name.AsSpan());

        public Value CreateLShr(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildLShr(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateMul(Value LHS, Value RHS, string Name = "") => CreateMul(LHS, RHS, Name.AsSpan());

        public Value CreateMul(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildMul(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateNeg(Value V, string Name = "") => CreateNeg(V, Name.AsSpan());

        public Value CreateNeg(Value V, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildNeg(V.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateNot(Value V, string Name = "") => CreateNot(V, Name.AsSpan());

        public Value CreateNot(Value V, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildNot(V.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateNSWAdd(Value LHS, Value RHS, string Name = "") => CreateNSWAdd(LHS, RHS, Name.AsSpan());

        public Value CreateNSWAdd(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildNSWAdd(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateNSWMul(Value LHS, Value RHS, string Name = "") => CreateNSWMul(LHS, RHS, Name.AsSpan());

        public Value CreateNSWMul(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildNSWMul(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateNSWNeg(Value V, string Name = "") => CreateNSWNeg(V, Name.AsSpan());

        public Value CreateNSWNeg(Value V, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildNSWNeg(V.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateNSWSub(Value LHS, Value RHS, string Name = "") => CreateNSWSub(LHS, RHS, Name.AsSpan());

        public Value CreateNSWSub(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildNSWSub(LHS.Handle, RHS.Handle, Name); ;
            return Context.GetOrCreate(handle);
        }

        public Value CreateNUWAdd(Value LHS, Value RHS, string Name = "") => CreateNUWAdd(LHS, RHS, Name.AsSpan());

        public Value CreateNUWAdd(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildNUWAdd(LHS.Handle, RHS.Handle, Name); ;
            return Context.GetOrCreate(handle);
        }

        public Value CreateNUWMul(Value LHS, Value RHS, string Name = "") => CreateNUWMul(LHS, RHS, Name.AsSpan());

        public Value CreateNUWMul(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildNUWMul(LHS.Handle, RHS.Handle, Name); ;
            return Context.GetOrCreate(handle);
        }

        public Value CreateNUWNeg(Value V, string Name = "") => CreateNUWNeg(V, Name.AsSpan());

        public Value CreateNUWNeg(Value V, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildNUWNeg(V.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateNUWSub(Value LHS, Value RHS, string Name = "") => CreateNUWSub(LHS, RHS, Name.AsSpan());

        public Value CreateNUWSub(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildNUWSub(LHS.Handle, RHS.Handle, Name); ;
            return Context.GetOrCreate(handle);
        }

        public Value CreateOr(Value LHS, Value RHS, string Name = "") => CreateOr(LHS, RHS, Name.AsSpan());

        public Value CreateOr(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildOr(LHS.Handle, RHS.Handle, Name); ;
            return Context.GetOrCreate(handle);
        }

        public PHINode CreatePHI(Type Ty, string Name = "") => CreatePHI(Ty, Name.AsSpan());

        public PHINode CreatePHI(Type Ty, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildPhi(Ty.Handle, Name);
            return Context.GetOrCreate<PHINode>(handle);
        }

        public Value CreatePointerCast(Value V, Type DestTy, string Name = "") => CreatePointerCast(V, DestTy, Name.AsSpan());

        public Value CreatePointerCast(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildPointerCast(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreatePtrDiff(Value LHS, Value RHS, string Name = "") => CreatePtrDiff(LHS, RHS, Name.AsSpan());

        public Value CreatePtrDiff(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildPtrDiff(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreatePtrToInt(Value V, Type DestTy, string Name = "") => CreatePtrToInt(V, DestTy, Name.AsSpan());

        public Value CreatePtrToInt(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildPtrToInt(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public ResumeInst CreateResume(Value Exn)
        {
            var handle = Handle.BuildResume(Exn.Handle);
            return Context.GetOrCreate<ResumeInst>(handle);
        }

        public ReturnInst CreateRet(Value V)
        {
            var handle = Handle.BuildRet(V.Handle);
            return Context.GetOrCreate<ReturnInst>(handle);
        }

        public ReturnInst CreateRetVoid()
        {
            var handle = Handle.BuildRetVoid();
            return Context.GetOrCreate<ReturnInst>(handle);
        }

        public Value CreateSDiv(Value LHS, Value RHS, string Name = "") => CreateSDiv(LHS, RHS, Name.AsSpan());

        public Value CreateSDiv(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildSDiv(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateSelect(Value C, Value True, Value False, string Name = "") => CreateSelect(C, True, False, Name.AsSpan());

        public Value CreateSelect(Value C, Value True, Value False, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildSelect(C.Handle, True.Handle, False.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateSExt(Value V, Type DestTy, string Name = "") => CreateSExt(V, DestTy, Name.AsSpan());

        public Value CreateSExt(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildSExt(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateSExtOrBitCast(Value V, Type DestTy, string Name = "") => CreateSExtOrBitCast(V, DestTy, Name.AsSpan());

        public Value CreateSExtOrBitCast(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildSExtOrBitCast(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateShl(Value LHS, Value RHS, string Name = "") => CreateShl(LHS, RHS, Name.AsSpan());

        public Value CreateShl(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildShl(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateShuffleVector(Value V1, Value V2, Value Mask, string Name = "") => CreateShuffleVector(V1, V2, Mask, Name.AsSpan());

        public Value CreateShuffleVector(Value V1, Value V2, Value Mask, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildShuffleVector(V1.Handle, V2.Handle, Mask.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateSIToFP(Value V, Type DestTy, string Name = "") => CreateSIToFP(V, DestTy, Name.AsSpan());

        public Value CreateSIToFP(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildSIToFP(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateSRem(Value LHS, Value RHS, string Name = "") => CreateSRem(LHS, RHS, Name.AsSpan());

        public Value CreateSRem(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildSRem(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public StoreInst CreateStore(Value V, Value Ptr)
        {
            var handle = Handle.BuildStore(V.Handle, Ptr.Handle);
            return Context.GetOrCreate<StoreInst>(handle);
        }

        public Value CreateStructGEP(Value Ptr, uint Idx, string Name = "") => CreateStructGEP(Ptr, Idx, Name.AsSpan());

        public Value CreateStructGEP(Value Ptr, uint Idx, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildStructGEP(Ptr.Handle, Idx, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateSub(Value LHS, Value RHS, string Name = "") => CreateSub(LHS, RHS, Name.AsSpan());

        public Value CreateSub(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildSub(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public SwitchInst CreateSwitch(Value V, BasicBlock Dest, uint NumCases = 10)
        {
            var handle = Handle.BuildSwitch(V.Handle, Dest.Handle, NumCases);
            return Context.GetOrCreate<SwitchInst>(handle);
        }

        public Value CreateTrunc(Value V, Type DestTy, string Name = "") => CreateTrunc(V, DestTy, Name.AsSpan());

        public Value CreateTrunc(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildTrunc(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateTruncOrBitCast(Value V, Type DestTy, string Name = "") => CreateTruncOrBitCast(V, DestTy, Name.AsSpan());

        public Value CreateTruncOrBitCast(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildTruncOrBitCast(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateUDiv(Value LHS, Value RHS, string Name = "") => CreateUDiv(LHS, RHS, Name.AsSpan());

        public Value CreateUDiv(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildUDiv(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateUIToFP(Value V, Type DestTy, string Name = "") => CreateUIToFP(V, DestTy, Name.AsSpan());

        public Value CreateUIToFP(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildUIToFP(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public UnreachableInst CreateUnreachable()
        {
            var handle = Handle.BuildUnreachable();
            return Context.GetOrCreate<UnreachableInst>(handle);
        }

        public Value CreateURem(Value LHS, Value RHS, string Name = "") => CreateURem(LHS, RHS, Name.AsSpan());

        public Value CreateURem(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildURem(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public VAArgInst CreateVAArg(Value List, Type Ty, string Name = "") => CreateVAArg(List, Ty, Name.AsSpan());

        public VAArgInst CreateVAArg(Value List, Type Ty, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildVAArg(List.Handle, Ty.Handle, Name);
            return Context.GetOrCreate<VAArgInst>(handle);
        }

        public Value CreateXor(Value LHS, Value RHS, string Name = "") => CreateXor(LHS, RHS, Name.AsSpan());

        public Value CreateXor(Value LHS, Value RHS, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildXor(LHS.Handle, RHS.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateZExt(Value V, Type DestTy, string Name = "") => CreateZExt(V, DestTy, Name.AsSpan());

        public Value CreateZExt(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildZExt(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Value CreateZExtOrBitCast(Value V, Type DestTy, string Name = "") => CreateZExtOrBitCast(V, DestTy, Name.AsSpan());

        public Value CreateZExtOrBitCast(Value V, Type DestTy, ReadOnlySpan<char> Name)
        {
            var handle = Handle.BuildZExtOrBitCast(V.Handle, DestTy.Handle, Name);
            return Context.GetOrCreate(handle);
        }

        public Instruction Insert(Instruction I, string Name = "") => Insert(I, Name.AsSpan());

        public Instruction Insert(Instruction I, ReadOnlySpan<char> Name)
        {
            Handle.InsertWithName(I.Handle, Name);
            return I;
        }
    }
}
