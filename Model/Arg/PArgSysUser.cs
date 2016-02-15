using System;

namespace Model.Arg
{
    public class PArgSysUser : IAjaxArg
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks></remarks>
        public int id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        /// <remarks></remarks>
        public string username { get; set; }
        /// <summary>
        /// 真实名
        /// </summary>
        /// <remarks></remarks>
        public string realname { get; set; }
        /// <summary>
        /// 用户性别,0女性，1男性，>=2中性
        /// </summary>
        /// <remarks></remarks>
        public int gender { get; set; }
    }
}