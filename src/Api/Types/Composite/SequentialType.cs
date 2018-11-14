namespace LLVMSharp.API.Types.Composite
{
    public abstract class SequentialType : CompositeType
    {
        internal SequentialType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public Type ElementType => LLVM.GetElementType(this.Unwrap()).Wrap();
        public abstract uint Length { get; }

        public override bool IsIndexValid(uint index) => true;
        public override Type GetTypeAtIndex(uint index) => this.ElementType;
    }
}
