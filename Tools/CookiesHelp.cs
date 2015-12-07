using System;
using System.Web;

namespace Tools
{
    using Config;

    /// <summary>
    /// Cookie操作类
    /// </summary>
    public static class CookiesHelp
    {
        /// <summary>
        /// cookies加密方式(DES二次加密)
        /// </summary>
        private static string JiaCoo(string str)
        {
            return Encrypt.DESEncrypt(Encrypt.DESEncrypt(str));
        }
        /// <summary>
        /// cookies加密方式
        /// </summary>
        private static string JieCoo(string str)
        {
            return Encrypt.DESDecrypt(Encrypt.DESDecrypt(str));
        }

        public static void SetCookie(string cookieKeyName, string strKeyValue, int expiresDays = 7)
        {
            SetCookie(cookieKeyName, strKeyValue, expiresDays, KeyCenter.KeyCookiesDomain, "/");
        }
        /// <summary>
        /// 创建cookies对象，并设置value值，修改cookies的value值也用这个方法，因为对cookies修改必须重新设Expires
        /// </summary>
        /// <param name="cookieKeyName">cookies对象名</param>
        /// <param name="cooKeyValue">cookie对象Value值</param>
        /// <param name="iExpires">cookie对象有效时间(此处是小时)</param>
        /// <param name="strDomains">cookie作用域</param>
        /// <param name="strPath">cookie传输的虚拟路径</param>
        public static void SetCookie(string cookieKeyName, string cooKeyValue, int expiresDays, string strDomains, string strPath)
        {
            if (string.IsNullOrEmpty(cookieKeyName) || string.IsNullOrEmpty(cooKeyValue))
                return;

            HttpCookie objCookie = new HttpCookie(cookieKeyName.Trim());
            objCookie.Value = JiaCoo(cooKeyValue.Trim());
            objCookie.Expires = DateTime.Now.AddDays(expiresDays > 0 ? expiresDays : 0);

            string _strDomain = SelectDomain(strDomains);
            if (_strDomain.Length > 0)
            {
                objCookie.Domain = _strDomain;
            }

            objCookie.Path = strPath.Trim();

            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

        /// <summary>
        /// 写入到同一个Cookies对象
        /// </summary>
        /// <param name="cookieName">cookie对象名</param>
        /// <param name="key">cookie键名</param>
        /// <param name="value">cookie键值</param>
        /// <param name="keepCookiesDays">cookie保存时间(天数)</param>
        public static void SetCookieItem(string cookieName, string key, string value, int keepCookiesDays = 7)
        {
            if (string.IsNullOrWhiteSpace(cookieName) ||
                string.IsNullOrWhiteSpace(key) ||
                string.IsNullOrWhiteSpace(value))
                return;

            if (HttpContext.Current.Request.Cookies[cookieName] == null)
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Expires = DateTime.Now.AddDays(keepCookiesDays);
                cookie.Values.Add(key, JiaCoo(value));

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static void DeleteCookies(string cookieName)
        {
            DeleteCookies(cookieName, KeyCenter.KeyCookiesDomain);
        }
        public static void DeleteCookies(string cookieName, string cookiesDomains)
        {
            DeleteCookies(cookieName, cookiesDomains, "/");
        }
        public static void DeleteCookies(string cookieName, string cookiesDomains, string strPath)
        {
            HttpCookie objCookie = new HttpCookie(cookieName.Trim());
            string _strDomain = SelectDomain(cookiesDomains);
            if (_strDomain.Length > 0)
            {
                objCookie.Domain = _strDomain;
            }

            objCookie.Path = strPath.Trim();
            objCookie.Expires = DateTime.Now.AddYears(-1); //让其过期无效
            HttpContext.Current.Response.Cookies.Add(objCookie);
            //HttpContext.Current.Response.Cookies.Remove(cookieName);
        }
        public static void DeleteCookiesKey(string cookieName, string cookieKey)
        {
            if (string.IsNullOrEmpty(cookieKey) || string.IsNullOrEmpty(cookieKey))
                return;

            var response = HttpContext.Current.Response;
            if (response == null) return;

            var cookie = GetCookie(cookieName);
            if (cookie != null && cookie.HasKeys)
            {
                cookie.Values.Remove(cookieKey);
            }
        }

        public static HttpCookie GetCookie(string strCookieName)
        {
            if (string.IsNullOrWhiteSpace(strCookieName)) return null;
            return HttpContext.Current.Request.Cookies[strCookieName] ?? null;
        }
        public static string GetCookieValue(string CookieName)
        {
            var cookies = GetCookie(CookieName);
            if (cookies != null)//&& cookies.HasKeys)
            {
                var cookiesValue = cookies.Value ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(cookiesValue))
                {
                    try
                    {
                        return JieCoo(cookiesValue);
                    }
                    finally
                    {
                    }
                }
            }

            return string.Empty;
        }
        public static string GetCookieValue(string CookieName, string cookiesKey)
        {
            var cookies = GetCookie(CookieName);
            if (cookies != null && cookies.HasKeys)
            {
                var cookiesValue = cookies[cookiesKey] ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(cookiesValue))
                {
                    try
                    {
                        return JieCoo(cookiesValue);
                    }
                    finally
                    {
                    }
                }
            }
            return string.Empty;
        }

        #region 定位Cookies作用域

        /*
         * 相同的所有Cookie 在客户端都存在一个文件中;
         * Cookie之间以”*”分割,每个Cookie的第一行是 Cookie 的名称，第二行是值,
         * 第三行是Domain属性＋Path属性组成的一个字符串，指示此Cookie的作用域;
         * 
         * Request.Cookies 属性中包含了客户端发送到服务器的所有Cookie的集合，
         * 只有在请求URL的作用范围内的Cookie才会被浏览器连同Http请求一起发送到服务器,
         */
        /// <summary>
        /// 将Cookie定位到正确的域
        /// </summary>
        /// <param name="strDomains">cookie作用域</param>
        /// <returns>作用域</returns>
        private static string SelectDomain(string strDomains)
        {
            if (strDomains.Trim().Length == 0) return "";

            string _thisDomain = HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
            bool _isLocalServer = !_thisDomain.Contains(".");

            string _strDomain = KeyCenter.KeyCookiesDomain;

            string[] _strDomains = strDomains.Split(';');
            for (int i = 0; i < _strDomains.Length; i++)
            {
                if (!_thisDomain.Contains(_strDomains[i].Trim()))
                    continue;

                _strDomain = _isLocalServer ? "" : _strDomains[i].Trim();
                break;
            }

            return _strDomain;
        }

        #endregion
    }
}