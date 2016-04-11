namespace UnitTests
{
    using System.Linq;
    using LLVMSharp.Api;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Targets
    {
        [TestMethod]
        public void InitializeX86Targets()
        {
            Initialize.X86.TargetInfo();
            var targets = Target.EnumerateTargets().ToList();
            Assert.IsTrue(targets.Any(x => x.Name == "x86"));
            Assert.IsTrue(targets.Any(x => x.Name == "x86-64"));
        }

        [TestMethod]
        public void InitializeARMTargets()
        {
            Initialize.ARM.TargetInfo();
            var targets = Target.EnumerateTargets().ToList();
            Assert.IsTrue(targets.Any(x => x.Name == "arm"));
            Assert.IsTrue(targets.Any(x => x.Name == "armeb"));
        }

        [TestMethod]
        public void DefaultTargetTriple()
        {
            var str = Host.GetDefaultTargetTriple();
            Assert.IsTrue(str.Length > 0);
        }
    }
}
