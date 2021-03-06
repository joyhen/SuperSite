﻿using System;

namespace SuperSite.admin.control
{
    public partial class langlabel : BaseUserControl, ILanguageControl
    {
        /// <summary>
        /// 输出的html标签
        /// </summary>
        protected string RenderHtml = "";
        /// <summary>
        /// 标签内容
        /// </summary>
        private string txt = "unknown";

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            EnableViewState = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Language != null)
                {
                    var showtxt = Language.LanguageList.GetCurrentLan(CurrentLanguage);
                    if (!string.IsNullOrWhiteSpace(showtxt))
                        txt = showtxt;
                }

                if (RenderHtmlType == RenderType.@null)
                    RenderHtml = string.Format("{0}", txt);
                else
                {
                    //需要改进此方法...
                    var td = "val" + DateTime.Now.Ticks.ToString();
                    var template = "<{0} ccvalue=\"{2}\" cctag=\"{2}\">{1}</{0}>";
                    RenderHtml = string.Format(template, RenderHtmlType.ToString(), txt, td);
                }
            }
        }

        /// <summary>
        /// 输出的标签样式
        /// </summary>
        public RenderType RenderHtmlType { get; set; }

        /// <summary>
        /// 当前标签语言集（实现接口定义）
        /// </summary>
        /// <remarks>可以写一个页面统一配置，基类方法通过配置统一设置（后期处理）</remarks>
        public LanguageLabel Language { get; set; }
    }
}