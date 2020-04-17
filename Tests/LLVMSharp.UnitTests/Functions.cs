// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

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
