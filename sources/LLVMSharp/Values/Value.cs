// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class Value : IEquatable<Value>
    {
        private protected Value(LLVMValueRef handle, LLVMValueKind expectedValueKind)
        {
            if (handle.Kind != expectedValueKind)
            {
                throw new ArgumentException(nameof(handle));
            }
            Handle = handle;
        }

        public LLVMValueRef Handle { get; }

        public static bool operator ==(Value left, Value right) => ReferenceEquals(left, right) || (left.Handle == right.Handle);

        public static bool operator !=(Value left, Value right) => !(left == right);

        public override bool Equals(object obj) => (obj is Value other) && Equals(other);

        public bool Equals(Value other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => Handle.ToString();

        internal static Value Create(LLVMValueRef handle) => handle switch
        {
            _ when handle.IsAArgument != null => new Argument(handle),
            _ when handle.IsABasicBlock != null => new BasicBlock(handle),
            _ when handle.IsAInlineAsm != null => new InlineAsm(handle),
            _ when handle.IsAUser != null => User.Create(handle),
            _ when handle.Kind == LLVMValueKind.LLVMMetadataAsValueValueKind => new MetadataAsValue(handle),
            _ => new Value(handle, handle.Kind),
        };
    }
}
