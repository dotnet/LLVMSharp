// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;

namespace LLVMSharp.Interop
{
    public unsafe partial struct LLVMPassManagerBuilderRef : IEquatable<LLVMPassManagerBuilderRef>, IDisposable
    {
        public IntPtr Handle;

        public LLVMPassManagerBuilderRef(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LLVMPassManagerBuilderRef(LLVMOpaquePassManagerBuilder* value) => new LLVMPassManagerBuilderRef((IntPtr)value);

        public static implicit operator LLVMOpaquePassManagerBuilder*(LLVMPassManagerBuilderRef value) => (LLVMOpaquePassManagerBuilder*)value.Handle;

        public static bool operator ==(LLVMPassManagerBuilderRef left, LLVMPassManagerBuilderRef right) => left.Handle == right.Handle;

        public static bool operator !=(LLVMPassManagerBuilderRef left, LLVMPassManagerBuilderRef right) => !(left == right);

        public void Dispose()
        {
            if (Handle != IntPtr.Zero)
            {
                LLVM.PassManagerBuilderDispose(this);
                Handle = IntPtr.Zero;
            }
        }

        public override bool Equals(object obj) => (obj is LLVMPassManagerBuilderRef other) && Equals(other);

        public bool Equals(LLVMPassManagerBuilderRef other) => this == other;

        public override int GetHashCode() => Handle.GetHashCode();

        public void PopulateFunctionPassManager(LLVMPassManagerRef PM) => LLVM.PassManagerBuilderPopulateFunctionPassManager(this, PM);

        public void PopulateModulePassManager(LLVMPassManagerRef PM) => LLVM.PassManagerBuilderPopulateModulePassManager(this, PM);

        public void PopulateLTOPassManager(LLVMPassManagerRef PM, int Internalize, int RunInliner)
        {
            LLVM.PassManagerBuilderPopulateLTOPassManager(this, PM, Internalize, RunInliner);
        }

        public void SetOptLevel(uint OptLevel) => LLVM.PassManagerBuilderSetOptLevel(this, OptLevel);

        public void SetSizeLevel(uint SizeLevel) => LLVM.PassManagerBuilderSetSizeLevel(this, SizeLevel);

        public void SetDisableUnitAtATime(int Value) => LLVM.PassManagerBuilderSetDisableUnitAtATime(this, Value);

        public void SetDisableUnrollLoops(int Value) => LLVM.PassManagerBuilderSetDisableUnrollLoops(this, Value);

        public void SetDisableSimplifyLibCalls(int Value) => LLVM.PassManagerBuilderSetDisableSimplifyLibCalls(this, Value);

        public override string ToString() => $"{nameof(LLVMPassManagerBuilderRef)}: {Handle:X}";

        public void UseInlinerWithThreshold(uint Threshold) => LLVM.PassManagerBuilderUseInlinerWithThreshold(this, Threshold);
    }
}
