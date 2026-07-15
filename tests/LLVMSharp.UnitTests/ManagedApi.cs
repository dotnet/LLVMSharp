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
}
