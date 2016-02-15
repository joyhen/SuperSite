using System;
using System.Linq;
using System.Dynamic;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Tools
{
    using Model.DTO;

    /// <summary>
    /// 对象map、合并处理，支持dynamic
    /// <example>http://blog.csdn.net/joyhen/article/details/50314977</example>
    /// </summary>
    /// <remarks>版本1.0，里面的方法很多需要改进</remarks>
    public class Class2Map
    {
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, PropertyInfo[]>
           DynamicObjectProperties = new ConcurrentDictionary<RuntimeTypeHandle, PropertyInfo[]>();

        private static PropertyInfo[] GetObjectProperties<T>()
        {
            var type = typeof(T);
            var key = type.TypeHandle;
            PropertyInfo[] queryPts = null;

            DynamicObjectProperties.TryGetValue(key, out queryPts);

            if (queryPts == null)
            {
                queryPts = type.GetProperties();
                DynamicObjectProperties.TryAdd(key, queryPts);
            }

            return queryPts;
        }

        /// <summary>
        /// 单个对象映射
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="source">实例</param>
        /// <param name="injectAct">map方法集</param>
        /// <returns>映射后的动态对象</returns>
        public static IDictionary<string, Object> DynamicResult<T>(T source, params MapCondition[] injectAct)//where T : ICustomMap
        {
            //Predicate<T> match
            var queryPts = GetObjectProperties<T>();
            var dynamicResult = new ExpandoObject() as IDictionary<string, Object>;

            foreach (var p in queryPts)
            {
                var attributes = p.GetCustomAttributes(typeof(IngoreProperty), true);
                if (attributes.FirstOrDefault() != null) continue;

                var _name = p.Name;                     //原来是属性名
                var _value = p.GetValue(source, null);  //原来的属性值
                object _resultvalue = _value;           //最终的映射值

                if (injectAct != null)
                {
                    string _tempname = null;
                    var condition = injectAct.FirstOrDefault(x => x.Orginal == _name);
                    if (CheckChangeInfo(condition, out _tempname))
                    {
                        _resultvalue = condition.fn.Invoke(_value);
                        dynamicResult.Add(_tempname ?? _name, _resultvalue);
                        continue;
                    }
                }

                //var value = Convert.ChangeType(value，typeof(string));  
                dynamicResult.Add(_name, _resultvalue);
            }

            return dynamicResult;
        }

        /// <summary>
        /// 合并2个对象
        /// </summary>
        /// <typeparam name="TSource">对象1类型</typeparam>
        /// <typeparam name="TTarget">对象2类型</typeparam>
        /// <param name="s">对象1实例</param>
        /// <param name="t">对象2实例</param>
        /// <returns>合并后的动态对象</returns>
        public static IDictionary<string, Object> MergerObject<TSource, TTarget>(TSource s, TTarget t)
        {
            var targetPts = GetObjectProperties<TSource>();

            PropertyInfo[] mergerPts = null;
            var _type = t.GetType();
            mergerPts = _type.Name.Contains("<>") ? _type.GetProperties() : GetObjectProperties<TTarget>();

            var dynamicResult = new ExpandoObject() as IDictionary<string, Object>;

            foreach (var p in targetPts)
            {
                var attributes = p.GetCustomAttributes(typeof(IngoreProperty), true);
                if (attributes.FirstOrDefault() != null) continue;

                dynamicResult.Add(p.Name, p.GetValue(s, null));
            }
            foreach (var p in mergerPts)
            {
                var attributes = p.GetCustomAttributes(typeof(IngoreProperty), true);
                if (attributes.FirstOrDefault() != null) continue;

                dynamicResult.Add(p.Name, p.GetValue(t, null));
            }

            return dynamicResult;
        }
        /// <summary>
        /// 合并2个对象
        /// </summary>
        /// <typeparam name="TSource">对象1类型</typeparam>
        /// <typeparam name="TTarget">对象2类型</typeparam>
        /// <param name="s">对象1实例</param>
        /// <param name="t">对象2实例</param>
        /// <returns>合并后的动态对象</returns>
        public static List<IDictionary<string, Object>> MergerListObject<TSource, TTarget>(List<TSource> s, TTarget t)
        {
            var targetPts = GetObjectProperties<TSource>();

            PropertyInfo[] mergerPts = null;
            var _type = t.GetType();
            mergerPts = _type.Name.Contains("<>") ? _type.GetProperties() : GetObjectProperties<TTarget>();

            var result = new List<IDictionary<string, Object>>();

            s.ForEach(x =>
            {
                var dynamicResult = new ExpandoObject() as IDictionary<string, Object>;

                foreach (var p in targetPts)
                {
                    var attributes = p.GetCustomAttributes(typeof(IngoreProperty), true);
                    if (attributes.FirstOrDefault() != null) continue;

                    dynamicResult.Add(p.Name, p.GetValue(x, null));
                }

                foreach (var p in mergerPts)
                {
                    var attributes = p.GetCustomAttributes(typeof(IngoreProperty), true);
                    if (attributes.FirstOrDefault() != null) continue;

                    dynamicResult.Add(p.Name, p.GetValue(t, null));
                }

                result.Add(dynamicResult);
            });

            return result;
        }

        private static bool CheckChangeInfo(MapCondition condition, out string name)
        {
            name = null;

            bool result = condition != null &&
                          condition.fn != null &&
                          !string.IsNullOrWhiteSpace(condition.Orginal);//&&
                        //!string.IsNullOrWhiteSpace(condition.NewName);

            if (result)
            {
                var temp = condition.NewName;
                name = (string.IsNullOrWhiteSpace(temp) || temp.Trim().Length == 0) ? null : temp;
            }

            return result;
        }
    }
}