using System;
using System.Linq;
using System.Dynamic;
using System.Reflection;
using System.Collections.Generic;

namespace Tools
{
    internal static class Mapper<T> where T : class
    {
        private static readonly Dictionary<string, PropertyInfo> PropertyMap;

        static Mapper()
        {
            PropertyMap = typeof(T).GetProperties().ToDictionary(p => p.Name.ToLower(), p => p);
        }

        public static void Map(ExpandoObject source, T destination)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (destination == null)
                throw new ArgumentNullException("destination");

            foreach (var kv in source)
            {
                PropertyInfo p;
                if (PropertyMap.TryGetValue(kv.Key.ToLower(), out p))
                {
                    var propType = p.PropertyType;
                    if (kv.Value == null)
                    {
                        if (!propType.IsByRef && propType.Name != "Nullable`1")
                        {
                            throw new ArgumentException("not nullable");
                        }
                    }
                    p.SetValue(destination, kv.Value == DBNull.Value ? default(T) : kv.Value, null);
                }
            }
        }
    }
}