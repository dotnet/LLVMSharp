namespace Tests
{
    using LLVMSharp.API;
    using LLVMSharp.API.Types;
    using LLVMSharp.API.Values.Constants.GlobalValues.GlobalObjects;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Module = LLVMSharp.API.Module;
    using Type = LLVMSharp.API.Type;

    public static class Utilities
    {
        public static void EnsurePropertiesWork(this object obj)
        {
            var map = new Dictionary<string, object>();
            foreach(var p in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                map.Add(p.Name, p.GetValue(obj));
            }
        }

        public static Function AddFunction(this Module module, Type returnType, string name, Type[] parameterTypes, Action<Function, IRBuilder> action)
        {
            var type = FunctionType.Create(returnType, parameterTypes);
            var func = module.AddFunction(name, type);
            var block = func.AppendBasicBlock(string.Empty);
            var builder = IRBuilder.Create(module.Context);
            builder.PositionBuilderAtEnd(block);
            action(func, builder);
            return func;
        }
    }
}
