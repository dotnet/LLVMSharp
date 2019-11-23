// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;

namespace LLVMSharp
{
    public unsafe partial struct LLVMPassManagerBuilderRef : IEquatable<LLVMPassManagerBuilderRef>, IDisposable
    {
        public LLVMPassManagerBuilderRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMPassManagerBuilderRef(LLVMOpaquePassManagerBuilder* value)
        {
            return new LLVMPassManagerBuilderRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaquePassManagerBuilder*(LLVMPassManagerBuilderRef value)
        {
            return (LLVMOpaquePassManagerBuilder*)value.Pointer;
        }

        public static bool operator ==(LLVMPassManagerBuilderRef left, LLVMPassManagerBuilderRef right) => left.Pointer == right.Pointer;

        public static bool operator !=(LLVMPassManagerBuilderRef left, LLVMPassManagerBuilderRef right) => !(left == right);

        public override bool Equals(object obj) => obj is LLVMPassManagerBuilderRef other && Equals(other);

        public bool Equals(LLVMPassManagerBuilderRef other) => Pointer == other.Pointer;

        public override int GetHashCode() => Pointer.GetHashCode();

        public void Dispose()
        {
            if (Pointer != IntPtr.Zero)
            {
                LLVM.PassManagerBuilderDispose(this);
                Pointer = IntPtr.Zero;
            }
        }

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

        public void UseInlinerWithThreshold(uint Threshold) => LLVM.PassManagerBuilderUseInlinerWithThreshold(this, Threshold);
    }
}
