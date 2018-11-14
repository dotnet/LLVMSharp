namespace Tests
{
    using LLVMSharp.API;
    using NUnit;
    using NUnit.Framework;

    public class Modules
    {
        [Test]
        public void SetsAndGetsDataLayout()
        {
            using(var module = Module.Create("test"))
            {
                const string ExampleDataLayout = "e-m:e-p:32:32-f64:32:64-f80:32-n8:16:32-S128";
                module.DataLayout = ExampleDataLayout;
                Assert.AreEqual(ExampleDataLayout, module.DataLayout);
            }
        }

        [Test]
        public void SetsAndGetsTarget()
        {
            using(var module = Module.Create("test"))
            {
                const string ExampleTarget = "x86_64-pc-windows-msvc";
                module.Target = ExampleTarget;
                Assert.AreEqual(ExampleTarget, module.Target);
            }
        }
    }
}
