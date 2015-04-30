namespace UnitTests
{
    using LLVMSharp;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConversionTests
    {
        [TestMethod]
        public void TestLLVMValueRefToFunction()
        {
            var module = LLVM.ModuleCreateWithName("module");
            Value function = LLVM.AddFunction(module, "foo", LLVM.FunctionType(LLVM.VoidType(), new [] { LLVM.Int32Type() }, false));
            Assert.IsTrue(function is Function);
        }
    }
}