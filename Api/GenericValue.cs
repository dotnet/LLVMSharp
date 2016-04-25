namespace LLVMSharp.Api
{
    using System;
    using Utilities;

    public sealed class GenericValue : IDisposableWrapper<LLVMGenericValueRef>, IDisposable
    {
        public static GenericValue CreateGenericValueOfInt(Type t, ulong n, bool isSigned)
        {
            return
                LLVM.CreateGenericValueOfInt(t.Unwrap(), n, isSigned)
                    .Wrap()
                    .MakeHandleOwner<GenericValue, LLVMGenericValueRef>();
        }

        public static GenericValue CreateGenericValueOfPointer(IntPtr p)
        {
            return LLVM.CreateGenericValueOfPointer(p).Wrap().MakeHandleOwner<GenericValue, LLVMGenericValueRef>();
        }

        public static GenericValue CreateGenericValueOfFloat(Type ty, double n)
        {
            return
                LLVM.CreateGenericValueOfFloat(ty.Unwrap(), n)
                    .Wrap()
                    .MakeHandleOwner<GenericValue, LLVMGenericValueRef>();
        }

        LLVMGenericValueRef IWrapper<LLVMGenericValueRef>.ToHandleType()
        {
            return this._instance;
        }

        void IDisposableWrapper<LLVMGenericValueRef>.MakeHandleOwner()
        {
            this._owner = true;
        }

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

        public uint IntWidth
        {
            get { return LLVM.GenericValueIntWidth(this.Unwrap()); }
        }

        public ulong ToInt(bool isSigned)
        {
            return LLVM.GenericValueToInt(this.Unwrap(), isSigned);
        }

        public IntPtr ToPointer()
        {
            return LLVM.GenericValueToPointer(this.Unwrap());
        }

        public double ToFloat(Type ty)
        {
            return LLVM.GenericValueToFloat(ty.Unwrap(), this.Unwrap());
        }
        
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
