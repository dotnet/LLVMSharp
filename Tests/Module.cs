namespace Tests
{
    using LLVMSharp.Api;
    using Xunit;

    public class Modules
    {
        //[Fact]
        public void SetsAndGetsDataLayout()
        {
            using(var module = Module.Create("test"))
            {
                const string ExampleDataLayout = "e-m:e-p:32:32-f64:32:64-f80:32-n8:16:32-S128";
                module.SetDataLayout(ExampleDataLayout);
                var dl = module.GetDataLayout();
                Assert.Equal(ExampleDataLayout, dl);
            }
        }

        //[Fact]
        public void SetsAndGetsTarget()
        {
            using(var module = Module.Create("test"))
            {
                const string ExampleTarget = "x86_64-pc-windows-msvc";
                module.SetTarget(ExampleTarget);
                var t = module.GetTarget();
                Assert.Equal(ExampleTarget, t);
            }
        }
    }
}
