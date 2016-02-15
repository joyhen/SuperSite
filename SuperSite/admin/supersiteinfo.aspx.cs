using System;

namespace SuperSite.admin
{
    using Tools;
    using Config;
    using Model.DTO;

    public partial class supersiteinfo : App_Code.BasePageBusiness
    {
        protected DSuperProgramInfo SuperProgramInfo;

        public override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                var filename = KeyCenter.KeySuperSiteProgramFile;
                SuperProgramInfo = BufHelp.ProtoBufDeserialize<DSuperProgramInfo>(filename)
                                ?? new DSuperProgramInfo();
            }
        }
    }
}