namespace LLVMSharp.API.Types.Composite
{
    public abstract class CompositeType : Type
    {
        internal CompositeType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public Type this[uint index] => this.GetTypeAtIndex(index);

        public abstract bool IsIndexValid(uint index);
        public abstract Type GetTypeAtIndex(uint index);
    }
}
