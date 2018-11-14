namespace Tests
{
    using LLVMSharp.API;
    using LLVMSharp.API.TargetInitializers;
    using NUnit.Framework;
    using System.Linq;

    public class Targets
    {
        [Test]
        public void InitializeX86Targets() => this.InitializeTargets(Initialize.X86, new[] { "x86" });

        [Test]
        public void InitializeARMTargets() => this.InitializeTargets(Initialize.ARM, new[] { "arm" });
       
        private void InitializeTargets(TargetInitializer init, string[] expectedTargets)
        {
            init.All();
            foreach (var u in Target.Targets)
            {
                u.EnsurePropertiesWork();
            }
            foreach (var t in expectedTargets)
            {
                Assert.IsTrue(Target.Targets.Any(x => x.Name == t));
            }
        }

        [Test]
        public void DefaultTargetTriple()
        {
            var str = Target.DefaultTriple;
            Assert.Greater(str.Length, 0);
        }
    }
}
