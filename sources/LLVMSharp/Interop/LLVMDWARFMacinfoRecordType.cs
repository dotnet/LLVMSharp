// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

// Ported from https://github.com/llvm/llvm-project/tree/llvmorg-11.0.0/llvm/include/llvm-c
// Original source is Copyright (c) the LLVM Project and Contributors. Licensed under the Apache License v2.0 with LLVM Exceptions. See NOTICE.txt in the project root for license information.

namespace LLVMSharp.Interop
{
    public enum LLVMDWARFMacinfoRecordType
    {
        LLVMDWARFMacinfoRecordTypeDefine = 0x01,
        LLVMDWARFMacinfoRecordTypeMacro = 0x02,
        LLVMDWARFMacinfoRecordTypeStartFile = 0x03,
        LLVMDWARFMacinfoRecordTypeEndFile = 0x04,
        LLVMDWARFMacinfoRecordTypeVendorExt = 0xff,
    }
}
