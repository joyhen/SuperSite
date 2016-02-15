using System;
using ProtoBuf;

namespace Model.DTO
{
    /// <summary>
    /// 当前程序配置信息
    /// </summary>
    [ProtoContract]
    public class DSuperProgramInfo
    {
        /// <summary>
        /// 程序名称
        /// </summary>
        [ProtoMember(1)]
        public string Name { get; set; }
        /// <summary>
        /// 系统版本
        /// </summary>
        [ProtoMember(2)]
        public string Version { get; set; }
        /// <summary>
        /// 操作系统
        /// </summary>
        [ProtoMember(3)]
        public string System { get; set; }
        /// <summary>
        /// Asp.Net
        /// </summary>
        [ProtoMember(4)]
        public string AspNet { get; set; }
        /// <summary>
        /// SqlServer
        /// </summary>
        [ProtoMember(5)]
        public string SqlServer { get; set; }
        /// <summary>
        /// 开发成员
        /// </summary>
        [ProtoMember(6)]
        public string Author { get; set; }
    }
}