using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    using Config;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.Caching;

    internal class Connection
    {
        public static IDbConnection GetConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            return connection;
        }
        public static IDbConnection GetOpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static string ConnectionString
        {
            get
            {
                try
                {
                    string myconnectiongstring = CacheHelper.GetCache(KeyCenter.KeyDataBaseConnectionSession) as String;
                    if (string.IsNullOrWhiteSpace(myconnectiongstring) || myconnectiongstring.Trim().Length == 0)
                    {
                        myconnectiongstring = ConfigurationManager.ConnectionStrings[KeyCenter.KeyDataBaseConnectionKey].ConnectionString;
                        CacheHelper.InsertCach(KeyCenter.KeyDataBaseConnectionSession, myconnectiongstring, cachePriority: CacheItemPriority.High);
                    }
                    return myconnectiongstring;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        //...

    }

    internal class CacheHelper
    {
        public static object GetCache(string cacheKey)
        {
            object cacheData = HttpContext.Current.Cache[cacheKey];
            return cacheData;
        }

        public static bool InsertCach(string cacheKey, object valueObj,
            int durationMinutes = 60,
            CacheItemPriority cachePriority = CacheItemPriority.Default)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                return false;
            }

            HttpContext.Current.Cache.Insert(
                cacheKey,
                valueObj,
                null,
                DateTime.Now.AddMinutes(durationMinutes),
                Cache.NoSlidingExpiration,
                cachePriority,
                null
            );

            return true;
        }
    }
}
