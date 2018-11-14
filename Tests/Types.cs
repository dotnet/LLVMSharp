namespace Tests
{
    using LLVMSharp.API;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class Types
    {
        [Test]
        public void IntSizes([Values(1, 8, 16, 32, 64)] int width)
        {
            var uWidth = (uint)width;
            var t = Context.Global.IntType(uWidth);
            Assert.AreEqual(uWidth, t.BitWidth);
        }

        [Test]
        public void FloatingTypes()
        {
            var dic = new Dictionary<Type, bool>
            {
                { Context.Global.VoidType, false },
                { Context.Global.Int32Type, false },
                { Context.Global.X86MMXType, false },
                { Context.Global.LabelType, false },

                { Context.Global.HalfType, true },
                { Context.Global.FloatType, true },
                { Context.Global.DoubleType, true },
                { Context.Global.FP128Type, true },
                { Context.Global.X86FP80Type, true },
                { Context.Global.PPCFP128Type, true },
            };
            foreach (var p in dic.Keys)
            {
                Assert.AreEqual(dic[p], p.IsFloatingPoint);
            }
        }
    }
}
