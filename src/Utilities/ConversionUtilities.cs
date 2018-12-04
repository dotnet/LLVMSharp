namespace LLVMSharp
{
    using System;
    using Utilities;
    using API;
    using Type = LLVMSharp.API.Type;

    internal static class ConversionUtilities
    {
        public static THandle Unwrap<THandle>(this IWrapper<THandle> wrapper)
            where THandle : struct
        {
            return wrapper.ToHandleType;
        }

        public static THandle[] Unwrap<THandle>(this IWrapper<THandle>[] wrappers)
            where THandle : struct
        {
            var handles = new THandle[wrappers.Length];
            for (var i = 0; i < handles.Length; i++)
            {
                handles[i] = wrappers[i].Unwrap();
            }
            return handles;
        }
        
        public static TWrapper Wrap<TWrapper>(this IHandle<TWrapper> handle)
            where TWrapper : class
        {
            if (handle.GetInternalPointer() == IntPtr.Zero)
            {
                return null;
            }
            return handle.ToWrapperType();
        }

        public static TWrapper[] Wrap<THandle, TWrapper>(this THandle[] handles)
            where TWrapper : class
            where THandle : IHandle<TWrapper>
        {
            var wrappers = new TWrapper[handles.Length];
            for (var i = 0; i < wrappers.Length; i++)
            {
                wrappers[i] = handles[i].Wrap();
            }
            return wrappers;
        }
        
        public static TWrapper WrapAs<TWrapper>(this IHandle<Value> handle)
            where TWrapper : Value
        {
            if (handle.GetInternalPointer() == IntPtr.Zero)
            {
                return null;
            }
            return (TWrapper)handle.ToWrapperType();
        }

        public static TWrapper[] WrapAs<TWrapper>(this LLVMValueRef[] handles)
            where TWrapper : Value
        {
            var wrappers = new TWrapper[handles.Length];
            for (var i = 0; i < wrappers.Length; i++)
            {
                wrappers[i] = handles[i].WrapAs<TWrapper>();
            }
            return wrappers;
        }

        public static TWrapper WrapAs<TWrapper>(this IHandle<Type> handle)
            where TWrapper : Type
        {
            if (handle.GetInternalPointer() == IntPtr.Zero)
            {
                return null;
            }
            return (TWrapper)handle.ToWrapperType();
        }

        public static TWrapper MakeHandleOwner<TWrapper, THandle>(this TWrapper wrapper)
            where TWrapper : class, IDisposableWrapper<THandle>
            where THandle : struct
        {
            wrapper.MakeHandleOwner();
            return wrapper;
        }

        internal static bool ToBool(this LLVMValueRef v) => v.Pointer != IntPtr.Zero;
        internal static LLVMBool ToLLVMBool(this LLVMValueRef v) => v.Pointer != IntPtr.Zero;

        public static LLVMIntPredicate Unwrap(this IntPredicate wrapper) => (LLVMIntPredicate)(int)wrapper;
        public static LLVMRealPredicate Unwrap(this RealPredicate wrapper) => (LLVMRealPredicate)(int)wrapper;
        public static LLVMThreadLocalMode Unwrap(this ThreadLocalMode wrapper) => (LLVMThreadLocalMode)(int)wrapper;
        public static LLVMLinkage Unwrap(this Linkage wrapper) => (LLVMLinkage)(int)wrapper;
        public static LLVMOpcode Unwrap(this Opcode wrapper) => (LLVMOpcode)(int)wrapper;
        public static LLVMDiagnosticSeverity Unwrap(this DiagnosticSeverity wrapper) => (LLVMDiagnosticSeverity)(int)wrapper;
        public static LLVMAtomicOrdering Unwrap(this AtomicOrdering wrapper) => (LLVMAtomicOrdering)(int)wrapper;
        public static LLVMAtomicRMWBinOp Unwrap(this AtomicRMWBinOp wrapper) => (LLVMAtomicRMWBinOp)(int)wrapper;
        public static LLVMDLLStorageClass Unwrap(this DLLStorageClass wrapper) => (LLVMDLLStorageClass)(int)wrapper;
        public static LLVMVisibility Unwrap(this Visibility wrapper) => (LLVMVisibility)(int)wrapper;

        public static IntPredicate Wrap(this LLVMIntPredicate handle) => (IntPredicate)(int)handle;
        public static RealPredicate Wrap(this LLVMRealPredicate handle) => (RealPredicate)(int)handle;
        public static ThreadLocalMode Wrap(this LLVMThreadLocalMode handle) => (ThreadLocalMode)(int)handle;
        public static Linkage Wrap(this LLVMLinkage handle) => (Linkage)(int)handle;
        public static Opcode Wrap(this LLVMOpcode handle) => (Opcode)(int)handle;
        public static DiagnosticSeverity Wrap(this LLVMDiagnosticSeverity handle) => (DiagnosticSeverity)(int)handle;
        public static AtomicOrdering Wrap(this LLVMAtomicOrdering handle) => (AtomicOrdering)(int)handle;
        public static AtomicRMWBinOp Wrap(this LLVMAtomicRMWBinOp handle) => (AtomicRMWBinOp)(int)handle;
        public static DLLStorageClass Wrap(this LLVMDLLStorageClass handle) => (DLLStorageClass)(int)handle;
        public static Visibility Wrap(this LLVMVisibility handle) => (Visibility)(int)handle;
    }
}