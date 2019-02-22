namespace LLVMSharp.Tests
{
    using NUnit.Framework;
    using System;

    public class Bindings
    {
        [Test]
        public void StringMarshaling()
        {
            var mod = LLVM.ModuleCreateWithName("string_marshaling_test");

            var param_types = new LLVMTypeRef[0];
            var func_type = LLVM.FunctionType(LLVM.Int32Type(), param_types, false);
            var main = LLVM.AddFunction(mod, "main", func_type);

            const string BasicBlockName = "entry";
            var entry = LLVM.AppendBasicBlock(main, BasicBlockName);

            var builder = LLVM.CreateBuilder();
            LLVM.PositionBuilderAtEnd(builder, entry);
            var ret = LLVM.BuildRet(builder, LLVM.ConstInt(LLVM.Int32Type(), 0ul, new LLVMBool(false)));

            if (LLVM.VerifyModule(mod, LLVMVerifierFailureAction.LLVMPrintMessageAction, out var error) != new LLVMBool(true))
            {
                Console.WriteLine($"Error: {error}");
            }

            var basicBlockName = LLVM.GetBasicBlockName(entry);
            Assert.AreEqual(BasicBlockName, basicBlockName);

            var valueName = LLVM.GetValueName(ret);
            Assert.IsEmpty(valueName);

            var layout = LLVM.GetDataLayout(mod);
            Assert.IsEmpty(layout);

            var moduleTarget = LLVM.GetTarget(mod);
            Assert.IsEmpty(moduleTarget);

            LLVM.InitializeX86TargetInfo();

            var targetName = LLVM.GetTargetName(LLVM.GetFirstTarget());
            Assert.IsTrue(targetName.Contains("x86"));

            var targetDescription = LLVM.GetTargetDescription(LLVM.GetFirstTarget());
            Assert.IsNotEmpty(targetDescription);

            LLVM.DisposeBuilder(builder);
        }
    }
}
