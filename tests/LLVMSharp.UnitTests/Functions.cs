// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using LLVMSharp.Interop;
using NUnit.Framework;

namespace LLVMSharp.UnitTests
{
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
    }
}
