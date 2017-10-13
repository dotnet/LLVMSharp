namespace UnitTests
{
    using LLVMSharp;
    using LLVMSharp.Api;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IRBuilder
    {
        [TestMethod]
        public void SimpleAdd()
        {
            using (var module = Module.Create("test_add"))
            {
                var func = module.DefineFunction(
                    Type.Int32, "add", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.GetParameter(0);
                        var p2 = f.GetParameter(1);
                        var add = b.CreateAdd(p1, p2, string.Empty);
                        var ret = b.CreateRet(add);
                    });

                using (var engine = module.CreateExecutionEngine())
                {
                    var run = engine.GetDelegate<Int32Int32Int32Delegate>(func);

                    Assert.AreEqual(0, run(0, 0));
                    Assert.AreEqual(3, run(1, 2));
                    Assert.AreEqual(10, run(9, 1));
                }
            }
        }

        [TestMethod]
        public void SimpleShift()
        {
            using (var module = Module.Create("test_shift"))
            {
                var func = module.DefineFunction(
                    Type.Int32, "shift", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.GetParameter(0);
                        var p2 = f.GetParameter(1);
                        var shift = b.CreateLShr(p1, p2, string.Empty);
                        var ret = b.CreateRet(shift);
                    });

                using (var engine = module.CreateExecutionEngine())
                {
                    var run = engine.GetDelegate<Int32Int32Int32Delegate>(func);

                    Assert.AreEqual(2, run(4, 1));
                    Assert.AreEqual(1, run(4, 2));
                }
            }
        }

        [TestMethod]
        public void GreaterThan()
        {
            using (var module = Module.Create("test_greaterthan"))
            {
                var func = module.DefineFunction(
                    Type.Int1, "greaterthan", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.GetParameter(0);
                        var p2 = f.GetParameter(1);
                        var comparison = b.CreateICmp(LLVMIntPredicate.LLVMIntSGT,
                            p1, p2, string.Empty);
                        var result = b.CreateBitCast(comparison, Type.Int1, string.Empty);
                        var ret = b.CreateRet(result);
                    });

                var engine = module.CreateExecutionEngine();
                var run = engine.GetDelegate<Int32Int32Int32Delegate>(func);

                Assert.AreEqual(1, run(10, 5));
                Assert.AreEqual(0, run(5, 10));
                Assert.AreEqual(0, run(5, 5));
            }

        }

        [TestMethod]
        public void FunctionCall()
        {
            using (var module = Module.Create("test_call"))
            {
                var addFunc = module.DefineFunction(
                    Type.Int32, "add", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.GetParameter(0);
                        var p2 = f.GetParameter(1);
                        var add = b.CreateAdd(p1, p2, string.Empty);
                        var ret = b.CreateRet(add);
                    });
                var entryFunc = module.DefineFunction(
                    Type.Int32, "entry", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.GetParameter(0);
                        var p2 = f.GetParameter(1);
                        var call = b.CreateCall(addFunc, new[] { p1, p2 }, string.Empty);
                        var ret = b.CreateRet(call);
                    });

                var engine = module.CreateExecutionEngine();
                var run = engine.GetDelegate<Int32Int32Int32Delegate>(entryFunc);

                Assert.AreEqual(1, run(1, 0));
                Assert.AreEqual(2, run(1, 1));
                Assert.AreEqual(3, run(1, 2));
            }
        }

        [TestMethod]
        public void Constant()
        {
            using (var module = Module.Create("test_constant"))
            {
                var func = module.DefineFunction(
                    Type.Int32, "constant", new Type[0], (f, b) =>
                    {
                        var value = Type.Int32.ConstInt(5u, false);
                        var ret = b.CreateRet(value);
                    });

                var engine = module.CreateExecutionEngine();
                var run = engine.GetDelegate<Int32Delegate>(func);

                Assert.AreEqual(5, run());
            }
        }
    }
}
