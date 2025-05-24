// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-20.1.2/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace LLVMSharp.Interop;

public static unsafe partial class LLVM
{
    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAArch64TargetInfo", ExactSpelling = true)]
    public static extern void InitializeAArch64TargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAMDGPUTargetInfo", ExactSpelling = true)]
    public static extern void InitializeAMDGPUTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeARMTargetInfo", ExactSpelling = true)]
    public static extern void InitializeARMTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAVRTargetInfo", ExactSpelling = true)]
    public static extern void InitializeAVRTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeBPFTargetInfo", ExactSpelling = true)]
    public static extern void InitializeBPFTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeHexagonTargetInfo", ExactSpelling = true)]
    public static extern void InitializeHexagonTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLanaiTargetInfo", ExactSpelling = true)]
    public static extern void InitializeLanaiTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLoongArchTargetInfo", ExactSpelling = true)]
    public static extern void InitializeLoongArchTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMipsTargetInfo", ExactSpelling = true)]
    public static extern void InitializeMipsTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMSP430TargetInfo", ExactSpelling = true)]
    public static extern void InitializeMSP430TargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeNVPTXTargetInfo", ExactSpelling = true)]
    public static extern void InitializeNVPTXTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializePowerPCTargetInfo", ExactSpelling = true)]
    public static extern void InitializePowerPCTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeRISCVTargetInfo", ExactSpelling = true)]
    public static extern void InitializeRISCVTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSparcTargetInfo", ExactSpelling = true)]
    public static extern void InitializeSparcTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSPIRVTargetInfo", ExactSpelling = true)]
    public static extern void InitializeSPIRVTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSystemZTargetInfo", ExactSpelling = true)]
    public static extern void InitializeSystemZTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeVETargetInfo", ExactSpelling = true)]
    public static extern void InitializeVETargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeWebAssemblyTargetInfo", ExactSpelling = true)]
    public static extern void InitializeWebAssemblyTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeX86TargetInfo", ExactSpelling = true)]
    public static extern void InitializeX86TargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeXCoreTargetInfo", ExactSpelling = true)]
    public static extern void InitializeXCoreTargetInfo();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAArch64Target", ExactSpelling = true)]
    public static extern void InitializeAArch64Target();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAMDGPUTarget", ExactSpelling = true)]
    public static extern void InitializeAMDGPUTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeARMTarget", ExactSpelling = true)]
    public static extern void InitializeARMTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAVRTarget", ExactSpelling = true)]
    public static extern void InitializeAVRTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeBPFTarget", ExactSpelling = true)]
    public static extern void InitializeBPFTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeHexagonTarget", ExactSpelling = true)]
    public static extern void InitializeHexagonTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLanaiTarget", ExactSpelling = true)]
    public static extern void InitializeLanaiTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLoongArchTarget", ExactSpelling = true)]
    public static extern void InitializeLoongArchTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMipsTarget", ExactSpelling = true)]
    public static extern void InitializeMipsTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMSP430Target", ExactSpelling = true)]
    public static extern void InitializeMSP430Target();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeNVPTXTarget", ExactSpelling = true)]
    public static extern void InitializeNVPTXTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializePowerPCTarget", ExactSpelling = true)]
    public static extern void InitializePowerPCTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeRISCVTarget", ExactSpelling = true)]
    public static extern void InitializeRISCVTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSparcTarget", ExactSpelling = true)]
    public static extern void InitializeSparcTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSPIRVTarget", ExactSpelling = true)]
    public static extern void InitializeSPIRVTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSystemZTarget", ExactSpelling = true)]
    public static extern void InitializeSystemZTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeVETarget", ExactSpelling = true)]
    public static extern void InitializeVETarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeWebAssemblyTarget", ExactSpelling = true)]
    public static extern void InitializeWebAssemblyTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeX86Target", ExactSpelling = true)]
    public static extern void InitializeX86Target();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeXCoreTarget", ExactSpelling = true)]
    public static extern void InitializeXCoreTarget();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAArch64TargetMC", ExactSpelling = true)]
    public static extern void InitializeAArch64TargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAMDGPUTargetMC", ExactSpelling = true)]
    public static extern void InitializeAMDGPUTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeARMTargetMC", ExactSpelling = true)]
    public static extern void InitializeARMTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAVRTargetMC", ExactSpelling = true)]
    public static extern void InitializeAVRTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeBPFTargetMC", ExactSpelling = true)]
    public static extern void InitializeBPFTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeHexagonTargetMC", ExactSpelling = true)]
    public static extern void InitializeHexagonTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLanaiTargetMC", ExactSpelling = true)]
    public static extern void InitializeLanaiTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLoongArchTargetMC", ExactSpelling = true)]
    public static extern void InitializeLoongArchTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMipsTargetMC", ExactSpelling = true)]
    public static extern void InitializeMipsTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMSP430TargetMC", ExactSpelling = true)]
    public static extern void InitializeMSP430TargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeNVPTXTargetMC", ExactSpelling = true)]
    public static extern void InitializeNVPTXTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializePowerPCTargetMC", ExactSpelling = true)]
    public static extern void InitializePowerPCTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeRISCVTargetMC", ExactSpelling = true)]
    public static extern void InitializeRISCVTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSparcTargetMC", ExactSpelling = true)]
    public static extern void InitializeSparcTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSPIRVTargetMC", ExactSpelling = true)]
    public static extern void InitializeSPIRVTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSystemZTargetMC", ExactSpelling = true)]
    public static extern void InitializeSystemZTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeVETargetMC", ExactSpelling = true)]
    public static extern void InitializeVETargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeWebAssemblyTargetMC", ExactSpelling = true)]
    public static extern void InitializeWebAssemblyTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeX86TargetMC", ExactSpelling = true)]
    public static extern void InitializeX86TargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeXCoreTargetMC", ExactSpelling = true)]
    public static extern void InitializeXCoreTargetMC();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAArch64AsmPrinter", ExactSpelling = true)]
    public static extern void InitializeAArch64AsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAMDGPUAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeAMDGPUAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeARMAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeARMAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAVRAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeAVRAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeBPFAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeBPFAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeHexagonAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeHexagonAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLanaiAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeLanaiAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLoongArchAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeLoongArchAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMipsAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeMipsAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMSP430AsmPrinter", ExactSpelling = true)]
    public static extern void InitializeMSP430AsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeNVPTXAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeNVPTXAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializePowerPCAsmPrinter", ExactSpelling = true)]
    public static extern void InitializePowerPCAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeRISCVAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeRISCVAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSparcAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeSparcAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSPIRVAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeSPIRVAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSystemZAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeSystemZAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeVEAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeVEAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeWebAssemblyAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeWebAssemblyAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeX86AsmPrinter", ExactSpelling = true)]
    public static extern void InitializeX86AsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeXCoreAsmPrinter", ExactSpelling = true)]
    public static extern void InitializeXCoreAsmPrinter();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAArch64AsmParser", ExactSpelling = true)]
    public static extern void InitializeAArch64AsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAMDGPUAsmParser", ExactSpelling = true)]
    public static extern void InitializeAMDGPUAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeARMAsmParser", ExactSpelling = true)]
    public static extern void InitializeARMAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAVRAsmParser", ExactSpelling = true)]
    public static extern void InitializeAVRAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeBPFAsmParser", ExactSpelling = true)]
    public static extern void InitializeBPFAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeHexagonAsmParser", ExactSpelling = true)]
    public static extern void InitializeHexagonAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLanaiAsmParser", ExactSpelling = true)]
    public static extern void InitializeLanaiAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLoongArchAsmParser", ExactSpelling = true)]
    public static extern void InitializeLoongArchAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMipsAsmParser", ExactSpelling = true)]
    public static extern void InitializeMipsAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMSP430AsmParser", ExactSpelling = true)]
    public static extern void InitializeMSP430AsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializePowerPCAsmParser", ExactSpelling = true)]
    public static extern void InitializePowerPCAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeRISCVAsmParser", ExactSpelling = true)]
    public static extern void InitializeRISCVAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSparcAsmParser", ExactSpelling = true)]
    public static extern void InitializeSparcAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSystemZAsmParser", ExactSpelling = true)]
    public static extern void InitializeSystemZAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeVEAsmParser", ExactSpelling = true)]
    public static extern void InitializeVEAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeWebAssemblyAsmParser", ExactSpelling = true)]
    public static extern void InitializeWebAssemblyAsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeX86AsmParser", ExactSpelling = true)]
    public static extern void InitializeX86AsmParser();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAArch64Disassembler", ExactSpelling = true)]
    public static extern void InitializeAArch64Disassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAMDGPUDisassembler", ExactSpelling = true)]
    public static extern void InitializeAMDGPUDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeARMDisassembler", ExactSpelling = true)]
    public static extern void InitializeARMDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeAVRDisassembler", ExactSpelling = true)]
    public static extern void InitializeAVRDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeBPFDisassembler", ExactSpelling = true)]
    public static extern void InitializeBPFDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeHexagonDisassembler", ExactSpelling = true)]
    public static extern void InitializeHexagonDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLanaiDisassembler", ExactSpelling = true)]
    public static extern void InitializeLanaiDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeLoongArchDisassembler", ExactSpelling = true)]
    public static extern void InitializeLoongArchDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMipsDisassembler", ExactSpelling = true)]
    public static extern void InitializeMipsDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeMSP430Disassembler", ExactSpelling = true)]
    public static extern void InitializeMSP430Disassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializePowerPCDisassembler", ExactSpelling = true)]
    public static extern void InitializePowerPCDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeRISCVDisassembler", ExactSpelling = true)]
    public static extern void InitializeRISCVDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSparcDisassembler", ExactSpelling = true)]
    public static extern void InitializeSparcDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeSystemZDisassembler", ExactSpelling = true)]
    public static extern void InitializeSystemZDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeVEDisassembler", ExactSpelling = true)]
    public static extern void InitializeVEDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeWebAssemblyDisassembler", ExactSpelling = true)]
    public static extern void InitializeWebAssemblyDisassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeX86Disassembler", ExactSpelling = true)]
    public static extern void InitializeX86Disassembler();

    [DllImport("libLLVM", CallingConvention = CallingConvention.Cdecl, EntryPoint = "LLVMInitializeXCoreDisassembler", ExactSpelling = true)]
    public static extern void InitializeXCoreDisassembler();

    [return: NativeTypeName("LLVMBool")]
    public static int InitializeNativeTarget()
    {
        switch (RuntimeInformation.ProcessArchitecture)
        {
            case Architecture.X86:
            case Architecture.X64:
            {
                InitializeX86TargetInfo();
                InitializeX86Target();
                InitializeX86TargetMC();
                return 0;
            }

            case Architecture.Arm:
            case Architecture.Armv6:
            {
                InitializeARMTargetInfo();
                InitializeARMTarget();
                InitializeARMTargetMC();
                return 0;
            }

            case Architecture.Arm64:
            {
                InitializeAArch64TargetInfo();
                InitializeAArch64Target();
                InitializeAArch64TargetMC();
                return 0;
            }

            case Architecture.Wasm:
            {
                InitializeWebAssemblyTargetInfo();
                InitializeWebAssemblyTarget();
                InitializeWebAssemblyTargetMC();
                return 0;
            }

            case Architecture.S390x:
            {
                InitializeSystemZTargetInfo();
                InitializeSystemZTarget();
                InitializeSystemZTargetMC();
                return 0;
            }

            case Architecture.LoongArch64:
            {
                InitializeLoongArchTargetInfo();
                InitializeLoongArchTarget();
                InitializeLoongArchTargetMC();
                return 0;
            }

            case Architecture.Ppc64le:
            {
                InitializePowerPCTargetInfo();
                InitializePowerPCTarget();
                InitializePowerPCTargetMC();
                return 0;
            }


            default:
            {
                return 1;
            }
        }
    }

    [return: NativeTypeName("LLVMBool")]
    public static int InitializeNativeAsmParser()
    {
        switch (RuntimeInformation.ProcessArchitecture)
        {
            case Architecture.X86:
            case Architecture.X64:
            {
                InitializeX86AsmParser();
                return 0;
            }

            case Architecture.Arm:
            case Architecture.Armv6:
            {
                InitializeARMAsmParser();
                return 0;
            }

            case Architecture.Arm64:
            {
                InitializeAArch64AsmParser();
                return 0;
            }

            case Architecture.Wasm:
            {
                InitializeWebAssemblyAsmParser();
                return 0;
            }

            case Architecture.S390x:
            {
                InitializeSystemZAsmParser();
                return 0;
            }

            case Architecture.LoongArch64:
            {
                InitializeLoongArchAsmParser();
                return 0;
            }

            case Architecture.Ppc64le:
            {
                InitializePowerPCAsmParser();
                return 0;
            }


            default:
            {
                return 1;
            }
        }
    }

    [return: NativeTypeName("LLVMBool")]
    public static int InitializeNativeAsmPrinter()
    {
        switch (RuntimeInformation.ProcessArchitecture)
        {
            case Architecture.X86:
            case Architecture.X64:
            {
                InitializeX86AsmPrinter();
                return 0;
            }

            case Architecture.Arm:
            case Architecture.Armv6:
            {
                InitializeARMAsmPrinter();
                return 0;
            }

            case Architecture.Arm64:
            {
                InitializeAArch64AsmPrinter();
                return 0;
            }

            case Architecture.Wasm:
            {
                InitializeWebAssemblyAsmPrinter();
                return 0;
            }

            case Architecture.S390x:
            {
                InitializeSystemZAsmPrinter();
                return 0;
            }

            case Architecture.LoongArch64:
            {
                InitializeLoongArchAsmPrinter();
                return 0;
            }

            case Architecture.Ppc64le:
            {
                InitializePowerPCAsmPrinter();
                return 0;
            }


            default:
            {
                return 1;
            }
        }
    }

    [return: NativeTypeName("LLVMBool")]
    public static int InitializeNativeDisassembler()
    {
        switch (RuntimeInformation.ProcessArchitecture)
        {
            case Architecture.X86:
            case Architecture.X64:
            {
                InitializeX86Disassembler();
                return 0;
            }

            case Architecture.Arm:
            case Architecture.Armv6:
            {
                InitializeARMDisassembler();
                return 0;
            }

            case Architecture.Arm64:
            {
                InitializeAArch64Disassembler();
                return 0;
            }

            case Architecture.Wasm:
            {
                InitializeWebAssemblyDisassembler();
                return 0;
            }

            case Architecture.S390x:
            {
                InitializeSystemZDisassembler();
                return 0;
            }

            case Architecture.LoongArch64:
            {
                InitializeLoongArchDisassembler();
                return 0;
            }

            case Architecture.Ppc64le:
            {
                InitializePowerPCDisassembler();
                return 0;
            }


            default:
            {
                return 1;
            }
        }
    }
}
