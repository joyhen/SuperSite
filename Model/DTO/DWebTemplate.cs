using ProtoBuf;
using System;

namespace Model.DTO
{
    /// <summary>
    /// 页面模板对象
    /// </summary>
    [ProtoContract]
    public class DWebTemplate
    {
        [ProtoMember(1)]
        public string Guid { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        [ProtoMember(2)]
        public string Name { get; set; }
        /// <summary>
        /// 模板作者
        /// </summary>
        [ProtoMember(3)]
        public string Author { get; set; }
        /// <summary>
        /// 模板路径
        /// </summary>
        [ProtoMember(4)]
        public string Path { get; set; }
        /// <summary>
        /// 预览图片
        /// </summary>
        [ProtoMember(5)]
        public string PreviewImg { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [ProtoMember(6)]
        public string[] Tags { get; set; }
        /// <summary>
        /// 模板可用状态
        /// </summary>
        [ProtoMember(7)]
        public bool Enable { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [ProtoMember(8)]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        [ProtoMember(9)]
        public DateTime AddUser { get; set; }
    }
}