namespace LLVMSharp.API.Types.Composite
{
    using System;
    using System.Collections.Generic;
    using Type = LLVMSharp.API.Type;
    using System.Collections;
    using System.Linq;

    public sealed class StructType : CompositeType, IEnumerable<Type>, IAggregateType
    {
        public static StructType Create(Context context, string name) => LLVM.StructCreateNamed(context.Unwrap(), name).WrapAs<StructType>();
        public static StructType Create(Context context) => LLVM.StructTypeInContext(context.Unwrap(), new LLVMTypeRef[0], false).WrapAs<StructType>();

        public static StructType Create(Type[] elementTypes, string name, bool packed)
        {
            var t = LLVM.StructCreateNamed(Context.Global.Unwrap(), name).WrapAs<StructType>();
            t.SetBody(elementTypes, packed);
            return t;
        }

        public static StructType Create(Type[] elementTypes, string name) => Create(elementTypes, name, false);
        public static StructType Create(Type[] elementTypes, bool packed) => LLVM.StructType(elementTypes.Unwrap(), packed).WrapAs<StructType>();

        public static StructType Create(Context context, Type[] elementTypes, string name, bool packed)
        {
            var t = Create(context, name);
            t.SetBody(elementTypes, packed);
            return t;
        }

        public static StructType Get(Context context, Type[] elementTypes, bool packed) => throw new NotImplementedException();
        public static StructType Get(Context context) => LLVM.StructTypeInContext(context.Unwrap(), new LLVMTypeRef[0], false).WrapAs<StructType>();
        public static StructType Get(params Type[] elementTypes) => Create(elementTypes, false);
        public static StructType Get(string name, params Type[] elementTypes) => Create(elementTypes, name);

        public static bool IsValidElementType(Type type)
        {
            return !(type is VoidType) && !(type is LabelType) &&
                   !(type is MetadataType) && !(type is FunctionType) &&
                   !(type is TokenType);
        }

        internal StructType(LLVMTypeRef typeRef) 
            : base(typeRef)
        {
        }

        public uint Length => LLVM.CountStructElementTypes(this.Unwrap());
        public Type GetElementType(uint index) => LLVM.GetStructElementTypes(this.Unwrap())[index].Wrap();
        public IReadOnlyList<Type> ElementTypes => LLVM.GetStructElementTypes(this.Unwrap()).Wrap<LLVMTypeRef, Type>();

        public bool HasName => string.IsNullOrEmpty(this.Name);
        public override string Name => LLVM.GetStructName(this.Unwrap());

        public bool IsPacked
        {
            get => LLVM.IsPackedStruct(this.Unwrap());
            set => this.SetBody((Type[])this.ElementTypes, value);
        }
        public bool IsOpaque => LLVM.IsOpaqueStruct(this.Unwrap());
        public bool IsLiteral => throw new NotImplementedException();

        public void SetBody(params Type[] elementTypes) => this.SetBody(elementTypes, false);
        public void SetBody(Type[] elementTypes, bool packed) => LLVM.StructSetBody(this.Unwrap(), elementTypes.Unwrap(), new LLVMBool(packed));

        public bool IsLayoutIdentical(StructType other) => throw new NotImplementedException();

        public override string ToString() => $"{string.Join(", ", ElementTypes)}";

        public override bool IsIndexValid(uint index) => index < this.Length;
        public override Type GetTypeAtIndex(uint index) => LLVM.GetStructElementTypes(this.Unwrap())[index].Wrap();

        public override bool IsEmpty => this.ElementTypes.Any(x => !x.IsEmpty);

        public IEnumerator<Type> GetEnumerator() => this.ElementTypes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
