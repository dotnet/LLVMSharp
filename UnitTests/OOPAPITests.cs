using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using LLVMSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class OOPAPITests
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int Delegate1(int a, int b);

        [TestMethod]
        public void SimpleAdd()
        {
            var module = new Module("module");
            var i32 = LLVM.Int32Type();
            var signature = LLVM.FunctionType(i32, new[] { i32, i32 }, false);
            var function = module.AddFunction("add", signature);
            var basicBlock = new BasicBlock(function);
            var builder = new IRBuilder();
            builder.PositionBuilderAtEnd(basicBlock);
            var p1 = LLVM.GetParam(function, 0u);
            var p2 = LLVM.GetParam(function, 1u);
            var add = builder.CreateAdd(p1, p2, "sum");
            var ret = builder.CreateRet(add);

            IntPtr error;
            LLVMExecutionEngineRef executionEngine;
            var optionsSize = (4 * sizeof(int)) + IntPtr.Size;
            var options = new LLVMMCJITCompilerOptions[optionsSize];
            LLVM.InitializeMCJITCompilerOptions(options);
            LLVM.CreateMCJITCompilerForModule(out executionEngine, module, options, out error);
            var functionPtr = LLVM.GetPointerToGlobal(executionEngine, function);
            var functionDelegate = (Delegate1)Marshal.GetDelegateForFunctionPointer(functionPtr, typeof(Delegate1));

            var result = functionDelegate(1, 2);
            Assert.AreEqual(3, result);
        }
    }
}
