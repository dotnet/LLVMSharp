using System;
using System.Runtime.InteropServices;

namespace LLVMSharp
{
    public unsafe partial struct LLVMTargetMachineRef
    {
        public LLVMTargetMachineRef(IntPtr pointer)
        {
            Pointer = pointer;
        }

        public IntPtr Pointer;

        public static implicit operator LLVMTargetMachineRef(LLVMOpaqueTargetMachine* value)
        {
            return new LLVMTargetMachineRef((IntPtr)value);
        }

        public static implicit operator LLVMOpaqueTargetMachine*(LLVMTargetMachineRef value)
        {
            return (LLVMOpaqueTargetMachine*)value.Pointer;
        }

        public string CreateTargetDataLayout()
        {
            var pDataLayout = LLVM.CreateTargetDataLayout(this);

            if (pDataLayout is null)
            {
                return string.Empty;
            }

            var span = new ReadOnlySpan<byte>(pDataLayout, int.MaxValue);
            return span.Slice(0, span.IndexOf((byte)'\0')).AsString();
        }

        public bool TryEmitToFile(LLVMModuleRef module, string fileName, LLVMCodeGenFileType codegen, out string message)
        {
            using (var marshaledFileName = new MarshaledString(fileName))
            {
                sbyte* errorMessage;

                int result = LLVM.TargetMachineEmitToFile(this, module, marshaledFileName, codegen, &errorMessage);

                if (errorMessage is null)
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

        public void EmitToFile(LLVMModuleRef module, string fileName, LLVMCodeGenFileType codegen)
        {
            if (!TryEmitToFile(module, fileName, codegen, out string Error))
            {
                throw new ExternalException(Error);
            }
        }
    }
}
