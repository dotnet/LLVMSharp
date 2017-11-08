namespace Tests
{
    using LLVMSharp.Api;
    using LLVMSharp.Api.Types.Composite;
    using LLVMSharp.Api.Values.Constants;
    using Xunit;

    public class IRBuilder
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 3)]
        [InlineData(9, 1, 10)]
        public void AddsSigned(int op1, int op2, int result)
        {
            using (var module = Module.Create("test_add"))
            {
                var def = module.DefineFunction(
                    Type.Int32, "add", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.Parameters[0];
                        var p2 = f.Parameters[1];
                        var add = b.CreateAdd(p1, p2);
                        var ret = b.CreateRet(add);
                    });

                using (var engine = module.CreateExecutionEngine())
                {
                    var func = engine.GetDelegate<Int32Int32Int32Delegate>(def);
                    Assert.Equal(result, func(op1, op2));
                }
            }
        }

        [Theory]
        [InlineData(4, 1, 2)]
        [InlineData(4, 2, 1)]
        public void ShiftsLeft(int op1, int op2, int result)
        {
            using (var module = Module.Create("test_lshift"))
            {
                var def = module.DefineFunction(
                    Type.Int32, "lshift", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.Parameters[0];
                        var p2 = f.Parameters[1];
                        var shift = b.CreateLShr(p1, p2);
                        var ret = b.CreateRet(shift);
                    });

                using (var engine = module.CreateExecutionEngine())
                {
                    var func = engine.GetDelegate<Int32Int32Int32Delegate>(def);
                    Assert.Equal(result, func(op1, op2));
                }
            }
        }

        [Theory]
        [InlineData(10, 5, 1)]
        [InlineData(5, 10, 0)]
        [InlineData(0, 0, 0)]
        public void ComparesGreaterThan(int op1, int op2, int result)
        {
            using (var module = Module.Create("test_greaterthan"))
            {
                var def = module.DefineFunction(
                    Type.Int1, "greaterthan", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.Parameters[0];
                        var p2 = f.Parameters[1];
                        var cmp = b.CreateICmp(IntPredicate.SGT, p1, p2);
                        var r = b.CreateBitCast(cmp, f.FunctionType.ReturnType);
                        var ret = b.CreateRet(r);
                    });

                using (var engine = module.CreateExecutionEngine())
                {
                    var func = engine.GetDelegate<Int32Int32Int8Delegate>(def);
                    Assert.Equal(result, func(op1, op2));
                }
            }
        }

        [Theory]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 3)]
        public void CallsFunction(int op1, int op2, int result)
        {
            using (var module = Module.Create("test_call"))
            {
                var defAdd = module.DefineFunction(
                    Type.Int32, "add", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.Parameters[0];
                        var p2 = f.Parameters[1];
                        var add = b.CreateAdd(p1, p2);
                        var ret = b.CreateRet(add);
                    });
                var defEntry = module.DefineFunction(
                    Type.Int32, "entry", new[] { Type.Int32, Type.Int32 }, (f, b) =>
                    {
                        var p1 = f.Parameters[0];
                        var p2 = f.Parameters[1];
                        var call = b.CreateCall(defAdd, p1, p2);
                        var ret = b.CreateRet(call);
                    });
                
                using (var engine = module.CreateExecutionEngine())
                {
                    var func = engine.GetDelegate<Int32Int32Int32Delegate>(defEntry);
                    Assert.Equal(result, func(op1, op2));
                }
            }
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void ReturnsConstant(uint input, int output)
        {
            using (var module = Module.Create("test_constant"))
            {
                var def = module.DefineFunction(
                    Type.Int32, "constant", new Type[0], (f, b) =>
                    {
                        var value = ConstantInt.Get(Type.Int32, input);
                        var ret = b.CreateRet(value);
                    });

                using (var engine = module.CreateExecutionEngine())
                {
                    var func = engine.GetDelegate<Int32Delegate>(def);
                    Assert.Equal(output, func());
                }
            }
        }

        [Fact]
        public void ReturnsSizeOf()
        {
            using(var module = Module.Create("test_sizeof"))
            {
                var str = StructType.Create(new[] { Type.Int32, Type.Int32 }, true);
                var def = module.DefineFunction(
                    Type.Int32, "structure", new Type[0], (f, b) =>
                    {
                        var sz = ConstantExpr.GetSizeOf(str);
                        var sz32 = b.CreateBitCast(sz, Type.Int32);
                        var ret = b.CreateRet(sz32);
                    });

                using(var engine = module.CreateExecutionEngine())
                {
                    var func = engine.GetDelegate<Int32Delegate>(def);
                    Assert.Equal(8, func());
                }
            }
        }
    }
}
