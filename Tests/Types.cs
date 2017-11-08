namespace Tests
{
    using LLVMSharp.Api;
    using System.Collections.Generic;
    using Xunit;

    public class Types
    {
        [Theory]
        [InlineData(1)]
        [InlineData(8)]
        [InlineData(16)]
        [InlineData(32)]
        [InlineData(64)]
        public void IntSizes(uint width)
        {
            var t = Context.Global.IntType(width);
            Assert.Equal(width, t.BitWidth);
        }

        [Fact]
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
                Assert.Equal(dic[p], p.IsFloatingPoint);
            }
        }
    }
}
