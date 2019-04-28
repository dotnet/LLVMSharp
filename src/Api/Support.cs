namespace LLVMSharp.API
{
    public static class Support
    {
        public static bool LoadLibraryPermanently(string filename) => LLVM.LoadLibraryPermanently(filename);
        public static void ParseCommandLineOptions(int argc, string[] argv, string overview)
        {
            var marshaledArgv = StringMarshaler.MarshalArray(argv);
            LLVM.ParseCommandLineOptions(argc, out marshaledArgv[0], overview);
        }
    }
}
