using System;

namespace Model.Arg
{
    /// <summary>
    /// 当前程序配置信息
    /// </summary>
    public class PArgSuperProgramInfo : IAjaxArg
    {
        /// <summary>
        /// 程序名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 系统版本
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 操作系统
        /// </summary>
        public string system { get; set; }
        /// <summary>
        /// Asp.Net
        /// </summary>
        public string aspnet { get; set; }
        /// <summary>
        /// SqlServer
        /// </summary>
        public string sqlserver { get; set; }
        /// <summary>
        /// 开发成员
        /// </summary>
        public string author { get; set; }
    }
}