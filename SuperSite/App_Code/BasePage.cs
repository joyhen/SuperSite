using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperSite.App_Code
{
    using Config;
    using Server;
    using Tools;
    using Model.Entity;

    public class BasePage : System.Web.UI.Page
    {
        /// <summary>
        /// 全局当前错误内容
        /// </summary>
        public string GlobalCurrentErroeMsg = string.Empty;
        /// <summary>
        /// 全局Ajax请求地址
        /// </summary>
        public string GlobalAjaxRequestUrl
        {
            get
            {
                string tag = Request.CurrentExecutionFilePathExtension;
                return "ajax/requestaction" + tag;
            }
        }

        public bool CheckUserLogin()
        {
            var username = HttpContext.Current.Session[KeyCenter.KeyUserLoginNameSession] ?? "";
            if (!string.IsNullOrWhiteSpace(username.ToString())) return true;

            var cookies = CookiesHelp.GetCookieValue(KeyCenter.KeyCookiesLoginUserName);
            if (string.IsNullOrWhiteSpace(cookies)) return false;

            var cookiesUser = JsonUtils.DeserializeObject<SysUser>(cookies);
            if (cookiesUser != null &&
                 !string.IsNullOrWhiteSpace(cookiesUser.UserName) &&
                 !string.IsNullOrWhiteSpace(cookiesUser.RealName) &&
                 !string.IsNullOrWhiteSpace(cookiesUser.Password))
            {
                var userdata = new LoginService().UserLogin(cookiesUser.UserName, cookiesUser.Password, false);
                if (userdata != null && userdata.success && userdata.value.Id > 0)
                {
                    currentUser = userdata.value;           //set current user
                    HttpContext.Current.Session[KeyCenter.KeyUserLoginNameSession] = currentUser.UserName;
                    return true;
                }
                else
                    GlobalCurrentErroeMsg = userdata.msg;   //set error msg
            }

            return false;
        }

        private Model.Entity.SysUser currentUser;
        /// <summary>
        /// 当前用户
        /// </summary>
        protected Model.Entity.SysUser CurrentUser
        {
            get
            {
                if (currentUser != null) return currentUser;

                var username = HttpContext.Current.Session[KeyCenter.KeyUserLoginNameSession] ?? "";
                if (!string.IsNullOrWhiteSpace(username.ToString()))
                {
                    var data = new UserService().GetUserByName(username.ToString());
                    if (data.success) currentUser = data.value;
                }

                return currentUser;
            }
        }

        /// <summary>
        /// 当前系统语言
        /// </summary>
        public EnumCenter.Lang CurrentLanguage
        {
            get
            {
                return Tools.LanguageUtil.CurrentLanguage();
            }
        }

        /// <summary>
        /// 获取数据，包含缓存（缓存有就取，没有就执行方法获取）
        /// </summary>
        /// <typeparam name="T">要获取的对象</typeparam>
        /// <param name="cacheKey">缓存键</param>
        /// <param name="fn">缓存没有执行的方法</param>
        public List<T> GetDataWithCache<T>(string cacheKey, Func<List<T>> fn) where T : class
        {
            var cachedata = CacheUtil.GetCache(cacheKey) as List<T>;
            if (cachedata == null || cachedata.Count == 0)
            {
                if (fn == null) return null;

                var fr = fn.Invoke().AsyncInsertCache(cacheKey);
                return fr;
            }

            return cachedata;
        }

        #region common
        /// <summary>
        /// 用户密码加密
        /// </summary>
        protected string EncryptAdmin(string paramStr)
        {
            return Encrypt.MD5Encrypt(Encrypt.MD5Encrypt(paramStr));
        }
        /// <summary>
        /// 设置Session
        /// </summary>
        protected void SetSession(string key, object value)
        {
            Session[key] = value;
        }
        /// <summary>
        /// 获取session
        /// </summary>
        protected string GetSession(string key)
        {
            var ss = Session[key].GetHashCode();
            return ss == 0 ? string.Empty : Session[key].ToString();
        }

        /// <summary>
        /// GET请求参数
        /// </summary>
        protected string Q(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return string.Empty;

            var query = Request.QueryString[key];
            return query ?? string.Empty;
        }
        protected int QInt(string key)
        {
            int id = 0;
            int.TryParse(Q(key), out id);
            return id;
        }
        /// <summary>
        /// POST请求参数
        /// </summary>
        protected string F(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return string.Empty;

            var query = Request.Form[key];
            return query ?? string.Empty;
        }
        protected int FInt(string key)
        {
            int id = 0;
            int.TryParse(Q(key), out id);
            return id;
        }

        /// <summary>
        /// 字符串有效性检查
        /// </summary>
        protected bool IsNotEmptyString(string str)
        {
            return (!string.IsNullOrWhiteSpace(str) && str.Trim().Length > 0);
        }

        /// <summary>
        /// 请求响应后的输出
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected void Outmsg(string msg)
        {
            Outmsg(false, msg);
        }
        /// <summary>
        /// 请求响应后的输出
        /// </summary>
        /// <remarks>outmsg : "" or default(String)</remarks>
        protected void Outmsg(bool success = false, string outmsg = "", object outdata = null)
        {
            Response.Write(JsonUtils.JsonSerializer(new Model.ResultModel
            {
                success = success,
                msg = outmsg,
                data = outdata
            }));
            Response.End();
        }
        #endregion

        //...

    }
}