namespace LLVMSharp.Api.Types.Composite
{
    using Utilities;

    public class StructType : Type
    {
        internal StructType(LLVMTypeRef typeRef) 
            : base(typeRef)
        {
        }

        public StructType(Type[] types, bool packed)
            : this(LLVM.StructType(out types.Unwrap()[0], (uint)types.Length, packed))
        {            
        }

        public StructType(Context context, string name)
            : this(LLVM.StructCreateNamed(context.Unwrap(), name))
        {            
        }
    }
}
