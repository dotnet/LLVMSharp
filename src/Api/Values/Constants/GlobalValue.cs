namespace LLVMSharp.API.Values.Constants
{
    public class GlobalValue : Constant
    {
        internal GlobalValue(LLVMValueRef instance)
            : base(instance)
        {
        }

        public uint Alignment
        {
            get => LLVM.GetAlignment(this.Unwrap());
            set => LLVM.SetAlignment(this.Unwrap(), value);
        }

        public bool HasUnnamedAddr
        {
            get => LLVM.HasUnnamedAddr(this.Unwrap());
            set => LLVM.SetUnnamedAddr(this.Unwrap(), value);
        }

        public DLLStorageClass DLLStorageClass
        {
            get => LLVM.GetDLLStorageClass(this.Unwrap()).Wrap();
            set => LLVM.SetDLLStorageClass(this.Unwrap(), value.Unwrap());
        }

        public Visibility Visibility
        {
            get => LLVM.GetVisibility(this.Unwrap()).Wrap();
            set => LLVM.SetVisibility(this.Unwrap(), value.Unwrap());
        }

        public string Section
        {
            get => LLVM.GetSection(this.Unwrap());
            set => LLVM.SetSection(this.Unwrap(), value);
        }

        public Linkage Linkage
        {
            get => LLVM.GetLinkage(this.Unwrap()).Wrap();
            set => LLVM.SetLinkage(this.Unwrap(), value.Unwrap());
        }

        public bool IsDeclaration => LLVM.IsDeclaration(this.Unwrap());

        public Module GlobalParent => LLVM.GetGlobalParent(this.Unwrap()).Wrap(); 
    }
}