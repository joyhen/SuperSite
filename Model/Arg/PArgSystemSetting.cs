namespace Model.Arg
{
    /// <summary>
    /// 系统设置
    /// </summary>
    public class PArgSystemSetting : IAjaxArg
    {
        /// <summary>
        /// 站点状态，0关闭，1正常
        /// </summary>
        /// <remarks>关闭情况下，有且只有后门用户可以登录系统</remarks>
        public bool sitestatic { get; set; }

        /// <summary>
        /// 是否启用伪静态
        /// </summary>
        public bool pseudostatic { get; set; }

        /// <summary>
        /// 登录验证码功能打开
        /// </summary>
        public bool loginvalidate { get; set; }

        /// <summary>
        /// 登录口令校验功能打开
        /// </summary>
        public bool loginqustion { get; set; }

        /// <summary>
        /// 支持多语言
        /// </summary>
        public bool multilanguage { get; set; }

        /// <summary>
        /// 允许QQ登录
        /// </summary>
        public bool allowqqlogin { get; set; }

        /// <summary>
        /// 文件缓存时间
        /// </summary>
        public int filecachetime { get; set; }
    }
}