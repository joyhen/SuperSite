using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace SuperSite.admin.control
{
    using Config;
    using Tools;

    /// <summary>
    /// 用户控件基类
    /// </summary>
    public class BaseUserControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// 渲染方式
        /// </summary>
        public enum RenderType
        {
            /// <summary>
            /// 无表情
            /// <remarks>以文本的方式输出</remarks>
            /// </summary>
            @null,
            /// <summary>
            /// p标签
            /// </summary>
            p,
            /// <summary>
            /// label标签
            /// </summary>
            label,
            /// <summary>
            /// a标签
            /// </summary>
            a
        }

        /// <summary>
        /// 当前系统语言
        /// </summary>
        protected EnumCenter.Lang CurrentLanguage
        {
            get
            {
                return LanguageUtil.CurrentLanguage();
            }
        }
    }
}