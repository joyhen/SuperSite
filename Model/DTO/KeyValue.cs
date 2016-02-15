using ProtoBuf;

namespace Model.DTO
{
    /// <summary>
    /// 键值对象
    /// </summary>
    [ProtoContract]
    public class KeyValue
    {
        /// <summary>
        /// 键
        /// </summary>
        [ProtoMember(1)]
        public string key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [ProtoMember(2)]
        public string value { get; set; }
    }

    /// <summary>
    /// 键、值、备注 对象
    /// </summary>
    [ProtoContract]
    public class KeyValueDesc
    {
        /// <summary>
        /// 键
        /// </summary>
        [ProtoMember(1)]
        public string key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [ProtoMember(2)]
        public string value { get; set; }
        /// <summary>
        /// 说明、描述
        /// </summary>
        [ProtoMember(3)]
        public object desc { get; set; }
    }
}