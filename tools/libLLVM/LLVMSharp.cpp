#include "llvm-c/Target.h"

extern "C"
{
    void LLVMInitializeAllTargetInfos_()
    {
        LLVMInitializeAllTargetInfos();
    }

    void LLVMInitializeAllTargets_()
    {
        LLVMInitializeAllTargets();
    }

    void LLVMInitializeAllTargetMCs_()
    {
        LLVMInitializeAllTargetMCs();
    }

    void LLVMInitializeAllAsmPrinters_()
    {
        LLVMInitializeAllAsmPrinters();
    }

    void LLVMInitializeAllAsmParsers_()
    {
        LLVMInitializeAllAsmParsers();
    }

    void LLVMInitializeAllDisassemblers_()
    {
        LLVMInitializeAllDisassemblers();
    }

    LLVMBool LLVMInitializeNativeTarget_()
    {
        return LLVMInitializeNativeTarget();
    }

    LLVMBool LLVMInitializeNativeAsmParser_()
    {
        return LLVMInitializeNativeAsmParser();
    }

    LLVMBool LLVMInitializeNativeAsmPrinter_()
    {
        return LLVMInitializeNativeAsmPrinter();
    }

    LLVMBool LLVMInitializeNativeDisassembler_()
    {
        return LLVMInitializeNativeDisassembler();
    }
}