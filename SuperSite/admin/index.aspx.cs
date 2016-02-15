using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperSite.admin
{
    public partial class index : App_Code.BasePageBusiness
    {
        public override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                this.maintop.CurrentUser = base.CurrentUser;
            }
        }

        //...

    }
}