namespace LLVMSharp.API.Types.Composite.SequentialTypes
{
    public sealed class PointerType : Type
    {
        public static PointerType GetUnqual(Type elementType) => Get(elementType, 0u);
        public static PointerType Get(Type elementType, uint addressSpace) => LLVM.PointerType(elementType.Unwrap(), addressSpace).WrapAs<PointerType>();

        public static bool IsValidElementType(Type type) => !(type is VoidType) && !(type is LabelType) && !(type is MetadataType) && !(type is TokenType);
        public static bool IsLoadableOrStorableType(Type type) => IsValidElementType(type) && !(type is FunctionType);

        internal PointerType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override string Name => $"{this.ElementType.Name} *";
        public uint AddressSpace => LLVM.GetPointerAddressSpace(this.Unwrap());
        public Type ElementType => LLVM.GetElementType(this.Unwrap()).Wrap();
        public override bool IsSingleValueType => true;
    }
}
