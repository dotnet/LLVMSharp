namespace Tests
{
    using System.Collections.Generic;
    using System.Reflection;

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
    }
}
