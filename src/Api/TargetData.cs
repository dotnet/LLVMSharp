namespace LLVMSharp.Api
{
    using System;
    using Utilities;

    public sealed class TargetData : IDisposableWrapper<LLVMTargetDataRef>, IDisposable
    {
        public static TargetData Create(string stringRep)
        {
            return LLVM.CreateTargetData(stringRep).Wrap().MakeHandleOwner<TargetData, LLVMTargetDataRef>();
        }

        LLVMTargetDataRef IWrapper<LLVMTargetDataRef>.ToHandleType()
        {
            return this._instance;
        }

        void IDisposableWrapper<LLVMTargetDataRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

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

        public void AddTargetData(PassManager pm)
        {
            LLVM.AddTargetData(this.Unwrap(), pm.Unwrap());
        }

        public IntPtr CopyStringRepOfTargetData()
        {
            return LLVM.CopyStringRepOfTargetData(this.Unwrap());
        }

        public LLVMByteOrdering ByteOrder
        {
            get { return LLVM.ByteOrder(this.Unwrap()); }
        }

        public uint PointerSize()
        {
            return LLVM.PointerSize(this.Unwrap());
        }

        public uint PointerSizeForAS(uint @as)
        {
            return LLVM.PointerSizeForAS(this.Unwrap(), @as);
        }

        public Type IntPtrType()
        {
            return LLVM.IntPtrType(this.Unwrap()).Wrap();
        }

        public Type IntPtrTypeForAS(uint @as)
        {
            return LLVM.IntPtrTypeForAS(this.Unwrap(), @as).Wrap();
        }

        public ulong SizeOfTypeInBits(Type ty)
        {
            return LLVM.SizeOfTypeInBits(this.Unwrap(), ty.Unwrap());
        }

        public ulong StoreSizeOfType(Type ty)
        {
            return LLVM.StoreSizeOfType(this.Unwrap(), ty.Unwrap());
        }

        public ulong ABISizeOfType(Type ty)
        {
            return LLVM.ABISizeOfType(this.Unwrap(), ty.Unwrap());
        }

        public uint ABIAlignmentOfType(Type ty)
        {
            return LLVM.ABIAlignmentOfType(this.Unwrap(), ty.Unwrap());
        }

        public uint CallFrameAlignmentOfType(Type ty)
        {
            return LLVM.CallFrameAlignmentOfType(this.Unwrap(), ty.Unwrap());
        }

        public uint PreferredAlignmentOfType(Type ty)
        {
            return LLVM.PreferredAlignmentOfType(this.Unwrap(), ty.Unwrap());
        }

        public uint PreferredAlignmentOfGlobal(Value globalVar)
        {
            return LLVM.PreferredAlignmentOfGlobal(this.Unwrap(), globalVar.Unwrap());
        }

        public uint ElementAtOffset(Type structTy, ulong offset)
        {
            return LLVM.ElementAtOffset(this.Unwrap(), structTy.Unwrap(), offset);
        }

        public ulong OffsetOfElement(Type structTy, uint element)
        {
            return LLVM.OffsetOfElement(this.Unwrap(), structTy.Unwrap(), element);
        }

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
