using System;
using System.Collections.Generic;

namespace LLVMSharp
{
    public unsafe partial struct LLVMTargetRef : IEquatable<LLVMTargetRef>
    {
        public static string DefaultTriple
        {
            get
            {
                var pDefaultTriple = LLVM.GetDefaultTargetTriple();

                if (pDefaultTriple is null)
                {
                    return string.Empty;
                }

                var span = new ReadOnlySpan<byte>(pDefaultTriple, int.MaxValue);
                return span.Slice(0, span.IndexOf((byte)'\0')).AsString();
            }
        }

        public static LLVMTargetRef First => LLVM.GetFirstTarget();

        public static IEnumerable<LLVMTargetRef> Targets
        {
            get
            {
                var target = First;

                while (target != null)
                {
                    yield return target;
                    target = target.GetNext();
                }
            }
        }

        public string Name
        {
            get
            {
                if (Pointer == IntPtr.Zero)
                {
                    return string.Empty;
                }

                var pName = LLVM.GetTargetName(this);

                if (pName is null)
                {
                    return string.Empty;
                }

                var span = new ReadOnlySpan<byte>(pName, int.MaxValue);
                return span.Slice(0, span.IndexOf((byte)'\0')).AsString();
            }
        }

        public static bool operator ==(LLVMTargetRef left, LLVMTargetRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMTargetRef left, LLVMTargetRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMTargetRef other && Equals(other);

        public bool Equals(LLVMTargetRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();

        public LLVMTargetRef GetNext() => LLVM.GetNextTarget(this);
    }
}
