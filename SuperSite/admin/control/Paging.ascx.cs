using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace SuperSite.admin.control
{
    /// <summary>
    /// 分页控件
    /// </summary>
    public partial class Paging : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //test
            }
        }

        /// <summary>
        /// 分页信息
        /// </summary>
        public PageingInfo Pageing { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        protected int __totalcount { get { return Pageing == null ? 0 : Pageing.TotalCount; } }
        /// <summary>
        /// 显示分页信息
        /// </summary>
        protected bool __showpage { get; set; }
    }

    /// <summary>
    /// 分页信息
    /// </summary>
    public class PageingInfo
    {
        /// <summary>
        /// 是否显示跳转到某页
        /// </summary>
        public bool ShowCurtomIndex { get; set; }

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        private const int PageSize = 15;
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentIndex { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        private int PageCount { get { return TotalCount / PageSize + 1; } }
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string Url { get; set; }
    }
}