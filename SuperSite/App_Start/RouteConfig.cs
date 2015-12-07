using System;
using System.Web;
using System.Web.Routing;
using System.Collections.Generic;
using Microsoft.AspNet.FriendlyUrls;

namespace SuperSite
{
    /// <summary>
    /// URL��д��α��̬����
    /// </summary>
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            //...

        }
    }
}