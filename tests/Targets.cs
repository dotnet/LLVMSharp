namespace Tests
{
    using LLVMSharp.Api;
    using LLVMSharp.Api.TargetInitializers;
    using Xunit;

    public class Targets
    {
        [Theory]
        [InlineData("x86", "x86-64")]
        public void InitializeX86Targets(params string[] expected) => this.InitializeTargets(Initialize.X86, expected);

        [Theory]
        [InlineData("arm")]
        public void InitializeARMTargets(params string[] expected) => this.InitializeTargets(Initialize.ARM, expected);
       
        public void InitializeTargets(TargetInitializer init, string[] expectedTargets)
        {
            init.All();
            foreach (var u in Target.Targets)
            {
                u.EnsurePropertiesWork();
            }
            foreach (var t in expectedTargets)
            {
                Assert.Contains(Target.Targets, x => x.Name == t);

            }
        }

        [Fact]
        public void DefaultTargetTriple()
        {
            var str = Target.DefaultTriple;
            Assert.True(str.Length > 0);
        }
    }
}
