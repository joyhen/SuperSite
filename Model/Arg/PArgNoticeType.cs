using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Arg
{
    /// <summary>
    /// 通知类型
    /// </summary>
    public class PArgNoticeType : IAjaxArg
    {
        /// <summary>
        /// 类别名（父类型）
        /// </summary>
        public string category { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string typename { get; set; }
        /// <summary>
        /// 提前多少天
        /// </summary>
        public int advday { get; set; }
        /// <summary>
        /// 是否打开
        /// </summary>
        public int open { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        public string remark { get; set; }
    }
}
