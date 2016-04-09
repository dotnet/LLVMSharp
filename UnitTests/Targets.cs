namespace UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using LLVMSharp;

    [TestClass]
    public class Targets
    {
        [TestMethod]
        public void InitializeX86Targets()
        {
            LLVM.InitializeX86TargetInfo();
            var targets = Target.EnumerateTargets().ToList();
            Assert.IsTrue(targets.Any(x => x.Name == "x86"));
            Assert.IsTrue(targets.Any(x => x.Name == "x86-64"));
        }

        [TestMethod]
        public void InitializeARMTargets()
        {
            LLVM.InitializeARMTargetInfo();
            var targets = Target.EnumerateTargets().ToList();
            Assert.IsTrue(targets.Any(x => x.Name == "arm"));
            Assert.IsTrue(targets.Any(x => x.Name == "armeb"));
        }        
    }
}
