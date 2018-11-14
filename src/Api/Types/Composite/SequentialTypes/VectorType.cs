namespace LLVMSharp.API.Types.Composite.SequentialTypes
{
    using System;
    using Type = LLVMSharp.API.Type;

    public sealed class VectorType : SequentialType
    {
        public static VectorType Get(Type elementType, uint numElements) => LLVM.VectorType(elementType.Unwrap(), numElements).WrapAs<VectorType>();

        public static VectorType GetInteger(VectorType vectorType)
        {
            if (vectorType.Length == 0)
            {
                throw new ArgumentException("Element count cannot be zero.", nameof(vectorType));
            }
            return GetSubstituteVectorType(vectorType, s => s, n => n);
        }

        public static VectorType GetExtendedElementVectorType(VectorType vectorType) => GetSubstituteVectorType(vectorType, s => s * 2, n => n);

        public static VectorType GetTruncatedElementVectorType(VectorType vectorType)
        {
            if ((vectorType.ElementType.PrimitiveSizeInBits & 1) == 0)
            {
                throw new ArgumentException("Element size in bits cannot be odd.", nameof(vectorType));
            }
            return GetSubstituteVectorType(vectorType, s => s / 2, n => n);
        }

        public static VectorType GetHalfElementsVectorType(VectorType vectorType)
        {
            if ((vectorType.Length & 1) == 0)
            {
                throw new ArgumentException("Element count cannot be odd.", nameof(vectorType));
            }
            return GetSubstituteVectorType(vectorType, s => s, n => n / 2);
        }

        public static VectorType GetDoubleElementsVectorType(VectorType vectorType) => GetSubstituteVectorType(vectorType, s => s, n => n * 2);

        private static VectorType GetSubstituteVectorType(VectorType vectorType,Func<uint, uint> elementSizeSelector, Func<uint, uint> elementCountSelector)
        {
            var originalSize = vectorType.ElementType.PrimitiveSizeInBits;
            var substituteSize = elementSizeSelector(originalSize);
            var integerType = vectorType.Context.IntType(substituteSize);
            return Get(integerType, vectorType.Length);
        }

        public static bool IsValidElementType(Type type) => type is IntegerType || type is FPType || type is PointerType;

        internal VectorType(LLVMTypeRef typeRef)
            : base(typeRef)
        {
        }

        public uint BitWidth => this.Length * this.ElementType.PrimitiveSizeInBits;

        public override bool IsSingleValueType => true;

        public override Type ScalarType => this.ElementType;
        public override uint Length => LLVM.GetVectorSize(this.Unwrap());
    }
}
