using System;
using System.Web;
using System.Web.Routing;

namespace SuperSite
{
    using Tools;
    using Config;
    using Model.DTO;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            var result = BufHelp.ProtoBufDeserialize<DSystemSetting>(KeyCenter.KeySystemSettingFile);
            if (result != null && result.PseudoStatic)
            {
                RouteConfig.RegisterRoutes(RouteTable.Routes);
            }
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }
    }
}