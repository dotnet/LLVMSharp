namespace LLVMSharp.Utilities
{
    using System;
    using Type = LLVMSharp.API.Type;

    internal static class TypeUtilities
    {
        public static TType MustBeSized<TType>(this TType type)
            where TType : Type
        {
            if (!type.IsSized)
            {
                throw new NotSupportedException(type.GetUnsizedTypeMessage());
            }
            return type;
        }

        public static TType MustHaveConstants<TType>(this TType type)
            where TType : Type
        {
            if (!type.CanHaveConstants)
            {
                throw new NotSupportedException(type.GetLimitedTypeMessage());
            }
            return type;
        }

        public static TType MustHaveArrays<TType>(this TType type)
            where TType : Type
        {
            if (!type.CanHaveArrays)
            {
                throw new NotSupportedException(type.GetLimitedTypeMessage());
            }
            return type;
        }

        public static TType MustHaveVectors<TType>(this TType type)
            where TType : Type
        {
            if (!type.CanHaveArrays)
            {
                throw new NotSupportedException(type.GetLimitedTypeMessage());
            }
            return type;
        }
    }
}
