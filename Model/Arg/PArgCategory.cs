using System;

namespace Model.Arg
{
    /// <summary>
    /// 栏目类别
    /// </summary>
    public class PArgCategory : IAjaxArg
    {
        public int id { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        /// <remarks></remarks>
        public int? parentid { get; set; }
        /// <summary>
        /// 栏目名称
        /// </summary>
        /// <remarks></remarks>
        public string name { get; set; }
        /// <summary>
        /// 栏目模型
        /// </summary>
        /// <remarks></remarks>
        public int? sitemodel { get; set; }
        /// <summary>
        /// Url地址
        /// </summary>
        /// <remarks></remarks>
        public string url { get; set; }
        /// <summary>
        /// 列表模板地址
        /// </summary>
        /// <remarks></remarks>
        public string listtemplate { get; set; }
        /// <summary>
        /// 内容模板地址
        /// </summary>
        /// <remarks></remarks>
        public string contenttemplate { get; set; }
        /// <summary>
        /// 是否启用，1是，0否
        /// </summary>
        /// <remarks></remarks>
        public int? status { get; set; }
        /// <summary>
        /// 新窗口打开，1是，0否
        /// </summary>
        /// <remarks></remarks>
        public int? targetblank { get; set; }
        /// <summary>
        /// 底部显示，1是，0否
        /// </summary>
        /// <remarks></remarks>
        public int? showfoot { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <remarks>排序越小越靠前</remarks>
        public int sortnumber { get; set; }
        /// <summary>
        /// 详细内容
        /// </summary>
        /// <remarks></remarks>
        public string content { get; set; }
    }
}