namespace Tests
{
    using LLVMSharp.Api;
    using Xunit;

    public class Targets
    {
        public void InitializeX86Targets()
        {
            Initialize.X86.TargetInfo();
            var targets = Target.Targets;
            Assert.Contains(targets, x => x.Name == "x86");
            Assert.Contains(targets, x => x.Name == "x86-64");
        }
        
        public void InitializeARMTargets()
        {
            Initialize.ARM.TargetInfo();
            var targets = Target.Targets;
            Assert.Contains(targets, x => x.Name == "arm");
            Assert.Contains(targets, x => x.Name == "armeb");
        }

        [Fact]
        public void DefaultTargetTriple()
        {
            var str = Target.DefaultTriple;
            Assert.True(str.Length > 0);
        }
    }
}
