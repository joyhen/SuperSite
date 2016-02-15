using ProtoBuf;

namespace Model.DTO
{
    /// <summary>
    /// 后台系统设置
    /// </summary>
    [ProtoContract]
    public class DSystemSetting
    {
        /// <summary>
        /// 站点状态，0关闭，1正常
        /// </summary>
        /// <remarks>关闭情况下，有且只有后门用户可以登录系统</remarks>
        [ProtoMember(1)]
        public bool SiteStatic { get; set; }

        /// <summary>
        /// 是否启用伪静态
        /// </summary>
        [ProtoMember(2)]
        public bool PseudoStatic { get; set; }

        /// <summary>
        /// 登录验证码功能打开
        /// </summary>
        [ProtoMember(3)]
        public bool LoginValidate { get; set; }

        /// <summary>
        /// 登录口令校验功能打开
        /// </summary>
        [ProtoMember(4)]
        public bool LoginQustion { get; set; }

        /// <summary>
        /// 支持多语言
        /// </summary>
        [ProtoMember(5)]
        public bool MultiLanguage { get; set; }

        /// <summary>
        /// 允许QQ登录
        /// </summary>
        [ProtoMember(6)]
        public bool AllowQQLogin { get; set; }

        /// <summary>
        /// 文件缓存时间
        /// </summary>
        [ProtoMember(7)]
        public int FileCacheTime { get; set; }
    }
}