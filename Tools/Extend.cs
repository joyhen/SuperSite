using System;
using System.Threading;
using System.Collections.Generic;

namespace Tools
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class Extend
    {
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

        /// <summary>
        /// List对象数据异步写入缓存
        /// </summary>
        public static List<T> AsyncInsertCache<T>(
            this List<T> listdata, string cacheKey, int cacheMinutes = 30) where T : class
        {
            if (listdata == null || listdata.Count == 0) return null;

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
