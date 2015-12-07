using System;

namespace Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// 统一接口输出实体
    /// </summary>
    public class ResultModel
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [Obsolete("后期使用", true), JsonIgnore]
        public int code { get; set; }
        /// <summary>
        /// 执行成功与否
        /// </summary>
        /// <remarks>ture:解析data，false:提示msg错误信息</remarks>
        public bool success { set; get; }
        /// <summary>
        /// 成功或错误的提示信息
        /// </summary>
        public string msg { set; get; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { set; get; }
    }
}
