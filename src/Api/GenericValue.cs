namespace LLVMSharp.API
{
    using LLVMSharp.API.Types;
    using System;
    using Utilities;

    public sealed class GenericValue : IDisposableWrapper<LLVMGenericValueRef>, IDisposable
    {
        LLVMGenericValueRef IWrapper<LLVMGenericValueRef>.ToHandleType => this._instance;
        void IDisposableWrapper<LLVMGenericValueRef>.MakeHandleOwner() => this._owner = true;

        public static GenericValue Create(IntegerType t, ulong n, bool isSigned) => LLVM.CreateGenericValueOfInt(t.Unwrap(), n, isSigned).Wrap().MakeHandleOwner<GenericValue, LLVMGenericValueRef>();
        public static GenericValue Create(IntegerType t, ulong n) => Create(t, n, false);
        public static GenericValue Create(FPType ty, double n) => LLVM.CreateGenericValueOfFloat(ty.Unwrap(), n).Wrap().MakeHandleOwner<GenericValue, LLVMGenericValueRef>();
        public static GenericValue Create(IntPtr p) => LLVM.CreateGenericValueOfPointer(p).Wrap().MakeHandleOwner<GenericValue, LLVMGenericValueRef>();

        private readonly LLVMGenericValueRef _instance;
        private bool _disposed;
        private bool _owner;

        internal GenericValue(LLVMGenericValueRef instance)
        {
            this._instance = instance;
        }

        ~GenericValue()
        {
            this.Dispose(false);
        }

        public uint IntWidth => LLVM.GenericValueIntWidth(this.Unwrap());
        public ulong ToInt(bool isSigned) => LLVM.GenericValueToInt(this.Unwrap(), isSigned);
        public IntPtr ToPointer() => LLVM.GenericValueToPointer(this.Unwrap());
        public double ToFloat(Type ty) => LLVM.GenericValueToFloat(ty.Unwrap(), this.Unwrap());

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (this._owner)
            {
                LLVM.DisposeGenericValue(this.Unwrap());
            }

            this._disposed = true;
        }
    }
}
