namespace LLVMSharp
{
    using System;

    /// <summary>
    /// Helper class that handles the internal conversions between C API and C++ API types.
    /// </summary>
    internal static class ConversionUtilities
    {
        public static THandle Unwrap<THandle>(this IWrapper<THandle> wrapper)
            where THandle : struct
        {
            return wrapper.ToHandleType();
        }

        public static THandle[] Unwrap<THandle>(this IWrapper<THandle>[] wrappers)
            where THandle : struct
        {
            var handles = new THandle[wrappers.Length];
            for (var i = 0; i < handles.Length; i++)
            {
                handles[i] = wrappers[i].Unwrap<THandle>();
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
                wrappers[i] = handles[i].Wrap<TWrapper>();
            }
            return wrappers;
        }

        public static TWrapper WrapAs<TWrapper>(this IHandle<Value> handle)
            where TWrapper : Value
        {
            return (TWrapper) handle.ToWrapperType();
        }

        public static TWrapper MakeHandleOwner<TWrapper, THandle>(this TWrapper wrapper)
            where TWrapper : class, IDisposableWrapper<THandle>
            where THandle : struct
        {
            wrapper.MakeHandleOwner();
            return wrapper;
        }

        internal static bool ToBool(this LLVMValueRef v)
        {
            return v.Pointer != IntPtr.Zero;
        }
    }
}