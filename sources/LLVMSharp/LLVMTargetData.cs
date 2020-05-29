using LLVMSharp.Interop;

namespace LLVMSharp
{
    public class LLVMTargetData
    {
        private readonly LLVMTargetDataRef _llvmTargetDataRef;

        public LLVMTargetData(LLVMTargetDataRef llvmTargetDataRef)
        {
            _llvmTargetDataRef = llvmTargetDataRef;
        }

        public ulong OffsetOfElement(LLVMTypeRef type, uint element)
        {
            return _llvmTargetDataRef.OffsetOfElement(type, element);
        }

        public ulong ElementAtOffset(LLVMTypeRef type, ulong offset)
        {
            return _llvmTargetDataRef.ElementAtOffset(type, offset);
        }

        public ulong SizeOfTypeInBits(LLVMTypeRef type)
        {
            return _llvmTargetDataRef.SizeOfTypeInBits(type);
        }

        public ulong StoreSizeOfType(LLVMTypeRef type)
        {
            return _llvmTargetDataRef.StoreSizeOfType(type);
        }

        public ulong ABISizeOfType(LLVMTypeRef type)
        {
            return _llvmTargetDataRef.ABISizeOfType(type);
        }

        public uint ABIAlignmentOfType(LLVMTypeRef type)
        {
            return _llvmTargetDataRef.ABIAlignmentOfType(type);
        }

        public uint CallFrameAlignmentOfType(LLVMTypeRef type)
        {
            return _llvmTargetDataRef.CallFrameAlignmentOfType(type);
        }

        public uint PreferredAlignmentOfType(LLVMTypeRef type)
        {
            return _llvmTargetDataRef.PreferredAlignmentOfType(type);
        }

        public uint PreferredAlignmentOfGlobal(LLVMValueRef globalVar)
        {
            return _llvmTargetDataRef.PreferredAlignmentOfGlobal(globalVar);
        }
    }
}
