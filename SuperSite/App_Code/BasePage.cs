using System;

namespace SuperSite.App_Code
{
    using Tools;
    using Config;
    using Server;
    using Model.Entity;
    using Model.DTO;

    public class BasePage : System.Web.UI.Page
    {
        #region Function
        /// <summary>
        /// 检查用户登录情况
        /// </summary>
        public bool CheckUserLogin()
        {
            var username = GetSession(KeyCenter.KeyUserLoginNameSession) ?? "";
            if (NotEmptyString(username.ToString())) return true;

            var cookies = CookiesHelp.GetCookieValue(KeyCenter.KeyCookiesLoginUserName);
            if (!NotEmptyString(cookies)) return false;

            var cookiesUser = JsonUtils.DeserializeObject<SysUser>(cookies);
            if (cookiesUser != null &&
                 NotEmptyString(cookiesUser.UserName) &&
                 NotEmptyString(cookiesUser.RealName) &&
                 NotEmptyString(cookiesUser.Password))
            {
                var userdata = new LoginService().UserLogin(cookiesUser.UserName, cookiesUser.Password, false);
                if (userdata != null && userdata.success && userdata.value.Id > 0)
                {
                    currentUser = userdata.value;   //set current user
                    SetSession(KeyCenter.KeyUserLoginNameSession, currentUser.UserName);
                    return true;
                }
                //userdata.msg;                     //set error msg
            }

            return false;
        }
        
        #endregion

        #region Property
        private Model.Entity.SysUser currentUser;
        /// <summary>
        /// 当前用户
        /// </summary>
        protected Model.Entity.SysUser CurrentUser
        {
            get
            {
                if (currentUser != null) return currentUser;

                var username = GetSession(KeyCenter.KeyUserLoginNameSession) ?? "";
                if (NotEmptyString(username.ToString()))
                {
                    var data = new UserService().GetUserByName(username.ToString());
                    if (data.success) currentUser = data.value;
                }

                return currentUser;
            }
        }

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
        /// 系统信息
        /// </summary>
        protected DSystemSetting SystemInfo
        {
            get
            {
                var result = GetDataWithCache<DSystemSetting>(new Func<DSystemSetting>(() =>
                {
                    return BufHelp.ProtoBufDeserialize<DSystemSetting>(KeyCenter.KeySystemSettingFile);
                }), KeyCenter.KeySystemSettingCache);

                return result ?? new DSystemSetting();
            }
        }
        /// <summary>
        /// 站点信息
        /// </summary>
        protected DSiteSetting SiteInfo
        {
            get
            {
                var result = GetDataWithCache<DSiteSetting>(new Func<DSiteSetting>(() =>
                {
                    return BufHelp.ProtoBufDeserialize<DSiteSetting>(KeyCenter.KeySiteSettingFile);
                }), KeyCenter.KeySiteSettingCache);

                return result ?? new DSiteSetting();
            }
        }

        #endregion

        #region Common
        /// <summary>
        /// 分页控件
        /// </summary>
        /// <param name="PageSize">每页显示</param>
        /// <param name="CurrentIndex">当前页</param>
        /// <param name="PageCount">总页数</param>
        /// <param name="Url">跳转的URL</param>
        /// <param name="paramType">URL的其他参数<remarks>注意：该参数前面有&符号</remarks></param>
        public string HtmlPageBar(int PageSize, int CurrentIndex, int PageCount, string Url, string paramType)
        {
            System.Text.StringBuilder strb = new System.Text.StringBuilder("");
            strb.Append(" <div id=\"J_pagination\" class=\"med-pagination\"> ");
            strb.Append("   <div class=\"pages\"> ");

            if (CurrentIndex < 1 || CurrentIndex > PageCount)
            {
                strb.Append(" <a class=\"first-disabled\">首页</a><a class=\"prev-disabled\"><span><s class=\"prev_s\"></s><s class=\"prev_s2\"></s></span>上一页</a> ");
                strb.Append(" <a>亲，木有了</a> ");
                strb.Append(" <a class=\"next-disabled\"><span><s class=\"next_s\"></s><s class=\"next_s2\"></s></span>下一页</a><a class=\"last-disabled\">末页</a> ");
            }
            else
            {
                strb.Append(CurrentIndex == 1 ? " <a class=\"first-disabled\">首页</a> <a class=\"prev-disabled\"><span><s class=\"prev_s\"></s><s class=\"prev_s2\"></s></span>上一页</a> " :
                    " <a href=\"" + Url + "?p=1" + paramType + "\" title=\"首页\" class=\"first\">首页</a> <a href=\"" + Url + "?p=" + (CurrentIndex - 1).ToString() + paramType
                    + "\" title=\"上一页\" class=\"prev\"><span><s class=\"prev_s\"></s><s class=\"prev_s2\"></s></span>上一页</a> ");
                #region 只显示8个数字+...
                if ((CurrentIndex - 4) > 0)
                    strb.Append("<a href=\"" + Url + "?p=" + 1 + paramType + "\" title=\"第1页\">" + 1 + "</a>");
                if ((CurrentIndex - 5) > 0)
                    strb.Append("<a>...</a>");
                for (int i = (CurrentIndex - 3) > 0 ? (CurrentIndex - 3) : 1; i <= ((CurrentIndex + 3) <= PageCount ? (CurrentIndex + 3) : PageCount); i++)
                {
                    if (i == CurrentIndex)
                        strb.Append("<a class=\"current\" title=\"第" + i + "页\">" + i + "</a>");
                    else
                        strb.Append("<a href=\"" + Url + "?p=" + i + paramType + "\" title=\"第" + i + "页\">" + i + "</a>");
                }
                if ((CurrentIndex + 4) < PageCount)
                {
                    strb.Append("<a>...</a>");
                    strb.Append("<a href=\"" + Url + "?p=" + PageCount + paramType + "\" title=\"第" + PageCount + "页\">" + PageCount + "</a>");
                }
                #endregion
                strb.Append(CurrentIndex == PageCount ? " <a class=\"next-disabled\"><span><s class=\"next_s\"></s><s class=\"next_s2\"></s></span>下一页</a> <a class=\"last-disabled\">末页</a> " :
                    " <a href=\"" + Url + "?p=" + (CurrentIndex + 1).ToString() + paramType + "\" title=\"下一页\" class=\"next\"><span><s class=\"next_s\"></s><s class=\"next_s2\"></s></span>下一页</a> <a href=\""
                    + Url + "?p=" + PageCount.ToString() + paramType + "\" title=\"末页\" class=\"last\">末页</a>");
            }

            strb.Append("   </div> ");
            strb.Append("   <div style=\"clear:both;\"></div> ");
            strb.Append(" </div> ");
            return strb.ToString();
        }
        /// <summary>
        /// 获取数据，包含缓存（缓存有就取，没有就执行方法获取）
        /// </summary>
        /// <typeparam name="T">要获取的对象</typeparam>
        /// <param name="fn">缓存没有执行的方法</param>
        /// <param name="cachekey">缓存键</param>
        private T GetDataWithCache<T>(Func<T> fn, string cachekey) where T : class
        {
            var cachedata = CacheUtil.GetCache(cachekey) as T;
            if (cachedata == null)
            {
                if (fn == null) return null;

                var fr = fn.Invoke().AsyncInsertCache(cachekey);
                return fr;
            }

            return cachedata;
        }
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
            var ss = Session[key] ?? "";
            return ss.ToString();
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
        protected bool NotEmptyString(string str)
        {
            return (!string.IsNullOrWhiteSpace(str) && str.Trim().Length > 0);
        }

        /// <summary>
        /// 请求响应后的输出
        /// </summary>
        /// <param name="msg">错误内容</param>
        protected void Outmsg(string msg)
        {
            Outmsg(false, outmsg: msg);
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
                msg = success ? "" : outmsg,
                data = outdata
            }));
            Response.End();
        }

        /// <summary>
        /// 脚注
        /// </summary>
        protected string SystemCopyRight(bool isindex = false)
        {
            string srcipt = @"
    <script type=""text/javascript"">
        var _glang = '{0}';
        var globalRequestUrl = '{1}';
    </script>";

            var year = DateTime.Now.Year.ToString() + "-" + (DateTime.Now.Year + 1).ToString();
            string indexcss = isindex ? "" : @" style=""margin-top: 400px; display: block!important;""";

            string url = @"<a href=""http://www.id124.com"" target=""_blank"">{0}</a>";
            string str1 = string.Format(url, "艾德创意工作室");
            string str2 = string.Format(url, "id124.com");

            string outputstr = string.Format(@"<div class=""footer""{0}>Powered by <b>{1}</b>&copy;{3} &nbsp;{2}</div>", indexcss, str1, str2, year);
            return outputstr + System.Environment.NewLine + string.Format(srcipt, CurrentLanguage.ToString(), GlobalAjaxRequestUrl);
        }
        #endregion

        //...

    }
}