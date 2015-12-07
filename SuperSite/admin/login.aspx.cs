using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace SuperSite.admin
{
    public partial class login : App_Code.BasePageBusiness
    {
        protected override void OnInit(EventArgs e)
        {
            //如果不想登录后访问login.aspx页面自动登录，可将下面代码注释掉
            //if (CheckUserLogin())
            //{
            //    Response.Redirect("index.aspx");
            //    Response.End();
            //}
        }

        public override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        //...

    }
}