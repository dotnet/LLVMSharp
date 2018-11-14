namespace LLVMSharp.API
{
    using LLVMSharp.Utilities;

    public sealed class Attribute : IWrapper<LLVMAttributeRef>
    {
        LLVMAttributeRef IWrapper<LLVMAttributeRef>.ToHandleType => this._instance;

        private readonly LLVMAttributeRef _instance;

        internal Attribute(LLVMAttributeRef attributeRef)
        {
            this._instance = attributeRef;
        }
    }
}
