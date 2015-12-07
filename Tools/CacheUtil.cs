using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace Tools
{
    /// <summary>
    /// 简单缓存常用操作
    /// Autho       ：zhouzhilong
    /// Version     ：1.1
    /// LastEditTime：2011-10-10
    /// </summary>
    public class CacheUtil
    {
        public CacheUtil() { }

        /// <summary>
        /// 读取缓存对象
        /// </summary>
        public static object GetCache(string cacheKey)
        {
            object cacheData = HttpContext.Current.Cache[cacheKey];
            return cacheData;
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="cacheKey"></param>缓存键
        /// <param name="valueObj">缓存对象</param>
        /// <param name="durationMinutes">缓存时间，分钟</param>
        /// <param name="cachePriority">缓存优先级，默认Default</param>
        public static bool InsertCach(string cacheKey, object valueObj,
            int durationMinutes = 60,
            CacheItemPriority cachePriority = CacheItemPriority.Default)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                return false;
            }

            CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);

            HttpContext.Current.Cache.Insert(
                cacheKey,
                valueObj,
                null,
                DateTime.Now.AddMinutes(durationMinutes),
                Cache.NoSlidingExpiration,
                cachePriority,
                callBack
            );

            return true;
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="context">HttpContext对象，多线程下可能为空</param>
        /// <param name="cacheKey">缓存键</param>
        /// <param name="valueObj">缓存对象</param>
        /// <param name="durationMinutes">缓存时间，分钟</param>
        /// <param name="cachePriority">缓存优先级，默认Default</param>
        public static bool InsertCachAsync(HttpContext context, string cacheKey, object valueObj,
            int durationMinutes = 60, CacheItemPriority cachePriority = CacheItemPriority.Default)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                return false;
            }

            CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);

            context.Cache.Insert(
                cacheKey,
                valueObj,
                null,
                DateTime.Now.AddMinutes(durationMinutes),
                Cache.NoSlidingExpiration,
                cachePriority,
                callBack
            );

            return true;
        }

        /// <summary>
        /// 判断缓存对象是否存在
        /// </summary>
        public static bool IsExist(string strKey)
        {
            return HttpContext.Current.Cache[strKey] != null;
        }

        /// <summary>
        /// 删除缓存对象
        /// </summary>
        public static void Remove(string strKey)
        {
            HttpContext.Current.Cache.Remove(strKey);
        }

        /// <summary>
        /// 清除所有缓存对象
        /// </summary>
        public static void Clear()
        {
            IDictionaryEnumerator enu = HttpContext.Current.Cache.GetEnumerator();
            while (enu.MoveNext())
            {
                Remove(enu.Key.ToString());
            }
        }

        public static CacheItemRemovedReason Reason;
        /// <summary>
        /// 此方法在值失效之前调用，可以用于在失效之前更新数据库，或从数据库重新获取数据
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="obj"></param>
        /// <param name="reason"></param>
        private static void onRemove(string key, object value, CacheItemRemovedReason reason)
        {
            Reason = reason;
            //....
        }

        //...

    }
}