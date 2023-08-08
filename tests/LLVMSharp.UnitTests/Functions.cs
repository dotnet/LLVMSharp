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
        Assert.AreEqual(parameterTypes, functionType.ParamTypes);
    }

    [Test]
    public void AddsAttributeAtIndex()
    {
        var module = LLVMModuleRef.CreateWithName("Test Module");
        var functionType = LLVMTypeRef.CreateFunction(LLVMTypeRef.Int8, new[] { LLVMTypeRef.Double });
        var functionValue = module.AddFunction("test", functionType);
        var attr = module.Context.CreateEnumAttribute((uint)AttributeKind.ByVal, default);
        functionValue.AddAttributeAtIndex((LLVMAttributeIndex)1, attr);

        var attrs = functionValue.GetAttributesAtIndex((LLVMAttributeIndex)1);
        Assert.AreEqual(attrs[0].Kind, (uint)AttributeKind.ByVal);
    }
}
