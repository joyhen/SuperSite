using System;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace SuperSite.App_Code
{
    using Tools;
    using Config;
    using SuperSite.admin.control;

    public class BasePageBusiness : BasePage
    {
        /// <summary>
        /// 控件列表
        /// <remarks>用来装载页面上的所有多语言自定义控件</remarks>
        /// </summary>
        private readonly List<Control> pageLanguageControl;

        public BasePageBusiness()
        {
            pageLanguageControl = new List<Control>();
        }

        protected override void OnInit(EventArgs e)
        {
            if (!CheckUserLogin())
            {
                this.PageMessage("系统尚未登录或登录超时！", "/Admin/login.aspx");
                return;
            }
            base.OnInit(e);
        }

        /// <summary>
        /// Page_Load事件，建议基类从写此方法
        /// </summary>
        public virtual void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetPageLanguageControl(Controls);
                SetControlLanguage();
            }
        }

        #region 语言用户控件设置
        /// <summary>
        /// 获取语言控件
        /// </summary>
        private void GetPageLanguageControl(ControlCollection langc)
        {
            foreach (Control c in langc)
            {
                if (c is admin.control.ILanguageControl)
                    pageLanguageControl.Add(c);
                else if (c.HasControls())
                    GetPageLanguageControl(c.Controls);
            }
        }
        /// <summary>
        /// 设置控件的语言集
        /// </summary>
        private void SetControlLanguage()
        {
            if (pageLanguageControl == null || pageLanguageControl.Count == 0)
                return;

            var modelName = GetRequestPageRenderLanguageModel();
            if (!NotEmptyString(modelName)) return;

            var querySource = GetPageLabelData(modelName);

            foreach (Control obj in pageLanguageControl)
            {
                var langControl = obj as admin.control.langlabel;
                if (langControl != null)
                {
                    var data = querySource.FirstOrDefault(x => x.LabelName == obj.ID);
                    if (data == null) continue;
                    langControl.Language = data;
                    langControl.RenderHtmlType = data.Lan;
                }
            }
        }

        private XDocument xdoc;
        private XDocument XDoc
        {
            get
            {
                if (xdoc == null)
                {
                    try
                    {
                        var xmlpath = KeyCenter.KeyBaseDirectory + "Config\\PageLabel.xml";
                        xdoc = XDocument.Load(xmlpath);
                    }
                    catch (Exception ex)
                    {
                        LogHelp.WriteLog("加载标签语言配置文件失败", ex);
                    }
                }

                return xdoc;
            }
        }
        /// <summary>
        /// 标签数据源
        /// </summary>
        private List<LanguageLabel> GetPageLabelData(string langModelName)
        {
            var result = new List<LanguageLabel>();
            langModelName = langModelName.Trim().ToLower();

            //当前已加载的标签缓存数据
            var cachedata = CacheUtil.GetCache(KeyCenter.KeyLanguageLabelCache) as Dictionary<string, List<LanguageLabel>>;
            if (cachedata != null)
            {
                result = cachedata.FirstOrDefault(x => x.Key == langModelName).Value;
                if (result != null) return result;      //加载过了，缓存有直接输出
                else result = new List<LanguageLabel>();
            }

            if (XDoc != null)
            {
                var items = XDoc.Root.Element(langModelName).Elements("item");
                foreach (var e in items)
                {
                    result.Add(new LanguageLabel
                    {
                        LanguageList = GetLanguage(e),
                        LabelName = (string)e.Attribute("id"),
                        Lan = GetLabelLang((string)e.Attribute("type"))
                    });
                }

                if (cachedata == null)
                {
                    cachedata = new Dictionary<string, List<LanguageLabel>>();
                }
                cachedata.Add(langModelName, result);   //添加到要缓存的数据对象
            }

            if (cachedata != null && cachedata.Count > 0)
                CacheUtil.InsertCach(KeyCenter.KeyLanguageLabelCache, cachedata, durationMinutes: 60 * 24);

            return result;
        }

        /// <summary>
        /// 标签类型
        /// </summary>
        private BaseUserControl.RenderType GetLabelLang(string strlang)
        {
            if (!NotEmptyString(strlang))
                return BaseUserControl.RenderType.@null;

            return EnumUtils.GetEnumBuyStr<BaseUserControl.RenderType>(strlang);
        }

        /// <summary>
        /// 从xml节点对象构建预言集
        /// </summary>
        private Model.DTO.CCTuple GetLanguage(XElement e)
        {
            if (e != null)
            {
                return new Model.DTO.CCTuple(
                    (string)e.Attribute(EnumCenter.Lang.zhcn.ToString()),
                    (string)e.Attribute(EnumCenter.Lang.zhtw.ToString()),
                    (string)e.Attribute(EnumCenter.Lang.en.ToString())
                );
            }

            return null;
        }
        /// <summary>
        /// 获取当前请求的页面的语言渲染模块名
        /// </summary>
        /// <remarks>注意URL伪静态的情况下无后缀名</remarks>
        private string GetRequestPageRenderLanguageModel()
        {
            string currentpage = Request.CurrentExecutionFilePath;          // “/admin/login.aspx”
            string pageextend = Request.CurrentExecutionFilePathExtension;  // “.aspx”

            var arr = currentpage.Split('/');
            var result = arr[arr.Length - 1];

            if (NotEmptyString(pageextend))
            {
                return result.Replace(pageextend, "");
            }

            return result;
        }
        #endregion

        /// <summary>
        /// 页面输出提示
        /// </summary>
        /// <param name="pageMsg">页面提示信息</param>
        /// <param name="go2Url">跳转地址（倒退步数小于等于0就跳转到它）</param>
        /// <param name="BackStep">倒退步数（小于等于0，就转到go2Url）</param>
        protected void PageMessage(string pageMsg, string go2Url = "", int backStep = 0)
        {
            PageMessage(pageMsg ?? "未知错误退出", go2Url, (string.IsNullOrWhiteSpace(go2Url) && backStep == 0) ? 1 : backStep, 2);
        }
        protected void PageMessage(string pageMsg, string go2Url, int BackStep, int Seconds)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>\r\n");
            sb.Append("<html xmlns='http://www.w3.org/1999/xhtml'>\r\n");
            sb.Append("<head>\r\n");
            sb.Append("<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />\r\n");
            sb.Append("<head>\r\n");
            sb.Append("<title>系统提示</title>\r\n");
            sb.Append("<style>\r\n");
            sb.Append("body {padding:0; margin:0; }\r\n");
            sb.Append("#infoBox{padding:0; margin:0; position:absolute; top:40%; width:100%; text-align:center;}\r\n");
            sb.Append("#info{padding:0; margin:0;position:relative; top:-40%; right:0; border:0px #B4E0F7 solid; text-align:center;}\r\n");
            sb.Append(".a_goto{ color:#ff0000; text-decoration:underline;}");
            sb.Append("</style>\r\n");
            sb.Append("<script language=\"javascript\">\r\n");
            sb.Append("var seconds=" + Seconds + ";\r\n");
            sb.Append("for(i=1;i<=seconds;i++)\r\n");
            sb.Append("{window.setTimeout(\"update(\" + i + \")\", i * 1000);}\r\n");
            sb.Append("function update(num)\r\n");
            sb.Append("{\r\n");
            sb.Append("if(num == seconds)\r\n");
            if (BackStep > 0)
                sb.Append("{ history.go(" + (0 - BackStep) + "); }\r\n");
            else
            {
                if (go2Url != "")
                    sb.Append("{ top.location.href='" + go2Url + "'; }\r\n");
                else
                    sb.Append("{window.close();}\r\n");
            }
            sb.Append("else\r\n");
            sb.Append("{ }\r\n");
            sb.Append("}\r\n");
            sb.Append("</script>\r\n");
            sb.Append("<base target='_self' />\r\n");
            sb.Append("</head>\r\n");
            sb.Append("<body>\r\n");
            sb.Append("<div id='infoBox'>\r\n");
            sb.Append("<div id='info'>\r\n");
            sb.Append("<div style='text-align:center;margin:0 auto;width:320px;padding-top:4px;line-height:26px;height:26px;font-weight:bold;color:#fff;font-size:14px;border:1px #1e71b1 solid;background:#1e71b1;'>提示信息</div>\r\n");
            sb.Append("<div style='text-align:center;padding:20px 0 20px 0;margin:0 auto;width:320px;font-size:12px;background:#F5FBFF;border-right:1px #1e71b1 solid;border-bottom:1px #1e71b1 solid;border-left:1px #1e71b1 solid;'>\r\n");
            sb.Append(pageMsg + "<br /><br />\r\n");
            if (BackStep > 0)
                sb.Append("        <a class=\"a_goto\" href=\"javascript:history.go(" + (0 - BackStep) + ")\">如果您的浏览器没有自动跳转，请点击这里</a>\r\n");
            else
                sb.Append("        <a class=\"a_goto\" href=\"" + go2Url + "\">如果您的浏览器没有自动跳转，请点击这里</a>\r\n");
            sb.Append("    </div>\r\n");
            sb.Append("</div>\r\n");
            sb.Append("</div>\r\n");
            sb.Append("</body>\r\n");
            sb.Append("</html>\r\n");
            Response.Write(sb.ToString());
            Response.End();
        }

        //...

    }
}