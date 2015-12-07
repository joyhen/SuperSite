using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Model.DTO
{
    /// <summary>
    /// 网站配置
    /// </summary>
    public class DSiteSetting
    {
        /// <summary>
        /// URL分隔符
        /// </summary>
        [System.ComponentModel.DefaultValue("-")]
        public string UrlSplit { get; set; }

        /// <summary>
        /// 网站名称
        /// </summary>
        public string SiteName { get; set; }

        /// <summary>
        /// 网站标题
        /// </summary>
        public string SiteTitle { get; set; }

        /// <summary>
        /// 网站关键词
        /// </summary>
        public string SiteKeywords { get; set; }

        /// <summary>
        /// 网站描述
        /// </summary>
        public string SiteDescription { get; set; }

    }
}