namespace LLVMSharp.API.Types.Composite.SequentialTypes
{
    public sealed class ArrayType : SequentialType, IAggregateType
    {
        public static ArrayType Get(Type elementType, uint length) => new ArrayType(LLVM.ArrayType(elementType.Unwrap(), length));

        public static bool IsValidElementType(Type type) => !(type is VoidType) && !(type is LabelType) && !(type is MetadataType) && !(type is FunctionType) && !(type is TokenType);

        internal ArrayType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public override uint Length => LLVM.GetArrayLength(this.Unwrap());
        public override string Name => $"{ElementType.Name}[{Length}]";
        public override bool IsEmpty => this.Length == 0 || this.ElementType.IsEmpty;
    }
}
