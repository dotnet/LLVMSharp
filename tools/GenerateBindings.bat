cd ClangSharpPInvokeGenerator

@echo off
if [%1]==[] (
  echo **ERROR**: LLVM Shared Library Location is required. A good value for this parameter is 'llvm' which will translate to 'llvm.dll' or 'llvm.so' in deployment relative directory
  EXIT /B
)
if [%2]==[] (
  echo **ERROR**: LLVM Include Directory is required. This is the directory which contains "llvm" and "llvm-c" as subdirectories
  EXIT /B
)

csc /out:ClangSharpPInvokeGenerator.exe ClangSharpPInvokeGenerator\*.cs
ClangSharpPInvokeGenerator.exe --m LLVM --p LLVM --namespace LLVMSharp --output Generated.tmp.cs --libraryPath %1 --include %2 --file %2/llvm-c/Analysis.h --file %2/llvm-c/BitReader.h --file %2/llvm-c/BitWriter.h --file %2/llvm-c/Core.h --file %2/llvm-c/Disassembler.h --file %2/llvm-c/ErrorHandling.h --file %2/llvm-c/ExecutionEngine.h --file %2/llvm-c/Initialization.h --file %2/llvm-c/IRReader.h --file %2/llvm-c/Linker.h --file %2/llvm-c/LinkTimeOptimizer.h --file %2/llvm-c/lto.h --file %2/llvm-c/Object.h --file %2/llvm-c/OrcBindings.h --file %2/llvm-c/Support.h --file %2/llvm-c/Target.h --file %2/llvm-c/TargetMachine.h --file %2/llvm-c/Types.h --file %2/llvm-c/Transforms/IPO.h --file %2/llvm-c/Transforms/PassManagerBuilder.h --file %2/llvm-c/Transforms/Scalar.h --file %2/llvm-c/Transforms/Vectorize.h

move Generated.tmp.cs ..\

cd ..