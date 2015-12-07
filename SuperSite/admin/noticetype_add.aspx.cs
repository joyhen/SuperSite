using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperSite.admin
{
    using Config;

    public partial class noticetype_add : System.Web.UI.Page
    {
        protected string[] category;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                category = Enum.GetNames(typeof(EnumCenter.NoticeCategory));
            }
        }

        //...

    }
}