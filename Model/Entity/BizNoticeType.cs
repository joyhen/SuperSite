using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Model.Entity
{
    /// <summary>
    /// 通知类型表
    /// </summary>
    [Dapper.Contrib.Extensions.Table("BizNoticeType"), Serializable]
    public class BizNoticeType : ZZLBaseEentity
    {
        /// <summary>
        /// 通知类型名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 提前多少天通知
        /// </summary>
        public int AdvanceDay { get; set; }
        /// <summary>
        /// 启用状态，0未启用，1启用
        /// </summary>
        public bool Open { get; set; }
        /// <summary>
        /// 预留字段
        /// </summary>
        public string Reserved1 { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        public string AddUser { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 通知类别，对应NoticeCategory枚举
        /// </summary>
        public int Category { get; set; }       
    }
}
