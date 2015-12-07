using System;
using System.Web;

namespace SuperSite.admin
{
    public partial class loginout : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (HttpContext.Current.Request.UrlReferrer == null ||
               HttpContext.Current.Request.UrlReferrer.Host != HttpContext.Current.Request.Url.Host)
            {
                Response.Redirect("404.html");
                Response.End();
            }

            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddMilliseconds(-1);
            Response.Expires = 0;
            Response.Cache.SetNoStore();                        // 禁用缓存
            Response.Clear();                                   // 清除输出
            Response.CacheControl = "no-cache";
            Response.AppendHeader("Pragma", "No-Cache");

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Tools.CacheUtil.Clear();
            Session.Remove(Config.KeyCenter.KeyUserLoginNameSession);
            Tools.CookiesHelp.DeleteCookies(Config.KeyCenter.KeyCookiesLoginUserName);
            Response.Redirect("login.aspx");
            Response.End();
        }
    }
}