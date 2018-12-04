namespace LLVMSharp.API
{
    public static class Support
    {
        public static bool LoadLibraryPermanently(string filename) => LLVM.LoadLibraryPermanently(filename);
        public static void ParseCommandLineOptions(int argc, string[] argv, string overview) => LLVM.ParseCommandLineOptions(argc, argv, overview);
    }
}
