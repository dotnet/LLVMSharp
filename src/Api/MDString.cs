namespace LLVMSharp.API
{
    public sealed class MDString : Metadata
    {
        public static MetadataAsValue GetMDString(string str) => LLVM.MDString(str, (uint)str.Length).WrapAs<MDStringAsValue>();
        public static MetadataAsValue GetMDString(Context context, string str) => LLVM.MDStringInContext(context.Unwrap(), str, (uint)str.Length).WrapAs<MDStringAsValue>();
        public static MetadataAsValue GetMDNode(Value[] vals) => LLVM.MDNode(vals.Unwrap()).WrapAs<MDStringAsValue>();
    }
}
