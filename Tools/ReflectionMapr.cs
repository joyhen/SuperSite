using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Tools
{
    public class ReflectionMapr<T> where T : class
    {
        /// <summary>
        /// ajax参数解析后的对象属性集
        /// </summary>
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, List<string>>
            AjaxParam2AjaxArgProperties = new ConcurrentDictionary<RuntimeTypeHandle, List<string>>();

        static ReflectionMapr()
        {
            var type = typeof(T);
            var properties = type.GetProperties();

            var propertyNames = type.GetProperties().Select(x => x.Name).ToList();
            AjaxParam2AjaxArgProperties.TryAdd(type.TypeHandle, propertyNames);
        }

        /// <summary>
        /// ajax传递过来的参数对应的目标对象
        /// </summary>
        /// <returns>缓存下</returns>
        public static List<string> GetAjaxParamName()
        {
            //暂时不支持嵌套类型，后期需要修改
            var ajaxArgName = new List<string>();
            AjaxParam2AjaxArgProperties.TryGetValue(typeof(T).TypeHandle, out ajaxArgName);
            return ajaxArgName;
        }

        //...

    }
}