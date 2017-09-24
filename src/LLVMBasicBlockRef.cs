namespace LLVMSharp
{
    using System;
    using LLVMSharp.Api.Values;
    using LLVMSharp.Utilities;

    partial struct LLVMBasicBlockRef : IHandle<BasicBlock>
    {
        IntPtr IHandle<BasicBlock>.GetInternalPointer() => this.Pointer;
        BasicBlock IHandle<BasicBlock>.ToWrapperType() => new BasicBlock(this);
    }
}
