// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;
using NUnit.Framework;

namespace LLVMSharp.UnitTests;

public class ManagedApi
{
    [Test]
    public void TypePredicates()
    {
        var context = new LLVMContext();

        var int32 = Type.GetInt32Ty(context);
        Assert.That(int32, Is.InstanceOf<IntegerType>());
        Assert.That(int32.IsIntegerTy, Is.True);
        Assert.That(int32.IsSized, Is.True);
        Assert.That(int32.IsFloatingPointTy, Is.False);
        Assert.That(int32.Kind, Is.EqualTo(LLVMTypeKind.LLVMIntegerTypeKind));
        Assert.That(int32.ScalarType, Is.SameAs(int32));
        Assert.That(int32.Context, Is.EqualTo(context));
        Assert.That(((IntegerType)int32).BitWidth, Is.EqualTo(32u));

        var flt = Type.GetFloatTy(context);
        Assert.That(flt.IsFloatingPointTy, Is.True);
        Assert.That(flt.IsFloatTy, Is.True);
        Assert.That(flt.IsIntegerTy, Is.False);
    }

    [Test]
    public void SequentialAndPointerTypes()
    {
        var context = new LLVMContext();
        var int32 = Type.GetInt32Ty(context);

        var vector = (VectorType)context.GetOrCreate(LLVMTypeRef.CreateVector(int32.Handle, 4));
        Assert.That(vector.IsVectorTy, Is.True);
        Assert.That(vector.NumElements, Is.EqualTo(4u));
        Assert.That(vector.ElementType, Is.EqualTo(int32));
        Assert.That(vector.ScalarType, Is.EqualTo(int32));

        var array = (ArrayType)context.GetOrCreate(LLVMTypeRef.CreateArray(int32.Handle, 8));
        Assert.That(array.IsArrayTy, Is.True);
        Assert.That(array.NumElements, Is.EqualTo(8ul));
        Assert.That(array.ElementType, Is.EqualTo(int32));

        var pointer = (PointerType)context.GetOrCreate(LLVMTypeRef.CreatePointer(int32.Handle, 1));
        Assert.That(pointer.IsPointerTy, Is.True);
        Assert.That(pointer.AddressSpace, Is.EqualTo(1u));
    }

    [Test]
    public void FunctionTypeAccessors()
    {
        var context = new LLVMContext();
        var int32 = Type.GetInt32Ty(context);
        var flt = Type.GetFloatTy(context);

        var handle = LLVMTypeRef.CreateFunction(int32.Handle, [int32.Handle, flt.Handle], IsVarArg: false);
        var functionType = (FunctionType)context.GetOrCreate(handle);

        Assert.That(functionType.IsFunctionTy, Is.True);
        Assert.That(functionType.ReturnType, Is.EqualTo(int32));
        Assert.That(functionType.NumParams, Is.EqualTo(2u));
        Assert.That(functionType.IsVarArg, Is.False);

        var parameters = functionType.GetParams();
        Assert.That(parameters.Length, Is.EqualTo(2));
        Assert.That(parameters[0], Is.EqualTo(int32));
        Assert.That(parameters[1], Is.EqualTo(flt));
    }

    [Test]
    public void StructTypeAccessors()
    {
        var context = new LLVMContext();
        var int32 = Type.GetInt32Ty(context);
        var flt = Type.GetFloatTy(context);

        var structType = StructType.Create(context, "MyStruct");
        Assert.That(structType.Name, Is.EqualTo("MyStruct"));
        Assert.That(structType.IsOpaque, Is.True);

        structType.SetBody([int32, flt], packed: true);
        Assert.That(structType.IsOpaque, Is.False);
        Assert.That(structType.IsPacked, Is.True);
        Assert.That(structType.NumElements, Is.EqualTo(2u));
        Assert.That(structType.GetElementType(0), Is.EqualTo(int32));
        Assert.That(structType.GetElementType(1), Is.EqualTo(flt));

        var elementTypes = structType.GetElementTypes();
        Assert.That(elementTypes.Length, Is.EqualTo(2));
        Assert.That(elementTypes[0], Is.EqualTo(int32));
    }

    [Test]
    public void ConstantIntAccessors()
    {
        var context = new LLVMContext();
        var int32 = Type.GetInt32Ty(context);

        // i32 with bit pattern 0xFFFFFFFB: zero-extends to 4294967291, sign-extends to -5.
        var constant = (ConstantInt)context.GetOrCreate(LLVMValueRef.CreateConstInt(int32.Handle, 4294967291UL));
        Assert.That(constant.ZExtValue, Is.EqualTo(4294967291UL));
        Assert.That(constant.SExtValue, Is.EqualTo(-5L));
        Assert.That(constant.Type, Is.EqualTo(int32));
        Assert.That(constant.Kind, Is.EqualTo(LLVMValueKind.LLVMConstantIntValueKind));
    }

    [Test]
    public void ConstantFPAccessors()
    {
        var context = new LLVMContext();
        var doubleTy = Type.GetDoubleTy(context);

        var constant = (ConstantFP)context.GetOrCreate(LLVMValueRef.CreateConstReal(doubleTy.Handle, 1.5));
        Assert.That(constant.ValueAsDouble, Is.EqualTo(1.5));

        var value = constant.GetDouble(out var losesInfo);
        Assert.That(value, Is.EqualTo(1.5));
        Assert.That(losesInfo, Is.False);
    }

    [Test]
    public void ConstantAggregateAndNull()
    {
        var context = new LLVMContext();
        var int32 = Type.GetInt32Ty(context);

        var nullValue = (Constant)context.GetOrCreate(LLVMValueRef.CreateConstNull(int32.Handle));
        Assert.That(nullValue.IsNullValue, Is.True);

        var elements = new[]
        {
            LLVMValueRef.CreateConstInt(int32.Handle, 10),
            LLVMValueRef.CreateConstInt(int32.Handle, 20),
        };

        var array = (Constant)context.GetOrCreate(LLVMValueRef.CreateConstArray(int32.Handle, elements));
        var element0 = array.GetAggregateElement(0);
        var element1 = array.GetAggregateElement(1);

        Assert.That(element0, Is.InstanceOf<ConstantInt>());
        Assert.That(((ConstantInt)element0!).ZExtValue, Is.EqualTo(10UL));
        Assert.That(((ConstantInt)element1!).ZExtValue, Is.EqualTo(20UL));
    }

    [Test]
    public void GlobalVariableAndUserOperands()
    {
        var context = new LLVMContext();
        var module = context.Handle.CreateModuleWithName("m");
        var int32 = Type.GetInt32Ty(context);

        var global = (GlobalVariable)context.GetOrCreate(module.AddGlobal(int32.Handle, "g"));
        Assert.That(global.ValueType, Is.EqualTo(int32));

        global.Initializer = (Constant)context.GetOrCreate(LLVMValueRef.CreateConstInt(int32.Handle, 42));
        global.IsConstant = true;
        global.Linkage = LLVMLinkage.LLVMInternalLinkage;
        global.Section = ".mysection";

        Assert.That(global.IsConstant, Is.True);
        Assert.That(global.Linkage, Is.EqualTo(LLVMLinkage.LLVMInternalLinkage));
        Assert.That(global.Section, Is.EqualTo(".mysection"));

        Assert.That(global.NumOperands, Is.EqualTo(1u));
        Assert.That(((ConstantInt)global.GetOperand(0)).ZExtValue, Is.EqualTo(42UL));
        Assert.That(global.Initializer, Is.Not.Null);
        Assert.That(((ConstantInt)global.Initializer!).ZExtValue, Is.EqualTo(42UL));
    }

    [Test]
    public void FunctionAccessors()
    {
        var context = new LLVMContext();
        var module = context.Handle.CreateModuleWithName("m");
        var int32 = Type.GetInt32Ty(context);

        var functionType = LLVMTypeRef.CreateFunction(int32.Handle, [int32.Handle, int32.Handle], IsVarArg: false);
        var function = (Function)context.GetOrCreate(module.AddFunction("f", functionType));

        Assert.That(function.IsDeclaration, Is.True);
        Assert.That(function.NumParams, Is.EqualTo(2u));
        Assert.That(function.ReturnType, Is.EqualTo(int32));
        Assert.That(function.FunctionType.NumParams, Is.EqualTo(2u));
        Assert.That(function.IntrinsicID, Is.EqualTo(0u));

        var parameter = function.GetParam(0);
        Assert.That(parameter, Is.InstanceOf<Argument>());
        Assert.That(parameter.Type, Is.EqualTo(int32));
        Assert.That(function.GetParams().Length, Is.EqualTo(2));

        function.CallingConvention = LLVMCallConv.LLVMColdCallConv;
        Assert.That(function.CallingConvention, Is.EqualTo(LLVMCallConv.LLVMColdCallConv));

        var entry = function.AppendBasicBlock("entry");
        Assert.That(function.BasicBlocksCount, Is.EqualTo(1u));
        Assert.That(function.EntryBasicBlock, Is.EqualTo(entry));
        Assert.That(function.IsDeclaration, Is.False);
        Assert.That(function.GetBasicBlocks().Length, Is.EqualTo(1));
    }

    [Test]
    public void InstructionCoreAccessors()
    {
        var context = new LLVMContext();
        var module = context.Handle.CreateModuleWithName("m");
        var int32 = Type.GetInt32Ty(context);

        var functionType = LLVMTypeRef.CreateFunction(int32.Handle, [int32.Handle, int32.Handle], IsVarArg: false);
        var function = (Function)context.GetOrCreate(module.AddFunction("f", functionType));
        var entry = function.AppendBasicBlock("entry");

        using var builder = LLVMBuilderRef.Create(context.Handle);
        builder.PositionAtEnd(entry.Handle);

        var addHandle = builder.BuildAdd(function.GetParam(0).Handle, function.GetParam(1).Handle, "sum");
        var retHandle = builder.BuildRet(addHandle);

        var add = (Instruction)context.GetOrCreate(addHandle);
        Assert.That(add.Opcode, Is.EqualTo(LLVMOpcode.LLVMAdd));
        Assert.That(add.IsTerminator, Is.False);
        Assert.That(add.Parent, Is.EqualTo(entry));

        var ret = (ReturnInst)context.GetOrCreate(retHandle);
        Assert.That(ret.IsTerminator, Is.True);
        Assert.That(ret.Opcode, Is.EqualTo(LLVMOpcode.LLVMRet));
        Assert.That(ret.ReturnValue, Is.EqualTo(add));
    }

    [Test]
    public void MemoryInstructionAccessors()
    {
        var context = new LLVMContext();
        var module = context.Handle.CreateModuleWithName("m");
        var int32 = Type.GetInt32Ty(context);

        var functionType = LLVMTypeRef.CreateFunction(Type.GetVoidTy(context).Handle, [], IsVarArg: false);
        var function = (Function)context.GetOrCreate(module.AddFunction("f", functionType));
        var entry = function.AppendBasicBlock("entry");

        using var builder = LLVMBuilderRef.Create(context.Handle);
        builder.PositionAtEnd(entry.Handle);

        var alloca = (AllocaInst)context.GetOrCreate(builder.BuildAlloca(int32.Handle, "slot"));
        alloca.Alignment = 8;
        Assert.That(alloca.AllocatedType, Is.EqualTo(int32));
        Assert.That(alloca.Alignment, Is.EqualTo(8u));

        var store = (StoreInst)context.GetOrCreate(builder.BuildStore(LLVMValueRef.CreateConstInt(int32.Handle, 7), alloca.Handle));
        store.Alignment = 4;
        store.Volatile = true;
        store.Ordering = AtomicOrdering.Monotonic;
        Assert.That(store.Alignment, Is.EqualTo(4u));
        Assert.That(store.Volatile, Is.True);
        Assert.That(store.Ordering, Is.EqualTo(AtomicOrdering.Monotonic));

        var load = (LoadInst)context.GetOrCreate(builder.BuildLoad2(int32.Handle, alloca.Handle, "v"));
        load.Volatile = true;
        load.Ordering = AtomicOrdering.Acquire;
        Assert.That(load.Volatile, Is.True);
        Assert.That(load.Ordering, Is.EqualTo(AtomicOrdering.Acquire));
    }

    [Test]
    public void ComparisonInstructionAccessors()
    {
        var context = new LLVMContext();
        var module = context.Handle.CreateModuleWithName("m");
        var int32 = Type.GetInt32Ty(context);
        var flt = Type.GetFloatTy(context);

        var functionType = LLVMTypeRef.CreateFunction(Type.GetVoidTy(context).Handle, [int32.Handle, int32.Handle, flt.Handle, flt.Handle], IsVarArg: false);
        var function = (Function)context.GetOrCreate(module.AddFunction("f", functionType));
        var entry = function.AppendBasicBlock("entry");

        using var builder = LLVMBuilderRef.Create(context.Handle);
        builder.PositionAtEnd(entry.Handle);

        var icmpHandle = builder.BuildICmp(LLVMIntPredicate.LLVMIntSLT, function.GetParam(0).Handle, function.GetParam(1).Handle, "c");
        var icmp = (ICmpInst)context.GetOrCreate(icmpHandle);
        Assert.That(icmp.GetPredicate(), Is.EqualTo(CmpInst.Predicate.ICMP_SLT));

        var fcmpHandle = builder.BuildFCmp(LLVMRealPredicate.LLVMRealOEQ, function.GetParam(2).Handle, function.GetParam(3).Handle, "f");
        var fcmp = (FCmpInst)context.GetOrCreate(fcmpHandle);
        Assert.That(fcmp.GetPredicate(), Is.EqualTo(CmpInst.Predicate.FCMP_OEQ));
    }

    [Test]
    public void BranchAndSwitchAccessors()
    {
        var context = new LLVMContext();
        var module = context.Handle.CreateModuleWithName("m");
        var int32 = Type.GetInt32Ty(context);

        var functionType = LLVMTypeRef.CreateFunction(Type.GetVoidTy(context).Handle, [], IsVarArg: false);
        var function = (Function)context.GetOrCreate(module.AddFunction("f", functionType));
        var entry = function.AppendBasicBlock("entry");
        var ifTrue = function.AppendBasicBlock("true");
        var ifFalse = function.AppendBasicBlock("false");

        using var builder = LLVMBuilderRef.Create(context.Handle);
        builder.PositionAtEnd(entry.Handle);

        var cond = builder.BuildICmp(LLVMIntPredicate.LLVMIntSLT, LLVMValueRef.CreateConstInt(int32.Handle, 1), LLVMValueRef.CreateConstInt(int32.Handle, 2), "c");
        var branch = (BranchInst)context.GetOrCreate(builder.BuildCondBr(cond, ifTrue.Handle, ifFalse.Handle));
        Assert.That(branch.IsConditional, Is.True);
        Assert.That(branch.Condition, Is.EqualTo(context.GetOrCreate(cond)));
        Assert.That(branch.SuccessorsCount, Is.EqualTo(2u));
        Assert.That(branch.GetSuccessor(0), Is.EqualTo(ifTrue));

        builder.PositionAtEnd(ifTrue.Handle);
        var switchInst = (SwitchInst)context.GetOrCreate(builder.BuildSwitch(LLVMValueRef.CreateConstInt(int32.Handle, 0), ifFalse.Handle, 1));
        switchInst.AddCase((ConstantInt)context.GetOrCreate(LLVMValueRef.CreateConstInt(int32.Handle, 1)), entry);
        Assert.That(switchInst.DefaultDest, Is.EqualTo(ifFalse));
        Assert.That(((ConstantInt)switchInst.Condition).ZExtValue, Is.EqualTo(0UL));
    }

    [Test]
    public void PhiAndSelectAccessors()
    {
        var context = new LLVMContext();
        var module = context.Handle.CreateModuleWithName("m");
        var int32 = Type.GetInt32Ty(context);
        var int1 = Type.GetInt1Ty(context);

        var functionType = LLVMTypeRef.CreateFunction(Type.GetVoidTy(context).Handle, [int1.Handle, int32.Handle, int32.Handle], IsVarArg: false);
        var function = (Function)context.GetOrCreate(module.AddFunction("f", functionType));
        var entry = function.AppendBasicBlock("entry");
        var other = function.AppendBasicBlock("other");

        using var builder = LLVMBuilderRef.Create(context.Handle);
        builder.PositionAtEnd(entry.Handle);

        var phi = (PHINode)context.GetOrCreate(builder.BuildPhi(int32.Handle, "p"));
        phi.AddIncoming((Value)context.GetOrCreate(LLVMValueRef.CreateConstInt(int32.Handle, 10)), entry);
        phi.AddIncoming((Value)context.GetOrCreate(LLVMValueRef.CreateConstInt(int32.Handle, 20)), other);
        Assert.That(phi.IncomingCount, Is.EqualTo(2u));
        Assert.That(phi.GetIncomingBlock(0), Is.EqualTo(entry));
        Assert.That(((ConstantInt)phi.GetIncomingValue(1)).ZExtValue, Is.EqualTo(20UL));

        var condVal = function.GetParam(0);
        var trueVal = function.GetParam(1);
        var falseVal = function.GetParam(2);
        var select = (SelectInst)context.GetOrCreate(builder.BuildSelect(condVal.Handle, trueVal.Handle, falseVal.Handle, "s"));
        Assert.That(select.Condition, Is.EqualTo(condVal));
        Assert.That(select.TrueValue, Is.EqualTo(trueVal));
        Assert.That(select.FalseValue, Is.EqualTo(falseVal));
    }

    [Test]
    public void CallInstructionAccessors()
    {
        var context = new LLVMContext();
        var module = context.Handle.CreateModuleWithName("m");
        var int32 = Type.GetInt32Ty(context);

        var functionType = LLVMTypeRef.CreateFunction(int32.Handle, [int32.Handle, int32.Handle], IsVarArg: false);
        var callee = (Function)context.GetOrCreate(module.AddFunction("callee", functionType));
        var caller = (Function)context.GetOrCreate(module.AddFunction("caller", functionType));
        var entry = caller.AppendBasicBlock("entry");

        using var builder = LLVMBuilderRef.Create(context.Handle);
        builder.PositionAtEnd(entry.Handle);

        var callHandle = builder.BuildCall2(functionType, callee.Handle, new[] { caller.GetParam(0).Handle, caller.GetParam(1).Handle }, "r");
        var call = (CallInst)context.GetOrCreate(callHandle);
        call.IsTailCall = true;

        Assert.That(call.ArgOperandsCount, Is.EqualTo(2u));
        Assert.That(call.CalledOperand, Is.EqualTo(callee));
        Assert.That(call.CalledFunctionType.NumParams, Is.EqualTo(2u));
        Assert.That(call.GetArgOperand(0), Is.EqualTo(caller.GetParam(0)));
        Assert.That(call.IsTailCall, Is.True);
    }

    [Test]
    public void GepAndAtomicAccessors()
    {
        var context = new LLVMContext();
        var module = context.Handle.CreateModuleWithName("m");
        var int32 = Type.GetInt32Ty(context);

        var functionType = LLVMTypeRef.CreateFunction(Type.GetVoidTy(context).Handle, [], IsVarArg: false);
        var function = (Function)context.GetOrCreate(module.AddFunction("f", functionType));
        var entry = function.AppendBasicBlock("entry");

        using var builder = LLVMBuilderRef.Create(context.Handle);
        builder.PositionAtEnd(entry.Handle);

        var arrayType = LLVMTypeRef.CreateArray(int32.Handle, 4);
        var storage = builder.BuildAlloca(arrayType, "arr");
        var gep = (GetElementPtrInst)context.GetOrCreate(builder.BuildGEP2(arrayType, storage, new[] { LLVMValueRef.CreateConstInt(int32.Handle, 0), LLVMValueRef.CreateConstInt(int32.Handle, 1) }, "elem"));
        Assert.That(gep.SourceElementType, Is.EqualTo(context.GetOrCreate(arrayType)));

        var slot = builder.BuildAlloca(int32.Handle, "slot");
        var atomic = (AtomicRMWInst)context.GetOrCreate(builder.BuildAtomicRMW(LLVMAtomicRMWBinOp.LLVMAtomicRMWBinOpAdd, slot, LLVMValueRef.CreateConstInt(int32.Handle, 1), LLVMAtomicOrdering.LLVMAtomicOrderingMonotonic, singleThread: false));
        Assert.That(atomic.Operation, Is.EqualTo(AtomicRMWInst.BinOp.Add));
        Assert.That(atomic.Ordering, Is.EqualTo(AtomicOrdering.Monotonic));

        var fence = (FenceInst)context.GetOrCreate(builder.BuildFence(LLVMAtomicOrdering.LLVMAtomicOrderingAcquire, singleThread: false, "fence"));
        Assert.That(fence.Ordering, Is.EqualTo(AtomicOrdering.Acquire));
    }

    [Test]
    public void ModuleAccessors()
    {
        var context = new LLVMContext();
        var module = Module.Create(context, "m");
        var int32 = Type.GetInt32Ty(context);

        Assert.That(module.ModuleIdentifier, Is.EqualTo("m"));
        Assert.That(module.Context, Is.EqualTo(context));

        module.SourceFileName = "source.ll";
        module.TargetTriple = "x86_64-pc-windows-msvc";
        module.DataLayoutString = "e-m:w-p:64:64";
        module.InlineAsm = "nop";

        Assert.That(module.SourceFileName, Is.EqualTo("source.ll"));
        Assert.That(module.TargetTriple, Is.EqualTo("x86_64-pc-windows-msvc"));
        Assert.That(module.DataLayoutString, Is.EqualTo("e-m:w-p:64:64"));
        Assert.That(module.InlineAsm, Does.Contain("nop"));

        var functionType = LLVMTypeRef.CreateFunction(int32.Handle, [int32.Handle], IsVarArg: false);
        var function = module.AddFunction("f", (FunctionType)context.GetOrCreate(functionType));
        var global = module.AddGlobal(int32, "g");

        Assert.That(module.GetFunction("f"), Is.EqualTo(function));
        Assert.That(module.GetFunction("missing"), Is.Null);
        Assert.That(module.GetGlobalVariable("g"), Is.EqualTo(global));
        Assert.That(module.GetOrInsertFunction("f", (FunctionType)context.GetOrCreate(functionType)), Is.EqualTo(function));
        Assert.That(module.GetFunctions().Length, Is.EqualTo(1));
        Assert.That(module.GetGlobalVariables().Length, Is.EqualTo(1));

        var structType = StructType.Create(context, "S");
        structType.SetBody([int32], packed: false);
        _ = module.AddGlobal(structType, "s");
        Assert.That(module.GetTypeByName("S"), Is.EqualTo(structType));

        Assert.That(module.TryVerify(LLVMVerifierFailureAction.LLVMReturnStatusAction, out _), Is.True);

        var clone = module.Clone();
        Assert.That(clone.GetFunction("f"), Is.Not.Null);
    }

    [Test]
    public void BasicBlockAccessors()
    {
        var context = new LLVMContext();
        var module = Module.Create(context, "m");
        var int32 = Type.GetInt32Ty(context);

        var functionType = LLVMTypeRef.CreateFunction(int32.Handle, [int32.Handle], IsVarArg: false);
        var function = module.AddFunction("f", (FunctionType)context.GetOrCreate(functionType));
        var entry = function.AppendBasicBlock("entry");
        var next = function.AppendBasicBlock("next");

        using var builder = LLVMBuilderRef.Create(context.Handle);
        builder.PositionAtEnd(entry.Handle);

        var addHandle = builder.BuildAdd(function.GetParam(0).Handle, function.GetParam(0).Handle, "sum");
        var retHandle = builder.BuildRet(addHandle);

        Assert.That(entry.Parent, Is.EqualTo(function));
        Assert.That(entry.Terminator, Is.EqualTo(context.GetOrCreate(retHandle)));
        Assert.That(entry.FirstInstruction, Is.EqualTo(context.GetOrCreate(addHandle)));
        Assert.That(entry.LastInstruction, Is.EqualTo(context.GetOrCreate(retHandle)));
        Assert.That(entry.GetInstructions().Length, Is.EqualTo(2));
        Assert.That(entry.Next, Is.EqualTo(next));
        Assert.That(next.Previous, Is.EqualTo(entry));
        Assert.That(next.Terminator, Is.Null);
    }

    [Test]
    public void InstructionFlagAccessors()
    {
        var context = new LLVMContext();
        var module = Module.Create(context, "m");
        var int32 = Type.GetInt32Ty(context);
        var int64 = Type.GetInt64Ty(context);
        var flt = Type.GetFloatTy(context);

        var functionType = LLVMTypeRef.CreateFunction(Type.GetVoidTy(context).Handle, [int32.Handle, int32.Handle, flt.Handle, flt.Handle], IsVarArg: false);
        var function = module.AddFunction("f", (FunctionType)context.GetOrCreate(functionType));
        var entry = function.AppendBasicBlock("entry");

        using var builder = LLVMBuilderRef.Create(context.Handle);
        builder.PositionAtEnd(entry.Handle);

        var lhs = function.GetParam(0).Handle;
        var rhs = function.GetParam(1).Handle;

        var add = (BinaryOperator)context.GetOrCreate(builder.BuildAdd(lhs, rhs, "add"));
        add.HasNoSignedWrap = true;
        add.HasNoUnsignedWrap = true;
        Assert.That(add.HasNoSignedWrap, Is.True);
        Assert.That(add.HasNoUnsignedWrap, Is.True);

        var div = (BinaryOperator)context.GetOrCreate(builder.BuildUDiv(lhs, rhs, "div"));
        div.IsExact = true;
        Assert.That(div.IsExact, Is.True);

        var disjoint = (BinaryOperator)context.GetOrCreate(builder.BuildOr(lhs, rhs, "or"));
        disjoint.IsDisjoint = true;
        Assert.That(disjoint.IsDisjoint, Is.True);

        var zext = (ZExtInst)context.GetOrCreate(builder.BuildZExt(lhs, int64.Handle, "zext"));
        zext.IsNonNeg = true;
        Assert.That(zext.IsNonNeg, Is.True);

        var icmp = (ICmpInst)context.GetOrCreate(builder.BuildICmp(LLVMIntPredicate.LLVMIntSLT, lhs, rhs, "cmp"));
        icmp.HasSameSign = true;
        Assert.That(icmp.HasSameSign, Is.True);

        var fadd = (Instruction)context.GetOrCreate(builder.BuildFAdd(function.GetParam(2).Handle, function.GetParam(3).Handle, "fadd"));
        fadd.FastMathFlags = LLVMFastMathFlags.LLVMFastMathAll;
        Assert.That(fadd.FastMathFlags, Is.EqualTo(LLVMFastMathFlags.LLVMFastMathAll));

        var arrayType = LLVMTypeRef.CreateArray(int32.Handle, 4);
        var storage = builder.BuildAlloca(arrayType, "arr");
        var gep = (GetElementPtrInst)context.GetOrCreate(builder.BuildGEP2(arrayType, storage, new[] { LLVMValueRef.CreateConstInt(int32.Handle, 0), LLVMValueRef.CreateConstInt(int32.Handle, 1) }, "elem"));
        gep.IsInBounds = true;
        Assert.That(gep.IsInBounds, Is.True);
        Assert.That(gep.NumIndices, Is.EqualTo(2u));
        Assert.That(gep.PointerOperand, Is.EqualTo(context.GetOrCreate(storage)));
    }
}
