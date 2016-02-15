using System;
using ProtoBuf;

namespace Model.DTO
{
    /// <summary>
    /// 用户登录信息
    /// </summary>
    [ProtoContract]
    public class DLoginRecord
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [ProtoMember(1)]
        public string UserName { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [ProtoMember(2)]
        public string RealName { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        [ProtoMember(3)]
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        [ProtoMember(4)]
        public string LoginIp { get; set; }
        /// <summary>
        ///登录地点
        /// </summary>
        [ProtoMember(5)]
        public string Location { get; set; }
        /// <summary>
        /// 客户端信息
        /// </summary>
        [ProtoMember(6)]
        public ClientInfo ClientInfo { get; set; }
    }

    /// <summary>
    /// 客户端信息
    /// </summary>
    [ProtoContract]
    public class ClientInfo
    {
        /// <summary>
        /// 浏览器名+版本
        /// </summary>
        [ProtoMember(1)]
        public string browser { get; set; }
        /// <summary>
        /// 操作平台
        /// </summary>
        [ProtoMember(2)]
        public string platform { get; set; }
        /// <summary>
        /// 支持cookies
        /// </summary>
        [ProtoMember(3)]
        public bool iscookies { get; set; }
        /// <summary>
        /// 来源url
        /// </summary>
        [ProtoMember(4)]
        public string rawurl { get; set; }
    }
}