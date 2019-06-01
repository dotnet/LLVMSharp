namespace LLVMSharp.API
{
    using LLVMSharp.API.Types;
    using LLVMSharp.API.Types.Composite;
    using LLVMSharp.API.Types.Composite.SequentialTypes;
    using System;
    using System.Collections.Generic;
    using Utilities;

    public abstract class Type : IEquatable<Type>, IWrapper<LLVMTypeRef>
    {
        LLVMTypeRef IWrapper<LLVMTypeRef>.ToHandleType => this._instance;

        private static Dictionary<LLVMTypeKind, Func<LLVMTypeRef, Type>> Map = new Dictionary<LLVMTypeKind, Func<LLVMTypeRef, Type>>
            {
                { LLVMTypeKind.LLVMArrayTypeKind, u => new ArrayType(u) },
                { LLVMTypeKind.LLVMFunctionTypeKind, u => new FunctionType(u) },
                { LLVMTypeKind.LLVMPointerTypeKind, u => new PointerType(u) },
                { LLVMTypeKind.LLVMStructTypeKind, u => new StructType(u) },
                { LLVMTypeKind.LLVMVectorTypeKind, u => new VectorType(u) },
                { LLVMTypeKind.LLVMVoidTypeKind, u => new VoidType(u) },
                { LLVMTypeKind.LLVMIntegerTypeKind, u => new IntegerType(u) },
                { LLVMTypeKind.LLVMHalfTypeKind, u => new HalfType(u) },
                { LLVMTypeKind.LLVMFloatTypeKind, u => new FloatType(u) },
                { LLVMTypeKind.LLVMDoubleTypeKind, u => new DoubleType(u) },
                { LLVMTypeKind.LLVMX86_FP80TypeKind, u => new X86FP80Type(u) },
                { LLVMTypeKind.LLVMFP128TypeKind, u => new FP128Type(u) },
                { LLVMTypeKind.LLVMPPC_FP128TypeKind, u => new PPCFP128Type(u) },
                { LLVMTypeKind.LLVMX86_MMXTypeKind, u => new X86MMXType(u) },
                { LLVMTypeKind.LLVMLabelTypeKind, u => new LabelType(u) },
            };

        internal static Type Create(LLVMTypeRef t)
        {
            if (t.Pointer == IntPtr.Zero)
            {
                return null;
            }

            var kind = LLVM.GetTypeKind(t);
            if (Map.ContainsKey(kind))
            {
                return Map[kind](t);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static VoidType Void => Context.Global.VoidType;
        public static IntegerType Int1 => Context.Global.Int1Type;
        public static IntegerType Int8 => Context.Global.Int8Type;
        public static IntegerType Int16 => Context.Global.Int16Type;
        public static IntegerType Int32 => Context.Global.Int32Type;
        public static IntegerType Int64 => Context.Global.Int64Type;
        public static IntegerType Int(uint bitLength) => Context.Global.IntType(bitLength);
        public static HalfType Half => Context.Global.HalfType;
        public static FloatType Float => Context.Global.FloatType;
        public static DoubleType Double => Context.Global.DoubleType;
        public static X86FP80Type X86FP80 => Context.Global.X86FP80Type;
        public static FP128Type FP128 => Context.Global.FP128Type;
        public static PPCFP128Type PPCFP128 => Context.Global.PPCFP128Type;

        private readonly LLVMTypeRef _instance;

        internal Type(LLVMTypeRef typeRef) => this._instance = typeRef;
        
        public string Print() => LLVM.PrintTypeToString(this.Unwrap()).MessageToString();

        public void Dump() => LLVM.DumpType(this.Unwrap());

        public Context Context => LLVM.GetTypeContext(this.Unwrap()).Wrap();

        public bool IsFloatingPoint => this is FPType;
        public bool IsIntegerType => this is IntegerType;
        public bool IsIntegerTypeOfWidth(uint bitWidth) => this is IntegerType t && t.BitWidth == bitWidth;

        public bool IsTypeOrVectorTypeOf<TType>() where TType : Type => this.ScalarType is TType;

        public virtual bool IsEmpty => false;
        public virtual bool IsFirstClassType => true;
        public virtual bool IsSingleValueType => false;
        public bool IsAggregateType => this is IAggregateType;
        public bool IsSized => LLVM.TypeIsSized(this.Unwrap());
        public virtual uint PrimitiveSizeInBits => 0;
        public uint ScalarSizeInBits => this.ScalarType.PrimitiveSizeInBits;

        public bool IsIntOrIntVectorType() => this.ScalarType is IntegerType;
        public bool IsIntOrIntVectorType(uint bitWidth) => this.ScalarType is IntegerType t && t.BitWidth == bitWidth;

        public virtual Type ScalarType => this;
        public PointerType PointerType => this.PointerTypeInAddressSpace(0u);
        public PointerType PointerTypeInAddressSpace(uint addressSpace) => PointerType.Get(this, addressSpace);
        public virtual bool CanHaveConstants => true;
        public virtual bool CanHaveVectors => true;
        public virtual bool CanHaveArrays => true;

        protected internal virtual string GetUnsizedTypeMessage() => $"The type {this.Name} does not have a size or alignment.";
        protected internal virtual string GetLimitedTypeMessage() => string.Empty;

        public virtual string Name => this.GetType().Name;

        public override string ToString() => !string.IsNullOrEmpty(this.Name) ? this.Name : base.ToString();

        public bool Equals(Type other) => ReferenceEquals(other, null) ? false : this._instance == other._instance;
        public override bool Equals(object obj) => this.Equals(obj as Type);
        public static bool operator ==(Type op1, Type op2) => (ReferenceEquals(op1, null) && ReferenceEquals(op2, null)) || op1.Equals(op2);
        public static bool operator !=(Type op1, Type op2) => !(op1 == op2);
        public override int GetHashCode() => this._instance.GetHashCode();
    }
}