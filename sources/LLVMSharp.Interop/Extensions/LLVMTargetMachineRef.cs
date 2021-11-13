// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMTargetMachineRef : IEquatable<LLVMTargetMachineRef>
    {
        public IntPtr Handle;

        public LLVMTargetMachineRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMTargetMachineRef(LLVMOpaqueTargetMachine* value) => new LLVMTargetMachineRef((IntPtr)value);

        public static implicit operator LLVMOpaqueTargetMachine*(LLVMTargetMachineRef value) => (LLVMOpaqueTargetMachine*)value.Handle;

        public static bool operator ==(LLVMTargetMachineRef left, LLVMTargetMachineRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMTargetMachineRef left, LLVMTargetMachineRef right) => !(left == right);

        public LLVMTargetDataRef CreateTargetDataLayout() => LLVM.CreateTargetDataLayout(this);

        public void EmitToFile(LLVMModuleRef module, string fileName, LLVMCodeGenFileType codegen) => EmitToFile(module, fileName.AsSpan(), codegen);

        public void EmitToFile(LLVMModuleRef module, ReadOnlySpan<char> fileName, LLVMCodeGenFileType codegen)
        {
            if (!TryEmitToFile(module, fileName, codegen, out string Error))
            {
                throw new ExternalException(Error);
            }
        }

        public override bool Equals(object obj) => (obj is LLVMTargetMachineRef other) && Equals(other);

        public bool Equals(LLVMTargetMachineRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public override string ToString() => $"{nameof(LLVMTargetMachineRef)}: {Handle:X}";

        public bool TryEmitToFile(LLVMModuleRef module, string fileName, LLVMCodeGenFileType codegen, out string message) => TryEmitToFile(module, fileName.AsSpan(), codegen, out message);

        public bool TryEmitToFile(LLVMModuleRef module, ReadOnlySpan<char> fileName, LLVMCodeGenFileType codegen, out string message)
        {
            using var marshaledFileName = new MarshaledString(fileName);

            sbyte* errorMessage = null;
            int result = LLVM.TargetMachineEmitToFile(this, module, marshaledFileName, codegen, &errorMessage);

            if (errorMessage == null)
            {
                message = string.Empty;
            }
            else
            {
                var span = new ReadOnlySpan<byte>(errorMessage, int.MaxValue);
                message = span.Slice(0, span.IndexOf((byte)'\0')).AsString();
                LLVM.DisposeErrorMessage(errorMessage);
            }

            return result == 0;
        }
    }
}
