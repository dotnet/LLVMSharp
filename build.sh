if [ -z "$1" ]; then
  echo **ERROR**: LLVM Shared Library Location is required. A good value for this parameter is 'llvm' which will translate to 'llvm.dll' or 'llvm.so' in deployment relative directory
  exit 1
fi
if [ -z "$2" ]; then
  echo **ERROR**: LLVM Include Directory is required. This is the directory which contains "llvm" and "llvm-c" as subdirectories
  exit 1
fi

mcs /out:ClangSharpPInvokeGenerator.exe ClangSharpPInvokeGenerator/ClangSharp.Extensions.cs ClangSharpPInvokeGenerator/EnumVisitor.cs ClangSharpPInvokeGenerator/Extensions.cs ClangSharpPInvokeGenerator/ForwardDeclarationVisitor.cs ClangSharpPInvokeGenerator/FunctionVisitor.cs ClangSharpPInvokeGenerator/Generated.cs ClangSharpPInvokeGenerator/ICXCursorVisitor.cs ClangSharpPInvokeGenerator/Program.cs ClangSharpPInvokeGenerator/StructVisitor.cs ClangSharpPInvokeGenerator/TypeDefVisitor.cs
mono ClangSharpPInvokeGenerator.exe --m LLVM --p LLVM --namespace LLVMSharp --output Generated.cs --libraryPath %1 --include %2 --file %2/llvm-c/Analysis.h --file %2/llvm-c/BitReader.h --file %2/llvm-c/BitWriter.h --file %2/llvm-c/Core.h --file %2/llvm-c/Disassembler.h --file %2/llvm-c/ExecutionEngine.h --file %2/llvm-c/Initialization.h --file %2/llvm-c/IRReader.h --file %2/llvm-c/Linker.h --file %2/llvm-c/LinkTimeOptimizer.h --file %2/llvm-c/lto.h --file %2/llvm-c/Object.h --file %2/llvm-c/Support.h --file %2/llvm-c/Target.h --file %2/llvm-c/TargetMachine.h --file %2/llvm-c/Transforms/IPO.h --file %2/llvm-c/Transforms/PassManagerBuilder.h --file %2/llvm-c/Transforms/Scalar.h --file %2/llvm-c/Transforms/Vectorize.h
mcs /target:library /out:LLVMSharp.dll Generated.cs