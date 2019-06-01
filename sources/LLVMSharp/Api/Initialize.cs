namespace LLVMSharp.API
{
    using LLVMSharp.API.TargetInitializers;

    public static class Initialize
    {
        public static AArch64TargetInitializer AArch64 { get; } = new AArch64TargetInitializer();
        public static ARMTargetInitializer ARM { get; } = new ARMTargetInitializer();
        public static HexagonTargetInitializer Hexagon { get; } = new HexagonTargetInitializer();
        public static MipsTargetInitializer Mips { get; } = new MipsTargetInitializer();
        public static NativeTargetInitializer Native { get; } = new NativeTargetInitializer();
        public static NVPTXTargetInitializer NVPTX { get; } = new NVPTXTargetInitializer();
        public static PowerPCTargetInitializer PowerPC { get; } = new PowerPCTargetInitializer();
        public static SparcTargetInitializer Sparc { get; } = new SparcTargetInitializer();
        public static SystemZTargetInitializer SystemZ { get; } = new SystemZTargetInitializer();
        public static X86TargetInitializer X86 { get; } = new X86TargetInitializer();
        public static XCoreTargetInitializer XCore { get; } = new XCoreTargetInitializer();
    }
}
