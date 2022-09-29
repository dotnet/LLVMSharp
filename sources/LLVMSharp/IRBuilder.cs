// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp;

public sealed class IRBuilder : IRBuilderBase
{
    public IRBuilder(LLVMContext c) : base(c)
    {
    }

    public Value CreateAdd(Value lhs, Value rhs, string name ="") => CreateAdd(lhs, rhs, name.AsSpan());

    public Value CreateAdd(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildAdd(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateAddrSpaceCast(Value v, Type destTy, string name = "") => CreateAddrSpaceCast(v, destTy, name.AsSpan());

    public Value CreateAddrSpaceCast(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildAddrSpaceCast(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public ReturnInst CreateAggregateRet(Value[] retVals) => CreateAggregateRet(retVals.AsSpan());

    public ReturnInst CreateAggregateRet(ReadOnlySpan<Value> retVals)
    {
        using var retValHandles = new MarshaledArray<Value, LLVMValueRef>(retVals, (value) => value.Handle);
        var handle = Handle.BuildAggregateRet(retValHandles.AsSpan());
        return Context.GetOrCreate<ReturnInst>(handle);
    }

    public AllocaInst CreateAlloca(Type ty, Value? arraySize = null, string name = "") => CreateAlloca(ty, arraySize, name.AsSpan());

    public AllocaInst CreateAlloca(Type ty, Value? arraySize, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildArrayAlloca(ty.Handle, arraySize?.Handle ?? default, name);
        return Context.GetOrCreate<AllocaInst>(handle);
    }

    public Value CreateAnd(Value lhs, Value rhs, string name = "") => CreateAnd(lhs, rhs, name.AsSpan());

    public Value CreateAnd(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildAnd(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateAShr(Value lhs, Value rhs, string name = "") => CreateAShr(lhs, rhs, name.AsSpan());

    public Value CreateAShr(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildAShr(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public AtomicRMWInst CreateAtomicRMW(AtomicRMWInst.BinOp op, Value ptr, Value val, AtomicOrdering ordering, SyncScopeID ssid = SyncScopeID.System)
    {
        var handle = Handle.BuildAtomicRMW((LLVMAtomicRMWBinOp)op, ptr.Handle, val.Handle, (LLVMAtomicOrdering)ordering, ssid == SyncScopeID.SingleThread);
        return Context.GetOrCreate<AtomicRMWInst>(handle);
    }

    public Value CreateBinOp(Instruction.BinaryOps opc, Value lhs, Value rhs, string name = "") => CreateBinOp(opc, lhs, rhs, name.AsSpan());

    public Value CreateBinOp(Instruction.BinaryOps opc, Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildBinOp((LLVMOpcode)opc, lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateBitCast(Value v, Type destTy, string name = "") => CreateBitCast(v, destTy, name.AsSpan());

    public Value CreateBitCast(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildBitCast(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public BranchInst CreateBr(BasicBlock dest)
    {
        var handle = Handle.BuildBr(dest.Handle);
        return Context.GetOrCreate<BranchInst>(handle);
    }

    public CallInst CreateCall(FunctionType fTy, Value callee, Value[]? args = null, string name = "") => CreateCall(fTy, callee, args.AsSpan(), name.AsSpan());

    public CallInst CreateCall(FunctionType fTy, Value callee, ReadOnlySpan<Value> args, ReadOnlySpan<char> name)
    {
        using var argHandles = new MarshaledArray<Value, LLVMValueRef>(args, (value) => value.Handle);
        var handle = Handle.BuildCall2(fTy.Handle, callee.Handle, argHandles.AsSpan(), name);
        return Context.GetOrCreate<CallInst>(handle);
    }

    public Value CreateCast(Instruction.CastOps op, Value v, Type destTy, string name = "") => CreateCast(op, v, destTy, name.AsSpan());

    public Value CreateCast(Instruction.CastOps op, Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildCast((LLVMOpcode)op, v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public BranchInst CreateCondBr(Value cond, BasicBlock @true, BasicBlock @false)
    {
        var handle = Handle.BuildCondBr(cond.Handle, @true.Handle, @false.Handle);
        return Context.GetOrCreate<BranchInst>(handle);
    }

    public Value CreateExactSDiv(Value lhs, Value rhs, string name = "") => CreateExactSDiv(lhs, rhs, name.AsSpan());

    public Value CreateExactSDiv(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildExactSDiv(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateExtractElement(Value vec, Value idx, string name = "") => CreateExtractElement(vec, idx, name.AsSpan());

    public Value CreateExtractElement(Value vec, Value idx, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildExtractElement(vec.Handle, idx.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateExtractValue(Value agg, uint idx, string name = "") => CreateExtractValue(agg, idx, name.AsSpan());

    public Value CreateExtractValue(Value agg, uint idx, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildExtractValue(agg.Handle, idx, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFAdd(Value l, Value r, string name = "") => CreateFAdd(l, r, name.AsSpan());

    public Value CreateFAdd(Value l, Value r, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFAdd(l.Handle, r.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFCmp(CmpInst.Predicate p, Value lhs, Value rhs, string name = "") => CreateFCmp(p, lhs, rhs, name.AsSpan());

    public Value CreateFCmp(CmpInst.Predicate p, Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFCmp((LLVMRealPredicate)p, lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFDiv(Value l, Value r, string name = "") => CreateFDiv(l, r, name.AsSpan());

    public Value CreateFDiv(Value l, Value r, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFDiv(l.Handle, r.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public FenceInst CreateFence(AtomicOrdering ordering, SyncScopeID ssid = SyncScopeID.System, string name = "") => CreateFence(ordering, ssid, name.AsSpan());

    public FenceInst CreateFence(AtomicOrdering ordering, SyncScopeID ssid, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFence((LLVMAtomicOrdering)ordering, ssid == SyncScopeID.SingleThread, name);
        return Context.GetOrCreate<FenceInst>(handle);
    }

    public Value CreateFMul(Value l, Value r, string name = "") => CreateFMul(l, r, name.AsSpan());

    public Value CreateFMul(Value l, Value r, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFMul(l.Handle, r.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFNeg(Value v, string name = "") => CreateFNeg(v, name.AsSpan());

    public Value CreateFNeg(Value v, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFNeg(v.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFPCast(Value v, Type destTy, string name = "") => CreateFPCast(v, destTy, name.AsSpan());

    public Value CreateFPCast(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFPCast(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFPExt(Value v, Type destTy, string name = "") => CreateFPExt(v, destTy, name.AsSpan());

    public Value CreateFPExt(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFPExt(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFPToSI(Value v, Type destTy, string name = "") => CreateFPToSI(v, destTy, name.AsSpan());

    public Value CreateFPToSI(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFPToSI(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFPToUI(Value v, Type destTy, string name = "") => CreateFPToUI(v, destTy, name.AsSpan());

    public Value CreateFPToUI(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFPToUI(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFPTrunc(Value v, Type destTy, string name = "") => CreateFPTrunc(v, destTy, name.AsSpan());

    public Value CreateFPTrunc(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFPTrunc(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFreeze(Value v, string name = "") => CreateFreeze(v, name.AsSpan());

    public Value CreateFreeze(Value v, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFreeze(v.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFRem(Value l, Value r, string name = "") => CreateFRem(l, r, name.AsSpan());

    public Value CreateFRem(Value l, Value r, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFRem(l.Handle, r.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateFSub(Value l, Value r, string name = "") => CreateFSub(l, r, name.AsSpan());

    public Value CreateFSub(Value l, Value r, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildFSub(l.Handle, r.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateGEP(Type ty, Value ptr, Value[] idxList, string name = "") => CreateGEP(ty, ptr, idxList.AsSpan(), name.AsSpan());

    public Value CreateGEP(Type ty, Value ptr, ReadOnlySpan<Value> idxList, ReadOnlySpan<char> name)
    {
        using var idxListHandles = new MarshaledArray<Value, LLVMValueRef>(idxList, (value) => value.Handle);
        var handle = Handle.BuildGEP2(ty.Handle, ptr.Handle, idxListHandles.AsSpan(), name);
        return Context.GetOrCreate(handle);
    }

    public Constant CreateGlobalStringPtr(string str, string name = "") => CreateGlobalStringPtr(str.AsSpan(), name.AsSpan());

    public Constant CreateGlobalStringPtr(ReadOnlySpan<char> str, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildGlobalStringPtr(str, name);
        return Context.GetOrCreate<Constant>(handle);
    }

    public Value CreateICmp(CmpInst.Predicate p, Value lhs, Value rhs, string name = "") => CreateICmp(p, lhs, rhs, name.AsSpan());

    public Value CreateICmp(CmpInst.Predicate p, Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildICmp((LLVMIntPredicate)p, lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateInBoundsGEP(Type ty, Value ptr, Value[] idxList, string name = "") => CreateInBoundsGEP(ty, ptr, idxList.AsSpan(), name.AsSpan());

    public Value CreateInBoundsGEP(Type ty, Value ptr, ReadOnlySpan<Value> idxList, ReadOnlySpan<char> name)
    {
        using var idxListHandles = new MarshaledArray<Value, LLVMValueRef>(idxList, (value) => value.Handle);
        var handle = Handle.BuildInBoundsGEP2(ty.Handle, ptr.Handle, idxListHandles.AsSpan(), name);
        return Context.GetOrCreate(handle);
    }

    public IndirectBrInst CreateIndirectBr(Value addr, uint numDests = 10)
    {
        var handle = Handle.BuildIndirectBr(addr.Handle, numDests);
        return Context.GetOrCreate<IndirectBrInst>(handle);
    }

    public Value CreateInsertElement(Value vec, Value newElt, Value idx, string name = "") => CreateInsertElement(vec, newElt, idx, name.AsSpan());

    public Value CreateInsertElement(Value vec, Value newElt, Value idx, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildInsertElement(vec.Handle, newElt.Handle, idx.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateInsertValue(Value agg, Value val, uint idx, string name = "") => CreateInsertValue(agg, val, idx, name.AsSpan());

    public Value CreateInsertValue(Value agg, Value val, uint idx, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildInsertValue(agg.Handle, val.Handle, idx, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateIntCast(Value v, Type destTy, string name = "") => CreateIntCast(v, destTy, name.AsSpan());

    public Value CreateIntCast(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildIntCast(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateIntToPtr(Value v, Type destTy, string name = "") => CreateIntToPtr(v, destTy, name.AsSpan());

    public Value CreateIntToPtr(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildIntToPtr(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public InvokeInst CreateInvoke(FunctionType ty, Value callee, BasicBlock normalDest, BasicBlock unwindDest, Value[] args, string name = "") => CreateInvoke(ty, callee, normalDest, unwindDest, args.AsSpan(), name.AsSpan());

    public InvokeInst CreateInvoke(FunctionType ty, Value callee, BasicBlock normalDest, BasicBlock unwindDest, ReadOnlySpan<Value> args, ReadOnlySpan<char> name)
    {
        using var argHandles = new MarshaledArray<Value, LLVMValueRef>(args, (value) => value.Handle);
        var handle = Handle.BuildInvoke2(ty.Handle, callee.Handle, argHandles.AsSpan(), normalDest.Handle, unwindDest.Handle, name);
        return Context.GetOrCreate<InvokeInst>(handle);
    }

    public Value CreateIsNotNull(Value arg, string name = "") => CreateIsNotNull(arg, name.AsSpan());

    public Value CreateIsNotNull(Value arg, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildIsNotNull(arg.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateIsNull(Value arg, string name = "") => CreateIsNull(arg, name.AsSpan());

    public Value CreateIsNull(Value arg, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildIsNull(arg.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public LandingPadInst CreateLandingPad(Type ty, uint numClauses, string name = "") => CreateLandingPad(ty, numClauses, name.AsSpan());

    public LandingPadInst CreateLandingPad(Type ty, uint numClauses, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildLandingPad(ty.Handle, default, numClauses, name);
        return Context.GetOrCreate<LandingPadInst>(handle);
    }

    public LoadInst CreateLoad(Type ty, Value ptr, string name = "") => CreateLoad(ty, ptr, name.AsSpan());

    public LoadInst CreateLoad(Type ty, Value ptr, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildLoad2(ty.Handle, ptr.Handle, name);
        return Context.GetOrCreate<LoadInst>(handle);
    }

    public Value CreateLShr(Value lhs, Value rhs, string name = "") => CreateLShr(lhs, rhs, name.AsSpan());

    public Value CreateLShr(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildLShr(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateMul(Value lhs, Value rhs, string name = "") => CreateMul(lhs, rhs, name.AsSpan());

    public Value CreateMul(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildMul(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateNeg(Value v, string name = "") => CreateNeg(v, name.AsSpan());

    public Value CreateNeg(Value v, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildNeg(v.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateNot(Value v, string name = "") => CreateNot(v, name.AsSpan());

    public Value CreateNot(Value v, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildNot(v.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateNSWAdd(Value lhs, Value rhs, string name = "") => CreateNSWAdd(lhs, rhs, name.AsSpan());

    public Value CreateNSWAdd(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildNSWAdd(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateNSWMul(Value lhs, Value rhs, string name = "") => CreateNSWMul(lhs, rhs, name.AsSpan());

    public Value CreateNSWMul(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildNSWMul(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateNSWNeg(Value v, string name = "") => CreateNSWNeg(v, name.AsSpan());

    public Value CreateNSWNeg(Value v, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildNSWNeg(v.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateNSWSub(Value lhs, Value rhs, string name = "") => CreateNSWSub(lhs, rhs, name.AsSpan());

    public Value CreateNSWSub(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildNSWSub(lhs.Handle, rhs.Handle, name); ;
        return Context.GetOrCreate(handle);
    }

    public Value CreateNUWAdd(Value lhs, Value rhs, string name = "") => CreateNUWAdd(lhs, rhs, name.AsSpan());

    public Value CreateNUWAdd(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildNUWAdd(lhs.Handle, rhs.Handle, name); ;
        return Context.GetOrCreate(handle);
    }

    public Value CreateNUWMul(Value lhs, Value rhs, string name = "") => CreateNUWMul(lhs, rhs, name.AsSpan());

    public Value CreateNUWMul(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildNUWMul(lhs.Handle, rhs.Handle, name); ;
        return Context.GetOrCreate(handle);
    }

    public Value CreateNUWNeg(Value v, string name = "") => CreateNUWNeg(v, name.AsSpan());

    public Value CreateNUWNeg(Value v, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildNUWNeg(v.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateNUWSub(Value lhs, Value rhs, string name = "") => CreateNUWSub(lhs, rhs, name.AsSpan());

    public Value CreateNUWSub(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildNUWSub(lhs.Handle, rhs.Handle, name); ;
        return Context.GetOrCreate(handle);
    }

    public Value CreateOr(Value lhs, Value rhs, string name = "") => CreateOr(lhs, rhs, name.AsSpan());

    public Value CreateOr(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildOr(lhs.Handle, rhs.Handle, name); ;
        return Context.GetOrCreate(handle);
    }

    public PHINode CreatePHI(Type ty, string name = "") => CreatePHI(ty, name.AsSpan());

    public PHINode CreatePHI(Type ty, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildPhi(ty.Handle, name);
        return Context.GetOrCreate<PHINode>(handle);
    }

    public Value CreatePointerCast(Value v, Type destTy, string name = "") => CreatePointerCast(v, destTy, name.AsSpan());

    public Value CreatePointerCast(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildPointerCast(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreatePtrDiff(Type elemTy, Value lhs, Value rhs, string name = "") => CreatePtrDiff(elemTy, lhs, rhs, name.AsSpan());

    public Value CreatePtrDiff(Type elemTy, Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildPtrDiff2(elemTy.Handle, lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreatePtrToInt(Value v, Type destTy, string name = "") => CreatePtrToInt(v, destTy, name.AsSpan());

    public Value CreatePtrToInt(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildPtrToInt(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public ResumeInst CreateResume(Value exn)
    {
        var handle = Handle.BuildResume(exn.Handle);
        return Context.GetOrCreate<ResumeInst>(handle);
    }

    public ReturnInst CreateRet(Value v)
    {
        var handle = Handle.BuildRet(v.Handle);
        return Context.GetOrCreate<ReturnInst>(handle);
    }

    public ReturnInst CreateRetVoid()
    {
        var handle = Handle.BuildRetVoid();
        return Context.GetOrCreate<ReturnInst>(handle);
    }

    public Value CreateSDiv(Value lhs, Value rhs, string name = "") => CreateSDiv(lhs, rhs, name.AsSpan());

    public Value CreateSDiv(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildSDiv(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateSelect(Value c, Value @true, Value @false, string name = "") => CreateSelect(c, @true, @false, name.AsSpan());

    public Value CreateSelect(Value c, Value @true, Value @false, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildSelect(c.Handle, @true.Handle, @false.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateSExt(Value v, Type destTy, string name = "") => CreateSExt(v, destTy, name.AsSpan());

    public Value CreateSExt(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildSExt(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateSExtOrBitCast(Value v, Type destTy, string name = "") => CreateSExtOrBitCast(v, destTy, name.AsSpan());

    public Value CreateSExtOrBitCast(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildSExtOrBitCast(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateShl(Value lhs, Value rhs, string name = "") => CreateShl(lhs, rhs, name.AsSpan());

    public Value CreateShl(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildShl(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateShuffleVector(Value v1, Value v2, Value mask, string name = "") => CreateShuffleVector(v1, v2, mask, name.AsSpan());

    public Value CreateShuffleVector(Value v1, Value v2, Value mask, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildShuffleVector(v1.Handle, v2.Handle, mask.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateSIToFP(Value v, Type destTy, string name = "") => CreateSIToFP(v, destTy, name.AsSpan());

    public Value CreateSIToFP(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildSIToFP(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateSRem(Value lhs, Value rhs, string name = "") => CreateSRem(lhs, rhs, name.AsSpan());

    public Value CreateSRem(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildSRem(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public StoreInst CreateStore(Value v, Value ptr)
    {
        var handle = Handle.BuildStore(v.Handle, ptr.Handle);
        return Context.GetOrCreate<StoreInst>(handle);
    }

    public Value CreateStructGEP(Type ty, Value ptr, uint idx, string name = "") => CreateStructGEP(ty, ptr, idx, name.AsSpan());

    public Value CreateStructGEP(Type ty, Value ptr, uint idx, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildStructGEP2(ty.Handle, ptr.Handle, idx, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateSub(Value lhs, Value rhs, string name = "") => CreateSub(lhs, rhs, name.AsSpan());

    public Value CreateSub(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildSub(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public SwitchInst CreateSwitch(Value v, BasicBlock dest, uint numCases = 10)
    {
        var handle = Handle.BuildSwitch(v.Handle, dest.Handle, numCases);
        return Context.GetOrCreate<SwitchInst>(handle);
    }

    public Value CreateTrunc(Value v, Type destTy, string name = "") => CreateTrunc(v, destTy, name.AsSpan());

    public Value CreateTrunc(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildTrunc(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateTruncOrBitCast(Value v, Type destTy, string name = "") => CreateTruncOrBitCast(v, destTy, name.AsSpan());

    public Value CreateTruncOrBitCast(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildTruncOrBitCast(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateUDiv(Value lhs, Value rhs, string name = "") => CreateUDiv(lhs, rhs, name.AsSpan());

    public Value CreateUDiv(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildUDiv(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateUIToFP(Value v, Type destTy, string name = "") => CreateUIToFP(v, destTy, name.AsSpan());

    public Value CreateUIToFP(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildUIToFP(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public UnreachableInst CreateUnreachable()
    {
        var handle = Handle.BuildUnreachable();
        return Context.GetOrCreate<UnreachableInst>(handle);
    }

    public Value CreateURem(Value lhs, Value rhs, string name = "") => CreateURem(lhs, rhs, name.AsSpan());

    public Value CreateURem(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildURem(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public VAArgInst CreateVAArg(Value list, Type ty, string name = "") => CreateVAArg(list, ty, name.AsSpan());

    public VAArgInst CreateVAArg(Value list, Type ty, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildVAArg(list.Handle, ty.Handle, name);
        return Context.GetOrCreate<VAArgInst>(handle);
    }

    public Value CreateXor(Value lhs, Value rhs, string name = "") => CreateXor(lhs, rhs, name.AsSpan());

    public Value CreateXor(Value lhs, Value rhs, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildXor(lhs.Handle, rhs.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateZExt(Value v, Type destTy, string name = "") => CreateZExt(v, destTy, name.AsSpan());

    public Value CreateZExt(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildZExt(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Value CreateZExtOrBitCast(Value v, Type destTy, string name = "") => CreateZExtOrBitCast(v, destTy, name.AsSpan());

    public Value CreateZExtOrBitCast(Value v, Type destTy, ReadOnlySpan<char> name)
    {
        var handle = Handle.BuildZExtOrBitCast(v.Handle, destTy.Handle, name);
        return Context.GetOrCreate(handle);
    }

    public Instruction Insert(Instruction i, string name = "") => Insert(i, name.AsSpan());

    public Instruction Insert(Instruction i, ReadOnlySpan<char> name)
    {
        Handle.InsertWithName(i.Handle, name);
        return i;
    }
}
