namespace LLVMSharp.API
{
    using System;
    using Utilities;

    public sealed class TargetData : IDisposableWrapper<LLVMTargetDataRef>, IDisposable
    {
        LLVMTargetDataRef IWrapper<LLVMTargetDataRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMTargetDataRef>.MakeHandleOwner() => this._owner = true;

        public static TargetData Create(string stringRep) => LLVM.CreateTargetData(stringRep).Wrap().MakeHandleOwner<TargetData, LLVMTargetDataRef>();

        private readonly LLVMTargetDataRef _instance;
        private bool _disposed;
        private bool _owner;

        internal TargetData(LLVMTargetDataRef instance)
        {
            this._instance = instance;
        }

        ~TargetData()
        {
            this.Dispose(false);
        }

        public string CopyStringRepOfTargetData() => LLVM.CopyStringRepOfTargetData(this.Unwrap()).MessageToString();

        public LLVMByteOrdering ByteOrder => LLVM.ByteOrder(this.Unwrap());

        public uint GetPointerSize() => LLVM.PointerSize(this.Unwrap());
        public uint GetPointerSize(uint addressSpace) => LLVM.PointerSizeForAS(this.Unwrap(), addressSpace);

        public Type GetIntPtrType() => LLVM.IntPtrType(this.Unwrap()).Wrap();
        public Type GetIntPtrType(uint addressSpace) => LLVM.IntPtrTypeForAS(this.Unwrap(), addressSpace).Wrap();

        public ulong SizeOfTypeInBits(Type ty) => LLVM.SizeOfTypeInBits(this.Unwrap(), ty.Unwrap());
        public ulong StoreSizeOfType(Type ty) => LLVM.StoreSizeOfType(this.Unwrap(), ty.Unwrap());
        public ulong ABISizeOfType(Type ty) => LLVM.ABISizeOfType(this.Unwrap(), ty.Unwrap());
        public uint ABIAlignmentOfType(Type ty) => LLVM.ABIAlignmentOfType(this.Unwrap(), ty.Unwrap());
        public uint CallFrameAlignmentOfType(Type ty) => LLVM.CallFrameAlignmentOfType(this.Unwrap(), ty.Unwrap());
        public uint PreferredAlignmentOfType(Type ty) => LLVM.PreferredAlignmentOfType(this.Unwrap(), ty.Unwrap());
        public uint PreferredAlignmentOfGlobal(Value globalVar) => LLVM.PreferredAlignmentOfGlobal(this.Unwrap(), globalVar.Unwrap());

        public uint ElementAtOffset(Type structTy, ulong offset) => LLVM.ElementAtOffset(this.Unwrap(), structTy.Unwrap(), offset);
        public ulong OffsetOfElement(Type structTy, uint element) => LLVM.OffsetOfElement(this.Unwrap(), structTy.Unwrap(), element);

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (this._owner)
            {
                LLVM.DisposeTargetData(this.Unwrap());
            }

            this._disposed = true;
        }
    }
}
