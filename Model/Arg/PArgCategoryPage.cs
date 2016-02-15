using System;
using System.Collections.Generic;

namespace Model.Arg
{
    /// <summary>
    /// Category.aspx页面参数对象集合
    /// </summary>
    public class PArgCategoryPage : IAjaxArg
    {
        public List<CategoryPage> items { get; set; }
    }

    /// <summary>
    /// Category.aspx页面参数对象
    /// </summary>
    public class CategoryPage
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 栏目名称
        /// </summary>
        /// <remarks></remarks>
        public string name { get; set; }
        /// <summary>
        /// Url地址
        /// </summary>
        /// <remarks></remarks>
        public string url { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <remarks>排序越小越靠前</remarks>
        public int sort { get; set; }
    }
}