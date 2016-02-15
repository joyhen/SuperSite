using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace SuperSite.admin
{
    public partial class ToolsPage : SuperSite.App_Code.BasePageRequest
    {
        protected override void OnInit(EventArgs e)
        {
            //base.OnInit(e);
        }

        protected List<string> ClassProperty = new List<string>();

        public override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var query = typeof(Model.DTO.DSuperProgramInfo).GetProperties().Select(x => x.Name).ToList();

                var len = query.Count;
                for (int i = 0; i < len; i++)
                {
                    var tail = (i == len - 1 ? "" : ",");
                    var equalobj = query[i].ToLower(); // " "
                    ClassProperty.Add(query[i] + " = argdata." + equalobj + tail);
                }
            }
        }

        //...

    }
}