namespace UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Type = LLVMSharp.Type;

    [TestClass]
    public class OOPAPITests
    {
        [TestMethod]
        public void SimpleAdd()
        {
            var i32 = Type.Int32;
            var run = Common.CreateDelegateInLLVM<Int32Int32Int32Delegate>("add", i32, new[] {i32, i32},
                (function, builder) =>
                {
                    var p1 = function.GetParameter(0);
                    var p2 = function.GetParameter(1);
                    var add = builder.CreateAdd(p1, p2, string.Empty);
                    var ret = builder.CreateRet(add);
                });
            Assert.AreEqual(0, run(0, 0));
            Assert.AreEqual(3, run(1, 2));
            Assert.AreEqual(10, run(9, 1));
        }

        [TestMethod]
        public void SimpleShift()
        {
            var i32 = Type.Int32;
            var run = Common.CreateDelegateInLLVM<Int32Int32Int32Delegate>("shift", i32, new[] {i32, i32},
                (function, builder) =>
                {
                    var p1 = function.GetParameter(0);
                    var p2 = function.GetParameter(1);
                    var shift = builder.CreateLShr(p1, p2, string.Empty);
                    var ret = builder.CreateRet(shift);
                });
            Assert.AreEqual(2, run(4, 1));
            Assert.AreEqual(1, run(4, 2));
        }

        [TestMethod]
        public void GreaterThan()
        {
            var i1 = Type.Int1;
            var i32 = Type.Int32;
            var run = Common.CreateDelegateInLLVM<Int32Int32Int32Delegate>("greaterthan", i1, new[] {i32, i32},
                (function, builder) =>
                {
                    var p1 = function.GetParameter(0);
                    var p2 = function.GetParameter(1);
                    var comparison = builder.CreateICmp(LLVMSharp.LLVMIntPredicate.LLVMIntSGT, p1, p2, string.Empty);
                    var result = builder.CreateBitCast(comparison, i1, string.Empty);
                    var ret = builder.CreateRet(result);
                });
            Assert.AreEqual(1, run(10, 5));
            Assert.AreEqual(0, run(5, 10));
            Assert.AreEqual(0, run(5, 5));
        }
    }
}
