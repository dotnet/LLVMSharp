namespace Tests
{
    using LLVMSharp.API;
    using LLVMSharp.API.Types.Composite;
    using LLVMSharp.API.Values.Constants;
    using NUnit.Framework;

    public class IR
    {
        [Test]
        public void AddsSigned()
        {
            var op1 = 0;
            var op2 = 0;
            using (var module = Module.Create("test_add"))
            {
                var def = module.AddFunction(
                    Type.Int32, "add", new[] { Type.Int32, Type.Int32 }, (f, b) =>
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
                    var func = engine.GetDelegate<Int32Int32Int32Delegate>(def);
                    var result = op1 + op2;
                    Assert.AreEqual(result, func(op1, op2));
                }
            }
        }

        [Test]
        public void ShiftsRight([Range(0, 256)] int op1, [Range(0, 8)] int op2)
        {
            using (var module = Module.Create("test_lshift"))
            {
                var def = module.AddFunction(
                    Type.Int32, "lshift", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.Parameters[0];
                        var p2 = f.Parameters[1];
                        var shift = b.CreateLShr(p1, p2);
                        var ret = b.CreateRet(shift);
                    });
                module.Verify();

                Initialize.X86.All();
                using (var engine = ExecutionEngine.CreateMCJITCompilerForModule(module))
                {
                    var func = engine.GetDelegate<Int32Int32Int32Delegate>(def);
                    var result = op1 >> op2;
                    Assert.AreEqual(result, func(op1, op2));
                }
            }
        }

        [Test]
        public void ComparesGreaterThan([Range(0, 10)] int op1, [Range(0, 10)] int op2)
        {
            using (var module = Module.Create("test_greaterthan"))
            {
                var def = module.AddFunction(
                    Type.Int1, "greaterthan", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.Parameters[0];
                        var p2 = f.Parameters[1];
                        var cmp = b.CreateICmp(IntPredicate.SGT, p1, p2);
                        var r = b.CreateBitCast(cmp, f.FunctionType.ReturnType);
                        var ret = b.CreateRet(r);
                    });
                module.Verify();

                Initialize.X86.All();
                using (var engine = ExecutionEngine.CreateMCJITCompilerForModule(module))
                {
                    var func = engine.GetDelegate<Int32Int32Int8Delegate>(def);
                    var result = op1 > op2 ? 1 : 0;
                    Assert.AreEqual(result, func(op1, op2));
                }
            }
        }

        [Test]
        public void CallsFunction([Range(0, 10)] int op1, [Range(0, 10)] int op2)
        {
            using (var module = Module.Create("test_call"))
            {
                var defAdd = module.AddFunction(
                    Type.Int32, "add", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.Parameters[0];
                        var p2 = f.Parameters[1];
                        var add = b.CreateAdd(p1, p2);
                        var ret = b.CreateRet(add);
                    });
                var defEntry = module.AddFunction(
                    Type.Int32, "entry", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.Parameters[0];
                        var p2 = f.Parameters[1];
                        var call = b.CreateCall(defAdd, p1, p2);
                        var ret = b.CreateRet(call);
                    });
                module.Verify();

                Initialize.X86.All();
                using (var engine = ExecutionEngine.CreateMCJITCompilerForModule(module))
                {
                    var func = engine.GetDelegate<Int32Int32Int32Delegate>(defEntry);
                    var result = op1 + op2;
                    Assert.AreEqual(result, func(op1, op2));
                }
            }
        }

        [Test]
        public void ReturnsConstant([Range(0, 10)] int input)
        {
            var uInput = (uint)input;
            using (var module = Module.Create("test_constant"))
            {
                var def = module.AddFunction(
                    Type.Int32, "constant", new Type[0], (f, b) =>
                    {
                        var value = ConstantInt.Get(Type.Int32, uInput);
                        var ret = b.CreateRet(value);
                    });
                module.Verify();

                Initialize.X86.All();
                using (var engine = ExecutionEngine.CreateMCJITCompilerForModule(module))
                {
                    var func = engine.GetDelegate<Int32Delegate>(def);
                    Assert.AreEqual(input, func());
                }
            }
        }

        [Test]
        public void ReturnsSizeOf()
        {
            using(var module = Module.Create("test_sizeof"))
            {
                var str = StructType.Create(new[] { Type.Int32, Type.Int32 }, true);
                var def = module.AddFunction(
                    Type.Int32, "structure", new Type[0], (f, b) =>
                    {
                        var sz = ConstantExpr.GetSizeOf(str);
                        var sz32 = b.CreateBitCast(sz, Type.Int32);
                        var ret = b.CreateRet(sz32);
                    });
                module.Verify();

                Initialize.X86.All();
                using(var engine = ExecutionEngine.CreateMCJITCompilerForModule(module))
                {
                    var func = engine.GetDelegate<Int32Delegate>(def);
                    Assert.AreEqual(8, func());
                }
            }
        }
    }
}
