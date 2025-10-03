// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;
using NUnit.Framework;

namespace LLVMSharp.UnitTests;

public class Functions
{
    [Test]
    public void ParamTypesRoundtrip()
    {
        var returnType = LLVMTypeRef.Int8;
        var parameterTypes = new[] { LLVMTypeRef.Double };
        var functionType = LLVMTypeRef.CreateFunction(returnType, parameterTypes);
        Assert.That(functionType.GetParamTypes(), Is.EquivalentTo(parameterTypes));
    }

    [Test]
    public void AddsAttributeAtIndex()
    {
        var module = LLVMModuleRef.CreateWithName("Test Module");
        var functionType = LLVMTypeRef.CreateFunction(LLVMTypeRef.Int8, [LLVMTypeRef.Double]);
        var functionValue = module.AddFunction("test", functionType);
        var attr = module.Context.CreateEnumAttribute((uint)AttributeKind.ByVal, default);
        functionValue.AddAttributeAtIndex((LLVMAttributeIndex)1, attr);

        var attrs = functionValue.GetAttributesAtIndex((LLVMAttributeIndex)1);
        Assert.That((AttributeKind)attrs[0].KindAsEnum, Is.EqualTo(AttributeKind.ByVal));
    }

    [Test]
    public void LibLLVMSharp_GetFunctionType()
    {
        var module = LLVMModuleRef.CreateWithName("Test Module");
        var returnType = LLVMTypeRef.Int32;
        var paramTypes = new[] { LLVMTypeRef.Int32, LLVMTypeRef.Int32 };
        var functionType = LLVMTypeRef.CreateFunction(returnType, paramTypes);
        var functionValue = module.AddFunction("add", functionType);
        
        var retrievedFunctionType = functionValue.GetFunctionType();
        
        Assert.That(retrievedFunctionType.Kind, Is.EqualTo(LLVMTypeKind.LLVMFunctionTypeKind));
        
        Assert.That(retrievedFunctionType.GetReturnType().Kind, Is.EqualTo(LLVMTypeKind.LLVMIntegerTypeKind));
        
        Assert.That(retrievedFunctionType.ParamTypesCount, Is.EqualTo(2));
    }

    [Test]
    public void LibLLVMSharp_GetReturnType()
    {
        var module = LLVMModuleRef.CreateWithName("Test Module");
        var returnType = LLVMTypeRef.Int32;
        var functionType = LLVMTypeRef.CreateFunction(returnType, [LLVMTypeRef.Int32, LLVMTypeRef.Int32]);
        var functionValue = module.AddFunction("add", functionType);
        
        var retrievedReturnType = functionValue.GetReturnType();
        
        Assert.That(retrievedReturnType.Kind, Is.EqualTo(LLVMTypeKind.LLVMIntegerTypeKind));
        Assert.That(retrievedReturnType.Handle, Is.EqualTo(returnType.Handle));
    }
}
