using System;
using System.Threading;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;

namespace Tools
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class Extend
    {
        public static Predicate<T> ToPredicate<T>(this Func<T, bool> source)
        {
            Predicate<T> result = new Predicate<T>(source);
            return result;
        }

        public static int? ToPositiveInt(this int? val)
        {
            if (val.HasValue)
                if (val.Value < 0) val = 0;

            return val;
        }

        public static bool? ToNullableBoolean(this int? val)
        {
            return val.HasValue && val.Value == 1;
        }
        public static bool ToBoolean(this int? val)
        {
            return val.HasValue && val.Value == 1;
        }

        /// <summary>
        /// 扩展比较
        /// </summary>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static List<T> MapTo<T>(this DataTable dt) where T : class, new()
        {
            var objects = new List<dynamic>();

            foreach (DataRow row in dt.Rows)
            {
                dynamic obj = new ExpandoObject();

                foreach (DataColumn column in dt.Columns)
                {
                    var x = (IDictionary<string, object>)obj;
                    x.Add(column.ColumnName, row[column.ColumnName]);
                }
                objects.Add(obj);
            }

            var retval = new List<T>();
            foreach (dynamic item in objects)
            {
                var o = new T();
                Mapper<T>.Map(item, o);
                retval.Add(o);
            }

            return retval;
        }

        public static T MapTo<T>(this DataRow row) where T : class, new()
        {
            dynamic obj = new ExpandoObject();

            foreach (DataColumn column in row.Table.Columns)
            {
                var x = (IDictionary<string, object>)obj;
                x.Add(column.ColumnName, row[column.ColumnName]);
            }

            var retval = new List<T>();

            var o = new T();
            Mapper<T>.Map(obj, o);
            retval.Add(o);

            return o;
        }

        /// <summary>
        /// 对象数据异步写入缓存
        /// </summary>
        public static T AsyncInsertCache<T>(
            this T listdata, string cacheKey, int cacheMinutes = 30) where T : class
        {
            if (listdata == null) return null;

            var context = System.Web.HttpContext.Current;

            ThreadPool.QueueUserWorkItem((state) =>
            {
                CacheUtil.InsertCachAsync(context, cacheKey, listdata, cacheMinutes);
            });

            return listdata;
        }

        //...

    }
}
