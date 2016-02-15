namespace Model.Arg
{
    /// <summary>
    /// 网站配置
    /// </summary>
    public class PArgSiteSetting : IAjaxArg
    {
        /// <summary>
        /// URL分隔符
        /// </summary>
        /// <remarks>默认-</remarks>
        public string urlsplit { get; set; }

        /// <summary>
        /// 网站名称
        /// </summary>
        public string sitename { get; set; }

        /// <summary>
        /// 网站标题
        /// </summary>
        public string sitetitle { get; set; }

        /// <summary>
        /// 网站关键词
        /// </summary>
        public string sitekeywords { get; set; }

        /// <summary>
        /// 网站描述
        /// </summary>
        public string sitedescription { get; set; }
    }
}