using System;

namespace SuperSite.admin.control
{
    public partial class maintop : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 当前用户
        /// </summary>
        public Model.Entity.SysUser CurrentUser { get; set; }

    }
}