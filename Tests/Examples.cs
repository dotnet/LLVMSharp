namespace Tests
{
    using LLVMSharp.API;
    using System.Runtime.InteropServices;
    using NUnit.Framework;

    public class Examples
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate int BinaryInt32Operation(int op1, int op2);

        [Test]
        public void Intro()
        {
            using(var module = Module.Create("LLVMSharpIntro"))
            {
                var def = module.AddFunction(
                    Type.Int32, "sum", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.Parameters[0];
                        var p2 = f.Parameters[1];
                        var add = b.CreateAdd(p1, p2);
                        var ret = b.CreateRet(add);
                    });
                module.Verify();

                Initialize.X86.All();
                using (var engine = ExecutionEngine.CreateMCJITCompilerForModule(module))
                {
                    var function = engine.GetDelegate<BinaryInt32Operation>(def);
                    var result = function(2, 2);
                    Assert.AreEqual(4, result);
                }
            }
        }
    }
}
