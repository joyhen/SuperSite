using System;

namespace SuperSite.admin
{
    public partial class login : App_Code.BasePageBusiness
    {
        protected override void OnInit(EventArgs e)
        {
            if (CheckUserLogin())
            {
                Response.Redirect("index.aspx");
                Response.End();
            }
        }

        public override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        //...

    }
}