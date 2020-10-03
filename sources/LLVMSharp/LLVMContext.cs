// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using System.Collections.Generic;
using LLVMSharp.Interop;

namespace LLVMSharp
{
    public sealed class LLVMContext : IEquatable<LLVMContext>
    {
        private readonly Dictionary<LLVMValueRef, WeakReference<Value>> _createdValues = new Dictionary<LLVMValueRef, WeakReference<Value>>();
        private readonly Dictionary<LLVMTypeRef, WeakReference<Type>> _createdTypes = new Dictionary<LLVMTypeRef, WeakReference<Type>>();

        public LLVMContext()
        {
            Handle = LLVMContextRef.Create();
        }

        public LLVMContextRef Handle { get; }

        public static bool operator ==(LLVMContext left, LLVMContext right) => ReferenceEquals(left, right) || (left?.Handle == right?.Handle);

        public static bool operator !=(LLVMContext left, LLVMContext right) => !(left == right);

        public override bool Equals(object obj) => (obj is LLVMContext other) && Equals(other);

        public bool Equals(LLVMContext other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => Handle.ToString();

        internal BasicBlock GetOrCreate(LLVMBasicBlockRef handle) => GetOrCreate<BasicBlock>(handle.AsValue());

        internal TType GetOrCreate<TType>(LLVMTypeRef handle)
            where TType : Type
        {
            WeakReference<Type> typeRef;

            if (handle == null)
            {
                return null;
            }
            else if (!_createdTypes.TryGetValue(handle, out typeRef))
            {
                typeRef = new WeakReference<Type>(null);
                _createdTypes.Add(handle, typeRef);
            }

            if (!typeRef.TryGetTarget(out Type type))
            {
                type = Type.Create(handle);
                typeRef.SetTarget(type);
            }
            return (TType)type;
        }

        internal TValue GetOrCreate<TValue>(LLVMValueRef handle)
            where TValue : Value
        {
            WeakReference<Value> valueRef;

            if (handle == null)
            {
                return null;
            }
            else if (!_createdValues.TryGetValue(handle, out valueRef))
            {
                valueRef = new WeakReference<Value>(null);
                _createdValues.Add(handle, valueRef);
            }

            if (!valueRef.TryGetTarget(out Value value))
            {
                value = Value.Create(handle);
                valueRef.SetTarget(value);
            }
            return (TValue)value;
        }

        internal Type GetOrCreate(LLVMTypeRef handle) => GetOrCreate<Type>(handle);

        internal Value GetOrCreate(LLVMValueRef handle) => GetOrCreate<Value>(handle);
    }
}
