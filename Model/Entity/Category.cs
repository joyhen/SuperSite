using System;

namespace Model.Entity
{
    /// <summary>
    /// 栏目类别
    /// </summary>
    public class Category
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        /// <remarks></remarks>
        public int Id { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        /// <remarks></remarks>
        public int? ParentId { get; set; }
        /// <summary>
        /// 栏目名称
        /// </summary>
        /// <remarks></remarks>
        public string Name { get; set; }
        /// <summary>
        /// Url地址
        /// </summary>
        /// <remarks></remarks>
        public string Url { get; set; }
        /// <summary>
        /// 栏目模型
        /// </summary>
        /// <remarks></remarks>
        public int? SiteModel { get; set; }
        /// <summary>
        /// 列表模板地址
        /// </summary>
        /// <remarks></remarks>
        public string ListTemplate { get; set; }
        /// <summary>
        /// 内容模板地址
        /// </summary>
        /// <remarks></remarks>
        public string ContentTemplate { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <remarks></remarks>
        public bool? Status { get; set; }
        /// <summary>
        /// 新窗口打开，1是，0否
        /// </summary>
        /// <remarks></remarks>
        public bool? TargetBlank { get; set; }
        /// <summary>
        /// 底部显示，1是，0否
        /// </summary>
        /// <remarks></remarks>
        public bool? ShowFoot { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <remarks>排序越小越靠前</remarks>
        public int SortNumber { get; set; } //数据库对应tinyint，映射时不可为Nullable
        /// <summary>
        /// 栏目图片
        /// </summary>
        /// <remarks></remarks>
        public string Img { get; set; }
        /// <summary>
        /// 详细内容
        /// </summary>
        /// <remarks></remarks>
        public string Content { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        /// <remarks></remarks>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        /// <remarks></remarks>
        public string AddUser { get; set; }
    }
}