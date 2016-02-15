using System;
using Model.Entity;

namespace SuperSite.admin
{
    public partial class sysuseredit : App_Code.BasePageBusiness
    {
        protected Model.Entity.SysUser SysUser;

        public override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = QInt("id");
                if (id <= 0) PageMessage("无效请求", backStep: 1);
                SysUser = new Server.UserService().GetEntity<SysUser>(QInt("id"));
            }

            base.Page_Load(sender, e);
        }

        //...

    }
}