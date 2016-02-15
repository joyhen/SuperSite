using ProtoBuf;

namespace Model.DTO
{
    /// <summary>
    /// 网站配置
    /// </summary>
    [ProtoContract]
    public class DSiteSetting
    {
        /// <summary>
        /// URL分隔符
        /// </summary>
        /// <remarks>默认-</remarks>
        [ProtoMember(1)]
        public string UrlSplit { get; set; }

        /// <summary>
        /// 网站名称
        /// </summary>
        [ProtoMember(2)]
        public string SiteName { get; set; }

        /// <summary>
        /// 网站标题
        /// </summary>
        [ProtoMember(3)]
        public string SiteTitle { get; set; }

        /// <summary>
        /// 网站关键词
        /// </summary>
        [ProtoMember(4)]
        public string SiteKeywords { get; set; }

        /// <summary>
        /// 网站描述
        /// </summary>
        [ProtoMember(5)]
        public string SiteDescription { get; set; }
    }
}