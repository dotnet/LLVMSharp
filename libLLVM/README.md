# Manual instructions for building (macOS)

`export LLVM_SRC_DIR=/build/llvm-6.0.1.src`

`export LLVM_BUILD_DIR=/build/llvm-6.0.1.build`

`export LLVM_LIB_DIR=$LLVM_BUILD_DIR/lib`

`curl http://releases.llvm.org/6.0.1/llvm-6.0.1.src.tar.xz --output llvm-6.0.1.src.tar.xz`

`tar zxvf llvm-6.0.1.src.tar.xz $LLVM_SRC_DIR`

`cd $LLVM_BUILD_DIR`

`cmake -DCMAKE_BUILD_TYPE=Release -DLLVM_BUILD_LLVM_DYLIB=True $LLVM_SRC_DIR`

`make -j4`

`cd $LLVM_LIB_DIR`

`nm $LLVM_LIB_DIR/libLLVM.dylib > exports.txt`

`Optionally strip out all symbols not starting with _LLVM`

`Run build.sh from this directory`
