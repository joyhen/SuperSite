using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Model.DTO
{
    /// <summary>
    /// 后台系统设置
    /// </summary>
    public class DSystemSetting
    {
        /// <summary>
        /// 系统状态，0关闭，1正常
        /// </summary>
        /// <remarks>关闭情况下，有且只有后门用户可以登录系统</remarks>
        [System.ComponentModel.DefaultValue(true)]
        public bool SiteStatic { get; set; }

        /// <summary>
        /// 是否启用伪静态
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        public bool PseudoStatic { get; set; }

        /// <summary>
        /// 登录验证码功能打开
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        public bool LoginValidate { get; set; }

        /// <summary>
        /// 登录口令校验功能打开
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        public bool LoginQustion { get; set; }

        /// <summary>
        /// 支持多语言
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        public bool MultiLanguage { get; set; }

        /// <summary>
        /// 显示主面板宽窄切换按钮
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        public bool ShowFullOrNarrowButton { get; set; }

        /// <summary>
        /// 允许QQ登录
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        public bool AllowQQLogin { get; set; }

        /// <summary>
        /// 文件缓存
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        public bool FileCache { get; set; }

        /// <summary>
        /// 文件缓存时间
        /// </summary>
        [System.ComponentModel.DefaultValue(1440)]
        public int FileCacheTime { get; set; }
    }
}